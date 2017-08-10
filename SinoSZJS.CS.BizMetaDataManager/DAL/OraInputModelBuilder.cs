using System;
using System.Collections.Generic;
using System.Text;
using SinoSZJS.Base.Misc;
using System.Data;
using SinoSZJS.Base.Authorize;
using System.Reflection;
using SinoSZJS.Base.MetaData.QueryModel;
using SinoSZJS.Base.InputModel;
using System.Data.SqlClient;
using SinoSZJS.DataAccess.Sql;

namespace SinoSZJS.CS.BizMetaDataManager.DAL
{
    public class OraInputModelBuilder
    {
        private string InputModelName = "";
        private MD_InputModel InputModel = null;
        private static OraMetaDataQueryFactroy QueryFactory = new OraMetaDataQueryFactroy();
        private static OraMetaDataFactroy MetaDataFactory = new OraMetaDataFactroy();
        public OraInputModelBuilder(string _inputModelName)
        {
            InputModelName = _inputModelName;
            InputModel = QueryFactory.GetInputModelByName(_inputModelName);
            //InputModel.RuleAssemblys = InputModelRuleBuilder.CreateRuleAssemblys(InputModel);
        }

        public MD_InputModel GetInputModelDefine()
        {
            return InputModel;
        }

        public MD_InputEntity GetData(List<MDQuery_GuideLineParameter> Params)
        {
            MD_InputEntity _ret = new MD_InputEntity(InputModelName);
            _ret.IsNewData = false;
            if (InputModel.GetDataGuideLine != "")
            {

                List<MDQuery_GuideLineParameter> _callParam = (Params == null) ? new List<MDQuery_GuideLineParameter>() : Params;

                DataTable _dt = QueryFactory.QueryGuideLine(InputModel.GetDataGuideLine, _callParam);
                _ret.IsNewData = true;
                if (_dt != null)
                {
                    _ret.InputData = GetInputDataByDataTable(_dt);
                }
            }
            else
            {
                //如果没有取数算法，则。。。。
            }
            if (InputModel.IsMixModel)
            {
                _ret.ChildInputData = new Dictionary<string, string>();
                foreach (MD_InputModel_Child _child in InputModel.ChildInputModel)
                {
                    switch (_child.ChildModel.ModelType)
                    {
                        case "FORM":
                            //_ret.ChildInputData.Add(_child.ID, GetChildFormData(_child, _ret));
                            break;
                        case "GRID":
                            _ret.ChildInputData.Add(_child.ID, GetChildGridData(_child, _ret));
                            break;
                    }

                }
            }
            return _ret;
        }


        private string GetChildGridData(MD_InputModel_Child _child, MD_InputEntity entity)
        {
            List<MD_InputEntity> _ret = new List<MD_InputEntity>();

            List<MDQuery_GuideLineParameter> _callParam = new List<MDQuery_GuideLineParameter>();
            foreach (MD_InputModel_ChildParam _p in _child.Parameters)
            {
                string _pValue = ConvetDataByMainEntityData(_p.Value, entity);
                MDQuery_GuideLineParameter _cp = new MDQuery_GuideLineParameter(new MD_GuideLineParameter(_p.Name, "", _p.DataType, 0, 0, "", false, ""), _pValue);
                _callParam.Add(_cp);
            }

            DataTable _dt = QueryFactory.QueryGuideLine(_child.ChildModel.GetDataGuideLine, _callParam);
            return _dt.DataTableToXml();
        }

        public Dictionary<string, string> GetNewChildRecord(MD_InputModel_Child _child, MD_InputEntity entity)
        {
            List<MDQuery_GuideLineParameter> _callParam = new List<MDQuery_GuideLineParameter>();
            foreach (MD_InputModel_ChildParam _p in _child.Parameters)
            {
                string _pValue = ConvetDataByMainEntityData(_p.Value, entity);
                MDQuery_GuideLineParameter _cp = new MDQuery_GuideLineParameter(new MD_GuideLineParameter(_p.Name, "", _p.DataType, 0, 0, "", false, ""), _pValue);
                _callParam.Add(_cp);
            }

            DataTable _dt = QueryFactory.QueryGuideLine(_child.ChildModel.GetNewRecordGuideLine, _callParam);
            return GetInputDataByDataTable(_dt);
        }

        private string ConvetDataByMainEntityData(string valuestr, MD_InputEntity entity)
        {
            string _ret = valuestr;
            foreach (string _key in entity.InputData.Keys)
            {
                string _field = string.Format("%{0}%", _key);
                object _valueObj = entity.InputData[_key];
                if (_valueObj != null)
                {
                    string _obj = _valueObj.ToString();
                    _ret = _ret.Replace(_field, _obj);
                }
                else
                {
                    _ret = _ret.Replace(_field, "");
                }
            }
            return _ret;
        }

        private MD_InputEntity GetChildFormData(MD_InputModel_Child _child, MD_InputEntity entity)
        {
            return new MD_InputEntity();
        }

        public MD_InputEntity GetNewData(List<MDQuery_GuideLineParameter> Params)
        {
            MD_InputEntity _ret = new MD_InputEntity(InputModelName);
            if (InputModel.GetNewRecordGuideLine != "")
            {
                //执行取新数据指标
                List<MDQuery_GuideLineParameter> _callParam = (Params == null) ? new List<MDQuery_GuideLineParameter>() : Params;

                DataTable _dt = QueryFactory.QueryGuideLine(InputModel.GetNewRecordGuideLine, _callParam);
                _ret.IsNewData = true;
                if (_dt != null)
                {
                    _ret.InputData = GetInputDataByDataTable(_dt);
                }
            }
            else
            {
                //暂未实现
                //执行初始化指标
                //执行取数据指标
            }
            if (InputModel.IsMixModel)
            {
                _ret.ChildInputData = new Dictionary<string, string>();
                foreach (MD_InputModel_Child _child in InputModel.ChildInputModel)
                {
                    switch (_child.ChildModel.ModelType)
                    {
                        case "FORM":
                            //_ret.ChildInputData.Add(_child.ID, GetChildFormData(_child, _ret));
                            break;
                        case "GRID":
                            _ret.ChildInputData.Add(_child.ID, GetChildGridData(_child, _ret));
                            break;
                    }

                }
            }
            return _ret;
        }

        private Dictionary<string, string> GetInputDataByDataTable(DataTable _dt)
        {
            Dictionary<string, string> _ret = new Dictionary<string, string>();
            if (_dt.Rows.Count > 0)
            {
                DataRow _dr = _dt.Rows[0];
                foreach (DataColumn _dc in _dt.Columns)
                {
                    if (_dr.IsNull(_dc.ColumnName))
                    {
                        _ret.Add(_dc.ColumnName, null);
                    }
                    else
                    {
                        _ret.Add(_dc.ColumnName, _dr[_dc.ColumnName].ToString());
                    }
                }
            }
            return _ret;
        }

        public bool WriteEntity(MD_InputEntity _entity)
        {
            bool _ret = false;
            using (SqlConnection cn = SqlHelper.OpenConnection())
            {
                SqlTransaction _txn = cn.BeginTransaction();
                try
                {
                    if (_entity.IsNewData)
                    {
                        _ret = WriteNewEntity(_entity, cn);
                    }
                    else
                    {
                        _ret = UpdateEntity(_entity, cn);
                    }

                    if (_ret)
                    {
                        _txn.Commit();
                        _entity.IsNewData = false;
                        if (InputModel.IsMixModel)
                        {
                            foreach (MD_InputModel_Child _child in InputModel.ChildInputModel)
                            {
                                switch (_child.ChildModel.ModelType)
                                {
                                    case "FORM":

                                        break;
                                    case "GRID":
                                        //DataTable _gridData = _entity.ChildInputData[_child.ID] as DataTable;
                                        //if (_gridData != null) _gridData.AcceptChanges();
                                        break;
                                }
                            }
                        }
                    }
                    else
                    {
                        _txn.Rollback();
                    }
                    return _ret;

                }
                catch (Exception ex)
                {
                    _txn.Rollback();
                    string _errmsg = string.Format("采用录入模型写入数据出错！错误信息:{0}!", ex.Message);
                    LogWriter.WriteSystemLog(_errmsg, "ERROR");
                    return false;
                }
                cn.Close();
            }
        }

        public bool WriteEntity(MD_InputEntity _entity, SqlConnection cn)
        {
            bool _ret = false;
            if (_entity.IsNewData)
            {
                _ret = WriteNewEntity(_entity, cn);
            }
            else
            {
                _ret = UpdateEntity(_entity, cn);
            }
            return _ret;
        }

        /// <summary>
        /// 更新记录
        /// </summary>
        /// <param name="_entity"></param>
        /// <returns></returns>
        private bool UpdateEntity(MD_InputEntity _entity, SqlConnection cn)
        {
            foreach (MD_InputModel_SaveTable _table in InputModel.WriteTableNames)
            {
                UpdateTableData(_table, _entity, cn);
            }

            if (InputModel.IsMixModel)
            {
                WriteChildData(_entity, cn);
            }
            return true;
        }

        private void UpdateTableData(MD_InputModel_SaveTable _table, MD_InputEntity _entity, SqlConnection cn)
        {
            List<string> _mainKeyList = MetaDataFactory.GetDBPrimayKeyList(_table.TableName);

            StringBuilder _sb = new StringBuilder();
            _sb.Append("update  ");
            _sb.Append(_table.TableName);
            _sb.Append(" set  ");
            string _fg = "";
            //制作更新字段SQL语句
            int _UpdateFieldCount = 0;
            foreach (MD_InputModel_SaveTableColumn _col in _table.Columns)
            {
                if (_col.SrcColumn == "" && _col.Method == "")
                {
                    //如果写入源字段和算法都为空，则此字段不写入
                    continue;
                }
                if (!_mainKeyList.Contains(_col.DesColumn))
                {
                    _UpdateFieldCount++;
                    _sb.Append(_fg);
                    _fg = " , ";
                    _sb.Append(_col.DesColumn);
                    if (_col.SrcColumn == "")
                    {
                        _sb.Append("=");
                        _sb.Append(ConvertVar(_col.Method, _entity));
                    }
                    else
                    {
                        if (_col.Method == "")
                        {
                            _sb.Append("=:");
                            _sb.Append(_col.DesColumn);
                        }
                        else
                        {
                            _sb.Append("=");
                            _sb.Append(string.Format(_col.Method, ConvertVar(_col.Method, _entity)));
                        }
                    }
                }
            }
            if (_UpdateFieldCount < 1)
            {
                //无更新字段，直接返回true;
                return;
            }
            _sb.Append(" where ");
            _fg = "";
            //制作主键字段条件语句
            foreach (string _key in _mainKeyList)
            {
                _sb.Append(_fg);
                _sb.Append(_key);
                _sb.Append(" =:");
                _sb.Append(_key);
                _fg = " and ";
            }

            List<SqlParameter> _plist = new List<SqlParameter>(); //SqlCommand _cmd = new SqlCommand(_sb.ToString(), cn);
            //添加更新字段参数
            foreach (MD_InputModel_SaveTableColumn _col in _table.Columns)
            {
                string _cname = _col.SrcColumn;
                if (_cname != "")
                {
                    string _data = _entity.InputData.ContainsKey(_cname) ? _entity.InputData[_cname] : null;
                    if (!_mainKeyList.Contains(_col.DesColumn))
                    {
                        _plist.Add(new SqlParameter(string.Format(":{0}", _col.DesColumn), _data));
                    }
                }
            }
            //添加主键字段参数
            foreach (string _key in _mainKeyList)
            {
                MD_InputModel_SaveTableColumn _kcol = GetColumnByDesName(_key, _table.Columns);
                if (_kcol != null)
                {
                    string _data = _entity.InputData.ContainsKey(_kcol.SrcColumn) ? _entity.InputData[_kcol.SrcColumn] : null;
                    _plist.Add(new SqlParameter(string.Format(":{0}", _key), _data));
                }
            }

            SqlParameter[] _params = _plist.ToArray();
            SqlHelper.ExecuteNonQuery(cn, CommandType.Text, _sb.ToString(), _params);
            //_cmd.ExecuteNonQuery();
        }

        private MD_InputModel_SaveTableColumn GetColumnByDesName(string _key, List<MD_InputModel_SaveTableColumn> columns)
        {
            foreach (MD_InputModel_SaveTableColumn _col in columns)
            {
                if (_col.DesColumn == _key) return _col;
            }
            return null;
        }

        /// <summary>
        /// 写入新的记录
        /// </summary>
        /// <param name="_entity"></param>
        /// <returns></returns>
        private bool WriteNewEntity(MD_InputEntity _entity, SqlConnection cn)
        {
            foreach (MD_InputModel_SaveTable _table in InputModel.WriteTableNames)
            {
                WriteNewTableData(_table, _entity, cn);
            }

            if (InputModel.IsMixModel)
            {
                WriteChildData(_entity, cn);
            }
            return true;
        }

        private void WriteChildData(MD_InputEntity _entity, SqlConnection cn)
        {
            foreach (MD_InputModel_Child _child in InputModel.ChildInputModel)
            {
                switch (_child.ChildModel.ModelType)
                {
                    case "FORM":

                        break;
                    case "GRID":
                        WriteGridChildData(_child, _entity.ChildInputData[_child.ID], cn);
                        break;
                }

            }
        }

        private void WriteGridChildData(MD_InputModel_Child _child, object ChildData, SqlConnection cn)
        {
            DataTable _srcData = ChildData as DataTable;
            if (_srcData == null) return;
            DataTable _newData = _srcData.GetChanges(DataRowState.Added);
            DataTable _modifyData = _srcData.GetChanges(DataRowState.Modified);
            DataTable _delData = _srcData.GetChanges(DataRowState.Deleted);

            if (_newData != null || _modifyData != null)
            {
                foreach (MD_InputModel_SaveTable _table in _child.ChildModel.WriteTableNames)
                {
                    string _sql = string.Format("select * from {0} ", _table.TableName);
                    //SqlDataAdapter adapter = new SqlDataAdapter(_sql, cn);
                    //SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                    if (_newData != null && _newData.Rows.Count > 0)
                    {
                        SqlHelper.UpdateData(cn, _sql, _newData.GetChanges());
                    }
                    if (_modifyData != null && _modifyData.Rows.Count > 0)
                    {
                        SqlHelper.UpdateData(cn, _sql, _modifyData.GetChanges());
                    }
                }
            }

            if (_delData != null && _delData.Rows.Count > 0)
            {
                for (int i = _child.ChildModel.WriteTableNames.Count; i > 0; i--)
                {
                    MD_InputModel_SaveTable _table = _child.ChildModel.WriteTableNames[i - 1];
                    string _sql = string.Format("select * from {0} ", _table.TableName);
                    SqlHelper.UpdateData(cn, _sql, _delData.GetChanges());

                }
            }
        }



        private void WriteNewTableData(MD_InputModel_SaveTable _table, MD_InputEntity _entity, SqlConnection cn)
        {
            StringBuilder _vStr = new StringBuilder();
            _vStr.Append(" values ( ");
            StringBuilder _sb = new StringBuilder();
            _sb.Append("insert into ");
            _sb.Append(_table.TableName);
            _sb.Append("  ( ");
            string _fg = "";
            foreach (MD_InputModel_SaveTableColumn _col in _table.Columns)
            {
                if (_col.SrcColumn == "" && _col.Method == "")
                {
                    //如果写入源字段和算法都为空，则此字段不写入
                    continue;
                }
                _sb.Append(string.Format("{0}{1}", _fg, _col.DesColumn));
                if (_col.SrcColumn == "")
                {
                    // 如果写入源字段为空，则仅使用算法写入本字段内容
                    _vStr.Append(_fg);
                    _vStr.Append(ConvertVar(_col.Method, _entity));
                }
                else
                {
                    //如果写入源字段不为空
                    if (_col.Method == "")
                    {
                        //如果算法为空，则写入源字段内容
                        _vStr.Append(string.Format("{0}:{1}", _fg, _col.DesColumn));
                    }
                    else
                    {
                        //算法不为空，将算法做为写入算法，参数照样代入
                        _vStr.Append(_fg);
                        _vStr.Append(string.Format(_col.Method, ConvertVar(_col.Method, _entity)));
                    }
                }
                _fg = ",";
            }

            _sb.Append(" ) ");
            _sb.Append(_vStr.ToString());
            _sb.Append(" ) ");

            List<SqlParameter> _plist = new List<SqlParameter>();
            foreach (MD_InputModel_SaveTableColumn _col in _table.Columns)
            {
                string _cname = _col.SrcColumn;
                if (_cname != "")
                {
                    string _data = _entity.InputData.ContainsKey(_cname) ? _entity.InputData[_cname] : null;
                    _plist.Add(new SqlParameter(string.Format(":{0}", _col.DesColumn), _data));
                }
            }
            SqlParameter[] _params=  _plist.ToArray();
            SqlHelper.ExecuteNonQuery(cn, CommandType.Text, _sb.ToString(), _params);
         
        }

        //变量替换
        private string ConvertVar(string _method, MD_InputEntity _entity)
        {
            string _ret = _method;
            _ret = OraQueryBuilder.ReplaceExtSecret(_ret, "");
            foreach (string _key in _entity.InputData.Keys)
            {
                string _varName = string.Format("${0}$", _key);
                string _value = string.Format("'{0}'", (_entity.InputData[_key] == null) ? "" : _entity.InputData[_key].ToString());
                _ret = _ret.Replace(_varName, _value);
            }
            return _ret;
        }

        public bool CheckInputData(MD_InputEntity _entity, ref Dictionary<string, string> ErrorList)
        {
            ErrorList = new Dictionary<string, string>();
            bool _ret = true;
            if (InputModel == null) return true;
            //必填项验证
            if (InputModel.Groups.Count > 0)
            {
                foreach (MD_InputModel_ColumnGroup _group in InputModel.Groups)
                {
                    foreach (MD_InputModel_Column _column in _group.Columns)
                    {
                        if (_column.Required)
                        {
                            if (_entity.InputData.ContainsKey(_column.ColumnName))
                            {
                                object _value = _entity.InputData[_column.ColumnName];
                                if (_value == null || _value.ToString() == "")
                                {
                                    AddErrorMsg(ErrorList, _column);
                                    _ret = false;
                                }
                            }
                            else
                            {
                                AddErrorMsg(ErrorList, _column);
                                _ret = false;
                            }
                        }
                    }
                }
            }
            else
            {
                foreach (MD_InputModel_Column _column in InputModel.Columns)
                {
                    if (_column.Required)
                    {
                        if (_entity.InputData.ContainsKey(_column.ColumnName))
                        {
                            object _value = _entity.InputData[_column.ColumnName];
                            if (_value == null || _value.ToString() == "")
                            {
                                AddErrorMsg(ErrorList, _column);
                                _ret = false;
                            }
                        }
                        else
                        {
                            AddErrorMsg(ErrorList, _column);
                            _ret = false;
                        }
                    }
                }
            }
            if (!_ret) return _ret;

            //foreach (Assembly _ruleAssmbly in InputModel.RuleAssemblys)
            //{
            //        bool _cret = InputModelRuleBuilder.CheckByRuleAssembly(_ruleAssmbly, _entity, ref ErrorList);
            //}
            if (ErrorList.Count > 0) _ret = false;

            return _ret;
        }

        private void AddErrorMsg(Dictionary<string, string> ErrorList, MD_InputModel_Column _column)
        {
            string _msg = string.Format("{0} 为必填项！", _column.DisplayName);
            ErrorList.Add(_column.DisplayName, _msg);
        }




    }
}
