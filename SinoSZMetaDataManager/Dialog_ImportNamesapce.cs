using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using SinoSZJS.Base.MetaData.Define;
using SinoSZClientBase.MetaDataService;

namespace SinoSZMetaDataManager
{
    public partial class Dialog_ImportNamesapce : DevExpress.XtraEditors.XtraForm
    {
        private MD_Nodes CurrentNode = null;
        protected string ImportMode = "0";
        private Dictionary<string, string> IDTable = new Dictionary<string, string>();
        public Dialog_ImportNamesapce()
        {
            InitializeComponent();
        }

        public Dialog_ImportNamesapce(MD_Nodes _node)
        {
            InitializeComponent();
            CurrentNode = _node;
            this.label2.Visible = false;
            this.te_Type.EditValue = "0";
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (this.TE_NEWNAME.EditValue == null || this.TE_NEWNAME.EditValue == "")
            {
                MessageBox.Show("请输入新命名空间名称！", "系统提示");

                return;
            }
            else
            {
                string _fname = (this.te_File.EditValue == null) ? "" : this.te_File.EditValue.ToString();
                string _type = (this.te_Type.EditValue == null) ? "0" : this.te_Type.EditValue.ToString();
                ImportMode = (this.te_Mode.EditValue == null) ? "0" : this.te_Mode.EditValue.ToString();

                if (_fname == "")
                {
                    XtraMessageBox.Show("请输入导入文件!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    try
                    {
                        switch (_type)
                        {
                            case "0":
                                ImportData(_fname);
                                break;
                            case "1":
                                ImportData_New(_fname);
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("导入失败!" + ex.Message, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
            }
        }

        #region 导入新版导出格式文件
        /// <summary>
        /// 导入新格式数据
        /// </summary>
        /// <param name="_fname"></param>
        private void ImportData_New(string _fname)
        {
            MD_Namespace _ns;
            this.te_File.Enabled = false;
            this.simpleButton1.Enabled = false;
            this.simpleButton2.Enabled = false;
            this.te_Type.Enabled = false;
            this.te_Mode.Enabled = false;
            this.label2.Visible = true;
            this.label2.Text = "打开导入文件 ....";
            Application.DoEvents();

            DataContractSerializer s = new DataContractSerializer(typeof(MD_Namespace));
            using (FileStream fs = File.Open(_fname, FileMode.Open))
            {
                _ns = s.ReadObject(fs) as MD_Namespace;
            }
            if (_ns == null)
            {
                XtraMessageBox.Show("导入文件失败！可能文件的格式不正确！", "系统提示");
                return;
            }
            //修改NODE和NAMESPACE定义
            _ns.Nodes = CurrentNode;
            if (this.TE_NEWNAME.EditValue == null || this.TE_NEWNAME.EditValue == "")
            {

            }
            else
            {
                _ns.NameSpace = this.TE_NEWNAME.EditValue.ToString().Trim();
            }

            //修改ID值
            ChangedID(_ns);

        }


        private void ChangedID(MD_Namespace _ns)
        {
            IDTable.Clear();
            this.label2.Text = "写入命名空间定义 ....";
            Application.DoEvents();
            MD_Namespace _newns = new MD_Namespace();

            _newns.NameSpace = _ns.NameSpace;
            _newns.Description = _ns.Description;
            _newns.MenuPosition = _ns.MenuPosition;
            _newns.DisplayTitle = _ns.DisplayTitle;
            _newns.Owner = "ZHTJ";
            _newns.DisplayOrder = _ns.DisplayOrder;
            _newns.Concepts = _ns.Concepts;
            _newns.Nodes = CurrentNode;
            _newns.DWDM = CurrentNode.DWDM;
            using (MetaDataServiceClient _mdc = new MetaDataServiceClient())
            {
                _mdc.SaveNewNameSapce(_newns);
            }

            _ns.DWDM = CurrentNode.DWDM;
            _ns.Nodes = CurrentNode;

            this.label2.Text = "写入表定义 ....";
            Application.DoEvents();
            WriteTableDefine_New(_ns);

            this.label2.Text = "写入查询模型定义 ....";
            Application.DoEvents();
            WriteModelDefine_New(_ns);

            this.label2.Text = "写入代码表定义 ....";
            Application.DoEvents();
            WriteRefTable_New(_ns);

            this.label2.Text = "导入完成 ....";
            Application.DoEvents();

            XtraMessageBox.Show("导入成功！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }



        private void WriteTableDefine_New(MD_Namespace _ns)
        {
            using (MetaDataServiceClient _mdc = new MetaDataServiceClient())
            {
                foreach (MD_Table _table in _ns.TableList)
                {
                    try
                    {
                        this.label2.Text = string.Format("写入表{0}的定义 ....", _table.TableName);
                        Application.DoEvents();
                        string _newid = GetNewID(_table.TID, "MD_TABLE", "TID", _mdc);
                        string _oldid = _table.TID;
                        IDTable.Add(_oldid, _newid);
                        _table.TID = _newid;
                        _table.NamespaceName = _ns.NameSpace;
                        _table.DWDM = _ns.DWDM;
                        foreach (MD_TableColumn _tc in _table.Columns)
                        {
                            string _newcolumnid = GetNewID(_tc.ColumnID, "MD_TABLECOLUMN", "TCID", _mdc);
                            IDTable.Add(_tc.ColumnID, _newcolumnid);
                            _tc.ColumnID = _newcolumnid;
                            _tc.DWDM = _ns.DWDM;
                            _tc.TID = _table.TID;
                        }
                        _mdc.ImportTableDefine(_table);
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show(string.Format("导入表{0}时失败！{1}", _table.TableName, ex.Message), "系统提示");
                        break;
                    }
                }
            }

        }

        private void WriteRefTable_New(MD_Namespace _ns)
        {
            using (MetaDataServiceClient _mdc = new MetaDataServiceClient())
            {
                foreach (MD_RefTable _rt in _ns.RefTableList)
                {
                    this.label2.Text = string.Format("写入代码表[{0}]的定义 ....", _rt.RefTableName);
                    Application.DoEvents();
                    string _newid = GetNewID(_rt.RefTableID, "MD_REFTABLELIST", "RTID", _mdc);
                    _rt.RefTableID = _newid;
                    _rt.NamespaceName = _ns.NameSpace;
                    _rt.DWDM = _ns.DWDM;
                    _mdc.ImportRefTableDefine(_rt);
                }
            }
        }

        private void WriteModelDefine_New(MD_Namespace _ns)
        {
            using (MetaDataServiceClient _mdc = new MetaDataServiceClient())
            {
                foreach (MD_QueryModel _qv in _ns.QueryModelList)
                {
                    this.label2.Text = string.Format("写入查询模型[{0}]的定义 ....", _qv.QueryModelName);
                    Application.DoEvents();
                    _qv.NamespaceName = _ns.NameSpace;
                    string _newid = GetNewID(_qv.QueryModelID, "MD_VIEW", "VIEWID", _mdc);
                    try
                    {
                        IDTable.Add(_qv.QueryModelID, _newid);
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                    _qv.QueryModelID = _newid;
                    _qv.DWDM = _ns.DWDM;
                    //处理主表

                    MD_ViewTable _mainTable = _qv.MainTable;
                    string old_fid = "";
                    if (_mainTable != null)
                    {
                        old_fid = _mainTable.ViewTableID;
                        try
                        {
                            ChangeTableID(_mainTable, _qv, _mdc);
                        }
                        catch (Exception e)
                        {
                            throw e;
                        }
                    }


                    List<MD_ViewTable> _newTables = new List<MD_ViewTable>();
                    //处理子表
                    foreach (MD_ViewTable _vTable in _qv.ChildTables)
                    {
                        try
                        {
                            _vTable.FatherTableID = old_fid;
                            ChangeTableID(_vTable, _qv, _mdc);
                            _newTables.Add(_vTable);
                        }
                        catch (Exception e)
                        {
                            throw e;
                        }
                    }
                    _newTables.Add(_qv.MainTable);
                    _qv.ChildTables = _newTables;

                    //处理关联表
                    if (_qv.View2ViewGroup != null)
                    {
                        foreach (MD_View2ViewGroup _group in _qv.View2ViewGroup)
                        {
                            ChangeView2ViewGroupID(_group, _qv, _mdc);
                        }
                    }

                    //处理关联指标
                    if (_qv.View2GuideLines != null)
                    {
                        foreach (MD_View_GuideLine _v2g in _qv.View2GuideLines)
                        {
                            ChangeView2GuideLineID(_v2g, _qv, _mdc);
                        }
                    }

                    //处理关联注册应用
                    if (_qv.View2Application != null)
                    {
                        foreach (MD_View2App _v2a in _qv.View2Application)
                        {
                            ChangeView2AppID(_v2a, _qv, _mdc);
                        }
                    }

                    bool _ret = _mdc.ImportQueryModelDefine(_qv);
                    if (!_ret) MessageBox.Show("导入失败！", "系统提示");
                }
            }
        }

        private void ChangeView2AppID(MD_View2App _v2a, MD_QueryModel _qv, MetaDataServiceClient _mdc)
        {
            if (_v2a == null) return;
            _v2a.ViewID = _qv.QueryModelID;
            string _newid = GetNewID(_v2a.ID, "MD_VIEW2APPLICATION", "ID", _mdc);
            try
            {
                IDTable.Add(_v2a.ID, _newid);
            }
            catch (Exception e)
            {
                throw e;
            }
            _v2a.ID = _newid;
        }

        private void ChangeView2GuideLineID(MD_View_GuideLine _v2g, MD_QueryModel _qv, MetaDataServiceClient _mdc)
        {
            if (_v2g == null) return;
            _v2g.ViewID = _qv.QueryModelID;
            string _newid = GetNewID(_v2g.ID, "MD_VIEW2GUIDELINE", "ID", _mdc);
            try
            {
                IDTable.Add(_v2g.ID, _newid);
            }
            catch (Exception e)
            {
                throw e;
            }
            _v2g.ID = _newid;
        }

        private void ChangeView2ViewGroupID(MD_View2ViewGroup _group, MD_QueryModel _qv, SinoSZClientBase.MetaDataService.MetaDataServiceClient _mdc)
        {
            if (_group == null) return;
            _group.QueryModelID = _qv.QueryModelID;
            string _newid = GetNewID(_group.ID, "MD_VIEW2VIEWGROUP", "ID", _mdc);
            try
            {
                IDTable.Add(_group.ID, _newid);
            }
            catch (Exception e)
            {
                throw e;
            }
            _group.ID = _newid;
            if (_group.View2Views != null && _group.View2Views.Count > 0)
            {
                foreach (MD_View2View _v2v in _group.View2Views)
                {
                    ChangeView2ViewID(_v2v, _group, _mdc);
                }
            }
        }

        private void ChangeView2ViewID(MD_View2View _v2v, MD_View2ViewGroup _group, MetaDataServiceClient _mdc)
        {
            if (_v2v == null) return;
            _v2v.QueryModelID = _group.QueryModelID;
            string _newid = GetNewID(_v2v.ID, "MD_VIEW2VIEW", "ID", _mdc);
            try
            {
                IDTable.Add(_v2v.ID, _newid);
            }
            catch (Exception e)
            {
                throw e;
            }
            _v2v.ID = _newid;
        }

        private void ChangeTableID(MD_ViewTable _table, MD_QueryModel _qv, MetaDataServiceClient _mdc)
        {
            if (_table == null) return;
            _table.NamespaceName = _qv.NamespaceName;
            string _newtid = IDTable[_table.TableID];
            _table.TableID = _newtid;
            _table.DWDM = _qv.DWDM;
            _table.QueryModelID = _qv.QueryModelID;
            string _newid = GetNewID(_table.ViewTableID, "MD_VIEWTABLE", "VTID", _mdc);
            try
            {
                IDTable.Add(_table.ViewTableID, _newtid);
            }
            catch (Exception e)
            {
                throw e;
            }
            _table.ViewTableID = _newid;
            if (_table.FatherTableID != "")
            {
                _table.FatherTableID = IDTable[_table.FatherTableID];
            }
            foreach (MD_ViewTableColumn _vtc in _table.Columns)
            {
                string _newVTCid = GetNewID(_vtc.ViewTableColumnID, "MD_VIEWTABLECOLUMN", "VTCID", _mdc);
                _vtc.ViewTableColumnID = _newVTCid;
                _vtc.ColumnID = IDTable[_vtc.ColumnID];
                _vtc.DWDM = _qv.DWDM;

            }

        }

        #endregion

        #region 导入旧格式数据
        /// <summary>
        /// 导入旧格式数据
        /// </summary>
        /// <param name="_fname"></param>
        private void ImportData(string _fname)
        {
            this.te_File.Enabled = false;
            this.simpleButton1.Enabled = false;
            this.simpleButton2.Enabled = false;
            this.te_Type.Enabled = false;
            this.te_Mode.Enabled = false;
            this.label2.Visible = true;
            this.label2.Text = "打开导入文件 ....";
            Application.DoEvents();

            DataSet _ds = new DataSet();
            _ds.ReadXml(_fname);


            WriteNamespace(_ds.Tables["MD_TBNAMESPACE"], _ds);


            this.label2.Text = "导入完成";
            Application.DoEvents();
            this.simpleButton1.Visible = false;
            this.simpleButton2.Enabled = true;
            this.simpleButton2.Text = "确定";
        }

        private void WriteNamespace(DataTable _dt, DataSet _ds)
        {
            using (MetaDataServiceClient _mdc = new MetaDataServiceClient())
            {
                IDTable.Clear();
                if (_dt.Rows.Count > 0)
                {
                    foreach (DataRow _dr in _dt.Rows)
                    {
                        this.label2.Text = "写入命名空间定义 ....";
                        Application.DoEvents();
                        string _oldNameSpace = _dr["NAMESPACE"].ToString();
                        string _NewNamespace = (this.TE_NEWNAME.EditValue == null || this.TE_NEWNAME.EditValue == "") ? _oldNameSpace : this.TE_NEWNAME.EditValue.ToString();

                        MD_Namespace _ns = new MD_Namespace();
                        _ns.NameSpace = _NewNamespace;
                        _ns.Description = _dr["DESCRIPTION"].ToString();
                        _ns.MenuPosition = _dr["MENUPOSITION"].ToString();
                        _ns.DisplayTitle = _dr["DISPLAYTITLE"].ToString();
                        _ns.Owner = _dr["OWNER"].ToString();
                        _ns.DisplayOrder = _dr.IsNull("DISPLAYORDER") ? 0 : Convert.ToInt32(_dr["DISPLAYORDER"]);
                        _ns.Concepts = _dr["CONCEPTS"].ToString();
                        _ns.Nodes = CurrentNode;
                        _ns.DWDM = CurrentNode.DWDM;
                        _mdc.SaveNewNameSapce(_ns);


                        this.label2.Text = "写入表定义 ....";
                        Application.DoEvents();
                        WriteTableDefine(_oldNameSpace, _ns, _ds);

                        this.label2.Text = "写入查询模型定义 ....";
                        Application.DoEvents();
                        WriteModelDefine(_oldNameSpace, _ns, _ds);

                        this.label2.Text = "写入代码表定义 ....";
                        Application.DoEvents();
                        WriteRefCodeDefine(_oldNameSpace, _ns, _ds);
                    }
                }
            }
        }

        private void WriteRefCodeDefine(string _oldNameSpace, MD_Namespace _ns, DataSet _ds)
        {
            using (MetaDataServiceClient _mdc = new MetaDataServiceClient())
            {
                DataRow[] _refRows = _ds.Tables["MD_REFTABLELIST"].Select(string.Format("NAMESPACE='{0}'", _oldNameSpace));
                foreach (DataRow _dr in _refRows)
                {
                    string _oldid = _dr["RTID"].ToString();
                    string _newid = GetNewID(_oldid, "MD_REFTABLELIST", "RTID", _mdc);
                    this.IDTable.Add(_oldid, _newid);
                    MD_RefTable _rt = new MD_RefTable(
                           _newid,
                            _ns.NameSpace,
                            _dr.IsNull("REFTABLENAME") ? "" : _dr["REFTABLENAME"].ToString(),
                            _dr.IsNull("REFTABLELEVELFORMAT") ? "" : _dr["REFTABLELEVELFORMAT"].ToString(),
                            _dr.IsNull("DESCRIPTION") ? "" : _dr["DESCRIPTION"].ToString(),
                            _ns.DWDM,
                            _dr.IsNull("DOWNLOADMODE") ? 1 : Convert.ToInt32(_dr["DOWNLOADMODE"]),
                            _dr.IsNull("REFTABLEMODE") ? 1 : Convert.ToInt32(_dr["REFTABLEMODE"]),
                            false
                            );
                    _mdc.ImportRefTableDefine(_rt);
                }
            }
        }


        private void WriteModelDefine(string _oldNameSpace, MD_Namespace _ns, DataSet _ds)
        {
            using (MetaDataServiceClient _mdc = new MetaDataServiceClient())
            {
                DataRow[] _qvDefineRows = _ds.Tables["MD_VIEW"].Select(string.Format("NAMESPACE='{0}'", _oldNameSpace));
                foreach (DataRow _dr in _qvDefineRows)
                {
                    string _oldid = _dr["VIEWID"].ToString();
                    string _newid = GetNewID(_oldid, "MD_VIEW", "VIEWID", _mdc);

                    this.IDTable.Add(_oldid, _newid);

                    MD_QueryModel _qv = new MD_QueryModel(
                            _newid,
                            _ns.NameSpace,
                            _dr.IsNull("VIEWNAME") ? "" : _dr["VIEWNAME"].ToString(),
                            _dr.IsNull("DESCRIPTION") ? "" : _dr["DESCRIPTION"].ToString(),
                            _dr.IsNull("DISPLAYNAME") ? "" : _dr["DISPLAYNAME"].ToString(),
                            _ns.DWDM,
                            _dr.IsNull("IS_GDCX") ? false : ((decimal)_dr["IS_GDCX"] > 0),
                            _dr.IsNull("IS_GLCX") ? false : ((decimal)_dr["IS_GLCX"] > 0),
                            _dr.IsNull("IS_SJSH") ? false : ((decimal)_dr["IS_SJSH"] > 0),
                            _dr.IsNull("DISPLAYORDER") ? 0 : Convert.ToInt32(_dr["DISPLAYORDER"]),
                            "ORA_JSIS"
                            );

                    _qv.ChildTables = new List<MD_ViewTable>();

                    DataRow[] _childTableRows = _ds.Tables["MD_VIEWTABLE"].Select(string.Format("VIEWID='{0}'", _oldid));
                    foreach (DataRow _ctRow in _childTableRows)
                    {
                        string _oldVTid = _ctRow["VTID"].ToString();
                        string _newVTid = GetNewID(_oldVTid, "MD_VIEWTABLE", "VTID", _mdc);

                        string _newTid = IDTable[_ctRow["TID"].ToString()];
                        this.IDTable.Add(_oldVTid, _newVTid);

                        int _displayType = 0;
                        if (_ds.Tables["MD_VIEWTABLE"].Columns.Contains("DISPLAYTYPE"))
                        {
                            _displayType = _ctRow.IsNull("DISPLAYTYPE") ? 0 : Convert.ToInt32(_ctRow["DISPLAYTYPE"]);
                        }
                        string _intApp = "";
                        if (_ds.Tables["MD_VIEWTABLE"].Columns.Contains("INTEGRATEDAPP"))
                        {
                            _intApp = _ctRow.IsNull("INTEGRATEDAPP") ? "" : _ctRow["INTEGRATEDAPP"].ToString();
                        }
                        MD_ViewTable _vt = new MD_ViewTable(
                                _newVTid,
                                _newid,
                                _newTid,
                                _ctRow["TABLETYPE"].ToString(),
                                _ctRow.IsNull("TABLERELATION") ? "" : _ctRow["TABLERELATION"].ToString(),
                                _ctRow.IsNull("CANCONDITION") ? "" : _ctRow["CANCONDITION"].ToString(),
                                _ctRow.IsNull("DISPLAYNAME") ? "" : _ctRow["DISPLAYNAME"].ToString(),
                                _ctRow.IsNull("DISPLAYORDER") ? 0 : Convert.ToInt32(_ctRow["DISPLAYORDER"]),
                                _ns.DWDM,
                                _ctRow.IsNull("FATHERID") ? "" : _ctRow["FATHERID"].ToString(),
                                0,
                                  _displayType,
                                  _intApp
                                );
                        _qv.ChildTables.Add(_vt);

                        _vt.Columns = new List<MD_ViewTableColumn>();

                        DataRow[] _vtRows = _ds.Tables["MD_VIEWTABLECOLUMN"].Select(string.Format("VTID='{0}'", _oldVTid));
                        foreach (DataRow _vtRow in _vtRows)
                        {
                            string _oldVTCid = _vtRow["VTCID"].ToString();
                            string _newVTCid = GetNewID(_oldVTCid, "MD_VIEWTABLECOLUMN", "VTCID", _mdc);
                            string _newTCid = IDTable[_vtRow["TCID"].ToString()];
                            MD_ViewTableColumn _vtc = new MD_ViewTableColumn(
                                    _newVTCid,
                                   _newVTid,
                                   _newTCid,
                                    _vtRow.IsNull("CANCONDITIONSHOW") ? false : ((decimal)_vtRow["CANCONDITIONSHOW"] > 0),
                                    _vtRow.IsNull("CANRESULTSHOW") ? false : ((decimal)_vtRow["CANRESULTSHOW"] > 0),
                                    _vtRow.IsNull("DEFAULTSHOW") ? false : ((decimal)_vtRow["DEFAULTSHOW"] > 0),
                                    _vtRow.IsNull("FIXQUERYITEM") ? false : ((decimal)_vtRow["FIXQUERYITEM"] > 0),
                                     _vtRow.IsNull("CANMODIFY") ? false : ((decimal)_vtRow["CANMODIFY"] > 0),
                                     _ns.DWDM,
                                     0,
                                     0
                                     );

                            _vt.Columns.Add(_vtc);
                        }
                    }
                    _mdc.ImportQueryModelDefine(_qv);
                }
            }
        }




        private void WriteTableDefine(string _oldNameSpace, MD_Namespace _ns, DataSet _ds)
        {
            using (MetaDataServiceClient _mdc = new MetaDataServiceClient())
            {
                DataRow[] _TableDefineRows = _ds.Tables["MD_TABLE"].Select(string.Format("NAMESPACE='{0}'", _oldNameSpace));
                foreach (DataRow _dr in _TableDefineRows)
                {
                    DB_TableMeta _tm = new DB_TableMeta();
                    _tm.TableName = _dr["TABLENAME"].ToString();
                    _tm.TableComment = _dr["DESCRIPTION"].ToString();
                    _tm.TableType = _dr["TABLETYPE"].ToString();

                    string _oldid = _dr["TID"].ToString();
                    string _newid = GetNewID(_oldid, "MD_TABLE", "TID", _mdc);

                    this.IDTable.Add(_oldid, _newid);

                    MD_Table _tableDefine = new MD_Table(
                            _newid,
                             _ns.NameSpace,
                             _tm.TableName,
                             _tm.TableType,
                             _tm.TableComment,
                             _dr.IsNull("DISPLAYNAME") ? "" : _dr["DISPLAYNAME"].ToString(),
                             _dr.IsNull("MAINKEY") ? "" : _dr["MAINKEY"].ToString(),
                             _ns.DWDM,
                             _dr.IsNull("SECRETFUN") ? "" : _dr["SECRETFUN"].ToString(),
                             _dr.IsNull("EXTSECRET") ? "" : _dr["EXTSECRET"].ToString()
                    );

                    _tableDefine.Columns = new List<MD_TableColumn>();
                    DataRow[] _columnRow = _ds.Tables["MD_TABLECOLUMN"].Select(string.Format("TID={0}", _dr["TID"]));
                    foreach (DataRow _dcrow in _columnRow)
                    {
                        string _oldTCid = _dcrow["TCID"].ToString();
                        string _newTCid = GetNewID(_oldTCid, "MD_TABLECOLUMN", "TCID", _mdc);
                        try
                        {
                            this.IDTable.Add(_oldTCid, _newTCid);
                        }
                        catch (Exception e)
                        {
                            throw e;
                        }

                        MD_TableColumn _tc = new MD_TableColumn(
                               _newTCid,
                                _newid,
                                _dcrow["COLUMNNAME"].ToString(),
                                (_dcrow["ISNULLABLE"].ToString() == "Y"),
                                _dcrow["TYPE"].ToString(),
                                _dcrow.IsNull("PRECISION") ? 1 : Convert.ToInt32(_dcrow["PRECISION"]),
                                 _dcrow.IsNull("SCALE") ? 1 : Convert.ToInt32(_dcrow["SCALE"]),
                                 _dcrow.IsNull("LENGTH") ? 1 : Convert.ToInt32(_dcrow["LENGTH"]),
                                _dcrow.IsNull("REFDMB") ? "" : _dcrow["REFDMB"].ToString(),
                                _dcrow.IsNull("DMBLEVELFORMAT") ? "" : _dcrow["DMBLEVELFORMAT"].ToString(),
                                _dcrow.IsNull("SECRETLEVEL") ? 0 : Convert.ToInt32(_dcrow["SECRETLEVEL"]),
                                _dcrow.IsNull("DISPLAYTITLE") ? "" : _dcrow["DISPLAYTITLE"].ToString(),
                                _dcrow.IsNull("DISPLAYFORMAT") ? "" : _dcrow["DISPLAYFORMAT"].ToString(),
                                 _dcrow.IsNull("DISPLAYLENGTH") ? 1 : Convert.ToInt32(_dcrow["DISPLAYLENGTH"]),
                                 _dcrow.IsNull("DISPLAYHEIGHT") ? 1 : Convert.ToInt32(_dcrow["DISPLAYHEIGHT"]),
                                 _dcrow.IsNull("DISPLAYORDER") ? 0 : Convert.ToInt32(_dcrow["DISPLAYORDER"]),
                                 _dcrow.IsNull("CANDISPLAY") ? true : ((decimal)_dcrow["CANDISPLAY"] > 0),
                                 _dcrow.IsNull("COLWIDTH") ? 1 : Convert.ToInt32(_dcrow["COLWIDTH"]),
                                _ns.DWDM,
                                _dcrow.IsNull("CTAG") ? "" : _dcrow["CTAG"].ToString(),
                                ""
                                );
                        _tableDefine.Columns.Add(_tc);
                    }
                    _mdc.ImportTableDefine(_tableDefine);
                }
            }

        }

        private string GetNewID(string _oldid, string _tname, string _colname, MetaDataServiceClient _mdc)
        {
            try
            {
                if (ImportMode == "0")
                {
                    return _mdc.GetNewID();
                }
                else
                {
                    if (_mdc.IsExistID(_oldid, _tname, _colname))
                    {
                        throw new Exception(string.Format("在{0}表中存在{2}值为{1}的记录！", _tname, _oldid, _colname));
                    }
                    else
                    {
                        return _oldid;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        private void te_File_Click(object sender, EventArgs e)
        {
            OpenFileDialog _f = new OpenFileDialog();
            _f.Filter = "旧版备份文件 (*.xml) | *.xml|新版备份文件 (*.bak) | *.bak";
            _f.FilterIndex = this.te_Type.SelectedIndex + 1;
            if (_f.ShowDialog() == DialogResult.OK)
            {
                this.te_File.EditValue = _f.FileName;
                if (_f.FilterIndex == 2)
                {
                    this.te_Type.SelectedIndex = 1;
                }
                else
                {
                    this.te_Type.SelectedIndex = 0;
                }

            }
        }
    }
}