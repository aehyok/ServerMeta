using System;
using System.Collections.Generic;
using System.Text;
using SinoSZJS.Base.Authorize;
using SinoSZJS.Base.MetaData.QueryModel;
using SinoSZJS.Base.MetaData.Common;

namespace SinoSZJS.CS.BizMetaDataManager.DAL
{
        public class SQLResultItemBuilder
        {
                public static string BuildItem(MDQuery_TableColumn _rColumn, MDModel_QueryModel  _qv)
                {
                        switch (_rColumn.ColumnType)
                        {
                                case QueryColumnType.TableColumn:
                                        return BuildTableColumnResult(_rColumn, _qv);

                                case QueryColumnType.CalculationColumn:
                                        break;
                                case QueryColumnType.StatisticsColumn:
                                        break;
                        }
                        return "";
                }

                private static string BuildTableColumnResult(MDQuery_TableColumn _rColumn, MDModel_QueryModel  _qv)
                {

                        MDModel_Table_Column  _mcolumn = MC_QueryModel.GetColumnDefineByName(_qv, _rColumn.TableName, _rColumn.ColumnName);
                        if (_mcolumn == null) return "";
                        return "," + BuildItem(_mcolumn);
                }





                public static string BuildItem(MDModel_Table_Column  _mcolumn)
                {

                        if ((_mcolumn.ColumnDefine.TableColumn.SecretLevel > SinoUserCtx.CurUser.SecretLevel) || (!_mcolumn.ColumnDefine.TableColumn.CanDisplay))
                        {
                                return string.Format("'＊＊＊' {0}", _mcolumn.ColumnAlias);
                        }


                        return string.Format("{0}.{1} {2}", _mcolumn.TableName, _mcolumn.ColumnName, _mcolumn.ColumnAlias);


                }
        }

}
