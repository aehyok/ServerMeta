using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;


using DevExpress.XtraEditors;
using SinoSZJS.Base.MetaData.QueryModel;
using SinoSZJS.Base.PAnalize;

namespace SinoSZMetaDataQuery.PAnalize
{
        class PAnalize_GridViewData
        {
                public static void SaveToPAnalize(DevExpress.XtraGrid.Views.Base.BaseView _bv)
                {
                        DataTable _savedt = null;
                        Dialog_SelectPAnalize _f = new Dialog_SelectPAnalize();
                        _f.InitData();
                        if (_f.ShowDialog() == DialogResult.OK)
                        {
                                DataView _dv = _bv.DataSource as DataView;
                                DataTable _dt = _dv.Table;

                                string _tname = _f.TableDisplayName;
                                List<MD_PATable_Column> columnDefine = new List<MD_PATable_Column>();

                                if (_bv is GridView)
                                {
                                        MD_PATable_Column _col = null;
                                        GridView _gridview = _bv as GridView;
                                        foreach (GridColumn _gc in _gridview.Columns)
                                        {
                                                MDQuery_TableColumn _cdefine = _gc.Tag as MDQuery_TableColumn;
                                                DataColumn _dc = _dt.Columns[_gc.FieldName];
                                                if (_cdefine == null)
                                                {

                                                        _col = new MD_PATable_Column("", "", "", _gc.FieldName, _gc.Caption, CovertColumnType(_dc.DataType), _dc.MaxLength, _gc.VisibleIndex);
                                                }
                                                else
                                                {
                                                        _col = new MD_PATable_Column("", "", "", _gc.FieldName, _gc.Caption, _cdefine.ColumnDataType,
                                                                                                                                       _cdefine.ColumnLength, _gc.VisibleIndex, _cdefine.RefDMB, _cdefine.DisplayFormat, _cdefine.RefWord);
                                                }
                                                columnDefine.Add(_col);
                                        }
                                }

                                //��֤����MAINID�ֶ�
                                //bool _findMainID = false;
                                //foreach (MD_PATable_Column _col in columnDefine)
                                //{
                                //        if (_col.ColumnName == "MAINID")
                                //        {
                                //                _findMainID = true;
                                //        }
                                //}
                                //û�������
                                //if (!_findMainID)
                                //{

                                //        
                                //}

                                //�������ַ������ͳ�����֤                               
                                foreach (MD_PATable_Column _col in columnDefine)
                                {
                                        switch (_col.ColumnType)
                                        {
                                                case "VARCHAR2":
                                                case "NVARCHAR2":
                                                case "VARCHAR":
                                                case "NVARCHAR":
                                                case "CHAR":
                                                        CheckLength(_col, _dt);
                                                        break;
                                                default:
                                                        if (_col.RefDMB==null || _col.RefDMB =="")
                                                        {
                                                        }
                                                        else
                                                        {
                                                                //ת��
                                                                CheckLength(_col, _dt);
                                                        }
                                                        break;
                                        }
                                }

                                #region �ж��Ƿ���ڼ����ֶ�
                                bool _haveComputData = false;
                                foreach (DataColumn _dc in _dt.Columns)
                                {
                                        if (_dc.Expression.Length > 0)
                                        {
                                                _haveComputData = true;
                                                break;
                                        }
                                }
                                if (_haveComputData)
                                {
                                        _savedt = new DataTable();
                                        foreach (MD_PATable_Column _col in columnDefine)
                                        {
                                                switch (_col.ColumnType)
                                                {
                                                        case "VARCHAR2":
                                                        case "NVARCHAR2":
                                                        case "VARCHAR":
                                                        case "NVARCHAR":
                                                        case "CHAR":
                                                                _savedt.Columns.Add(_col.ColumnName, typeof(string));
                                                                break;
                                                        default:
                                                                if (_col.RefDMB.Length > 0)
                                                                {
                                                                        //ת��
                                                                        _savedt.Columns.Add(_col.ColumnName, typeof(string));
                                                                }
                                                                else
                                                                {
                                                                        _savedt.Columns.Add(_col.ColumnName, _dt.Columns[_col.ColumnName].DataType);
                                                                }
                                                                break;
                                                }
                                        }

                                        foreach (DataRow _dr in _dt.Rows)
                                        {
                                                DataRow _newrow = _savedt.NewRow();
                                                foreach (MD_PATable_Column _col in columnDefine)
                                                {
                                                        _newrow[_col.ColumnName] = _dr[_col.ColumnName];
                                                }
                                                _savedt.Rows.Add(_newrow);
                                        }                                      
                                }
                                else
                                {
                                        _savedt = _dt;
                                }

                                #endregion


                                //�������ݶ����������
                                _savedt = _savedt.Copy();
                                columnDefine.Add(new MD_PATable_Column("", "", "", "PAMAINID", "����", "VARCHAR2", 50, 0));
                                _savedt.Columns.Add("PAMAINID", typeof(string));
                                foreach (DataRow _dr in _savedt.Rows)
                                {
                                        _dr["PAMAINID"] = Guid.NewGuid().ToString();
                                }

                                _savedt.AcceptChanges();



                                //������˷����ռ�
                                //if (SinoSZQueryConfig.MetaDataFactroy.SaveDataToPAnalize(_f.CurrentProject, _f.TableDisplayName, columnDefine, _savedt))
                                //{
                                //        XtraMessageBox.Show("����ɹ���", "ϵͳ��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //        return;
                                //}
                                //else
                                //{
                                //        XtraMessageBox.Show("����ʧ�ܣ�", "ϵͳ��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //        return;
                                //}


                        }
                }

                /// <summary>
                /// �����ַ����ֶεĳ��ȣ���Ҫ���ڽ����ѯ���������ת���󣬳��ȱȴ���Ҫ������Ԫ���ݶ���ĳ����޷�д�������ݵ����ݿ��С�
                /// </summary>
                /// <param name="_col"></param>
                /// <param name="_dt"></param>
                private static void CheckLength(MD_PATable_Column _col, DataTable _dt)
                {
                        string _fieldName = _col.ColumnName;
                        foreach (DataRow _dr in _dt.Rows)
                        {
                                string _s = _dr[_fieldName].ToString();
                                int _len = _s.Length * 2;
                                if (_len > _col.ColumnLength) _col.ColumnLength = _len;
                        }
                        _col.ColumnType = "VARCHAR2";
                }

                private static string CovertColumnType(Type type)
                {
                        if (type == typeof(string)) return "VARCHAR2";
                        if (type == typeof(DateTime)) return "DATE";
                        if (type == typeof(decimal)) return "NUMBER";
                        if (type == typeof(int)) return "NUMBER";
                        if (type == typeof(Double)) return "NUMBER";
                        return "VARCHAR2";
                }
        }
}
