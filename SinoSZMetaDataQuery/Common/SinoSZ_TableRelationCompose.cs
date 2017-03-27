using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using SinoSZJS.Base.MetaData.QueryModel;
using System.Linq;
using SinoSZJS.Base.MetaData.DataCompare;

namespace SinoSZMetaDataQuery.Common
{
    /// <summary>
    /// 将两个关联的表合成一个表
    /// </summary>
    public class SinoSZ_TableRelationCompose
    {
        public MDQuery_Request QueryRequest = null;
        public MDModel_QueryModel QueryModel = null;
        public DataTable ResultData = null;

        public static SinoSZ_TableRelationCompose Compse(MDQuery_Request _srcRequest, MDModel_QueryModel _srcModel, DataTable _srcChildTable)
        {
            SinoSZ_TableRelationCompose _ret = new SinoSZ_TableRelationCompose();
            #region 处理查询结果字段
            _ret.QueryRequest = new MDQuery_Request();
            _ret.ResultData = new DataTable();
            _ret.ResultData.Columns.Add(new DataColumn("MAINID", typeof(String)));

            MDQuery_ResultTable _qrDefine = new MDQuery_ResultTable();

            _qrDefine.TableName = _srcRequest.MainResultTable.TableName;
            _qrDefine.TableName = _srcRequest.MainResultTable.DisplayTitle;
            _qrDefine.Columns = new List<MDQuery_TableColumn>();
            //添加所有主表字段
            Dictionary<string, string> _aliasLib = new Dictionary<string, string>();
            int _index = 0;
            DataTable _mainTable = _srcChildTable.DataSet.Tables[_srcRequest.MainResultTable.TableName];
            foreach (MDQuery_TableColumn _col in _srcRequest.MainResultTable.Columns)
            {
                MDQuery_TableColumn _newcol = CopyResultTableColumn(_col);
                _newcol.ColumnAlias = string.Format("F{0}", _index++);
                _aliasLib.Add(string.Format("{0}.{1}", _col.TableName, _col.ColumnAlias), _newcol.ColumnAlias);
                _qrDefine.Columns.Add(_newcol);
                DataColumn _dc = _mainTable.Columns[_col.ColumnAlias];
                DataColumn _newdc = new DataColumn(_newcol.ColumnAlias, _dc.DataType);
                _newdc.Caption = _dc.Caption;
                _ret.ResultData.Columns.Add(_newdc);
            }

            //添加所有子表字段
            var _find = from _t in _srcRequest.ChildResultTables
                        where _t.TableName == _srcChildTable.TableName
                        select _t;
            if (_find != null && _find.Count() > 0)
            {
                MDQuery_ResultTable _CResultTable = _find.First();
                foreach (MDQuery_TableColumn _col in _CResultTable.Columns)
                {
                    MDQuery_TableColumn _newcol = CopyResultTableColumn(_col);
                    _newcol.ColumnAlias = string.Format("F{0}", _index++);
                    _aliasLib.Add(string.Format("{0}.{1}", _col.TableName, _col.ColumnAlias), _newcol.ColumnAlias);
                    _qrDefine.Columns.Add(_newcol);

                    DataColumn _dc = _srcChildTable.Columns[_col.ColumnAlias];
                    DataColumn _newdc = new DataColumn(_newcol.ColumnAlias, _dc.DataType);
                    _newdc.Caption = _dc.Caption;
                    _ret.ResultData.Columns.Add(_newdc);
                }
            }
            else
            {
                foreach (DataColumn _dc in _srcChildTable.Columns)
                {
                    if (_dc.ColumnName != "MAINID")
                    {
                        MDQuery_TableColumn _newcol = new MDQuery_TableColumn();
                        _newcol.ColumnAlias = _dc.ColumnName;
                        _newcol.ColumnTitle = "EXCEL_" + _dc.ColumnName;
                        _aliasLib.Add(string.Format("{0}.{1}", _srcChildTable.TableName, _dc.ColumnName), _dc.ColumnName);
                        _qrDefine.Columns.Add(_newcol);

                        DataColumn _newdc = new DataColumn(_dc.ColumnName, _dc.DataType);
                        _newdc.Caption = _dc.Caption;
                        _ret.ResultData.Columns.Add(_newdc);
                    }
                }
            }

            _ret.QueryRequest.MainResultTable = _qrDefine;

            #endregion

            #region 处理元数据定义字段

            #endregion

            #region 处理数据表


            //添加数据
            foreach (DataRow _dr in _srcChildTable.Rows)
            {
                DataRow _newrow = _ret.ResultData.NewRow();
                foreach (DataColumn _dc in _srcChildTable.Columns)
                {
                    if (_dc.ColumnName != "MAINID")
                    {
                        string _newFieldName = _aliasLib[string.Format("{0}.{1}", _dc.Table.TableName, _dc.ColumnName)];
                        _newrow[_newFieldName] = _dr[_dc.ColumnName];
                    }
                }
                DataRow _fatherRow = _dr.GetParentRow(_srcChildTable.ParentRelations[0].RelationName);
                foreach (DataColumn _dc in _fatherRow.Table.Columns)
                {
                    if (_dc.ColumnName == "MAINID")
                    {
                        _newrow["MAINID"] = _fatherRow[_dc.ColumnName];
                    }
                    else
                    {
                        string _newFieldName = _aliasLib[string.Format("{0}.{1}", _dc.Table.TableName, _dc.ColumnName)];
                        _newrow[_newFieldName] = _fatherRow[_dc.ColumnName];
                    }
                }
                _ret.ResultData.Rows.Add(_newrow);
            }
            #endregion



            return _ret;
        }

        /// <summary>
        /// 复制查询结果字段元数据定义
        /// </summary>
        /// <param name="_columnDefine"></param>
        /// <returns></returns>
        private static MDQuery_TableColumn CopyResultTableColumn(MDQuery_TableColumn _columnDefine)
        {
            MDQuery_TableColumn _ret = new MDQuery_TableColumn();
            _ret.ColumnAlgorithm = _columnDefine.ColumnAlgorithm;
            _ret.ColumnAlias = _columnDefine.ColumnAlias;
            _ret.ColumnDataType = _columnDefine.ColumnDataType;
            _ret.ColumnName = _columnDefine.ColumnName;
            _ret.ColumnTitle = _columnDefine.ColumnTitle;
            _ret.ColumnType = _columnDefine.ColumnType;
            _ret.DisplayOrder = _columnDefine.DisplayOrder;
            _ret.Source = _columnDefine.Source;
            return _ret;
        }

        public static SinoSZ_TableRelationCompose CompareResultFullCompse(MDCompare_Request _Request, MDModel_QueryModel mDModel_QueryModel, DataSet CompareResult)
        {
            SinoSZ_TableRelationCompose _ret = new SinoSZ_TableRelationCompose();
            #region 处理查询结果字段
            _ret.QueryRequest = _Request as MDQuery_Request;
            _ret.ResultData = new DataTable();
            _ret.ResultData.Columns.Add(new DataColumn("MAINID", typeof(String)));

            #endregion

            #region 处理数据表


            #endregion



            return _ret;
        }
    }
}
