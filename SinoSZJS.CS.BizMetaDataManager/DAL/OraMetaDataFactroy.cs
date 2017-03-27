using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using SinoSZJS.Base.Misc;
using SinoSZJS.Base.SystemLog;
using System.Diagnostics;
using SinoSZJS.DataAccess;
using SinoSZJS.Base.MetaData.QueryModel;
using SinoSZJS.Base.InputModel;
using SinoSZJS.Base.MetaData.Define;
using SinoSZJS.Base.MetaData.EnumDefine;
using SinoSZJS.Base.IMetaData;

namespace SinoSZJS.CS.BizMetaDataManager.DAL
{
    public class OraMetaDataFactroy : IMetaDataFactroy
    {

        #region IMetaDataFactroy Members
        private const string SQL_GetQueryModelByName = @"select VIEWID,NAMESPACE,VIEWNAME,DESCRIPTION,DISPLAYNAME,DWDM,IS_GDCX,IS_GLCX,IS_SJSH,DISPLAYORDER,ICSTYPE,EXTMETA
                                                        from MD_VIEW where VIEWNAME = :VIEWNAME order by DISPLAYORDER";
        public MD_QueryModel GetQueryModelByName(string modelName)
        {
            string[] _ms = modelName.Split('.');
            if (_ms.Length > 1)
            {
                return GetQueryModelByName(_ms[1], _ms[0]);
            }
            else
            {
                MD_QueryModel modelInfo = null;
                StringBuilder _sb = new StringBuilder();

                OracleParameter[] _param = {
                                                                new OracleParameter(":VIEWNAME",OracleDbType.Varchar2,50)
                                };

                _param[0].Value = modelName;

                OracleDataReader dr = OracleHelper.ExecuteReader(OracleHelper.ConnectionStringProfile, CommandType.Text, SQL_GetQueryModelByName, _param);

                IList<MD_QueryModel> nodeItems = new List<MD_QueryModel>();

                while (dr.Read())
                {
                    modelInfo = new MD_QueryModel(dr.GetOracleDecimal(0).ToString(), dr.GetString(1), dr.GetString(2),
                                    dr.IsDBNull(3) ? "" : dr.GetString(3), dr.IsDBNull(4) ? "" : dr.GetString(4), dr.IsDBNull(5) ? "" : dr.GetString(5),
                                    dr.IsDBNull(6) ? false : dr.GetOracleDecimal(6).Value > 0, dr.IsDBNull(7) ? false : dr.GetOracleDecimal(7).Value > 0,
                                    dr.IsDBNull(8) ? false : dr.GetOracleDecimal(8).Value > 0, dr.IsDBNull(9) ? 0 : Convert.ToInt32(dr.GetOracleDecimal(9).Value),
                                    dr.IsDBNull(10) ? "ORA_JSIS" : dr.GetString(10));

                    modelInfo.EXTMeta = dr.IsDBNull(11) ? "" : dr.GetString(11);
                }
                dr.Close();

                return modelInfo;
            }
        }

        private const string SQL_GetQueryModelByName2 = @"select VIEWID,NAMESPACE,VIEWNAME,DESCRIPTION,DISPLAYNAME,DWDM,IS_GDCX,IS_GLCX,IS_SJSH,DISPLAYORDER,ICSTYPE,EXTMETA
                                                            from MD_VIEW where NAMESPACE = :NAMESPACE and VIEWNAME = :VIEWNAME order by DISPLAYORDER";
        public MD_QueryModel GetQueryModelByName(string modelName, string nameSpace)
        {
            MD_QueryModel modelInfo = null;
            StringBuilder _sb = new StringBuilder();

            OracleParameter[] _param = {
                                new OracleParameter(":NAMESPACE", OracleDbType.Varchar2, 50),
                                new OracleParameter(":VIEWNAME",OracleDbType.Varchar2,50)
                        };
            _param[0].Value = nameSpace;
            _param[1].Value = modelName;

            OracleDataReader dr = OracleHelper.ExecuteReader(OracleHelper.ConnectionStringProfile, CommandType.Text, SQL_GetQueryModelByName2, _param);

            IList<MD_QueryModel> nodeItems = new List<MD_QueryModel>();

            while (dr.Read())
            {
                modelInfo = new MD_QueryModel(dr.GetOracleDecimal(0).ToString(), dr.GetString(1), dr.GetString(2),
                                dr.IsDBNull(3) ? "" : dr.GetString(3), dr.IsDBNull(4) ? "" : dr.GetString(4), dr.IsDBNull(5) ? "" : dr.GetString(5),
                                dr.IsDBNull(6) ? false : dr.GetOracleDecimal(6).Value > 0, dr.IsDBNull(7) ? false : dr.GetOracleDecimal(7).Value > 0,
                                dr.IsDBNull(8) ? false : dr.GetOracleDecimal(8).Value > 0, dr.IsDBNull(9) ? 0 : Convert.ToInt32(dr.GetOracleDecimal(9).Value),
                                dr.IsDBNull(10) ? "ORA_JSIS" : dr.GetString(10));

                modelInfo.EXTMeta = dr.IsDBNull(11) ? "" : dr.GetString(11);
            }
            dr.Close();

            return modelInfo;
        }

        public MD_QueryModelGroup GetQueryModelGroup(string queryModelGroupID)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public MD_QueryModelGroup GetQueryModelGroup(string queryModelGroupID, string nameSpace)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public MD_RefTable GetRefTable(string refTableName)
        {
            MD_RefTable _ret = null;
            OracleParameter[] _param;
            string[] _ctNames = refTableName.Split('.');

            StringBuilder _sb = new StringBuilder();
            _sb.Append("select RTID,NAMESPACE,REFTABLENAME,REFTABLELEVELFORMAT,DESCRIPTION,DWDM,DOWNLOADMODE,REFTABLEMODE,HIDECODE ");
            _sb.Append(" from md_reftablelist where REFTABLENAME = :TNAME");
            if (_ctNames.Length > 1)
            {
                _sb.Append(" and NAMESPACE=:NAMESPACE ");

                _param = new OracleParameter[] {
                                                new OracleParameter(":TNAME",OracleDbType.Varchar2,50),
                                                new OracleParameter(":NAMESPACE",OracleDbType.Varchar2,50) };
                _param[0].Value = _ctNames[1];
                _param[1].Value = _ctNames[0];
            }
            else
            {
                _param = new OracleParameter[] {
                                                new OracleParameter(":TNAME",OracleDbType.Varchar2,50)};
                _param[0].Value = _ctNames[0];
            }


            OracleDataReader dr = OracleHelper.ExecuteReader(OracleHelper.ConnectionStringProfile, CommandType.Text, _sb.ToString(), _param);

            while (dr.Read())
            {
                _ret = new MD_RefTable(dr.GetOracleDecimal(0).ToString(), dr.GetString(1), dr.GetString(2),
                                   dr.IsDBNull(3) ? "" : dr.GetString(3), dr.IsDBNull(4) ? "" : dr.GetString(4), dr.IsDBNull(5) ? "" : dr.GetString(5),
                                   dr.IsDBNull(6) ? 0 : Convert.ToInt32(dr.GetOracleDecimal(6).Value),
                                   dr.IsDBNull(7) ? 0 : Convert.ToInt32(dr.GetOracleDecimal(7).Value),
                                   dr.IsDBNull(8) ? false : (dr.GetDecimal(8) > 0));

            }
            dr.Close();

            return _ret;
        }

        public MD_RefTable GetRefTable(string refTableName, string nameSpace)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public MD_QueryModel GetQueryModelByID(string modelID)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public MD_QueryModel GetQueryModelByID(string modelID, string nameSpace)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        private const string SQL_GetNodeList = @"SELECT ID,NODENAME,DISPLAYTITLE,DESCRIPT,DWDM FROM MD_NODES";
        public IList<MD_Nodes> GetNodeList()
        {

            OracleDataReader dr = OracleHelper.ExecuteReader(OracleHelper.ConnectionStringProfile, CommandType.Text, SQL_GetNodeList);

            IList<MD_Nodes> nodeItems = new List<MD_Nodes>();

            while (dr.Read())
            {
                MD_Nodes nodeInfo = new MD_Nodes(dr.GetString(0), dr.GetString(1),
                                dr.GetString(2), dr.GetString(3), dr.GetString(4));
                nodeItems.Add(nodeInfo);
            }
            dr.Close();
            return nodeItems;
        }

        private const string SQL_GetNameSpaceAtNode = @"SELECT NAMESPACE,DESCRIPTION,MENUPOSITION,DISPLAYTITLE,OWNER,DISPLAYORDER,DWDM,CONCEPTS FROM MD_TBNAMESPACE
                                                        where DWDM = :DWDM order by DISPLAYORDER ASC";
        public IList<MD_Namespace> GetNameSpaceAtNode(string _nodeDWDM)
        {

            OracleParameter[] _param = {
                                new OracleParameter(":DWDM", OracleDbType.Varchar2, 12),
                        };
            _param[0].Value = _nodeDWDM;

            OracleDataReader dr = OracleHelper.ExecuteReader(OracleHelper.ConnectionStringProfile, CommandType.Text, SQL_GetNameSpaceAtNode, _param);

            IList<MD_Namespace> nodeItems = new List<MD_Namespace>();

            while (dr.Read())
            {
                MD_Namespace nodeInfo = new MD_Namespace();
                nodeInfo.NameSpace = dr.GetString(0);
                nodeInfo.Description = dr.IsDBNull(1) ? "" : dr.GetString(1);
                nodeInfo.MenuPosition = dr.IsDBNull(2) ? "" : dr.GetString(2);
                nodeInfo.DisplayTitle = dr.IsDBNull(3) ? "" : dr.GetString(3);
                nodeInfo.Owner = dr.IsDBNull(4) ? "" : dr.GetString(4);
                nodeInfo.DisplayOrder = dr.IsDBNull(5) ? 0 : Convert.ToInt32(dr.GetOracleDecimal(5).Value);
                nodeInfo.DWDM = dr.IsDBNull(6) ? "" : dr.GetString(6);
                nodeInfo.Concepts = dr.IsDBNull(7) ? "" : dr.GetString(7);
                nodeItems.Add(nodeInfo);
            }
            dr.Close();
            return nodeItems;
        }


        #endregion


        #region IMetaDataFactroy Members


        public bool SaveNewNameSapce(MD_Namespace _ns)
        {
            StringBuilder _sb = new StringBuilder();
            _sb.Append("insert into  MD_TBNAMESPACE (NAMESPACE,DESCRIPTION,MENUPOSITION,DISPLAYTITLE,OWNER,DISPLAYORDER,DWDM,CONCEPTS) ");
            _sb.Append(" values (:NAMESPACE,:DESCRIPTION,:MENUPOSITION,:DISPLAYTITLE,:OWNER,:DISPLAYORDER,:DWDM,:CONCEPTS) ");
            OracleParameter[] _param = {
                                 new OracleParameter(":NAMESPACE", OracleDbType.Varchar2, 50),
                                new OracleParameter(":DESCRIPTION", OracleDbType.Varchar2, 100),
                                new OracleParameter(":MENUPOSITION", OracleDbType.Varchar2, 50),
                                new OracleParameter(":DISPLAYTITLE", OracleDbType.Varchar2, 50),
                                new OracleParameter(":OWNER", OracleDbType.Varchar2, 50),
                                new OracleParameter(":DISPLAYORDER", OracleDbType.Decimal),
                                new OracleParameter(":DWDM", OracleDbType.Varchar2, 12),
                                new OracleParameter(":CONCEPTS", OracleDbType.Varchar2, 1000)
                               
                        };
            _param[0].Value = _ns.NameSpace;
            _param[1].Value = _ns.Description;
            _param[2].Value = _ns.MenuPosition;
            _param[3].Value = _ns.DisplayTitle;
            _param[4].Value = _ns.Owner;
            _param[5].Value = _ns.DisplayOrder;
            _param[6].Value = _ns.DWDM;
            _param[7].Value = _ns.Concepts;


            OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionStringProfile, CommandType.Text, _sb.ToString(), _param);
            OraMetaDataQueryFactroy.ModelLib.Clear();
            return true;
        }

        #endregion

        #region IMetaDataFactroy Members


        public bool SaveNodes(MD_Nodes _nodes)
        {
            StringBuilder _sb = new StringBuilder();
            _sb.Append("update MD_NODES set NODENAME=:NODENAME,DISPLAYTITLE=:DISPLAYTITLE,DESCRIPT=:DESCRIPT,DWDM=:DWDM ");
            _sb.Append(" where ID = :ID");
            OracleParameter[] _param = {
                                new OracleParameter(":NODENAME", OracleDbType.Varchar2, 100),
                                new OracleParameter(":DISPLAYTITLE", OracleDbType.Varchar2, 200),
                                new OracleParameter(":DESCRIPT", OracleDbType.Varchar2, 2000),
                                new OracleParameter(":DWDM", OracleDbType.Varchar2, 100),
                                 new OracleParameter(":ID", OracleDbType.Varchar2, 100)
                        };
            _param[0].Value = _nodes.NodeName;
            _param[1].Value = _nodes.DisplayTitle;
            _param[2].Value = _nodes.Descript;
            _param[3].Value = _nodes.DWDM;
            _param[4].Value = _nodes.ID;

            OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionStringProfile, CommandType.Text, _sb.ToString(), _param);
            OraMetaDataQueryFactroy.ModelLib.Clear();
            return true;
        }

        #endregion

        #region IMetaDataFactroy Members


        public bool SaveNewNodes(MD_Nodes _nodes)
        {
            StringBuilder _sb = new StringBuilder();
            _sb.Append("insert into  MD_NODES (ID,NODENAME,DISPLAYTITLE,DESCRIPT,DWDM) ");
            _sb.Append(" values (:ID,:NODENAME,:DISPLAYTITLE,:DESCRIPT,:DWDM) ");
            OracleParameter[] _param = {
                                 new OracleParameter(":ID", OracleDbType.Varchar2, 100),
                                new OracleParameter(":NODENAME", OracleDbType.Varchar2, 100),
                                new OracleParameter(":DISPLAYTITLE", OracleDbType.Varchar2, 200),
                                new OracleParameter(":DESCRIPT", OracleDbType.Varchar2, 2000),
                                new OracleParameter(":DWDM", OracleDbType.Varchar2, 100)
                                
                        };
            _param[0].Value = _nodes.ID;
            _param[1].Value = _nodes.NodeName;
            _param[2].Value = _nodes.DisplayTitle;
            _param[3].Value = _nodes.Descript;
            _param[4].Value = _nodes.DWDM;


            OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionStringProfile, CommandType.Text, _sb.ToString(), _param);
            OraMetaDataQueryFactroy.ModelLib.Clear();
            return true;
        }

        #endregion

        #region IMetaDataFactroy Members

        private const string SQL_DelNodes = @"delete  MD_NODES where ID=:ID ";
        public bool DelNodes(string _nodeID)
        {
            OracleParameter[] _param = {
                                 new OracleParameter(":ID", OracleDbType.Varchar2, 100)   
                        };
            _param[0].Value = _nodeID;
            OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionStringProfile, CommandType.Text, SQL_DelNodes, _param);
            OraMetaDataQueryFactroy.ModelLib.Clear();
            return true;
        }

        #endregion

        #region IMetaDataFactroy Members


        public bool SaveNameSapce(MD_Namespace _ns)
        {
            StringBuilder _sb = new StringBuilder();
            _sb.Append("update MD_TBNAMESPACE set DESCRIPTION = :DESCRIPTION,MENUPOSITION=:MENUPOSTION,");
            _sb.Append(" DISPLAYTITLE = :DISPLAYTITLE,OWNER = :OWNER,DISPLAYORDER = :DISPLAYORDER,DWDM =:DWDM,CONCEPTS = :CONCEPTS ");
            _sb.Append(" where NAMESPACE = :NAMESPACE");
            OracleParameter[] _param = {                                
                                new OracleParameter(":DESCRIPTION", OracleDbType.Varchar2, 100),
                                new OracleParameter(":MENUPOSTION", OracleDbType.Varchar2, 50),
                                new OracleParameter(":DISPLAYTITLE", OracleDbType.Varchar2, 50),
                                new OracleParameter(":OWNER", OracleDbType.Varchar2, 50),
                                new OracleParameter(":DISPLAYORDER", OracleDbType.Decimal),
                                new OracleParameter(":DWDM", OracleDbType.Varchar2, 12),
                                new OracleParameter(":CONCEPTS", OracleDbType.Varchar2, 1000),
                                new OracleParameter(":NAMESPACE", OracleDbType.Varchar2, 50)                         
                        };

            _param[0].Value = _ns.Description;
            _param[1].Value = _ns.MenuPosition;
            _param[2].Value = _ns.DisplayTitle;
            _param[3].Value = _ns.Owner;
            _param[4].Value = _ns.DisplayOrder;
            _param[5].Value = _ns.DWDM;
            _param[6].Value = _ns.Concepts;
            _param[7].Value = _ns.NameSpace;


            OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionStringProfile, CommandType.Text, _sb.ToString(), _param);
            OraMetaDataQueryFactroy.ModelLib.Clear();
            return true;
        }

        #endregion

        #region IMetaDataFactroy Members


        private const string SQL_DelNamespace = "delete MD_TBNAMESPACE where NAMESPACE=:NAMESPACE  ";
        public bool DelNamespace(MD_Namespace _ns)
        {
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                OracleTransaction txn = cn.BeginTransaction();
                try
                {
                    OracleParameter[] _param = {
                                                         new OracleParameter(":NAMESPACE", OracleDbType.Varchar2, 100)   
                                                };
                    _param[0].Value = _ns.NameSpace;
                    OracleHelper.ExecuteNonQuery(cn, CommandType.Text, SQL_DelNamespace, _param);
                    txn.Commit();
                    OraMetaDataQueryFactroy.ModelLib.Clear();
                    return true;
                }
                catch (Exception ex)
                {
                    txn.Rollback();
                    return false;
                }
            }

        }

        #endregion

        #region IMetaDataFactroy Members


        private const string SQL_GetDBTableList = @"select TC.table_name TNAME,TC.comments COMMENTS,tc.table_type TYPE,tc.OWNER from ALL_TAB_COMMENTS TC where OWNER ='ZHTJ' or OWNER='JSODS' or OWNER=:CURRENTOWNER";
        public IList<DB_TableMeta> GetDBTableList()
        {

            string _cowner = GetConnectionUser();
            OracleParameter[] _param = {                                
                                new OracleParameter(":CURRENTOWNER",_cowner)};

            OracleDataReader dr = OracleHelper.ExecuteReader(OracleHelper.ConnectionStringProfile, CommandType.Text, SQL_GetDBTableList, _param);

            IList<DB_TableMeta> tableList = new List<DB_TableMeta>();

            while (dr.Read())
            {
                string _tanme = dr.GetString(0);
                string _owner = dr.GetString(3);
                string _comment = dr.IsDBNull(1) ? "" : dr.GetString(1);
                string _type = dr.GetString(2);

                DB_TableMeta nodeInfo = new DB_TableMeta();
                nodeInfo.TableName = string.Format("{0}.{1}", _owner, _tanme);
                nodeInfo.TableComment = _comment;
                nodeInfo.TableType = _type;
                tableList.Add(nodeInfo);
            }
            dr.Close();
            return tableList;
        }

        public IList<DB_TableMeta> GetDBTableListOfDMB()
        {
            string cmdStr = "select TC.table_name TNAME,TC.comments COMMENTS,tc.table_type TYPE,tc.OWNER from ALL_TAB_COMMENTS TC where (OWNER='JSODS') ";
            cmdStr += " and TABLE_NAME LIKE 'DM%' ";
            OracleDataReader dr = OracleHelper.ExecuteReader(OracleHelper.ConnectionStringProfile, CommandType.Text, cmdStr);

            IList<DB_TableMeta> tableList = new List<DB_TableMeta>();

            while (dr.Read())
            {
                string _tanme = dr.GetString(0);
                string _owner = dr.GetString(3);
                string _comment = dr.IsDBNull(1) ? "" : dr.GetString(1);
                string _type = dr.GetString(2);

                DB_TableMeta nodeInfo = new DB_TableMeta();
                nodeInfo.TableName = string.Format("{0}.{1}", _owner, _tanme);
                nodeInfo.TableComment = _comment;
                nodeInfo.TableType = _type;
                tableList.Add(nodeInfo);
            }
            dr.Close();
            return tableList;
        }

        #endregion

        #region IMetaDataFactroy Members

        public bool SaveNewTable(DB_TableMeta _tm, MD_Namespace _ns)
        {
            string InsertStr = "insert into MD_TABLE (TID,NAMESPACE,TABLENAME,TABLETYPE,DESCRIPTION,DISPLAYNAME,DWDM) VALUES ";
            InsertStr += "( sequences_meta.nextval,:NAMESPACE,:TABLENAME,:TABLETYPE,:DESCRIPTION,:DISPLAYNAME,:DWDM)";

            OracleParameter[] _param = {
                                new OracleParameter(":NAMESPACE", OracleDbType.Varchar2, 50),
                                new OracleParameter(":TABLENAME", OracleDbType.Varchar2, 50),
                                new OracleParameter(":TABLETYPE", OracleDbType.Varchar2, 50),
                                new OracleParameter(":DESCRIPTION", OracleDbType.Varchar2, 100),
                                new OracleParameter(":DISPLAYNAME", OracleDbType.Varchar2, 100),
                                new OracleParameter(":DWDM", OracleDbType.Varchar2, 12)
                        };
            _param[0].Value = _ns.NameSpace;
            _param[1].Value = _tm.TableName;
            _param[2].Value = _tm.TableType;
            _param[3].Value = _tm.TableComment;
            _param[4].Value = _tm.TableName;
            _param[5].Value = _ns.DWDM;

            OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionStringProfile, CommandType.Text, InsertStr, _param);
            OraMetaDataQueryFactroy.ModelLib.Clear();
            return true;
        }

        #endregion

        #region IMetaDataFactroy Members

        private const string SQL_GetTablesAtNamespace = @"select TID,NAMESPACE,TABLENAME,TABLETYPE,DESCRIPTION,DISPLAYNAME,MAINKEY,DWDM,
                                                            SECRETFUN,EXTSECRET,RESTYPE from MD_TABLE where NAMESPACE = :NAMESPACE order by DISPLAYNAME";
        public IList<MD_Table> GetTablesAtNamespace(string NsName)
        {
            OracleParameter[] _param = {
                                new OracleParameter(":NAMESPACE", OracleDbType.Varchar2, 50),
                        };
            _param[0].Value = NsName;

            OracleDataReader dr = OracleHelper.ExecuteReader(OracleHelper.ConnectionStringProfile, CommandType.Text, SQL_GetTablesAtNamespace, _param);

            IList<MD_Table> nodeItems = new List<MD_Table>();

            while (dr.Read())
            {
                MD_Table nodeInfo = new MD_Table(dr.GetOracleDecimal(0).ToString(), dr.GetString(1), dr.GetString(2), dr.GetString(3),
                                dr.IsDBNull(4) ? "" : dr.GetString(4), dr.IsDBNull(5) ? "" : dr.GetString(5), dr.IsDBNull(6) ? "" : dr.GetString(6),
                                dr.IsDBNull(7) ? "" : dr.GetString(7), dr.IsDBNull(8) ? "" : dr.GetString(8), dr.IsDBNull(9) ? "" : dr.GetString(9),
                                dr.IsDBNull(10) ? "" : dr.GetString(10));
                nodeItems.Add(nodeInfo);
            }
            dr.Close();

            return nodeItems;
        }
        public IList<MD_Table> GetTablesAtNamespace(MD_Namespace _ns)
        {
            return GetTablesAtNamespace(_ns.NameSpace);
        }

        private const string SQL_GetTableByTableID = @"select TID,NAMESPACE,TABLENAME,TABLETYPE,DESCRIPTION,DISPLAYNAME,MAINKEY,DWDM,
                                                         SECRETFUN,EXTSECRET,RESTYPE from MD_TABLE where TID=:TID";
        public MD_Table GetTableByTableID(string _tid)
        {
            MD_Table _ret = null;

            OracleParameter[] _param = {
                                new OracleParameter(":TID", OracleDbType.Decimal)
                        };
            _param[0].Value = decimal.Parse(_tid);

            OracleDataReader dr = OracleHelper.ExecuteReader(OracleHelper.ConnectionStringProfile, CommandType.Text, SQL_GetTableByTableID, _param);



            while (dr.Read())
            {
                _ret = new MD_Table(dr.GetOracleDecimal(0).ToString(), dr.GetString(1), dr.GetString(2), dr.GetString(3),
                                dr.IsDBNull(4) ? "" : dr.GetString(4), dr.IsDBNull(5) ? "" : dr.GetString(5), dr.IsDBNull(6) ? "" : dr.GetString(6),
                                dr.IsDBNull(7) ? "" : dr.GetString(7), dr.IsDBNull(8) ? "" : dr.GetString(8), dr.IsDBNull(9) ? "" : dr.GetString(9),
                                dr.IsDBNull(10) ? "" : dr.GetString(10));

            }
            dr.Close();

            return _ret;
        }

        #endregion

        #region IMetaDataFactroy Members

        private const string SQL_GetQueryModelAtNamespace = @"select VIEWID,NAMESPACE,VIEWNAME,DESCRIPTION,DISPLAYNAME,DWDM,IS_GDCX,IS_GLCX,IS_SJSH,DISPLAYORDER,ICSTYPE,EXTMETA
                                                                from MD_VIEW where NAMESPACE = :NAMESPACE order by DISPLAYORDER";
        public IList<MD_QueryModel> GetQueryModelAtNamespace(string NsName)
        {
            OracleParameter[] _param = {
                                new OracleParameter(":NAMESPACE", OracleDbType.Varchar2, 50),
                        };
            _param[0].Value = NsName;

            OracleDataReader dr = OracleHelper.ExecuteReader(OracleHelper.ConnectionStringProfile, CommandType.Text, SQL_GetQueryModelAtNamespace, _param);

            IList<MD_QueryModel> nodeItems = new List<MD_QueryModel>();

            while (dr.Read())
            {
                MD_QueryModel nodeInfo = new MD_QueryModel(dr.GetOracleDecimal(0).ToString(), dr.GetString(1), dr.GetString(2),
                                dr.IsDBNull(3) ? "" : dr.GetString(3), dr.IsDBNull(4) ? "" : dr.GetString(4), dr.IsDBNull(5) ? "" : dr.GetString(5),
                                dr.IsDBNull(6) ? false : dr.GetOracleDecimal(6).Value > 0, dr.IsDBNull(7) ? false : dr.GetOracleDecimal(7).Value > 0,
                                dr.IsDBNull(8) ? false : dr.GetOracleDecimal(8).Value > 0, dr.IsDBNull(9) ? 0 : Convert.ToInt32(dr.GetOracleDecimal(9).Value),
                                dr.IsDBNull(10) ? "ORA_JSIS" : dr.GetString(10));
                nodeInfo.EXTMeta = dr.IsDBNull(11) ? "" : dr.GetString(11);
                nodeItems.Add(nodeInfo);

            }
            dr.Close();

            return nodeItems;
        }
        public IList<MD_QueryModel> GetQueryModelAtNamespace(MD_Namespace _ns)
        {
            return GetQueryModelAtNamespace(_ns.NameSpace);
        }

        #endregion

        #region IMetaDataFactroy Members

        public IList<MD_RefTable> GetRefTableAtNamespace(MD_Namespace _ns)
        {
            return GetRefTableAtNamespace(_ns.NameSpace);
        }
        public IList<MD_RefTable> GetRefTableAtNamespace(string _ns)
        {
            StringBuilder _sb = new StringBuilder();
            _sb.Append("select RTID,NAMESPACE,REFTABLENAME,REFTABLELEVELFORMAT,DESCRIPTION,DWDM,DOWNLOADMODE,REFTABLEMODE ,HIDECODE");
            _sb.Append(" from MD_REFTABLELIST where NAMESPACE = :NAMESPACE order by REFTABLENAME");

            OracleParameter[] _param = {
                                new OracleParameter(":NAMESPACE", OracleDbType.Varchar2, 50),
                        };
            _param[0].Value = _ns;

            OracleDataReader dr = OracleHelper.ExecuteReader(OracleHelper.ConnectionStringProfile, CommandType.Text, _sb.ToString(), _param);

            IList<MD_RefTable> nodeItems = new List<MD_RefTable>();

            while (dr.Read())
            {
                MD_RefTable nodeInfo = new MD_RefTable(dr.GetOracleDecimal(0).ToString(), dr.GetString(1), dr.GetString(2),
                                dr.IsDBNull(3) ? "" : dr.GetString(3), dr.IsDBNull(4) ? "" : dr.GetString(4), dr.IsDBNull(5) ? "" : dr.GetString(5),
                                dr.IsDBNull(6) ? 0 : Convert.ToInt32(dr.GetOracleDecimal(6).Value),
                                dr.IsDBNull(7) ? 0 : Convert.ToInt32(dr.GetOracleDecimal(7).Value),
                                dr.IsDBNull(8) ? false : (dr.GetDecimal(8) > 0));
                nodeItems.Add(nodeInfo);

            }
            dr.Close();

            return nodeItems;
        }



        #endregion

        #region IMetaDataFactroy Members

        private const string SQL_GetColumnOfTable = @"select TCID,TID,COLUMNNAME,ISNULLABLE,TYPE,PRECISION,SCALE,LENGTH,REFDMB,
                                                        DMBLEVELFORMAT,SECRETLEVEL,DISPLAYTITLE,DISPLAYFORMAT,DISPLAYLENGTH,DISPLAYHEIGHT,
                                                        DISPLAYORDER,CANDISPLAY,COLWIDTH, DWDM,CTAG,REFWORDTB
                                                         from MD_TABLECOLUMN where TCID = :TCID order by DISPLAYORDER";
        public MD_TableColumn GetColumnOfTable(string _tcid)
        {
            MD_TableColumn nodeInfo = null;
            OracleParameter[] _param = {
                                new OracleParameter(":TCID", OracleDbType.Decimal),
                        };
            _param[0].Value = decimal.Parse(_tcid);

            OracleDataReader dr = OracleHelper.ExecuteReader(OracleHelper.ConnectionStringProfile, CommandType.Text, SQL_GetColumnOfTable, _param);
            while (dr.Read())
            {
                nodeInfo = new MD_TableColumn(
                               dr.GetOracleDecimal(0).ToString(), dr.GetOracleDecimal(1).ToString(), dr.GetString(2),
                               dr.IsDBNull(3) ? true : ((dr.GetString(3) == "Y") ? true : false),
                               dr.GetString(4),
                               dr.IsDBNull(5) ? 1 : Convert.ToInt32(dr.GetOracleDecimal(5).Value),
                               dr.IsDBNull(6) ? 1 : Convert.ToInt32(dr.GetOracleDecimal(6).Value),
                               dr.IsDBNull(7) ? 1 : Convert.ToInt32(dr.GetOracleDecimal(7).Value),
                               dr.IsDBNull(8) ? "" : dr.GetString(8),
                               dr.IsDBNull(9) ? "" : dr.GetString(9),
                               dr.IsDBNull(10) ? 0 : Convert.ToInt32(dr.GetOracleDecimal(10).Value),
                               dr.IsDBNull(11) ? "" : dr.GetString(11),
                               dr.IsDBNull(12) ? "" : dr.GetString(12),
                               dr.IsDBNull(13) ? 0 : Convert.ToInt32(dr.GetOracleDecimal(13).Value),
                               dr.IsDBNull(14) ? 0 : Convert.ToInt32(dr.GetOracleDecimal(14).Value),
                               dr.IsDBNull(15) ? 0 : Convert.ToInt32(dr.GetOracleDecimal(15).Value),
                               dr.IsDBNull(16) ? false : dr.GetOracleDecimal(16).Value > 0,
                               dr.IsDBNull(17) ? 0 : Convert.ToInt32(dr.GetOracleDecimal(17).Value),
                               dr.IsDBNull(18) ? "" : dr.GetString(18),
                               dr.IsDBNull(19) ? "" : dr.GetString(19),
                               dr.IsDBNull(20) ? "" : dr.GetString(20)
                               );
            }
            dr.Close();
            return nodeInfo;
        }

        public IList<MD_TableColumn> GetColumnsOfTable(string _tid)
        {
            StringBuilder _sb = new StringBuilder();
            _sb.Append("select TCID,TID,COLUMNNAME,");
            _sb.Append(" ISNULLABLE,TYPE,PRECISION,");
            _sb.Append(" SCALE,LENGTH,REFDMB,");
            _sb.Append(" DMBLEVELFORMAT,SECRETLEVEL,DISPLAYTITLE,");
            _sb.Append(" DISPLAYFORMAT,DISPLAYLENGTH,DISPLAYHEIGHT,");
            _sb.Append(" DISPLAYORDER,CANDISPLAY,COLWIDTH,");
            _sb.Append(" DWDM,CTAG,REFWORDTB");
            _sb.Append(" from MD_TABLECOLUMN where TID = :TID order by DISPLAYORDER");

            OracleParameter[] _param = {
                                new OracleParameter(":TID", OracleDbType.Decimal),
                        };
            _param[0].Value = decimal.Parse(_tid);

            OracleDataReader dr = OracleHelper.ExecuteReader(OracleHelper.ConnectionStringProfile, CommandType.Text, _sb.ToString(), _param);

            IList<MD_TableColumn> nodeItems = new List<MD_TableColumn>();

            while (dr.Read())
            {
                MD_TableColumn nodeInfo = new MD_TableColumn(
                                dr.GetOracleDecimal(0).ToString(), dr.GetOracleDecimal(1).ToString(), dr.GetString(2),
                                dr.IsDBNull(3) ? true : ((dr.GetString(3) == "Y") ? true : false),
                                dr.GetString(4),
                                dr.IsDBNull(5) ? 1 : Convert.ToInt32(dr.GetOracleDecimal(5).Value),
                                dr.IsDBNull(6) ? 1 : Convert.ToInt32(dr.GetOracleDecimal(6).Value),
                                dr.IsDBNull(7) ? 1 : Convert.ToInt32(dr.GetOracleDecimal(7).Value),
                                dr.IsDBNull(8) ? "" : dr.GetString(8),
                                dr.IsDBNull(9) ? "" : dr.GetString(9),
                                dr.IsDBNull(10) ? 0 : Convert.ToInt32(dr.GetOracleDecimal(10).Value),
                                dr.IsDBNull(11) ? "" : dr.GetString(11),
                                dr.IsDBNull(12) ? "" : dr.GetString(12),
                                dr.IsDBNull(13) ? 0 : Convert.ToInt32(dr.GetOracleDecimal(13).Value),
                                dr.IsDBNull(14) ? 0 : Convert.ToInt32(dr.GetOracleDecimal(14).Value),
                                dr.IsDBNull(15) ? 0 : Convert.ToInt32(dr.GetOracleDecimal(15).Value),
                                dr.IsDBNull(16) ? false : dr.GetOracleDecimal(16).Value > 0,
                                dr.IsDBNull(17) ? 0 : Convert.ToInt32(dr.GetOracleDecimal(17).Value),
                                dr.IsDBNull(18) ? "" : dr.GetString(18),
                                dr.IsDBNull(19) ? "" : dr.GetString(19),
                                dr.IsDBNull(20) ? "" : dr.GetString(20)
                                );
                nodeItems.Add(nodeInfo);
            }
            dr.Close();

            return nodeItems;
        }

        #endregion

        #region IMetaDataFactroy Members

        public MD_ViewTable GetMainTableOfQueryModel(MD_QueryModel _qm)
        {
            return GetMainTableOfQueryModel(_qm.QueryModelID);
        }

        private const string SQL_GetMainTableOfQueryModel = @"select vt.VTID,vt.VIEWID,vt.TID,
                                                                vt.TABLETYPE,vt.TABLERELATION,vt.CANCONDITION,
                                                                vt.DISPLAYNAME,vt.DISPLAYORDER,vt.DWDM,
                                                                vt.FATHERID,vt.PRIORITY,vt.DISPLAYTYPE,vt.INTEGRATEDAPP,v.namespace
                                                                from MD_VIEWTABLE vt
                                                                join MD_VIEW V on  v.viewid=vt.viewid
                                                                where vt.VIEWID = :VID and vt.TABLETYPE = 'M' order by vt.DISPLAYORDER";
        public MD_ViewTable GetMainTableOfQueryModel(string QueryModelID)
        {
            MD_ViewTable _vt = null;

            OracleParameter[] _param = {
                                new OracleParameter(":VID", OracleDbType.Decimal),
                        };
            _param[0].Value = decimal.Parse(QueryModelID);

            OracleDataReader dr = OracleHelper.ExecuteReader(OracleHelper.ConnectionStringProfile, CommandType.Text, SQL_GetMainTableOfQueryModel, _param);

            while (dr.Read())
            {
                _vt = new MD_ViewTable(dr.GetOracleDecimal(0).ToString(),
                                dr.GetOracleDecimal(1).ToString(),
                                dr.GetOracleDecimal(2).ToString(),
                                dr.IsDBNull(3) ? "M" : dr.GetString(3),
                                dr.IsDBNull(4) ? "" : dr.GetString(4),
                                dr.IsDBNull(5) ? "" : dr.GetString(5),
                                dr.IsDBNull(6) ? "" : dr.GetString(6),
                                dr.IsDBNull(7) ? 0 : Convert.ToInt32(dr.GetOracleDecimal(7).Value),
                                dr.IsDBNull(8) ? "" : dr.GetString(8),
                                dr.IsDBNull(9) ? "" : dr.GetOracleDecimal(9).ToString(),
                                dr.IsDBNull(10) ? 0 : Convert.ToInt32(dr.GetOracleDecimal(10).Value),
                                dr.IsDBNull(11) ? 0 : Convert.ToInt32(dr.GetOracleDecimal(11).Value),
                                dr.IsDBNull(12) ? "" : dr.GetString(12)

                                );
                _vt.NamespaceName = dr.IsDBNull(13) ? "" : dr.GetString(13);
            }
            dr.Close();
            if (_vt != null)
            {
                _vt.Table = GetTableByTableID(_vt.TableID);
                _vt.TableName = _vt.Table.TableName;
                _vt.Columns = GetColumnsOfViewTable(_vt);
            }
            return _vt;
        }

        private const string SQL_GetColumnsOfViewTable = @"select VTC.VTCID,VTC.VTID,VTC.TCID,VTC.CANCONDITIONSHOW,VTC.CANRESULTSHOW,VTC.DEFAULTSHOW,VTC.FIXQUERYITEM,VTC.CANMODIFY,
                                                            VTC.dwdm,VTC.PRIORITY
                                                            ,case when VTC.DISPLAYORDER =0 or  VTC.DISPLAYORDER is null then (select tc.displayorder from md_tablecolumn tc where tc.tcid=vtc.tcid) else VTC.DISPLAYORDER end  VTCORDER
                                                             from MD_VIEWTABLECOLUMN VTC 
                                                            where VTC.VTID = :VTID order by vtcorder ";
        private IList<MD_ViewTableColumn> GetColumnsOfViewTable(MD_ViewTable _vt)
        {
            IList<MD_ViewTableColumn> nodeItems = new List<MD_ViewTableColumn>();
            MD_ViewTableColumn nodeInfo;
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                OracleCommand _cmd = new OracleCommand(SQL_GetColumnsOfViewTable, cn);
                _cmd.Parameters.Add(":VTID", _vt.ViewTableID);
                OracleDataReader _dr = _cmd.ExecuteReader();
                while (_dr.Read())
                {
                    nodeInfo = new MD_ViewTableColumn(
                       _dr.IsDBNull(0) ? "" : _dr.GetOracleDecimal(0).ToString(),
                       _dr.IsDBNull(1) ? "" : _dr.GetOracleDecimal(1).ToString(),
                       _dr.IsDBNull(2) ? "" : _dr.GetOracleDecimal(2).ToString(),
                       _dr.IsDBNull(3) ? false : _dr.GetOracleDecimal(3).Value > 0,
                       _dr.IsDBNull(4) ? false : _dr.GetOracleDecimal(4).Value > 0,
                       _dr.IsDBNull(5) ? false : _dr.GetOracleDecimal(5).Value > 0,
                       _dr.IsDBNull(6) ? false : _dr.GetOracleDecimal(6).Value > 0,
                       _dr.IsDBNull(7) ? false : _dr.GetOracleDecimal(7).Value > 0,
                       _dr.IsDBNull(8) ? "" : _dr.GetString(8),
                       _dr.IsDBNull(9) ? 0 : Convert.ToInt32(_dr.GetOracleDecimal(9).Value),
                       _dr.IsDBNull(10) ? 0 : Convert.ToInt32(_dr.GetOracleDecimal(10).Value)
                       );
                    nodeInfo.TableColumn = GetColumnOfTable(nodeInfo.ColumnID);
                    nodeInfo.TID = _vt.TableID;
                    nodeInfo.TableName = _vt.TableName;
                    nodeItems.Add(nodeInfo);
                }
                _dr.Close();


            }
            #region 旧的方法，已经废弃
            /*
                        StringBuilder _sb = new StringBuilder();
                        _sb.Append("select TC.TCID,TC.TID,TC.COLUMNNAME,");
                        _sb.Append(" TC.ISNULLABLE,TC.TYPE,TC.PRECISION,");
                        _sb.Append(" TC.SCALE,TC.LENGTH,TC.REFDMB,");
                        _sb.Append(" TC.DMBLEVELFORMAT,TC.SECRETLEVEL,TC.DISPLAYTITLE,");
                        _sb.Append(" TC.DISPLAYFORMAT,TC.DISPLAYLENGTH,TC.DISPLAYHEIGHT,");
                        _sb.Append(" TC.DISPLAYORDER,TC.CANDISPLAY,TC.COLWIDTH,");
                        _sb.Append(" TC.DWDM,TC.CTAG,TC.REFWORDTB,");
                        _sb.Append(" VTC.VTCID,VTC.CANCONDITIONSHOW,VTC.CANRESULTSHOW,");
                        _sb.Append(" VTC.DEFAULTSHOW,VTC.FIXQUERYITEM,VTC.CANMODIFY, ");
                        _sb.Append(" VTC.PRIORITY,VTC.DISPLAYORDER VTCORDER");
                        _sb.Append(" from MD_TABLECOLUMN TC,MD_VIEWTABLECOLUMN VTC where VTC.VTID = :VTID ");
                        _sb.Append(" and TC.TCID = VTC.TCID order by VTC.DISPLAYORDER,tc.displayorder");

                        OracleParameter[] _param = {
                                new OracleParameter(":VTID", OracleDbType.Decimal),
                        };
                        _param[0].Value = decimal.Parse(_vtid);

                        OracleDataReader dr = OracleHelper.ExecuteReader(OracleHelper.ConnectionStringProfile, CommandType.Text, _sb.ToString(), _param);

                        IList<MD_ViewTableColumn> nodeItems = new List<MD_ViewTableColumn>();

                        while (dr.Read())
                        {
                                decimal _dorder = (dr.IsDBNull(28) || (dr.GetDecimal(28) == 0)) ?
                                                (dr.IsDBNull(15) ? (decimal)0 : dr.GetDecimal(15)) : dr.GetDecimal(28);
                                //此处要做大的修改！分两步，先取ViewTableColumn的数据，再取TableColumn的数据

                                MD_ViewTableColumn nodeInfo = new MD_ViewTableColumn(
                                                dr.GetOracleDecimal(0).ToString(), dr.GetOracleDecimal(1).ToString(), dr.GetString(2),
                                                dr.IsDBNull(3) ? true : ((dr.GetString(3) == "Y") ? true : false),
                                                dr.GetString(4),
                                                dr.IsDBNull(5) ? 1 : Convert.ToInt32(dr.GetOracleDecimal(5).Value),
                                                dr.IsDBNull(6) ? 1 : Convert.ToInt32(dr.GetOracleDecimal(6).Value),
                                                dr.IsDBNull(7) ? 1 : Convert.ToInt32(dr.GetOracleDecimal(7).Value),
                                                dr.IsDBNull(8) ? "" : dr.GetString(8),
                                                dr.IsDBNull(9) ? "" : dr.GetString(9),
                                                dr.IsDBNull(10) ? 0 : Convert.ToInt32(dr.GetOracleDecimal(10).Value),
                                                dr.IsDBNull(11) ? "" : dr.GetString(11),
                                                dr.IsDBNull(12) ? "" : dr.GetString(12),
                                                dr.IsDBNull(13) ? 0 : Convert.ToInt32(dr.GetOracleDecimal(13).Value),
                                                dr.IsDBNull(14) ? 0 : Convert.ToInt32(dr.GetOracleDecimal(14).Value),
                                                Convert.ToInt32(_dorder),
                                                dr.IsDBNull(16) ? false : dr.GetOracleDecimal(16).Value > 0,
                                                dr.IsDBNull(17) ? 0 : Convert.ToInt32(dr.GetOracleDecimal(17).Value),
                                                dr.IsDBNull(18) ? "" : dr.GetString(18),
                                                dr.IsDBNull(19) ? "" : dr.GetString(19),
                                                dr.IsDBNull(20) ? "" : dr.GetString(20),
                                                dr.GetOracleDecimal(21).ToString(),
                                                dr.IsDBNull(22) ? false : dr.GetOracleDecimal(22).Value > 0,
                                                dr.IsDBNull(23) ? false : dr.GetOracleDecimal(23).Value > 0,
                                                dr.IsDBNull(24) ? false : dr.GetOracleDecimal(24).Value > 0,
                                                dr.IsDBNull(25) ? false : dr.GetOracleDecimal(25).Value > 0,
                                                dr.IsDBNull(26) ? false : dr.GetOracleDecimal(26).Value > 0,
                                                dr.IsDBNull(27) ? 0 : Convert.ToInt32(dr.GetOracleDecimal(27).Value)
                                                );
                                nodeItems.Add(nodeInfo);

                        }
                        dr.Close();
                    */
            #endregion


            return nodeItems;
        }


        public bool AddMainTableToQueryModel(string _queryModelID, MD_Table _selectedTable)
        {
            string InsertStr = "insert into MD_VIEWTABLE (VTID,VIEWID,TID,TABLETYPE,CANCONDITION,DISPLAYNAME,DWDM) VALUES ";
            InsertStr += "( sequences_meta.nextval,:VIEWID,:TID,'M',1,:DISPLAYNAME,:DWDM)";

            OracleParameter[] _param = {
                                new OracleParameter(":VIEWID", OracleDbType.Decimal),
                                new OracleParameter(":TID", OracleDbType.Decimal),
                                new OracleParameter(":DISPLAYNAME", OracleDbType.Varchar2,100),
                                new OracleParameter(":DWDM", OracleDbType.Varchar2,12),
                        };
            _param[0].Value = decimal.Parse(_queryModelID);
            _param[1].Value = decimal.Parse(_selectedTable.TID);
            _param[2].Value = _selectedTable.DisplayTitle;
            _param[3].Value = _selectedTable.DWDM;

            OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionStringProfile, CommandType.Text, InsertStr, _param);
            return true;
        }

        public bool AddChildTableToQueryModel(string _queryModelID, string _mainTableID, MD_Table _selectedTable)
        {
            string InsertStr = "insert into MD_VIEWTABLE (VTID,VIEWID,TID,TABLETYPE,CANCONDITION,DISPLAYNAME,DWDM,FATHERID) VALUES";
            InsertStr += " (sequences_meta.nextval,:VIEWID,:TID,'F',1,:DISPLAYNAME,:DWDM,:FATHERID)";
            OracleParameter[] _param = {
                                new OracleParameter(":VIEWID", OracleDbType.Decimal),
                                new OracleParameter(":TID", OracleDbType.Decimal),
                                new OracleParameter(":DISPLAYNAME", OracleDbType.Varchar2,100),
                                new OracleParameter(":DWDM", OracleDbType.Varchar2,12),
                                new OracleParameter(":FATHERID",OracleDbType.Decimal)
                        };
            _param[0].Value = decimal.Parse(_queryModelID);
            _param[1].Value = decimal.Parse(_selectedTable.TID);
            _param[2].Value = _selectedTable.DisplayTitle;
            _param[3].Value = _selectedTable.DWDM;
            _param[4].Value = decimal.Parse(_mainTableID);

            OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionStringProfile, CommandType.Text, InsertStr, _param);
            return true;


        }

        #endregion

        #region IMetaDataFactroy Members




        #endregion

        #region IMetaDataFactroy Members

        private const string SQL_GetDBColumnsOfTable = @"select col.column_name,COMM.COMMENTS,col.data_type,col.nullable,col.DATA_LENGTH,col.DATA_PRECISION 
                                                           from ALL_TAB_COLUMNS col,ALL_COL_COMMENTS comm where col.OWNER=:OWNER AND col.table_name = :TABLENAME
                                                           and col.table_name = comm.table_name and col.column_name = comm.column_name and col.owner = comm.owner";
        public IList<DB_ColumnMeta> GetDBColumnsOfTable(string _tableName)
        {
            string[] _names = _tableName.Split('.');

            OracleParameter[] _param = {
                                new OracleParameter(":OWNER", OracleDbType.Varchar2),
                                new OracleParameter(":TABLENAME",OracleDbType.Varchar2)
                        };

            if (_names.Length < 2)
            {
                _param[0].Value = GetConnectionUser();
                _param[1].Value = _names[0];
            }
            else
            {
                _param[0].Value = _names[0];
                _param[1].Value = _names[1];
            }
            OracleDataReader dr = OracleHelper.ExecuteReader(OracleHelper.ConnectionStringProfile, CommandType.Text, SQL_GetDBColumnsOfTable, _param);

            IList<DB_ColumnMeta> nodeItems = new List<DB_ColumnMeta>();

            while (dr.Read())
            {
                DB_ColumnMeta nodeInfo = new DB_ColumnMeta();

                nodeInfo.ColumnName = dr.IsDBNull(0) ? "" : dr.GetString(0);
                nodeInfo.Comments = dr.IsDBNull(1) ? "" : dr.GetString(1);
                nodeInfo.DataType = dr.IsDBNull(2) ? "" : dr.GetString(2);
                nodeInfo.Nullable = dr.IsDBNull(3) ? true : ((dr.GetString(3) == "Y") ? true : false);
                nodeInfo.DataLength = dr.IsDBNull(4) ? 0 : Convert.ToInt32(dr.GetOracleDecimal(4).Value);
                nodeInfo.DataPrecision = dr.IsDBNull(5) ? 0 : Convert.ToInt32(dr.GetOracleDecimal(5).Value);

                nodeItems.Add(nodeInfo);
            }
            dr.Close();

            return nodeItems;

        }

        private string GetConnectionUser()
        {
            string[] _ss = OracleHelper.ConnectionStringProfile.Split(';');
            foreach (string _s in _ss)
            {
                string[] _cs = _s.Split('=');
                if (_cs[0].ToUpper() == "USER ID" && _cs.Length > 1)
                {
                    return _cs[1];
                }
            }
            return "ZHTJ";
        }
        #endregion

        #region IMetaDataFactroy Members


        private const string SQL_GetNewID = @"SELECT sequences_meta.nextval FROM DUAL";
        public string GetNewID()
        {
            object _ret = OracleHelper.ExecuteScalar(OracleHelper.ConnectionStringProfile, CommandType.Text, SQL_GetNewID);
            return _ret.ToString();
        }

        #endregion

        #region IMetaDataFactroy Members

        private const string SQL_SaveTableDefine = @"update MD_TABLE SET NAMESPACE=:NAMESPACE,TABLENAME = :TABLENAME,TABLETYPE = :TABLETYPE,
                                                        DESCRIPTION = :DESCRIPTION,DISPLAYNAME = :DISPLAYNAME,DWDM = :DWDM,MAINKEY=:MAINKEY, 
                                                        SECRETFUN=:SECRETFUN,EXTSECRET=:EXTSECRET,RESTYPE=:RESTYPE
                                                        WHERE TID = :TID ";
        public bool SaveTableDefine(MD_Table _table)
        {
            OracleString[] _TCIDActions = null;
            //保存表定义信息
            OracleParameter[] _param = {
                                new OracleParameter(":NAMESPACE", OracleDbType.Varchar2, 50),
                                new OracleParameter(":TABLENAME", OracleDbType.Varchar2, 50),
                                new OracleParameter(":TABLETYPE", OracleDbType.Varchar2, 50),
                                new OracleParameter(":DESCRIPTION", OracleDbType.Varchar2, 100),
                                new OracleParameter(":DISPLAYNAME", OracleDbType.Varchar2, 100),
                                new OracleParameter(":DWDM", OracleDbType.Varchar2, 12),
                                new OracleParameter(":MAINKEY",OracleDbType.Varchar2,50),
                                new OracleParameter(":SECRETFUN",OracleDbType.Varchar2,50),
                                new OracleParameter(":EXTSECRET",OracleDbType.Varchar2,1000),
                                new OracleParameter(":RESTYPE",OracleDbType.Varchar2,100),
                                new OracleParameter(":TID",OracleDbType.Decimal)
                        };
            _param[0].Value = _table.NamespaceName;
            _param[1].Value = _table.TableName;
            _param[2].Value = _table.TableType;
            _param[3].Value = _table.Description;
            _param[4].Value = _table.DisplayTitle;
            _param[5].Value = _table.DWDM;
            _param[6].Value = _table.MainKey;
            _param[7].Value = _table.SecretFun;
            _param[8].Value = _table.ExtSecret;
            _param[9].Value = (_table.ResourceType == null) ? "" : string.Join(",", _table.ResourceType);
            _param[10].Value = Convert.ToDecimal(_table.TID);

            OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionStringProfile, CommandType.Text, SQL_SaveTableDefine, _param);

            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                //取所有TCID的状态,如果不需要的TCID,则删除
                OracleCommand cmd = new OracleCommand("begin ZHTJ_META.CheckTCID(:1, :2, :3); end;", cn);
                OracleParameter Param1 = cmd.Parameters.Add(new OracleParameter(":1", OracleDbType.Decimal));
                OracleParameter Param2 = cmd.Parameters.Add(new OracleParameter(":2", OracleDbType.Decimal));
                OracleParameter Param3 = cmd.Parameters.Add(new OracleParameter(":3", OracleDbType.Varchar2, 10));

                Param1.Direction = ParameterDirection.Input;
                Param2.Direction = ParameterDirection.Input;
                Param3.Direction = ParameterDirection.Output;

                // Specify that we are binding PL/SQL Associative Array                           
                Param2.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                Param3.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                Param1.Value = Convert.ToDecimal(_table.TID);
                decimal[] _tcItems = new decimal[_table.Columns.Count];
                int[] p2_bindSizes = new int[_table.Columns.Count];
                int[] p3_bindSizes = new int[_table.Columns.Count];
                for (int i = 0; i < _table.Columns.Count; i++)
                {
                    _tcItems[i] = decimal.Parse(_table.Columns[i].ColumnID);
                    p2_bindSizes[i] = 10;
                    p3_bindSizes[i] = 10;
                }

                Param2.Value = _tcItems;
                Param3.Value = null;

                Param2.Size = _table.Columns.Count;
                Param3.Size = _table.Columns.Count;

                Param2.ArrayBindSize = p2_bindSizes;
                Param3.ArrayBindSize = p3_bindSizes;
                cmd.ExecuteNonQuery();

                _TCIDActions = Param3.Value as OracleString[];

            }

            for (int i = 0; i < _table.Columns.Count; i++)
            {
                switch (_TCIDActions[i].ToString())
                {
                    case "UPDATE":
                        UpdateColumnDefine(_table, _table.Columns[i]);
                        break;
                    case "INSERT":
                        InsertColumnDefine(_table, _table.Columns[i]);
                        break;
                }
            }
            OraMetaDataQueryFactroy.ModelLib.Clear();
            return true;
        }

        private const string SQL_ImportTableDefine = @"insert into MD_TABLE
                                                       (NAMESPACE,TABLENAME,TABLETYPE,DESCRIPTION,
                                                        DISPLAYNAME,DWDM,MAINKEY,SECRETFUN,
                                                        EXTSECRET,TID ) VALUES
                                                        (:NAMESPACE,:TABLENAME,:TABLETYPE,:DESCRIPTION,
                                                        :DISPLAYNAME,:DWDM,:MAINKEY,:SECRETFUN, 
                                                        :EXTSECRET,:TID )";
        public bool ImportTableDefine(MD_Table _table)
        {
            try
            {
                OracleString[] _TCIDActions = null;
                //保存表定义信息

                using (OracleConnection cn = OracleHelper.OpenConnection())
                {
                    OracleTransaction _txn = cn.BeginTransaction();
                    OracleCommand _cmdInsert = new OracleCommand(SQL_ImportTableDefine, cn);
                    _cmdInsert.Parameters.Add(":NAMESPACE", _table.NamespaceName);
                    _cmdInsert.Parameters.Add(":TABLENAME", _table.TableName);
                    _cmdInsert.Parameters.Add(":TABLETYPE", _table.TableType);
                    _cmdInsert.Parameters.Add(":DESCRIPTION", _table.Description);
                    _cmdInsert.Parameters.Add(":DISPLAYNAME", _table.DisplayTitle);
                    _cmdInsert.Parameters.Add(":DWDM", _table.DWDM);
                    _cmdInsert.Parameters.Add(":MAINKEY", _table.MainKey);
                    _cmdInsert.Parameters.Add(":SECRETFUN", _table.SecretFun);
                    _cmdInsert.Parameters.Add(":EXTSECRET", _table.ExtSecret);
                    _cmdInsert.Parameters.Add(":TID", Convert.ToDecimal(_table.TID));
                    _cmdInsert.ExecuteNonQuery();
                    _txn.Commit();

                    _txn = cn.BeginTransaction();
                    //取所有TCID的状态,如果不需要的TCID,则删除
                    OracleCommand cmd = new OracleCommand("begin ZHTJ_META.CheckTCID(:1, :2, :3); end;", cn);
                    OracleParameter Param1 = cmd.Parameters.Add(new OracleParameter(":1", OracleDbType.Decimal));
                    OracleParameter Param2 = cmd.Parameters.Add(new OracleParameter(":2", OracleDbType.Decimal));
                    OracleParameter Param3 = cmd.Parameters.Add(new OracleParameter(":3", OracleDbType.Varchar2, 10));

                    Param1.Direction = ParameterDirection.Input;
                    Param2.Direction = ParameterDirection.Input;
                    Param3.Direction = ParameterDirection.Output;

                    // Specify that we are binding PL/SQL Associative Array                           
                    Param2.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    Param3.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

                    Param1.Value = Convert.ToDecimal(_table.TID);
                    decimal[] _tcItems = new decimal[_table.Columns.Count];
                    int[] p2_bindSizes = new int[_table.Columns.Count];
                    int[] p3_bindSizes = new int[_table.Columns.Count];
                    for (int i = 0; i < _table.Columns.Count; i++)
                    {
                        _tcItems[i] = decimal.Parse(_table.Columns[i].ColumnID);
                        p2_bindSizes[i] = 10;
                        p3_bindSizes[i] = 10;
                    }

                    Param2.Value = _tcItems;
                    Param3.Value = null;

                    Param2.Size = _table.Columns.Count;
                    Param3.Size = _table.Columns.Count;

                    Param2.ArrayBindSize = p2_bindSizes;
                    Param3.ArrayBindSize = p3_bindSizes;
                    cmd.ExecuteNonQuery();

                    _TCIDActions = Param3.Value as OracleString[];
                    _txn.Commit();

                }

                for (int i = 0; i < _table.Columns.Count; i++)
                {
                    switch (_TCIDActions[i].ToString())
                    {
                        case "UPDATE":
                            UpdateColumnDefine(_table, _table.Columns[i]);
                            break;
                        case "INSERT":
                            InsertColumnDefine(_table, _table.Columns[i]);
                            break;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                OralceLogWriter.WriteSystemLog(string.Format("导入表{0}的元数据失败!错误信息：{1}", _table.TableName, ex.Message), "ERROR");
                return false;
            }
        }


        private void UpdateColumnDefine(MD_Table _table, MD_TableColumn _tc)
        {
            StringBuilder _sb = new StringBuilder();
            _sb.Append(" update MD_TABLECOLUMN  set TID=:TID,COLUMNNAME=:COLUMNNAME,");
            _sb.Append(" ISNULLABLE=:ISNULLABLE,TYPE=:TYPE,PRECISION=:PRECISION,SCALE=:SCALE,");
            _sb.Append(" LENGTH=:LENGTH,REFDMB=:REFDMB,DMBLEVELFORMAT=:DMBLEVELFORMAT,SECRETLEVEL=:SECRETLEVEL,");
            _sb.Append(" DISPLAYTITLE=:DISPLAYTITLE,DISPLAYFORMAT=:DISPLAYFORMAT,DISPLAYLENGTH=:DISPLAYLENGTH,DISPLAYHEIGHT=:DISPLAYHEIGHT,");
            _sb.Append(" DISPLAYORDER=:DISPLAYORDER,CANDISPLAY=:CANDISPLAY,COLWIDTH=:COLWIDTH,DWDM=:DWDM,");
            _sb.Append(" CTAG=:CTAG,REFWORDTB=:REFWORD ");
            _sb.Append(" WHERE TCID=:TCID");

            OracleParameter[] _param3 = {                                        
                                        new OracleParameter(":TID", OracleDbType.Decimal),
                                        new OracleParameter(":COLUMNNAME", OracleDbType.Varchar2, 50),
                                        new OracleParameter(":ISNULLABLE", OracleDbType.Varchar2, 100),
                                        new OracleParameter(":TYPE", OracleDbType.Varchar2, 20),
                                        new OracleParameter(":PRECISION", OracleDbType.Decimal),
                                        new OracleParameter(":SCALE",OracleDbType.Decimal),
                                        new OracleParameter(":LENGTH",OracleDbType.Decimal),
                                        new OracleParameter(":REFDMB",OracleDbType.Varchar2,50),
                                        new OracleParameter(":DMBLEVELFORMAT",OracleDbType.Varchar2,20),
                                        new OracleParameter(":SECRETLEVEL", OracleDbType.Decimal),
                                        new OracleParameter(":DISPLAYTITLE", OracleDbType.Varchar2, 50),
                                        new OracleParameter(":DISPLAYFORMAT", OracleDbType.Varchar2, 50),
                                        new OracleParameter(":DISPLAYLENGTH", OracleDbType.Decimal),
                                        new OracleParameter(":DISPLAYHEIGHT", OracleDbType.Decimal),
                                        new OracleParameter(":DISPLAYORDER", OracleDbType.Decimal),
                                        new OracleParameter(":CANDISPLAY",OracleDbType.Decimal),
                                        new OracleParameter(":COLWIDTH",OracleDbType.Decimal),
                                        new OracleParameter(":DWDM",OracleDbType.Varchar2,20),
                                        new OracleParameter(":CTAG",OracleDbType.Varchar2,500),
                                        new OracleParameter(":REFWORDTB",OracleDbType.Varchar2,50),
                                        new OracleParameter(":TCID", OracleDbType.Decimal)
                                };

            _param3[0].Value = Convert.ToDecimal(_table.TID);
            _param3[1].Value = _tc.ColumnName;
            _param3[2].Value = _tc.IsNullable ? "Y" : "N";
            _param3[3].Value = _tc.ColumnType;
            _param3[4].Value = Convert.ToDecimal(_tc.Precision);
            _param3[5].Value = Convert.ToDecimal(_tc.Scale);
            _param3[6].Value = Convert.ToDecimal(_tc.Length);
            _param3[7].Value = _tc.RefDMB;
            _param3[8].Value = _tc.DMBLevelFormat;

            _param3[9].Value = Convert.ToDecimal(_tc.SecretLevel);
            _param3[10].Value = _tc.DisplayTitle;
            _param3[11].Value = _tc.DisplayFormat;
            _param3[12].Value = Convert.ToDecimal(_tc.DisplayLength);
            _param3[13].Value = Convert.ToDecimal(_tc.DisplayHeight);
            _param3[14].Value = Convert.ToDecimal(_tc.DisplayOrder);
            _param3[15].Value = _tc.CanDisplay ? 1 : 0;
            _param3[16].Value = Convert.ToDecimal(_tc.ColWidth);
            _param3[17].Value = _tc.DWDM;
            _param3[18].Value = _tc.CTag;
            _param3[19].Value = _tc.RefWordTableName;
            _param3[20].Value = Convert.ToDecimal(_tc.ColumnID);

            OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionStringProfile, CommandType.Text, _sb.ToString(), _param3);
            OraMetaDataQueryFactroy.ModelLib.Clear();
        }

        private void InsertColumnDefine(MD_Table _table, MD_TableColumn _tc)
        {
            StringBuilder _sb_insert = new StringBuilder();
            _sb_insert.Append(" insert into MD_TABLECOLUMN (TCID,TID,COLUMNNAME,");
            _sb_insert.Append(" ISNULLABLE,TYPE,PRECISION,SCALE,");
            _sb_insert.Append(" LENGTH,REFDMB,DMBLEVELFORMAT,SECRETLEVEL,");
            _sb_insert.Append(" DISPLAYTITLE,DISPLAYFORMAT,DISPLAYLENGTH,DISPLAYHEIGHT,");
            _sb_insert.Append(" DISPLAYORDER,CANDISPLAY,COLWIDTH,DWDM,");
            _sb_insert.Append(" CTAG,REFWORDTB ) values ");
            _sb_insert.Append(" (:TCID,:TID,:COLUMNNAME,");
            _sb_insert.Append(" :ISNULLABLE,:TYPE,:PRECISION,:SCALE,");
            _sb_insert.Append(" :LENGTH,:REFDMB,:DMBLEVELFORMAT,:SECRETLEVEL,");
            _sb_insert.Append(" :DISPLAYTITLE,:DISPLAYFORMAT,:DISPLAYLENGTH,:DISPLAYHEIGHT,");
            _sb_insert.Append(" :DISPLAYORDER,:CANDISPLAY,:COLWIDTH,:DWDM,");
            _sb_insert.Append(" :CTAG,:REFWORDTB)  ");

            OracleParameter[] _param3 = {
                                        new OracleParameter(":TCID", OracleDbType.Decimal),
                                        new OracleParameter(":TID", OracleDbType.Decimal),
                                        new OracleParameter(":COLUMNNAME", OracleDbType.Varchar2, 50),
                                        new OracleParameter(":ISNULLABLE", OracleDbType.Varchar2, 100),
                                        new OracleParameter(":TYPE", OracleDbType.Varchar2, 20),
                                        new OracleParameter(":PRECISION", OracleDbType.Decimal),
                                        new OracleParameter(":SCALE",OracleDbType.Decimal),
                                        new OracleParameter(":LENGTH",OracleDbType.Decimal),
                                        new OracleParameter(":REFDMB",OracleDbType.Varchar2,50),
                                        new OracleParameter(":DMBLEVELFORMAT",OracleDbType.Varchar2,20),
                                        new OracleParameter(":SECRETLEVEL", OracleDbType.Decimal),
                                        new OracleParameter(":DISPLAYTITLE", OracleDbType.Varchar2, 50),
                                        new OracleParameter(":DISPLAYFORMAT", OracleDbType.Varchar2, 50),
                                        new OracleParameter(":DISPLAYLENGTH", OracleDbType.Decimal),
                                        new OracleParameter(":DISPLAYHEIGHT", OracleDbType.Decimal),
                                        new OracleParameter(":DISPLAYORDER", OracleDbType.Decimal),
                                        new OracleParameter(":CANDISPLAY",OracleDbType.Decimal),
                                        new OracleParameter(":COLWIDTH",OracleDbType.Decimal),
                                        new OracleParameter(":DWDM",OracleDbType.Varchar2,20),
                                        new OracleParameter(":CTAG",OracleDbType.Varchar2,500),
                                        new OracleParameter(":REFWORDTB",OracleDbType.Varchar2,50)
                        };
            _param3[0].Value = Convert.ToDecimal(_tc.ColumnID);
            _param3[1].Value = Convert.ToDecimal(_table.TID);
            _param3[2].Value = _tc.ColumnName;
            _param3[3].Value = _tc.IsNullable ? "Y" : "N";
            _param3[4].Value = _tc.ColumnType;
            _param3[5].Value = Convert.ToDecimal(_tc.Precision);
            _param3[6].Value = Convert.ToDecimal(_tc.Scale);
            _param3[7].Value = Convert.ToDecimal(_tc.Length);
            _param3[8].Value = _tc.RefDMB;
            _param3[9].Value = _tc.DMBLevelFormat;

            _param3[10].Value = Convert.ToDecimal(_tc.SecretLevel);
            _param3[11].Value = _tc.DisplayTitle;
            _param3[12].Value = _tc.DisplayFormat;
            _param3[13].Value = Convert.ToDecimal(_tc.DisplayLength);
            _param3[14].Value = Convert.ToDecimal(_tc.DisplayHeight);
            _param3[15].Value = Convert.ToDecimal(_tc.DisplayOrder);
            _param3[16].Value = _tc.CanDisplay ? 1 : 0;
            _param3[17].Value = Convert.ToDecimal(_tc.ColWidth);
            _param3[18].Value = _tc.DWDM;
            _param3[19].Value = _tc.CTag;
            _param3[20].Value = _tc.RefWordTableName;


            OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionStringProfile, CommandType.Text, _sb_insert.ToString(), _param3);

            OraMetaDataQueryFactroy.ModelLib.Clear();
        }


        #endregion

        #region IMetaDataFactroy Members

        public bool SaveNewQueryModel(MD_QueryModel _queryModel)
        {
            //保存查询模型定义信息
            StringBuilder _sb = new StringBuilder();
            _sb.Append(" insert into MD_VIEW (");
            _sb.Append(" VIEWID,VIEWNAME,DESCRIPTION,DISPLAYNAME, ");
            _sb.Append(" DWDM,IS_GDCX,IS_GLCX,IS_SJSH,");
            _sb.Append(" DISPLAYORDER,NAMESPACE,EXTMETA )");
            _sb.Append(" values ( ");
            _sb.Append("  sequences_meta.nextval,:VIEWNAME,:DESCRIPTION,:DISPLAYNAME, ");
            _sb.Append(" :DWDM,:IS_GDCX,:IS_GLCX,:IS_SJSH,");
            _sb.Append(" :DISPLAYORDER,:NAMESPACE,:EXTMETA)");

            OracleParameter[] _param = {                                
                                new OracleParameter(":VIEWNAME", OracleDbType.Varchar2, 50),
                                new OracleParameter(":DESCRIPTION", OracleDbType.Varchar2, 100),
                                new OracleParameter(":DISPLAYNAME", OracleDbType.Varchar2, 100),
                                new OracleParameter(":DWDM", OracleDbType.Varchar2, 12),
                                new OracleParameter(":IS_GDCX", OracleDbType.Decimal),
                                new OracleParameter(":IS_GLCX",OracleDbType.Decimal),
                                new OracleParameter(":IS_SJSH",OracleDbType.Decimal),
                                new OracleParameter(":DISPLAYORDER",OracleDbType.Decimal),
                                new OracleParameter(":NAMESPACE",OracleDbType.Varchar2,50),
                                 new OracleParameter(":EXTMETA",OracleDbType.Varchar2,4000)
                        };

            _param[0].Value = _queryModel.QueryModelName;
            _param[1].Value = _queryModel.Description;
            _param[2].Value = _queryModel.DisplayTitle;
            _param[3].Value = _queryModel.DWDM;
            _param[4].Value = _queryModel.IsFixQuery ? (decimal)1 : (decimal)0;
            _param[5].Value = _queryModel.IsRelationQuery ? (decimal)1 : (decimal)0;
            _param[6].Value = _queryModel.IsDataAuditing ? (decimal)1 : (decimal)0;
            _param[7].Value = Convert.ToDecimal(_queryModel.DisplayOrder);
            _param[8].Value = _queryModel.NamespaceName;
            _param[9].Value = _queryModel.EXTMeta;

            OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionStringProfile, CommandType.Text, _sb.ToString(), _param);

            OraMetaDataQueryFactroy.ModelLib.Clear();

            return true;

        }


        public bool SaveQueryModel(MD_QueryModel _queryModel)
        {
            //保存查询模型定义信息
            StringBuilder _sb = new StringBuilder();
            _sb.Append(" update MD_VIEW SET VIEWNAME = :VIEWNAME,DESCRIPTION = :DESCRIPTION,");
            _sb.Append(" DISPLAYNAME = :DISPLAYNAME,DWDM = :DWDM,IS_GDCX = :IS_GDCX,IS_GLCX=:IS_GLCX, ");
            _sb.Append(" IS_SJSH=:IS_SJSH,DISPLAYORDER=:DISPLAYORDER,ICSTYPE=:ICSTYPE,EXTMETA=:EXTMETA ");
            _sb.Append(" WHERE VIEWID = :VIEWID ");
            OracleParameter[] _param = {                                
                                new OracleParameter(":VIEWNAME", OracleDbType.Varchar2, 50),
                                new OracleParameter(":DESCRIPTION", OracleDbType.Varchar2, 100),
                                new OracleParameter(":DISPLAYNAME", OracleDbType.Varchar2, 100),
                                new OracleParameter(":DWDM", OracleDbType.Varchar2, 12),
                                new OracleParameter(":IS_GDCX", OracleDbType.Decimal),
                                new OracleParameter(":IS_GLCX",OracleDbType.Decimal),
                                new OracleParameter(":IS_SJSH",OracleDbType.Decimal),
                                new OracleParameter(":DISPLAYORDER",OracleDbType.Decimal),
                                new OracleParameter(":ICSTYPE", OracleDbType.Varchar2, 20),
                                new OracleParameter(":EXTMETA", OracleDbType.Varchar2, 4000),
                                new OracleParameter(":VIEWID",OracleDbType.Decimal)
                        };

            _param[0].Value = _queryModel.QueryModelName;
            _param[1].Value = _queryModel.Description;
            _param[2].Value = _queryModel.DisplayTitle;
            _param[3].Value = _queryModel.DWDM;
            _param[4].Value = _queryModel.IsFixQuery ? 1 : 0;
            _param[5].Value = _queryModel.IsRelationQuery ? 1 : 0;
            _param[6].Value = _queryModel.IsDataAuditing ? 1 : 0;
            _param[7].Value = Convert.ToDecimal(_queryModel.DisplayOrder);
            _param[8].Value = _queryModel.QueryInterface;
            _param[9].Value = _queryModel.EXTMeta;
            _param[10].Value = Convert.ToDecimal(_queryModel.QueryModelID);

            OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionStringProfile, CommandType.Text, _sb.ToString(), _param);
            OraMetaDataQueryFactroy.ModelLib.Clear();
            return true;
        }


        private const string SQL_Insert_MD_View2ViewGroup = @"insert into MD_VIEW2VIEWGROUP (ID,VIEWID,DISPLAYORDER,DISPLAYTITLE) values (:ID,:VIEWID,:DISPLAYORDER,:DISPLAYTITLE)";
        private const string SQL_Insert_MD_View2View = @"insert into MD_VIEW2VIEW (ID,VIEWID,TARGETVIEWNAME,RELATIONSTR,DISPLAYORDER,DISPLAYTITLE,GROUPID)
                                                                                                values (:ID,:VIEWID,:TARGETVIEWNAME,:RELATIONSTR,:DISPLAYORDER,:DISPLAYTITLE,:GROUPID)";

        public bool ImportQueryModelDefine(MD_QueryModel _qv)
        {
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                OracleTransaction txn = cn.BeginTransaction();
                try
                {
                    #region  保存查询模型定义信息
                    StringBuilder _sb = new StringBuilder();
                    _sb.Append(" insert into MD_VIEW (");
                    _sb.Append(" VIEWNAME,DESCRIPTION,DISPLAYNAME, ");
                    _sb.Append(" DWDM,IS_GDCX,IS_GLCX,IS_SJSH,");
                    _sb.Append(" DISPLAYORDER,NAMESPACE,VIEWID,EXTMETA )");
                    _sb.Append(" values ( ");
                    _sb.Append(" :VIEWNAME,:DESCRIPTION,:DISPLAYNAME, ");
                    _sb.Append(" :DWDM,:IS_GDCX,:IS_GLCX,:IS_SJSH,");
                    _sb.Append(" :DISPLAYORDER,:NAMESPACE,:VIEWID,:EXTMETA)");

                    OracleParameter[] _param = {
                                                        new OracleParameter(":VIEWNAME", OracleDbType.Varchar2, 50),
                                                        new OracleParameter(":DESCRIPTION", OracleDbType.Varchar2, 100),
                                                        new OracleParameter(":DISPLAYNAME", OracleDbType.Varchar2, 100),
                                                        new OracleParameter(":DWDM", OracleDbType.Varchar2, 12),
                                                        new OracleParameter(":IS_GDCX", OracleDbType.Decimal),
                                                        new OracleParameter(":IS_GLCX",OracleDbType.Decimal),
                                                        new OracleParameter(":IS_SJSH",OracleDbType.Decimal),
                                                        new OracleParameter(":DISPLAYORDER",OracleDbType.Decimal),
                                                        new OracleParameter(":NAMESPACE",OracleDbType.Varchar2,50),
                                                        new OracleParameter(":VIEWID",OracleDbType.Decimal),
                                                        new OracleParameter(":EXTMETA",OracleDbType.Varchar2,4000),
                                                };

                    _param[0].Value = _qv.QueryModelName;
                    _param[1].Value = _qv.Description;
                    _param[2].Value = _qv.DisplayTitle;
                    _param[3].Value = _qv.DWDM;
                    _param[4].Value = _qv.IsFixQuery ? (decimal)1 : (decimal)0;
                    _param[5].Value = _qv.IsRelationQuery ? (decimal)1 : (decimal)0;
                    _param[6].Value = _qv.IsDataAuditing ? (decimal)1 : (decimal)0;
                    _param[7].Value = Convert.ToDecimal(_qv.DisplayOrder);
                    _param[8].Value = _qv.NamespaceName;
                    _param[9].Value = Convert.ToDecimal(_qv.QueryModelID);
                    _param[10].Value = _qv.EXTMeta;
                    OracleHelper.ExecuteNonQuery(cn, CommandType.Text, _sb.ToString(), _param);
                    #endregion

                    #region 导入子表定义
                    foreach (MD_ViewTable _vtable in _qv.ChildTables)
                    {
                        if (_vtable != null)
                        {

                            _sb = new StringBuilder();
                            _sb.Append(" insert into MD_VIEWTABLE ");
                            _sb.Append(" (VTID,FATHERID,VIEWID,TID,");
                            _sb.Append(" TABLETYPE,TABLERELATION,CANCONDITION,DISPLAYNAME,");
                            _sb.Append(" DISPLAYORDER,DWDM,PRIORITY) ");
                            _sb.Append(" values ");
                            _sb.Append(" (:VTID,:FATHERID,:VIEWID,:TID,");
                            _sb.Append(" :TABLETYPE,:TABLERELATION,:CANCONDITION,:DISPLAYNAME,");
                            _sb.Append(" :DISPLAYORDER,:DWDM,:PRIORITY) ");

                            OracleParameter[] _param5 = {            
                                                                                new OracleParameter(":VTID",OracleDbType.Decimal),
                                                                                new OracleParameter(":FATHERID",OracleDbType.Decimal),
                                                                                new OracleParameter(":VIEWID",OracleDbType.Decimal),
                                                                                new OracleParameter(":TID",OracleDbType.Decimal),
                                                                                 new OracleParameter(":TABLETYPE",OracleDbType.Varchar2,20),                                        
                                                                                new OracleParameter(":TABLERELATION",OracleDbType.Varchar2,300),
                                                                                new OracleParameter(":CANCONDITION",OracleDbType.Varchar2,10),
                                                                                new OracleParameter(":DISPLAYNAME",OracleDbType.Varchar2,100),
                                                                                new OracleParameter(":DISPLAYORDER",OracleDbType.Decimal),
                                                                                new OracleParameter(":DWDM",OracleDbType.Varchar2,12),
                                                                                new OracleParameter(":PRIORITY",OracleDbType.Decimal)
                                                                                 };
                            _param5[0].Value = Convert.ToDecimal(_vtable.ViewTableID);
                            if (_vtable.FatherTableID == "")
                            {
                                _param5[1].Value = DBNull.Value;
                            }
                            else
                            {
                                _param5[1].Value = Convert.ToDecimal(_vtable.FatherTableID);
                            }
                            _param5[2].Value = Convert.ToDecimal(_qv.QueryModelID);
                            _param5[3].Value = Convert.ToDecimal(_vtable.TableID);

                            _param5[4].Value = (_vtable.ViewTableType == MDType_ViewTable.MainTable) ? "M" : "F";
                            _param5[5].Value = _vtable.RelationString;
                            _param5[6].Value = (_vtable.ViewTableRelationType == MDType_ViewTableRelation.SingleChildRecord) ? 1 : 0;
                            _param5[7].Value = _vtable.DisplayTitle;
                            _param5[8].Value = Convert.ToDecimal(_vtable.DisplayOrder);
                            _param5[9].Value = _vtable.DWDM;
                            _param5[10].Value = (decimal)0;

                            OracleHelper.ExecuteNonQuery(cn, CommandType.Text, _sb.ToString(), _param5);

                            //清除所有字段定义
                            string _del = "delete from MD_VIEWTABLECOLUMN where VTID=:VTID";
                            OracleParameter[] _param2 = {
						                        new OracleParameter(":VTID",OracleDbType.Decimal)
					                         };
                            _param2[0].Value = Convert.ToDecimal(_vtable.ViewTableID);
                            OracleHelper.ExecuteNonQuery(cn, CommandType.Text, _del, _param2);

                            _sb = new StringBuilder();
                            _sb.Append(" insert into MD_VIEWTABLECOLUMN (VTCID,VTID,TCID,");
                            _sb.Append(" CANCONDITIONSHOW,CANRESULTSHOW,DEFAULTSHOW,");
                            _sb.Append(" DWDM,FIXQUERYITEM,CANMODIFY,PRIORITY) ");
                            _sb.Append(" VALUES (:VTCID,:VTID,:TCID,");
                            _sb.Append(" :CANCONDITIONSHOW,:CANRESULTSHOW,:DEFAULTSHOW,");
                            _sb.Append(" :DWDM,:FIXQUERYITEM,:CANMODIFY,:PRIORITY) ");
                            //保存字段定义信息
                            foreach (MD_ViewTableColumn _tc in _vtable.Columns)
                            {
                                OracleParameter[] _param3 = {
                                                                        new OracleParameter(":VTCID", OracleDbType.Decimal),
                                                                        new OracleParameter(":VTID", OracleDbType.Decimal),
                                                                        new OracleParameter(":TCID", OracleDbType.Decimal),
                                                                        new OracleParameter(":CANCONDITIONSHOW", OracleDbType.Decimal),
                                                                        new OracleParameter(":CANRESULTSHOW", OracleDbType.Decimal),
                                                                        new OracleParameter(":DEFAULTSHOW", OracleDbType.Decimal),
                                                                        new OracleParameter(":DWDM",OracleDbType.Varchar2,12),
                                                                        new OracleParameter(":FIXQUERYITEM",OracleDbType.Decimal),
                                                                        new OracleParameter(":CANMODIFY",OracleDbType.Decimal),
                                                                        new OracleParameter(":PRIORITY",OracleDbType.Decimal)
                                                                };
                                _param3[0].Value = Convert.ToDecimal(_tc.ViewTableColumnID);
                                _param3[1].Value = Convert.ToDecimal(_vtable.ViewTableID);
                                _param3[2].Value = Convert.ToDecimal(_tc.ColumnID);
                                _param3[3].Value = _tc.CanShowAsCondition ? 1 : 0;
                                _param3[4].Value = _tc.CanShowAsResult ? 1 : 0;
                                _param3[5].Value = _tc.DefaultResult ? 1 : 0;
                                _param3[6].Value = _tc.DWDM;
                                _param3[7].Value = _tc.IsFixQueryItem ? 1 : 0;
                                _param3[8].Value = _tc.CanModify ? 1 : 0;
                                _param3[9].Value = Convert.ToDecimal(_tc.Priority);
                                OracleHelper.ExecuteNonQuery(cn, CommandType.Text, _sb.ToString(), _param3);
                            }
                        }

                    }
                    #endregion

                    #region 导入模型关联定义
                    if (_qv.View2ViewGroup != null)
                    {
                        foreach (MD_View2ViewGroup _group in _qv.View2ViewGroup)
                        {
                            OracleParameter[] _pv2vg = {
                                                                        new OracleParameter(":ID", OracleDbType.Varchar2, 50),
                                                                        new OracleParameter(":VIEWID", OracleDbType.Decimal),
                                                                        new OracleParameter(":DISPLAYORDER", OracleDbType.Decimal),
                                                                        new OracleParameter(":DISPLAYTITLE", OracleDbType.Varchar2, 200)                                                    
                                                                };
                            _pv2vg[0].Value = _group.ID;
                            _pv2vg[1].Value = Convert.ToDecimal(_qv.QueryModelID);
                            _pv2vg[2].Value = Convert.ToDecimal(_group.DisplayOrder);
                            _pv2vg[3].Value = _group.DisplayTitle;
                            OracleHelper.ExecuteNonQuery(cn, CommandType.Text, SQL_Insert_MD_View2ViewGroup, _pv2vg);

                            foreach (MD_View2View _v2v in _group.View2Views)
                            {
                                OracleParameter[] _pv2v = {
                                                                        new OracleParameter(":ID", OracleDbType.Varchar2, 50),
                                                                        new OracleParameter(":VIEWID", OracleDbType.Decimal),
                                                                        new OracleParameter(":TARGETVIEWNAME", OracleDbType.Varchar2,300),
                                                                        new OracleParameter(":RELATIONSTR", OracleDbType.Varchar2,4000),
                                                                        new OracleParameter(":DISPLAYORDER", OracleDbType.Decimal),
                                                                        new OracleParameter(":DISPLAYTITLE", OracleDbType.Varchar2, 200),
                                                                        new OracleParameter(":GROUPID", OracleDbType.Varchar2, 50)
                                                                };
                                _pv2v[0].Value = _v2v.ID;
                                _pv2v[1].Value = Convert.ToDecimal(_qv.QueryModelID);
                                _pv2v[2].Value = _v2v.TargetViewName;
                                _pv2v[3].Value = _v2v.RelationString;
                                _pv2v[4].Value = Convert.ToDecimal(_v2v.DisplayOrder);
                                _pv2v[5].Value = _v2v.DisplayTitle;
                                _pv2v[6].Value = _group.ID;
                                OracleHelper.ExecuteNonQuery(cn, CommandType.Text, SQL_Insert_MD_View2View, _pv2v);
                            }
                        }
                    }
                    #endregion

                    #region 导入关联指标定义
                    if (_qv.View2GuideLines != null)
                    {
                        foreach (MD_View_GuideLine _v2g in _qv.View2GuideLines)
                        {
                            OracleCommand SaveCmd = new OracleCommand(SQL_InsertV2G, cn);
                            SaveCmd.Parameters.Add(":ID", _v2g.ID);
                            SaveCmd.Parameters.Add(":VIEWID", _v2g.ViewID);
                            SaveCmd.Parameters.Add(":TARGETGL", _v2g.TargetGuideLineID);
                            SaveCmd.Parameters.Add(":TARGETCS", _v2g.RelationParam);
                            SaveCmd.Parameters.Add(":DISPLAYORDER", Convert.ToDecimal(_v2g.DisplayOrder));
                            SaveCmd.Parameters.Add(":DISPLAYTITLE", _v2g.DisplayTitle);
                            SaveCmd.ExecuteNonQuery();
                        }

                    }
                    #endregion

                    #region 导入关联集成应用定义
                    if (_qv.View2Application != null)
                    {
                        foreach (MD_View2App _v2a in _qv.View2Application)
                        {
                            OracleCommand _ins = new OracleCommand(SQL_SaveView2App_Insert, cn);
                            _ins.Parameters.Add(":ID", decimal.Parse(_v2a.ID));
                            _ins.Parameters.Add(":VIEWID", decimal.Parse(_v2a.ViewID));
                            _ins.Parameters.Add(":TITLE", _v2a.Title);
                            _ins.Parameters.Add(":INTEGRATEDAPP", _v2a.AppName);
                            _ins.Parameters.Add(":DISPLAYHEIGHT", Convert.ToDecimal(_v2a.DisplayHeight));
                            _ins.Parameters.Add(":URL", _v2a.RegURL);
                            _ins.Parameters.Add(":DISPLAYORDER", Convert.ToDecimal(_v2a.DisplayOrder));
                            _ins.Parameters.Add(":META", _v2a.Meta);
                            _ins.ExecuteNonQuery();

                        }
                    }
                    #endregion

                    txn.Commit();
                    return true;

                }
                catch (Exception ex)
                {
                    txn.Rollback();
                    return false;
                }
            }


        }


        #endregion

        #region IMetaDataFactroy Members


        private const string SQL_SaveViewMainTable_Update = @" update MD_VIEWTABLE SET DISPLAYNAME=:DISPLAYNAME,INTEGRATEDAPP=:INTEGRATEDAPP
                                                                WHERE VTID = :VTID";
        private const string SQL_SaveViewMainTable_Delete = @"delete from MD_VIEWTABLECOLUMN where VTID=:VTID";
        private const string SQL_SaveViewMainTable_Insert = @"insert into MD_VIEWTABLECOLUMN (VTCID,VTID,TCID,
                                                                    CANCONDITIONSHOW,CANRESULTSHOW,DEFAULTSHOW,
                                                                    DWDM,FIXQUERYITEM,CANMODIFY,PRIORITY,DISPLAYORDER)
                                                                    VALUES (:VTCID,:VTID,:TCID,
                                                                    :CANCONDITIONSHOW,:CANRESULTSHOW,:DEFAULTSHOW,
                                                                    :DWDM,:FIXQUERYITEM,:CANMODIFY,:PRIORITY,:DISPLAYORDER)";
        /// <summary>
        /// 保存主表定义信息
        /// </summary>
        /// <param name="_viewtable"></param>
        /// <returns></returns>
        public bool SaveViewMainTable(MD_ViewTable _viewtable)
        {
            OracleParameter[] _param = {            
                                new OracleParameter(":DISPLAYNAME",OracleDbType.Varchar2,100),
                                new OracleParameter(":INTEGRATEDAPP",OracleDbType.Varchar2,1000),
                                new OracleParameter(":VTID",OracleDbType.Decimal)
                        };
            _param[0].Value = _viewtable.DisplayTitle;
            _param[1].Value = _viewtable.IntegratedApp;
            _param[2].Value = Convert.ToDecimal(_viewtable.ViewTableID);

            OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionStringProfile, CommandType.Text, SQL_SaveViewMainTable_Update, _param);

            //清除所有字段定义
            OracleParameter[] _param2 = {
                               new OracleParameter(":VTID",OracleDbType.Decimal)
                        };
            _param2[0].Value = Convert.ToDecimal(_viewtable.ViewTableID);
            OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionStringProfile, CommandType.Text, SQL_SaveViewMainTable_Delete, _param2);


            //保存字段定义信息
            foreach (MD_ViewTableColumn _tc in _viewtable.Columns)
            {
                OracleParameter[] _param3 = {
                                        new OracleParameter(":VTCID", OracleDbType.Decimal),
                                        new OracleParameter(":VTID", OracleDbType.Decimal),
                                        new OracleParameter(":TCID", OracleDbType.Decimal),
                                        new OracleParameter(":CANCONDITIONSHOW", OracleDbType.Decimal),
                                        new OracleParameter(":CANRESULTSHOW", OracleDbType.Decimal),
                                        new OracleParameter(":DEFAULTSHOW", OracleDbType.Decimal),
                                        new OracleParameter(":DWDM",OracleDbType.Varchar2,12),
                                        new OracleParameter(":FIXQUERYITEM",OracleDbType.Decimal),
                                        new OracleParameter(":CANMODIFY",OracleDbType.Decimal),
                                        new OracleParameter(":PRIORITY",OracleDbType.Decimal),
                                        new OracleParameter(":DISPLAYORDER",OracleDbType.Decimal)
                                };
                _param3[0].Value = Convert.ToDecimal(_tc.ViewTableColumnID);
                _param3[1].Value = Convert.ToDecimal(_viewtable.ViewTableID);
                _param3[2].Value = Convert.ToDecimal(_tc.ColumnID);
                _param3[3].Value = _tc.CanShowAsCondition ? 1 : 0;
                _param3[4].Value = _tc.CanShowAsResult ? 1 : 0;
                _param3[5].Value = _tc.DefaultResult ? 1 : 0;
                _param3[6].Value = _tc.DWDM;
                _param3[7].Value = _tc.IsFixQueryItem ? 1 : 0;
                _param3[8].Value = _tc.CanModify ? 1 : 0;
                _param3[9].Value = Convert.ToDecimal(_tc.Priority);
                _param3[10].Value = Convert.ToDecimal(_tc.DisplayOrder);
                OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionStringProfile, CommandType.Text, SQL_SaveViewMainTable_Insert, _param3);
            }
            OraMetaDataQueryFactroy.ModelLib.Clear();
            return true;
        }



        #endregion

        #region IMetaDataFactroy Members

        private const string SQL_GetChildTableOfQueryModel = @"select VTID,VIEWID,TID,TABLETYPE,TABLERELATION,CANCONDITION,DISPLAYNAME,DISPLAYORDER,DWDM,
                                                                FATHERID,PRIORITY,DISPLAYTYPE,INTEGRATEDAPP from MD_VIEWTABLE where VIEWID = :VID and TABLETYPE = 'F' order by DISPLAYORDER";
        public IList<MD_ViewTable> GetChildTableOfQueryModel(string QueryModelID)
        {
            IList<MD_ViewTable> _ret = new List<MD_ViewTable>();

            OracleParameter[] _param = {
                                new OracleParameter(":VID", OracleDbType.Decimal),
                        };
            _param[0].Value = decimal.Parse(QueryModelID);

            OracleDataReader dr = OracleHelper.ExecuteReader(OracleHelper.ConnectionStringProfile, CommandType.Text, SQL_GetChildTableOfQueryModel, _param);

            while (dr.Read())
            {
                MD_ViewTable _vt = new MD_ViewTable(dr.GetOracleDecimal(0).ToString(),
                                dr.GetOracleDecimal(1).ToString(),
                                dr.GetOracleDecimal(2).ToString(),
                                dr.IsDBNull(3) ? "M" : dr.GetString(3),
                                dr.IsDBNull(4) ? "" : dr.GetString(4),
                                dr.IsDBNull(5) ? "" : dr.GetString(5),
                                dr.IsDBNull(6) ? "" : dr.GetString(6),
                                dr.IsDBNull(7) ? 0 : Convert.ToInt32(dr.GetOracleDecimal(7).Value),
                                dr.IsDBNull(8) ? "" : dr.GetString(8),
                                dr.IsDBNull(9) ? "" : dr.GetOracleDecimal(9).ToString(),
                                dr.IsDBNull(10) ? 0 : Convert.ToInt32(dr.GetOracleDecimal(10).Value),
                                 dr.IsDBNull(11) ? 0 : Convert.ToInt32(dr.GetOracleDecimal(11).Value),
                                 dr.IsDBNull(12) ? "" : dr.GetString(12)
                                );
                _vt.Table = GetTableByTableID(_vt.TableID);
                _vt.TableName = _vt.Table.TableName;
                _vt.Columns = GetColumnsOfViewTable(_vt);
                _ret.Add(_vt);
            }
            dr.Close();

            return _ret;
        }

        public IList<MD_ViewTable> GetChildTableOfQueryModel(MD_QueryModel _qm)
        {
            return GetChildTableOfQueryModel(_qm.QueryModelID);
        }

        #endregion

        #region IMetaDataFactroy Members


        private const string SQL_SaveViewChildTable_Update = @"update MD_VIEWTABLE SET DISPLAYNAME=:DISPLAYNAME,TABLERELATION=:TABLERELATION,CANCONDITION=:CANCONDITION,
                                                                DISPLAYORDER=:DISPLAYORDER,DISPLAYTYPE=:DISPLAYTYPE,INTEGRATEDAPP=:INTEGRATEDAPP WHERE VTID = :VTID";
        private const string SQL_SaveViewChildTable_Insert = @"insert into MD_VIEWTABLECOLUMN (VTCID,VTID,TCID,
                                                                CANCONDITIONSHOW,CANRESULTSHOW,DEFAULTSHOW,
                                                                DWDM,FIXQUERYITEM,CANMODIFY,PRIORITY,DISPLAYORDER)
                                                                VALUES (:VTCID,:VTID,:TCID,
                                                                :CANCONDITIONSHOW,:CANRESULTSHOW,:DEFAULTSHOW,
                                                                :DWDM,:FIXQUERYITEM,:CANMODIFY,:PRIORITY,:DISPLAYORDER)";
        private const string SQL_SaveViewChildTable_Delete = @"delete from MD_VIEWTABLECOLUMN where VTID=:VTID";

        public bool SaveViewChildTable(MD_ViewTable _viewtable)
        {
            OracleParameter[] _param = {            
                                new OracleParameter(":DISPLAYNAME",OracleDbType.Varchar2,100),
                                new OracleParameter(":TABLERELATION",OracleDbType.Varchar2,300),
                                new OracleParameter(":CANCONDITION",OracleDbType.Varchar2,10),
                                new OracleParameter(":DISPLAYORDER",OracleDbType.Decimal),
                                new OracleParameter(":DISPLAYTYPE",OracleDbType.Decimal),
                                new OracleParameter(":INTEGRATEDAPP",OracleDbType.Varchar2,1000),
                                new OracleParameter(":VTID",OracleDbType.Decimal)
                        };
            _param[0].Value = _viewtable.DisplayTitle;
            _param[1].Value = _viewtable.RelationString;
            _param[2].Value = (_viewtable.ViewTableRelationType == MDType_ViewTableRelation.SingleChildRecord) ? 1 : 0;
            _param[3].Value = Convert.ToDecimal(_viewtable.DisplayOrder);
            _param[4].Value = (_viewtable.DisplayType == MDType_DisplayType.GridType) ? (decimal)0 : (decimal)1;
            _param[5].Value = _viewtable.IntegratedApp;
            _param[6].Value = Convert.ToDecimal(_viewtable.ViewTableID);

            OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionStringProfile, CommandType.Text, SQL_SaveViewChildTable_Update, _param);

            //清除所有字段定义
            OracleParameter[] _param2 = {
                               new OracleParameter(":VTID",OracleDbType.Decimal)
                        };
            _param2[0].Value = Convert.ToDecimal(_viewtable.ViewTableID);
            OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionStringProfile, CommandType.Text, SQL_SaveViewChildTable_Delete, _param2);


            //保存字段定义信息
            foreach (MD_ViewTableColumn _tc in _viewtable.Columns)
            {
                OracleParameter[] _param3 = {
                                        new OracleParameter(":VTCID", OracleDbType.Decimal),
                                        new OracleParameter(":VTID", OracleDbType.Decimal),
                                        new OracleParameter(":TCID", OracleDbType.Decimal),
                                        new OracleParameter(":CANCONDITIONSHOW", OracleDbType.Decimal),
                                        new OracleParameter(":CANRESULTSHOW", OracleDbType.Decimal),
                                        new OracleParameter(":DEFAULTSHOW", OracleDbType.Decimal),
                                        new OracleParameter(":DWDM",OracleDbType.Varchar2,12),
                                        new OracleParameter(":FIXQUERYITEM",OracleDbType.Decimal),
                                        new OracleParameter(":CANMODIFY",OracleDbType.Decimal),
                                        new OracleParameter(":PRIORITY",OracleDbType.Decimal),
                                        new OracleParameter(":DISPLAYORDER",OracleDbType.Decimal)
                                };
                _param3[0].Value = Convert.ToDecimal(_tc.ViewTableColumnID);
                _param3[1].Value = Convert.ToDecimal(_viewtable.ViewTableID);
                _param3[2].Value = Convert.ToDecimal(_tc.ColumnID);
                _param3[3].Value = _tc.CanShowAsCondition ? 1 : 0;
                _param3[4].Value = _tc.CanShowAsResult ? 1 : 0;
                _param3[5].Value = _tc.DefaultResult ? 1 : 0;
                _param3[6].Value = _tc.DWDM;
                _param3[7].Value = _tc.IsFixQueryItem ? 1 : 0;
                _param3[8].Value = _tc.CanModify ? 1 : 0;
                _param3[9].Value = Convert.ToDecimal(_tc.Priority);
                _param3[10].Value = Convert.ToDecimal(_tc.DisplayOrder);
                OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionStringProfile, CommandType.Text, SQL_SaveViewChildTable_Insert, _param3);
            }
            OraMetaDataQueryFactroy.ModelLib.Clear();
            return true;
        }


        public bool IsExistChildTable(string _viewTableID)
        {
            string _sql = "select count(*) from MD_VIEWTABLE WHERE FATHERID =:FID";
            OracleParameter[] _param = {            
                                new OracleParameter(":FID",OracleDbType.Decimal)                                
                        };
            _param[0].Value = decimal.Parse(_viewTableID);
            decimal _count = (decimal)OracleHelper.ExecuteScalar(OracleHelper.ConnectionStringProfile, CommandType.Text, _sql, _param);
            return (_count > 0);
        }

        public bool DelViewTable(string _viewTableID)
        {
            string _del = "delete MD_VIEWTABLECOLUMN WHERE VTID= :VTID";
            string _del2 = "delete MD_VIEWTABLE WHERE VTID =:VTID ";
            OracleParameter[] _param = {            
                                new OracleParameter(":VTID",OracleDbType.Decimal)                                
                        };
            _param[0].Value = decimal.Parse(_viewTableID);

            OracleParameter[] _param2 = {            
                                new OracleParameter(":VTID",OracleDbType.Decimal)                                
                        };
            _param2[0].Value = decimal.Parse(_viewTableID);

            OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionStringProfile, CommandType.Text, _del, _param);
            OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionStringProfile, CommandType.Text, _del2, _param2);
            OraMetaDataQueryFactroy.ModelLib.Clear();
            return true;
        }

        public bool IsExistChildOfView(string _queryModelID)
        {
            string _querystr = "select count(*) from MD_VIEWTABLE WHERE VIEWID =:VIEWID ";
            OracleParameter[] _param = {            
                                new OracleParameter(":VIEWID",OracleDbType.Decimal)                                
                        };
            _param[0].Value = decimal.Parse(_queryModelID);

            decimal _count = (decimal)OracleHelper.ExecuteScalar(OracleHelper.ConnectionStringProfile, CommandType.Text, _querystr, _param);
            return (_count > 0);
        }

        public bool DelViewMeta(string QueryModelID)
        {
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                OracleTransaction txn = cn.BeginTransaction();
                try
                {
                    OracleCommand _cmd = new OracleCommand(DelView_View2View, cn);
                    _cmd.Parameters.Add(":VIEWID", decimal.Parse(QueryModelID));
                    _cmd.ExecuteNonQuery();

                    _cmd = new OracleCommand(DelView_View2ViewGroup, cn);
                    _cmd.Parameters.Add(":VIEWID", decimal.Parse(QueryModelID));
                    _cmd.ExecuteNonQuery();

                    _cmd = new OracleCommand(DelView_InGroup, cn);
                    _cmd.Parameters.Add(":VIEWID", decimal.Parse(QueryModelID));
                    _cmd.ExecuteNonQuery();

                    _cmd = new OracleCommand(DelView_View, cn);
                    _cmd.Parameters.Add(":VIEWID", decimal.Parse(QueryModelID));
                    _cmd.ExecuteNonQuery();


                    txn.Commit();
                }
                catch (Exception ex)
                {
                    string _errStr = string.Format("删除查询模型及其子对象定义时发生错误! QueryModelID={0} \n\r ErrorMsg:{1}  ",
                                    QueryModelID, ex.Message);
                    OralceLogWriter.WriteSystemLog(_errStr, "ERROR");
                    txn.Rollback();
                    return false;
                }
            }
            return true;
        }

        private const string DelView_ViewTableColumn = @"delete from MD_VIEWTABLECOLUMN vtc where vtc.vtid in  (
														select vt.VTID from MD_VIEWTABLE vt where vt.VIEWID=:VIEWID) ";
        private const string DelView_ViewTable = "delete from MD_VIEWTABLE vt where vt.VIEWID=:VIEWID ";
        private const string DelView_View = "delete from MD_VIEW where VIEWID=:VIEWID";
        private const string DelView_InGroup = "delete from MD_VIEWGROUPITEM where VIEWID=:VIEWID";
        private const string DelView_View2ViewGroup = "delete from MD_VIEW2VIEWGROUP where VIEWID=:VIEWID";
        private const string DelView_View2View = "delete from MD_VIEW2VIEW where VIEWID=:VIEWID";
        private const string DelView_View2Guideline = "delete from md_view2gl where VIEWID=:VIEWID";
        private const string DelView_View2Application = "delete from md_view2app where viewid=:VIEWID";
        public bool DelViewAndChildren(string QueryModelID)
        {
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                OracleTransaction txn = cn.BeginTransaction();
                try
                {

                    OracleCommand _cmd = new OracleCommand(DelView_ViewTableColumn, cn);
                    _cmd.Parameters.Add(":VIEWID", decimal.Parse(QueryModelID));
                    _cmd.ExecuteNonQuery();

                    _cmd = new OracleCommand(DelView_ViewTable, cn);
                    _cmd.Parameters.Add(":VIEWID", decimal.Parse(QueryModelID));
                    _cmd.ExecuteNonQuery();

                    _cmd = new OracleCommand(DelView_View2View, cn);
                    _cmd.Parameters.Add(":VIEWID", decimal.Parse(QueryModelID));
                    _cmd.ExecuteNonQuery();

                    _cmd = new OracleCommand(DelView_View2ViewGroup, cn);
                    _cmd.Parameters.Add(":VIEWID", decimal.Parse(QueryModelID));
                    _cmd.ExecuteNonQuery();

                    _cmd = new OracleCommand(DelView_InGroup, cn);
                    _cmd.Parameters.Add(":VIEWID", decimal.Parse(QueryModelID));
                    _cmd.ExecuteNonQuery();

                    _cmd = new OracleCommand(DelView_View, cn);
                    _cmd.Parameters.Add(":VIEWID", decimal.Parse(QueryModelID));
                    _cmd.ExecuteNonQuery();

                    _cmd = new OracleCommand(DelView_View2Guideline, cn);
                    _cmd.Parameters.Add(":VIEWID", decimal.Parse(QueryModelID));
                    _cmd.ExecuteNonQuery();

                    _cmd = new OracleCommand(DelView_View2Application, cn);
                    _cmd.Parameters.Add(":VIEWID", QueryModelID);
                    _cmd.ExecuteNonQuery();

                    txn.Commit();
                }
                catch (Exception ex)
                {
                    string _errStr = string.Format("删除查询模型及其子对象定义时发生错误! QueryModelID={0} \n\r ErrorMsg:{1}  ",
                                    QueryModelID, ex.Message);
                    OralceLogWriter.WriteSystemLog(_errStr, "ERROR");
                    txn.Rollback();
                    return false;
                }
            }
            return true;
        }

        public bool IsExistViewUsedTable(string _tableID)
        {
            string _querystr = "select count(*) from MD_VIEWTABLE WHERE TID=:TID ";
            OracleParameter[] _param = {            
                                new OracleParameter(":TID",OracleDbType.Decimal)                                
                        };
            _param[0].Value = decimal.Parse(_tableID);

            decimal _count = (decimal)OracleHelper.ExecuteScalar(OracleHelper.ConnectionStringProfile, CommandType.Text, _querystr, _param);
            return (_count > 0);
        }

        public bool DelTableMeta(string _tableID)
        {
            string _del2 = "delete MD_TABLECOLUMN where TID=:TID ";
            string _del = "delete MD_TABLE where TID =:TID";
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                OracleTransaction txn = cn.BeginTransaction();
                try
                {
                    OracleCommand _cmd = new OracleCommand(_del2, cn);
                    _cmd.Parameters.Add(":TID", decimal.Parse(_tableID));
                    _cmd.ExecuteNonQuery();

                    _cmd = new OracleCommand(_del, cn);
                    _cmd.Parameters.Add(":TID", decimal.Parse(_tableID));
                    _cmd.ExecuteNonQuery();

                    txn.Commit();
                    OraMetaDataQueryFactroy.ModelLib.Clear();
                }
                catch (Exception ex)
                {
                    string _errStr = string.Format("删除表定义时发生错误! TableID={0} \n\r ErrorMsg:{1}  ",
                                    _tableID, ex.Message);
                    OralceLogWriter.WriteSystemLog(_errStr, "ERROR");
                    txn.Rollback();
                    return false;
                }
            }
            return true;
        }

        public bool SaveNewRefTable(DB_TableMeta _tm, MD_Namespace _namespace)
        {
            StringBuilder _insertStr = new StringBuilder();
            _insertStr.Append(" Insert into md_reftablelist ");
            _insertStr.Append(" (RTID,NAMESPACE,REFTABLENAME,REFTABLELEVELFORMAT,");
            _insertStr.Append(" DESCRIPTION,DOWNLOADMODE,REFTABLEMODE,DWDM ) ");
            _insertStr.Append(" values ");
            _insertStr.Append(" (sequences_meta.nextval,:NAMESPACE,:REFTABLENAME,'',");
            _insertStr.Append(" :DESCRIPTION,1,1,:DWDM ) ");

            OracleParameter[] _param = {            
                                new OracleParameter(":NAMESPACE",OracleDbType.Varchar2,50),
                                new OracleParameter(":REFTABLENAME",OracleDbType.Varchar2,50),
                                new OracleParameter(":DESCRIPTION",OracleDbType.Varchar2,100),
                                new OracleParameter(":DWDM",OracleDbType.Varchar2,12)                                                         
                        };
            string[] _tnames = _tm.TableName.Split('.');

            _param[0].Value = _namespace.NameSpace;
            _param[1].Value = _tnames[_tnames.Length - 1];
            _param[2].Value = (_tm.TableComment == "") ? _tm.TableName : _tm.TableComment;
            _param[3].Value = _namespace.DWDM;
            OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionStringProfile, CommandType.Text, _insertStr.ToString(), _param);
            OraMetaDataQueryFactroy.ModelLib.Clear();
            return true;
        }
        public DataTable Get_RefTableColumn(MD_RefTable _refTable)
        {
            return Get_RefTableColumn(_refTable.RefTableName);
        }
        public DataTable Get_RefTableColumn(string _refTableName)
        {
            DataTable _metadata = new DataTable("RefTable");
            string cmdStr = string.Format("select * from JSODS.{0} ", _refTableName);
            using (OracleConnection cn = OpenConnection())
            {
                _metadata = OracleHelper.FillDataTable(cn, CommandType.Text, cmdStr);
                _metadata.TableName = "RefTable";
                _metadata.CaseSensitive = true;
                cn.Close();
            }
            return _metadata;
        }

        public bool SaveRefTable(MD_RefTable _refTable, DataTable _refData)
        {
            StringBuilder _updateStr = new StringBuilder();
            _updateStr.Append(" update md_reftablelist set ");
            _updateStr.Append(" REFTABLELEVELFORMAT=:LEVELFORMAT,DESCRIPTION=:DES,DOWNLOADMODE=:DOWNLOAD,");
            _updateStr.Append(" REFTABLEMODE=:REFMODE,HIDECODE=:HIDECODE where RTID=:RTID");
            OracleParameter[] _param = {            
                                new OracleParameter(":LEVELFORMAT",OracleDbType.Varchar2,20),
                                new OracleParameter(":DES",OracleDbType.Varchar2,100),
                                new OracleParameter(":DOWNLOAD",OracleDbType.Decimal),
                                new OracleParameter(":REFMODE",OracleDbType.Decimal),
                                 new OracleParameter(":HIDECODE",OracleDbType.Decimal), 
                                new OracleParameter(":RTID",OracleDbType.Decimal)                               
                        };
            _param[0].Value = _refTable.LevelFormat;
            _param[1].Value = _refTable.Description;
            _param[2].Value = Convert.ToDecimal((int)_refTable.RefDownloadMode);
            _param[3].Value = Convert.ToDecimal((int)_refTable.RefParamMode);
            _param[4].Value = _refTable.HideCode ? (decimal)1 : (decimal)0;
            _param[5].Value = decimal.Parse(_refTable.RefTableID);
            OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionStringProfile, CommandType.Text, _updateStr.ToString(), _param);

            if (_refData != null && _refData.Rows.Count > 0)
            {
                string _cmdStr = string.Format("select * from JSODS.{0}", _refTable.RefTableName);
                using (OracleConnection cn = OpenConnection())
                {

                    OracleTransaction txn = cn.BeginTransaction();
                    OracleHelper.UpdateData(cn, _cmdStr, _refData);
                    txn.Commit();
                    cn.Close();
                    return true;
                }
            }
            OraMetaDataQueryFactroy.ModelLib.Clear();
            return true;
        }

        public bool ImportRefTableDefine(MD_RefTable _rt)
        {
            StringBuilder _insertStr = new StringBuilder();
            _insertStr.Append(" Insert into md_reftablelist ");
            _insertStr.Append(" (RTID,NAMESPACE,REFTABLENAME,REFTABLELEVELFORMAT,");
            _insertStr.Append(" DESCRIPTION,DOWNLOADMODE,REFTABLEMODE,DWDM,HIDECODE ) ");
            _insertStr.Append(" values ");
            _insertStr.Append(" (:RTID,:NAMESPACE,:REFTABLENAME,:REFTABLELEVELFORMAT,");
            _insertStr.Append(" :DESCRIPTION,:DOWNLOADMODE,:REFTABLEMODE,:DWDM,:HIDECODE ) ");

            OracleParameter[] _param = {          
                                new OracleParameter(":RTID",OracleDbType.Decimal),
                                new OracleParameter(":NAMESPACE",OracleDbType.Varchar2,50),
                                new OracleParameter(":REFTABLENAME",OracleDbType.Varchar2,50),
                                new OracleParameter(":REFTABLELEVELFORMAT",OracleDbType.Varchar2,20),
                                new OracleParameter(":DESCRIPTION",OracleDbType.Varchar2,100),
                                new OracleParameter(":DOWNLOADMODE",OracleDbType.Decimal),
                                new OracleParameter(":REFTABLEMODE",OracleDbType.Decimal),
                                new OracleParameter(":DWDM",OracleDbType.Varchar2,12)    ,
                                 new OracleParameter(":HIDECODE",OracleDbType.Decimal)
                        };
            _param[0].Value = decimal.Parse(_rt.RefTableID);
            _param[1].Value = _rt.NamespaceName;
            _param[2].Value = _rt.RefTableName;
            _param[3].Value = _rt.LevelFormat;
            _param[4].Value = _rt.Description;
            _param[5].Value = Convert.ToDecimal((int)_rt.RefDownloadMode);
            _param[6].Value = Convert.ToDecimal((int)_rt.RefParamMode);
            _param[7].Value = _rt.DWDM;
            _param[8].Value = _rt.HideCode ? (decimal)1 : (decimal)0;

            OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionStringProfile, CommandType.Text, _insertStr.ToString(), _param);
            return true;
        }

        private const string SQL_GetMenuDefineOfNode = @"select ID,MENUNAME,MENUTYPE,MENUCS,
                                                           DISPLAYORDER,FATHERID,MENUTOOLTIP,MENUICON,
                                                           SHOWTOOLBAR,SYSTEMID,ICONNAME
                                                           from MD_MAINMENU where SYSTEMID=:SYSTEMID AND FATHERID=0
                                                           order by DISPLAYORDER asc";
        public IList<MD_Menu> GetMenuDefineOfNode(string _nodeCode)
        {
            IList<MD_Menu> _ret = new List<MD_Menu>();

            OracleParameter[] _param = {            
                                new OracleParameter(":SYSTEMID",OracleDbType.Varchar2,12)
                        };
            _param[0].Value = _nodeCode;

            OracleDataReader dr = OracleHelper.ExecuteReader(OracleHelper.ConnectionStringProfile, CommandType.Text, SQL_GetMenuDefineOfNode, _param);

            while (dr.Read())
            {
                MD_Menu _vt = new MD_Menu();
                _vt.MenuID = dr.GetOracleDecimal(0).ToString();
                _vt.MenuName = dr.GetString(1);
                _vt.MenuType = dr.IsDBNull(2) ? "" : dr.GetString(2);
                _vt.MenuParameter = dr.IsDBNull(3) ? "" : dr.GetString(3);
                _vt.DisplayOrder = dr.IsDBNull(4) ? 0 : Convert.ToInt32(dr.GetOracleDecimal(4).Value);
                _vt.FatherMenuID = dr.GetOracleDecimal(5).ToString();
                _vt.MenuToolTip = dr.IsDBNull(6) ? "" : dr.GetString(6);
                _vt.MenuIcon = dr.IsDBNull(10) ? "" : dr.GetString(10);
                _vt.ShowInToolBar = dr.IsDBNull(8) ? false : (dr.GetString(8) == "Y");
                _vt.SystemID = dr.IsDBNull(9) ? "" : dr.GetString(9);
                _vt.IconName = dr.IsDBNull(10) ? "" : dr.GetString(10);
                _ret.Add(_vt);
            }
            dr.Close();

            return _ret;
        }


        private const string SQL_GetSubMenuDefine = @"select ID,MENUNAME,MENUTYPE,MENUCS,
                                                        DISPLAYORDER,FATHERID,MENUTOOLTIP,MENUICON,
                                                        SHOWTOOLBAR,SYSTEMID, ICONNAME
                                                        from MD_MAINMENU where FATHERID=:FID
                                                        order by DISPLAYORDER asc";
        public IList<MD_Menu> GetSubMenuDefine(string _fmenuID)
        {
            IList<MD_Menu> _ret = new List<MD_Menu>();
            OracleParameter[] _param = {            
                                new OracleParameter(":FID",OracleDbType.Decimal)
                        };
            _param[0].Value = decimal.Parse(_fmenuID);
            OracleDataReader dr = OracleHelper.ExecuteReader(OracleHelper.ConnectionStringProfile, CommandType.Text, SQL_GetSubMenuDefine, _param);
            while (dr.Read())
            {
                MD_Menu _vt = new MD_Menu();
                _vt.MenuID = dr.GetOracleDecimal(0).ToString();
                _vt.MenuName = dr.GetString(1);
                _vt.MenuType = dr.IsDBNull(2) ? "" : dr.GetString(2);
                _vt.MenuParameter = dr.IsDBNull(3) ? "" : dr.GetString(3);
                _vt.DisplayOrder = dr.IsDBNull(4) ? 0 : Convert.ToInt32(dr.GetOracleDecimal(4).Value);
                _vt.FatherMenuID = dr.GetOracleDecimal(5).ToString();
                _vt.MenuToolTip = dr.IsDBNull(6) ? "" : dr.GetString(6);
                _vt.MenuIcon = dr.IsDBNull(10) ? "" : dr.GetString(10);
                _vt.ShowInToolBar = dr.IsDBNull(8) ? false : (dr.GetString(8) == "Y");
                _vt.SystemID = dr.GetString(9);
                _vt.IconName = dr.IsDBNull(10) ? "" : dr.GetString(10);

                _ret.Add(_vt);
            }
            dr.Close();

            return _ret;
        }

        public bool SaveMenuDefine(MD_Menu _menu)
        {
            StringBuilder _updateStr = new StringBuilder();
            _updateStr.Append(" update MD_MAINMENU set ");
            _updateStr.Append(" MENUNAME=:MENUNAME,MENUTYPE=:MENUTYPE,MENUCS=:MENUCS,");
            _updateStr.Append(" DISPLAYORDER=:DISPLAYORDER,MENUTOOLTIP=:MENUTOOLTIP,MENUICON=-1, ICONNAME=:ICONNAME,");
            _updateStr.Append(" SHOWTOOLBAR=:SHOWTOOLBAR ");
            _updateStr.Append(" where ID=:ID");
            OracleParameter[] _param = {            
                                new OracleParameter(":MENUNAME",OracleDbType.Varchar2,100),
                                new OracleParameter(":MENUTYPE",OracleDbType.Varchar2,100),
                                new OracleParameter(":MENUCS",OracleDbType.Varchar2,1000),
                                new OracleParameter(":DISPLAYORDER",OracleDbType.Decimal),
                                new OracleParameter(":MENUTOOLTIP",OracleDbType.Varchar2,1000),
                                new OracleParameter(":ICONNAME",OracleDbType.Varchar2),
                                new OracleParameter(":SHOWTOOLBAR",OracleDbType.Varchar2,10),
                                new OracleParameter(":ID",OracleDbType.Decimal)                               
                        };
            _param[0].Value = _menu.MenuName;
            _param[1].Value = _menu.MenuType;
            _param[2].Value = _menu.MenuParameter;
            _param[3].Value = Convert.ToDecimal((int)_menu.DisplayOrder);
            _param[4].Value = _menu.MenuToolTip;
            _param[5].Value = _menu.MenuIcon;
            _param[6].Value = _menu.ShowInToolBar ? "Y" : "N";
            _param[7].Value = decimal.Parse(_menu.MenuID);
            OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionStringProfile, CommandType.Text, _updateStr.ToString(), _param);
            return true;
        }

        private const string SQL_AddSystemMenu = @"insert into  MD_MAINMENU
                                                    (ID,MENUNAME,MENUTYPE,MENUCS,DISPLAYORDER,
                                                    FATHERID,MENUTOOLTIP,MENUICON,SHOWTOOLBAR,SYSTEMID )
                                                    VALUES
                                                    (sequences_meta.nextval,'MENU','','',0, 
                                                     0,'',-1,'N',:SYSTEMID )";
        public bool AddSystemMenu(string _nodeCode)
        {

            OracleParameter[] _param = {                                           
                                new OracleParameter(":SYSTEMID",OracleDbType.Varchar2,12)                               
                        };

            _param[0].Value = _nodeCode;

            OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionStringProfile, CommandType.Text, SQL_AddSystemMenu, _param);
            return true;
        }

        private const string SQL_AddSystemSubMenu = @"insert into  MD_MAINMENU
                                                        (ID,MENUNAME,MENUTYPE,MENUCS,DISPLAYORDER,
                                                        FATHERID,MENUTOOLTIP,MENUICON,SHOWTOOLBAR,SYSTEMID )
                                                        VALUES
                                                        (sequences_meta.nextval,'MENU','','',0, 
                                                          :FID,'',-1,'N',:SYSTEMID )   ";
        public bool AddSystemSubMenu(string _fatherMenuID, string SystemID)
        {
            OracleParameter[] _param = {            
                                new OracleParameter(":FID",OracleDbType.Decimal),
                                new OracleParameter(":SYSTEMID",OracleDbType.Varchar2,12)                               
                        };

            _param[0].Value = decimal.Parse(_fatherMenuID);
            _param[1].Value = SystemID;

            OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionStringProfile, CommandType.Text, SQL_AddSystemSubMenu, _param);
            return true;
        }


        public bool DelSystemMenu(string _menuid)
        {
            //判断是否有子菜单
            string _select = "select count(ID) from md_mainmenu where fatherid=:FID";
            OracleParameter[] _param2 = { 
                                new OracleParameter(":FID",OracleDbType.Decimal)
                        };
            _param2[0].Value = decimal.Parse(_menuid);
            decimal _countnum = (decimal)OracleHelper.ExecuteScalar(OracleHelper.ConnectionStringProfile, CommandType.Text, _select, _param2);
            if (_countnum > 0) return false;
            //删除
            StringBuilder _delStr = new StringBuilder();
            _delStr.Append(" delete from MD_MAINMENU ");
            _delStr.Append(" where id = :MID ");

            OracleParameter[] _param = { 
                                new OracleParameter(":MID",OracleDbType.Decimal)
                        };
            _param[0].Value = decimal.Parse(_menuid);

            OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionStringProfile, CommandType.Text, _delStr.ToString(), _param);
            return true;
        }

        public IList<MD_GuideLineGroup> GetGuideLineGroup(string _nodeCode, string _guideLineGroupType)
        {
            IList<MD_GuideLineGroup> _ret = new List<MD_GuideLineGroup>();

            StringBuilder _sql = new StringBuilder();
            _sql.Append(" select ZBZTMC,ZBZTSM,LX,QXLX,NAMESPACE,SSDW ");
            _sql.Append(" from TJ_ZBZTMCDYB where SSDW=:DWDM and LX=:LX");
            OracleParameter[] _param = {
                                new OracleParameter(":DWDM",OracleDbType.Varchar2,12),
                                new OracleParameter(":LX",OracleDbType.Decimal)
                        };
            _param[0].Value = _nodeCode;
            _param[1].Value = decimal.Parse(_guideLineGroupType);


            OracleDataReader dr = OracleHelper.ExecuteReader(OracleHelper.ConnectionStringProfile, CommandType.Text, _sql.ToString(), _param);

            while (dr.Read())
            {
                MD_GuideLineGroup _vt = new MD_GuideLineGroup(
                                dr.GetString(0),
                                dr.IsDBNull(1) ? "" : dr.GetString(1),
                                dr.IsDBNull(4) ? "" : dr.GetString(4),
                                dr.IsDBNull(5) ? "" : dr.GetString(5),
                                dr.IsDBNull(2) ? 0 : Convert.ToInt32(dr.GetOracleDecimal(2).Value),
                                dr.IsDBNull(3) ? 0 : Convert.ToInt32(dr.GetOracleDecimal(3).Value)
                                );
                _ret.Add(_vt);
            }
            dr.Close();

            return _ret;

        }

        public bool SaveGuideLineGroupDefine(MD_GuideLineGroup _GuideLineGroup)
        {
            StringBuilder _updateStr = new StringBuilder();
            _updateStr.Append(" update TJ_ZBZTMCDYB set ");
            _updateStr.Append(" ZBZTSM=:ZBZTSM,LX=:LX,");
            _updateStr.Append(" QXLX=:QXLX,NAMESPACE=:NAMESPACE ");
            _updateStr.Append(" where ZBZTMC=:ZBZTMC");
            OracleParameter[] _param = {            
                                new OracleParameter(":ZBZTSM",OracleDbType.Varchar2,200),
                                new OracleParameter(":LX",OracleDbType.Decimal),
                                new OracleParameter(":QXLX",OracleDbType.Decimal),
                                new OracleParameter(":NAMESPACE",OracleDbType.Varchar2,50),
                                new OracleParameter(":ZBZTMC",OracleDbType.Varchar2,200)                                                           
                        };

            _param[0].Value = _GuideLineGroup.ZBZTSM;
            _param[1].Value = Convert.ToDecimal(_GuideLineGroup.LX);
            _param[2].Value = Convert.ToDecimal(_GuideLineGroup.QXLX);
            _param[3].Value = _GuideLineGroup.NamespaceName;
            _param[4].Value = _GuideLineGroup.ZBZTMC;
            OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionStringProfile, CommandType.Text, _updateStr.ToString(), _param);
            return true;
        }

        public IList<MD_GuideLine> GetGuideLineOfGroup(string _groupName)
        {
            IList<MD_GuideLine> _ret = new List<MD_GuideLine>();

            StringBuilder _sql = new StringBuilder();
            _sql.Append(" select ID,ZBMC,ZBZT,ZBSF, ZBMETA,FID,ZBCXSF,JSMX_ZBMETA,XSXH,ZBSM ");
            _sql.Append(" from TJ_ZDYZBDYB where ZBZT=:ZBZT and FID=1 order by XSXH ASC");
            OracleParameter[] _param = {
                                new OracleParameter(":ZBZT",OracleDbType.Varchar2,200)
                               
                        };
            _param[0].Value = _groupName;

            OracleDataReader dr = OracleHelper.ExecuteReader(OracleHelper.ConnectionStringProfile, CommandType.Text, _sql.ToString(), _param);

            while (dr.Read())
            {
                MD_GuideLine _vt = new MD_GuideLine(
                                dr.GetOracleDecimal(0).Value.ToString(),
                                dr.IsDBNull(1) ? "" : dr.GetString(1),
                                dr.IsDBNull(2) ? "" : dr.GetString(2),
                                dr.IsDBNull(3) ? "" : dr.GetString(3),
                                dr.IsDBNull(4) ? "" : dr.GetString(4),
                                dr.IsDBNull(5) ? "0" : dr.GetOracleDecimal(5).Value.ToString(),
                                dr.IsDBNull(6) ? "" : dr.GetString(6),
                                dr.IsDBNull(7) ? "" : dr.GetString(7),
                                dr.IsDBNull(8) ? 0 : Convert.ToInt32(dr.GetOracleDecimal(8).Value),
                                 dr.IsDBNull(9) ? "" : dr.GetString(9)
                                );
                _ret.Add(_vt);
            }
            dr.Close();

            return _ret;
        }

        public IList<MD_GuideLine> GetChildGuideLines(string _fatherGuildLineID)
        {
            IList<MD_GuideLine> _ret = new List<MD_GuideLine>();

            StringBuilder _sql = new StringBuilder();
            _sql.Append(" select ID,ZBMC,ZBZT,ZBSF, ZBMETA,FID,ZBCXSF,JSMX_ZBMETA,XSXH,ZBSM ");
            _sql.Append(" from TJ_ZDYZBDYB where FID=:FID ORDER BY XSXH ASC ");
            OracleParameter[] _param = {
                                new OracleParameter(":FID",OracleDbType.Decimal)
                               
                        };
            _param[0].Value = decimal.Parse(_fatherGuildLineID);

            OracleDataReader dr = OracleHelper.ExecuteReader(OracleHelper.ConnectionStringProfile, CommandType.Text, _sql.ToString(), _param);

            while (dr.Read())
            {
                MD_GuideLine _vt = new MD_GuideLine(
                                dr.GetOracleDecimal(0).Value.ToString(),
                                dr.IsDBNull(1) ? "" : dr.GetString(1),
                                dr.IsDBNull(2) ? "" : dr.GetString(2),
                                dr.IsDBNull(3) ? "" : dr.GetString(3),
                                dr.IsDBNull(4) ? "" : dr.GetString(4),
                                dr.IsDBNull(5) ? "0" : dr.GetOracleDecimal(5).Value.ToString(),
                                dr.IsDBNull(6) ? "" : dr.GetString(6),
                                dr.IsDBNull(7) ? "" : dr.GetString(7),
                                dr.IsDBNull(8) ? 0 : Convert.ToInt32(dr.GetOracleDecimal(8).Value),
                                 dr.IsDBNull(9) ? "" : dr.GetString(9)
                                );
                _ret.Add(_vt);
            }
            dr.Close();

            return _ret;
        }

        public bool DelGuideLineGroup(string _guideLineGroupName)
        {
            StringBuilder _sb = new StringBuilder();
            _sb.Append("delete tj_zbztmcdyb   ");
            _sb.Append(" where ZBZTMC=:ZBZTMC ");
            OracleParameter[] _param = {
                                 new OracleParameter(":ZBZTMC", OracleDbType.Varchar2, 100)   
                        };
            _param[0].Value = _guideLineGroupName;
            OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionStringProfile, CommandType.Text, _sb.ToString(), _param);
            return true;
        }

        public bool IsExistChildOfGuideLineGroup(string _groupName)
        {
            StringBuilder _sql = new StringBuilder();
            _sql.Append(" select count(id) ");
            _sql.Append(" from TJ_ZDYZBDYB where ZBZT=:ZBZT and FID=1");
            OracleParameter[] _param = {
                                new OracleParameter(":ZBZT",OracleDbType.Varchar2,200)                               
                        };
            _param[0].Value = _groupName;

            decimal _count = (decimal)OracleHelper.ExecuteScalar(OracleHelper.ConnectionStringProfile, CommandType.Text, _sql.ToString(), _param);
            return (_count > 0);
        }

        public bool IsExistGuideLineGroupName(string _guideLineGroupName)
        {
            StringBuilder _sql = new StringBuilder();
            _sql.Append(" select count(ZBZTMC) ");
            _sql.Append(" from tj_zbztmcdyb ");
            _sql.Append(" where ZBZTMC=:ZBZTMC ");
            OracleParameter[] _param = {
                                 new OracleParameter(":ZBZTMC", OracleDbType.Varchar2, 100)   
                        };
            _param[0].Value = _guideLineGroupName;

            decimal _count = (decimal)OracleHelper.ExecuteScalar(OracleHelper.ConnectionStringProfile, CommandType.Text, _sql.ToString(), _param);
            return (_count > 0);
        }


        public bool SaveNewGuideLineGroupDefine(MD_GuideLineGroup _guideLineGroup)
        {
            StringBuilder _sb = new StringBuilder();
            _sb.Append("INSERT INTO TJ_ZBZTMCDYB   ");
            _sb.Append(" (ZBZTMC,ZBZTSM,LX,QXLX,NAMESPACE,SSDW) VALUES ");
            _sb.Append(" (:ZBZTMC,:ZBZTSM,:LX,:QXLX,:NAMESPACE,:SSDW) ");
            OracleParameter[] _param = {
                                 new OracleParameter(":ZBZTMC", OracleDbType.Varchar2, 200),
                                 new OracleParameter(":ZBZTSM", OracleDbType.Varchar2, 200),
                                 new OracleParameter(":LX", OracleDbType.Decimal),
                                 new OracleParameter(":QXLX", OracleDbType.Decimal),
                                 new OracleParameter(":NAMESPACE", OracleDbType.Varchar2, 50),
                                 new OracleParameter(":SSDW", OracleDbType.Varchar2, 12)

                        };
            _param[0].Value = _guideLineGroup.ZBZTMC;
            _param[1].Value = _guideLineGroup.ZBZTSM;
            _param[2].Value = Convert.ToDecimal(_guideLineGroup.LX);
            _param[3].Value = Convert.ToDecimal(_guideLineGroup.QXLX);
            _param[4].Value = _guideLineGroup.NamespaceName;
            _param[5].Value = _guideLineGroup.SSDW;

            OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionStringProfile, CommandType.Text, _sb.ToString(), _param);
            return true;
        }

        public bool SaveNewGuideLine(string _guideLineName, decimal _fid, string _guideLineGroupName)
        {
            StringBuilder _sb = new StringBuilder();
            _sb.Append("INSERT INTO TJ_ZDYZBDYB   ");
            _sb.Append(" (ID,ZBMC,ZBZT,FID,XSXH) VALUES ");
            _sb.Append(" (sequences_meta.nextval,:ZBMC,:ZBZT,:FID,0) ");
            OracleParameter[] _param = {
                                 new OracleParameter(":ZBMC", OracleDbType.Varchar2, 200),
                                 new OracleParameter(":ZBZT", OracleDbType.Varchar2, 200),
                                 new OracleParameter(":FID", OracleDbType.Decimal)                                

                        };
            _param[0].Value = _guideLineName;
            _param[1].Value = _guideLineGroupName;
            _param[2].Value = _fid;

            OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionStringProfile, CommandType.Text, _sb.ToString(), _param);
            return true;
        }


        public bool IsExistGuideLineID(string _guideLineID)
        {
            StringBuilder _sql = new StringBuilder();
            _sql.Append(" select count(ID) ");
            _sql.Append(" from TJ_ZDYZBDYB ");
            _sql.Append(" where ID=:ID ");
            OracleParameter[] _param = {
                                 new OracleParameter(":ID", OracleDbType.Decimal)   
                        };
            _param[0].Value = decimal.Parse(_guideLineID);

            decimal _count = (decimal)OracleHelper.ExecuteScalar(OracleHelper.ConnectionStringProfile, CommandType.Text, _sql.ToString(), _param);
            return (_count > 0);

        }


        public bool IsExistChildOfGuideLine(string _guideLineID)
        {
            StringBuilder _sql = new StringBuilder();
            _sql.Append(" select count(ID) ");
            _sql.Append(" from TJ_ZDYZBDYB ");
            _sql.Append(" where FID=:FID ");
            OracleParameter[] _param = {
                                 new OracleParameter(":FID", OracleDbType.Decimal)   
                        };
            _param[0].Value = decimal.Parse(_guideLineID);

            decimal _count = (decimal)OracleHelper.ExecuteScalar(OracleHelper.ConnectionStringProfile, CommandType.Text, _sql.ToString(), _param);
            return (_count > 0);
        }

        public bool DelGuideLine(string _guideLineID)
        {
            StringBuilder _sb = new StringBuilder();
            _sb.Append(" delete from tj_zdyzbdyb where id in   ");
            _sb.Append(" (select t.id from tj_zdyzbdyb t  ");
            _sb.Append("    START WITH   id =:ID  CONNECT BY PRIOR  id=fid )");
            OracleParameter[] _param = {
                                 new OracleParameter(":ID", OracleDbType.Decimal)
                        };
            _param[0].Value = decimal.Parse(_guideLineID);
            OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionStringProfile, CommandType.Text, _sb.ToString(), _param);
            return true;
        }

        public bool SaveGuideLine(MD_GuideLine _guideLine)
        {
            string _metaStr1 = "";
            string _metaStr2 = "";
            StringBuilder _sb = new StringBuilder();
            _sb.Append("update TJ_ZDYZBDYB   ");
            _sb.Append(" set ZBMC=:ZBMC,ZBSF=:ZBSF,ZBMETA=:ZBMETA,XSXH=:XSXH,JSMX_ZBMETA=:JSMXMETA ,ZBSM=:ZBSM");
            _sb.Append(" where ID=:ID ");
            OracleParameter[] _param = {
                                new OracleParameter(":ZBMC", OracleDbType.Varchar2,200),
                                new OracleParameter(":ZBSF", OracleDbType.Varchar2,4000),
                                new OracleParameter(":ZBMETA", OracleDbType.Varchar2,4000),
                                new OracleParameter(":XSXH", OracleDbType.Decimal),
                                new OracleParameter(":JSMXMETA",OracleDbType.Varchar2,4000),
                                new OracleParameter(":ZBSM",OracleDbType.Varchar2,4000),
                                new OracleParameter(":ID", OracleDbType.Decimal)
                        };

            SplitMetaString(_guideLine.GuideLineMeta, ref _metaStr1, ref _metaStr2);
            //if (_guideLine.GuideLineMeta.Length > 3700)
            //{
            //        _metaStr1 = _guideLine.GuideLineMeta.Substring(0, 3700);
            //        _metaStr2 = _guideLine.GuideLineMeta.Substring(3700);
            //}
            //else
            //{
            //        _metaStr1 = _guideLine.GuideLineMeta;
            //        _metaStr2 = "";
            //}

            _param[0].Value = _guideLine.GuideLineName;
            _param[1].Value = _guideLine.GuideLineMethod;
            _param[2].Value = _metaStr1;
            _param[3].Value = Convert.ToDecimal(_guideLine.DisplayOrder);
            _param[4].Value = _metaStr2;
            _param[5].Value = _guideLine.Description;
            _param[6].Value = decimal.Parse(_guideLine.ID);
            OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionStringProfile, CommandType.Text, _sb.ToString(), _param);
            return true;
        }

        private void SplitMetaString(string fullString, ref string _metaStr1, ref string _metaStr2)
        {

            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                try
                {
                    OracleCommand _cmd = new OracleCommand("ZHTJ_COMM.SplitString", cn);
                    _cmd.CommandType = CommandType.StoredProcedure;
                    _cmd.Parameters.Add("strInput", fullString);
                    _cmd.Parameters.Add("nLen", (decimal)3900);
                    _cmd.Parameters.Add(new OracleParameter("str1", OracleDbType.Varchar2, 4000, "", ParameterDirection.Output));
                    _cmd.Parameters.Add(new OracleParameter("str2", OracleDbType.Varchar2, 4000, "", ParameterDirection.Output));
                    _cmd.ExecuteScalar();

                    _metaStr1 = _cmd.Parameters[2].Value.ToString();
                    _metaStr2 = _cmd.Parameters[3].Value.ToString();

                    cn.Close();
                }
                catch (Exception ex)
                {
                    string _errmsg = string.Format("执行ZHTJ_COMM.SplitString出错,错误信息为:{0}!",
                               ex.Message);

                    OralceLogWriter.WriteSystemLog(_errmsg, "ERROR");
                    throw ex;
                }
            }
            return;
        }

        public bool SaveNewGuideLine(MD_GuideLine _guideLine)
        {
            string _metaStr1 = "";
            string _metaStr2 = "";
            StringBuilder _sb = new StringBuilder();
            _sb.Append("INSERT INTO TJ_ZDYZBDYB   ");
            _sb.Append(" (ID,ZBMC,ZBSM,ZBZT,FID,XSXH,ZBMETA,ZBSF,JSMX_ZBMETA) VALUES ");
            _sb.Append(" (:ID,:ZBMC,:ZBSM,:ZBZT,:FID,:XSXH,:ZBMETA,:ZBSF,:JSMXMETA) ");
            OracleParameter[] _param = {
                                 new OracleParameter(":ID",OracleDbType.Decimal),
                                 new OracleParameter(":ZBMC", OracleDbType.Varchar2, 200),
                                  new OracleParameter(":ZBSM", OracleDbType.Varchar2, 4000),
                                 new OracleParameter(":ZBZT", OracleDbType.Varchar2, 200),
                                 new OracleParameter(":FID", OracleDbType.Decimal),
                                new OracleParameter(":XSXH",OracleDbType.Decimal),
                                new OracleParameter(":ZBMETA",OracleDbType.Varchar2,4000), 
                                new OracleParameter(":ZBSF",OracleDbType.Varchar2,4000),
                                new OracleParameter(":JSMXMETA",OracleDbType.Varchar2,4000)
                        };
            SplitMetaString(_guideLine.GuideLineMeta, ref _metaStr1, ref _metaStr2);
            //if (_guideLine.GuideLineMeta.Length > 3700)
            //{
            //        _metaStr1 = _guideLine.GuideLineMeta.Substring(0, 3700);
            //        _metaStr2 = _guideLine.GuideLineMeta.Substring(3700);
            //}
            //else
            //{
            //        _metaStr1 = _guideLine.GuideLineMeta;
            //        _metaStr2 = "";
            //}
            _param[0].Value = decimal.Parse(_guideLine.ID);
            _param[1].Value = _guideLine.GuideLineName;
            _param[2].Value = _guideLine.Description;
            _param[3].Value = _guideLine.GroupName;
            _param[4].Value = decimal.Parse(_guideLine.FatherID);
            _param[5].Value = Convert.ToDecimal(_guideLine.DisplayOrder);
            _param[6].Value = _metaStr1;
            _param[7].Value = _guideLine.GuideLineMethod;
            _param[8].Value = _metaStr2;

            OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionStringProfile, CommandType.Text, _sb.ToString(), _param);
            return true;
        }


        public IList<MD_ConceptGroup> GetConceptGroups()
        {
            OraMetaDataQueryFactroy _of = new OraMetaDataQueryFactroy();
            return _of.GetConceptList();
        }

        public List<MD_ConceptItem> GetSubConceptTagDefine(string _groupName)
        {
            OraMetaDataQueryFactroy _of = new OraMetaDataQueryFactroy();
            return _of.GetSubConceptTag(_groupName);
        }

        public bool SaveConceptGroup(MD_ConceptGroup _ConceptGroup)
        {
            StringBuilder _sb = new StringBuilder();
            _sb.Append("update md_conceptgroup ");
            _sb.Append(" set groupdes=:DESCRIPT,displayorder=:DISPLAYORDER ");
            _sb.Append(" where groupname=:GROUPNAME ");
            OracleParameter[] _param = {
                                new OracleParameter(":DESCRIPT", OracleDbType.Varchar2),
                                new OracleParameter(":DISPLAYORDER", OracleDbType.Decimal),
                                new OracleParameter(":GROUPNAME", OracleDbType.Varchar2)
                        };
            _param[0].Value = _ConceptGroup.Description;
            _param[1].Value = Convert.ToDecimal(_ConceptGroup.DisplayOrder);
            _param[2].Value = _ConceptGroup.Name;
            OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionStringProfile, CommandType.Text, _sb.ToString(), _param);
            OraMetaDataQueryFactroy.ModelLib.Clear();
            return true;
        }

        public bool IsExistConceptGroup(string _groupName)
        {
            string _sql = "select count(*) from md_conceptgroup WHERE groupname =:GROUPNAME";
            OracleParameter[] _param = {            
                                new OracleParameter(":GROUPNAME",OracleDbType.Varchar2)                                
                        };
            _param[0].Value = _groupName;

            decimal _count = (decimal)OracleHelper.ExecuteScalar(OracleHelper.ConnectionStringProfile, CommandType.Text, _sql, _param);
            return (_count > 0);
        }

        public bool AddNewConceptGroup(string _groupName)
        {
            StringBuilder _sb = new StringBuilder();
            _sb.Append("insert into  md_conceptgroup ");
            _sb.Append(" (GROUPNAME,GROUPDES,DWDM,DISPLAYORDER )");
            _sb.Append(" VALUES (:GROUPNAME,'','',0) ");
            OracleParameter[] _param = {                            
                                new OracleParameter(":GROUPNAME", OracleDbType.Varchar2)
                        };
            _param[0].Value = _groupName;

            OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionStringProfile, CommandType.Text, _sb.ToString(), _param);
            return true;
        }

        public bool DelConcpetGroup(string _groupName)
        {
            StringBuilder _sb = new StringBuilder();
            _sb.Append("delete from  md_conceptgroup ");
            _sb.Append(" where GROUPNAME=:GROUPNAME ");
            OracleParameter[] _param = {                            
                                new OracleParameter(":GROUPNAME", OracleDbType.Varchar2)
                        };
            _param[0].Value = _groupName;

            OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionStringProfile, CommandType.Text, _sb.ToString(), _param);
            OraMetaDataQueryFactroy.ModelLib.Clear();
            return true;
        }

        public bool IsExistChildOfConceptGroup(string _groupName)
        {
            string _sql = "select count(*) from md_concept WHERE groupname =:GROUPNAME";
            OracleParameter[] _param = {            
                                new OracleParameter(":GROUPNAME",OracleDbType.Varchar2)                                
                        };
            _param[0].Value = _groupName;

            decimal _count = (decimal)OracleHelper.ExecuteScalar(OracleHelper.ConnectionStringProfile, CommandType.Text, _sql, _param);
            return (_count > 0);
        }

        public bool IsExistConceptTag(string _TagName)
        {
            string _sql = "select count(*) from md_concept WHERE CTAG =:CTAG";
            OracleParameter[] _param = {            
                                new OracleParameter(":CTAG",OracleDbType.Varchar2)                                
                        };
            _param[0].Value = _TagName;

            decimal _count = (decimal)OracleHelper.ExecuteScalar(OracleHelper.ConnectionStringProfile, CommandType.Text, _sql, _param);
            return (_count > 0);
        }

        public bool AddNewConceptTag(string _TagName, string _description, string _groupName)
        {
            StringBuilder _sb = new StringBuilder();
            _sb.Append("insert into  md_concept ");
            _sb.Append(" (CTAG,DESCRIPT,GROUPNAME,DWDM,DISPLAYORDER )");
            _sb.Append(" VALUES (:CTAG,:DESCRIPT,:GROUPNAME,'',0) ");
            OracleParameter[] _param = {                            
                                new OracleParameter(":CTAG", OracleDbType.Varchar2),
                                new OracleParameter(":DESCRIPT", OracleDbType.Varchar2),
                                new OracleParameter(":GROUPNAME", OracleDbType.Varchar2)
                        };
            _param[0].Value = _TagName;
            _param[1].Value = _description;
            _param[2].Value = _groupName;

            OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionStringProfile, CommandType.Text, _sb.ToString(), _param);
            return true;
        }

        public bool SaveConceptTag(MD_ConceptItem _ConceptItem)
        {
            StringBuilder _sb = new StringBuilder();
            _sb.Append("update md_concept ");
            _sb.Append(" set DESCRIPT=:DESCRIPT,displayorder=:DISPLAYORDER ");
            _sb.Append(" where CTAG=:CTAG ");
            OracleParameter[] _param = {
                                new OracleParameter(":DESCRIPT", OracleDbType.Varchar2),
                                new OracleParameter(":DISPLAYORDER", OracleDbType.Decimal),
                                new OracleParameter(":CTAG", OracleDbType.Varchar2)
                        };
            _param[0].Value = _ConceptItem.Description;
            _param[1].Value = Convert.ToDecimal(_ConceptItem.DisplayOrder);
            _param[2].Value = _ConceptItem.CTag;
            OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionStringProfile, CommandType.Text, _sb.ToString(), _param);
            OraMetaDataQueryFactroy.ModelLib.Clear();
            return true;
        }

        public bool DelConceptTag(string _CTag)
        {
            StringBuilder _sb = new StringBuilder();
            _sb.Append("delete from md_concept ");
            _sb.Append(" where CTAG=:CTAG ");
            OracleParameter[] _param = {                            
                                new OracleParameter(":CTAG", OracleDbType.Varchar2)
                        };
            _param[0].Value = _CTag;
            OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionStringProfile, CommandType.Text, _sb.ToString(), _param);
            OraMetaDataQueryFactroy.ModelLib.Clear();
            return true;
        }

        public MD_GuideLine GetGuideLineDefine(string _guideLineID)
        {
            OraMetaDataQueryFactroy _of = new OraMetaDataQueryFactroy();
            List<MD_GuideLine> _glist = _of.GetRootGuideLineList(_guideLineID);
            if (_glist.Count > 0) return _glist[0];
            return null;
        }

        public List<MD_RightDefine> GetRightData()
        {
            List<MD_RightDefine> _ret = new List<MD_RightDefine>();

            StringBuilder _sql = new StringBuilder();
            _sql.Append(" select QXID,QXMC,QXMS,QXLX,QXMETA,XH,MENUID,SJQXID ");
            _sql.Append(" from qx_qxdyb order by xh");

            OracleDataReader dr = OracleHelper.ExecuteReader(OracleHelper.ConnectionStringProfile, CommandType.Text, _sql.ToString());

            while (dr.Read())
            {
                MD_RightDefine _rd = new MD_RightDefine(dr.IsDBNull(0) ? "" : dr.GetDecimal(0).ToString(),
                                dr.IsDBNull(7) ? "" : dr.GetDecimal(7).ToString(),
                                dr.IsDBNull(1) ? "" : dr.GetString(1),
                                dr.IsDBNull(2) ? "" : dr.GetString(2),
                                dr.IsDBNull(3) ? "" : dr.GetString(3),
                                dr.IsDBNull(4) ? "" : dr.GetString(4),
                                dr.IsDBNull(5) ? 0 : Convert.ToInt32(dr.GetDecimal(5)),
                                dr.IsDBNull(6) ? "" : dr.GetDecimal(6).ToString()
                                );
                _ret.Add(_rd);
            }
            dr.Close();
            return _ret;
        }

        private const string SQL_GetRightData = @"select QXID,QXMC,QXMS,QXLX,QXMETA,XH,MENUID,SJQXID
										from qx_qxdyb 
										where menuid in
										(select m.id from md_mainmenu m where m.systemid=:SYSTEMID) 
										order by xh	";
        public List<MD_RightDefine> GetRightData(string SystemID)
        {
            List<MD_RightDefine> _ret = new List<MD_RightDefine>();
            OracleParameter[] _param = {                            
                                new OracleParameter(":SYSTEMID", OracleDbType.Varchar2)
                        };
            _param[0].Value = SystemID;

            OracleDataReader dr = OracleHelper.ExecuteReader(OracleHelper.ConnectionStringProfile, CommandType.Text, SQL_GetRightData, _param);
            while (dr.Read())
            {
                MD_RightDefine _rd = new MD_RightDefine(dr.IsDBNull(0) ? "" : dr.GetDecimal(0).ToString(),
                                dr.IsDBNull(7) ? "" : dr.GetDecimal(7).ToString(),
                                dr.IsDBNull(1) ? "" : dr.GetString(1),
                                dr.IsDBNull(2) ? "" : dr.GetString(2),
                                dr.IsDBNull(3) ? "" : dr.GetString(3),
                                dr.IsDBNull(4) ? "" : dr.GetString(4),
                                dr.IsDBNull(5) ? 0 : Convert.ToInt32(dr.GetDecimal(5)),
                                dr.IsDBNull(6) ? "" : dr.GetDecimal(6).ToString()
                                );
                _ret.Add(_rd);
            }
            dr.Close();
            return _ret;
        }

        private const string SQL_SetFlag = @"update qx_qxdyb set xh=-1 where QXLX<>'固定菜单' AND SSDWID=:SSDWID";
        private const string SQL_ClearRightsOfNoUse = "delete from qx_qxdyb where QXLX<>'固定菜单' and xh<0 AND SSDWID=:SSDWID";
        private const string SQL_GetAppRights = @"select t.qxid,t.qxmc,t.qxms,'功能注册菜单',t.sjqxid,t.qxmeta,t.xh,t.qxid / 1000 menuid ,
                                                    (select count(qxid) from qx_qxdyb qx where qx.qxid=t.qxid) gs from md_appqxdyb t";

        private const string SQL_InsertAppRights = @"insert into qx_qxdyb (qxid,qxmc,qxms,qxlx,sjqxid,qxmeta,xh,menuid,SSDWID)
                                                            values (:QXID,:QXMC,:QXMS,:QXLX,:SJQXID,:QXMETA,:XH,:MENUID,:SSDWID)";
        private const string SQL_UpdateAppRights = @"update qx_qxdyb set qxmc=:QXMC,qxms=:QXMS,qxlx=:QXLX,sjqxid=:SJQXID,qxmeta=:QXMETA,xh=:XH,menuid=:MENUID 
                                                             where qxid=:QXID AND SSDWID=:SSDWID";
        public bool SaveRightDefine(List<MD_RightDefine> _rightList)
        {
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                OracleTransaction txn = cn.BeginTransaction();
                try
                {
                    #region 设置清除标志

                    OracleCommand _setFlagCmd = new OracleCommand(SQL_SetFlag, cn);
                    _setFlagCmd.Parameters.Add(":SSDWID", decimal.Parse(ConfigFile.SystemID));
                    _setFlagCmd.ExecuteNonQuery();
                    #endregion

                    foreach (MD_RightDefine _rd in _rightList)
                    {
                        bool _isExist = FindRightByID(_rd, cn);
                        if (_isExist)
                        {
                            //使用UPDATE
                            UpdateRightDefine(_rd, cn);
                        }
                        else
                        {
                            //使用INSERT
                            InsertRightDefine(_rd, cn);
                        }
                    }
                }
                catch (Exception ex)
                {
                    txn.Rollback();
                    cn.Close();
                    throw new Exception(string.Format("更新菜单项限项时发出错误：{0}", ex.Message));
                }

                try
                {
                    #region 取功能注册中定义的权限项并更新
                    OracleCommand _getRightCmd = new OracleCommand(SQL_GetAppRights, cn);
                    OracleDataReader _dr = _getRightCmd.ExecuteReader();
                    while (_dr.Read())
                    {
                        decimal qxid = _dr.IsDBNull(0) ? (decimal)-1 : _dr.GetDecimal(0);
                        string qxmc = _dr.IsDBNull(1) ? "" : _dr.GetString(1);
                        string qxms = _dr.IsDBNull(2) ? "" : _dr.GetString(2);
                        string qxlx = "功能注册菜单";
                        decimal sjqxid = _dr.IsDBNull(4) ? (decimal)-1 : _dr.GetDecimal(4);
                        string qxmeta = _dr.IsDBNull(5) ? "" : _dr.GetString(5);
                        decimal xh = _dr.IsDBNull(6) ? (decimal)0 : _dr.GetDecimal(6);
                        decimal menuid = _dr.IsDBNull(7) ? (decimal)-1 : _dr.GetDecimal(7);
                        decimal gs = _dr.IsDBNull(8) ? (decimal)0 : _dr.GetDecimal(8);

                        if (gs > 0)
                        {
                            #region 更新权限定义记录
                            OracleCommand _updateAppRight = new OracleCommand(SQL_UpdateAppRights, cn);
                            _updateAppRight.Parameters.Add(":QXMC", qxmc);
                            _updateAppRight.Parameters.Add(":QXMS", qxms);
                            _updateAppRight.Parameters.Add(":QXLX", qxlx);
                            _updateAppRight.Parameters.Add(":SJQXID", sjqxid);
                            _updateAppRight.Parameters.Add(":QXMETA", qxmeta);
                            _updateAppRight.Parameters.Add(":XH", xh);
                            _updateAppRight.Parameters.Add(":MENUID", menuid);
                            _updateAppRight.Parameters.Add(":QXID", qxid);
                            _updateAppRight.Parameters.Add(":SSDWID", decimal.Parse(ConfigFile.SystemID));
                            _updateAppRight.ExecuteNonQuery();
                            #endregion
                        }
                        else
                        {
                            #region 插入新权限定义记录
                            OracleCommand _insAppRight = new OracleCommand(SQL_InsertAppRights, cn);
                            _insAppRight.Parameters.Add(":QXID", qxid);
                            _insAppRight.Parameters.Add(":QXMC", qxmc);
                            _insAppRight.Parameters.Add(":QXMS", qxms);
                            _insAppRight.Parameters.Add(":QXLX", qxlx);
                            _insAppRight.Parameters.Add(":SJQXID", sjqxid);
                            _insAppRight.Parameters.Add(":QXMETA", qxmeta);
                            _insAppRight.Parameters.Add(":XH", xh);
                            _insAppRight.Parameters.Add(":MENUID", menuid);
                            _insAppRight.Parameters.Add(":SSDWID", decimal.Parse(ConfigFile.SystemID));
                            _insAppRight.ExecuteNonQuery();
                            #endregion
                        }
                    }
                    _dr.Close();

                    #endregion

                }
                catch (Exception ex)
                {
                    txn.Rollback();
                    cn.Close();
                    throw new Exception(string.Format("插入功能注册中定义的权限项时发出错误：{0}", ex.Message));
                }

                try
                {
                    #region 清除要删除的无用记录
                    OracleCommand _delCmd = new OracleCommand(SQL_ClearRightsOfNoUse, cn);
                    _delCmd.Parameters.Add(":SSDWID", decimal.Parse(ConfigFile.SystemID));
                    _delCmd.ExecuteNonQuery();
                    #endregion
                }
                catch (Exception ex)
                {
                    txn.Rollback();
                    cn.Close();
                    throw new Exception(string.Format("清除非固定菜单的多余记录时发出错误：{0}", ex.Message));
                }


                txn.Commit();
                cn.Close();
                return true;
            }

        }

        private bool FindRightByID(MD_RightDefine _rd, OracleConnection cn)
        {
            string _sql = "select count(QXID) from qx_qxdyb where QXID=:QXID";
            OracleCommand _cmd = new OracleCommand(_sql, cn);
            _cmd.Parameters.Add(":QXID", decimal.Parse(_rd.RightID));
            decimal _ret = (decimal)_cmd.ExecuteScalar();
            return _ret > 0;
        }

        private const string SQL_UpdateRightDefine = @"update  qx_qxdyb
                                                       set QXMC=:QXMC,QXMS=:QXMS,QXLX=:QXLX,QXMETA=:QXMETA,
                                                         XH=:XH,MENUID=:MENUID,SJQXID=:SJQXID,SSDWID=:SSDWID
                                                        WHERE QXID=:QXID  ";
        private void UpdateRightDefine(MD_RightDefine _rd, OracleConnection cn)
        {
            //添加新权限表内容           
            OracleCommand _cmd = new OracleCommand(SQL_UpdateRightDefine, cn);
            _cmd.Parameters.Add(":QXMC", _rd.RightName);
            _cmd.Parameters.Add(":QXMS", _rd.RightDescript);
            _cmd.Parameters.Add(":QXLX", _rd.RightType);
            _cmd.Parameters.Add(":QXMETA", _rd.RightMeta);
            _cmd.Parameters.Add(":XH", Convert.ToDecimal(_rd.DisplayOrder));
            _cmd.Parameters.Add(":MENUID", decimal.Parse(_rd.MenuID));
            _cmd.Parameters.Add(":SJQXID", (_rd.FatherRightID == "") ? (decimal)-1 : decimal.Parse(_rd.FatherRightID));
            _cmd.Parameters.Add(":SSDWID", decimal.Parse(ConfigFile.SystemID));
            _cmd.Parameters.Add(":QXID", decimal.Parse(_rd.RightID));
            _cmd.ExecuteNonQuery();
        }

        private const string SQL_InsertRightDefine = @"insert into qx_qxdyb
                                                        (QXID,QXMC,QXMS,QXLX,QXMETA,XH,MENUID,SJQXID,SSDWID) values 
                                                        (:QXID,:QXMC,:QXMS,:QXLX,:QXMETA,:XH,:MENUID,:SJQXID,:SSDWID)";
        private void InsertRightDefine(MD_RightDefine _rd, OracleConnection cn)
        {
            //添加新权限表内容

            OracleCommand _cmd = new OracleCommand(SQL_InsertRightDefine, cn);
            _cmd.Parameters.Add(":QXID", decimal.Parse(_rd.RightID));
            _cmd.Parameters.Add(":QXMC", _rd.RightName);
            _cmd.Parameters.Add(":QXMS", _rd.RightDescript);
            _cmd.Parameters.Add(":QXLX", _rd.RightType);
            _cmd.Parameters.Add(":QXMETA", _rd.RightMeta);
            _cmd.Parameters.Add(":XH", Convert.ToDecimal(_rd.DisplayOrder));
            _cmd.Parameters.Add(":MENUID", decimal.Parse(_rd.MenuID));
            _cmd.Parameters.Add(":SJQXID", (_rd.FatherRightID == "") ? (decimal)-1 : decimal.Parse(_rd.FatherRightID));
            _cmd.Parameters.Add(":SSDWID", decimal.Parse(ConfigFile.SystemID));
            _cmd.ExecuteNonQuery();
        }



        public string AddTableRelationView(string _tableID, string _modelName)
        {
            //查找是否已经有此关联定义
            string _isExistSql = "select count(id) from MD_TABLE2VIEW where TID=:TID and VIEWNAME=:VIEWNAME ";
            OracleParameter[] _isParam = {                            
                                new OracleParameter(":TID", OracleDbType.Decimal),
                                new OracleParameter(":VIEWNAME",OracleDbType.Varchar2,1000)
                        };
            _isParam[0].Value = decimal.Parse(_tableID);
            _isParam[1].Value = _modelName;

            decimal _isResult = (decimal)OracleHelper.ExecuteScalar(OracleHelper.ConnectionStringProfile, CommandType.Text, _isExistSql, _isParam);
            if (_isResult > 0)
            {
                return string.Format("此表对应查询模型[{0}]的关联定义已经存在!", _modelName);
            }

            //添加关联定义
            StringBuilder _sb = new StringBuilder();
            _sb.Append(" insert into MD_TABLE2VIEW (ID,TID,VIEWNAME,CONDITIONSTR) ");
            _sb.Append(" values (:ID,:TID,:VIEWNAME,'') ");
            OracleParameter[] _Param = {                            
                                new OracleParameter(":ID", Guid.NewGuid().ToString()),
                                new OracleParameter(":TID",decimal.Parse(_tableID)),
                                new OracleParameter(":VIEWNAME",_modelName)
                        };
            OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionStringProfile, CommandType.Text, _sb.ToString(), _Param);
            return "";
        }

        private const string SQL_GetAllQueryModelNames = @"select NAMESPACE,VIEWNAME from MD_VIEW ";
        public List<string> GetAllQueryModelNames()
        {
            List<string> _ret = new List<string>();
            OracleDataReader dr = OracleHelper.ExecuteReader(OracleHelper.ConnectionStringProfile, CommandType.Text, SQL_GetAllQueryModelNames);

            while (dr.Read())
            {
                _ret.Add(string.Format("{0}.{1}",
                                dr.IsDBNull(0) ? "" : dr.GetString(0),
                                dr.IsDBNull(1) ? "" : dr.GetString(1)
                )
                );
            }
            dr.Close();
            return _ret;
        }

        private const string SQL_GetTable2ViewList = @"select ID,TID,VIEWNAME,CONDITIONSTR,CONFINE from MD_TABLE2VIEW where TID=:TID";
        public List<MD_Table2View> GetTable2ViewList(string _tid)
        {
            List<MD_Table2View> _ret = new List<MD_Table2View>();
            OracleParameter[] _Param = { new OracleParameter(":TID", decimal.Parse(_tid)) };
            OracleDataReader dr = OracleHelper.ExecuteReader(OracleHelper.ConnectionStringProfile, CommandType.Text, SQL_GetTable2ViewList, _Param);

            while (dr.Read())
            {
                MD_Table2View _t2v = new MD_Table2View(
                                dr.IsDBNull(0) ? "" : dr.GetString(0),
                                dr.IsDBNull(1) ? "" : dr.GetDecimal(1).ToString(),
                                dr.IsDBNull(2) ? "" : dr.GetString(2),
                                dr.IsDBNull(3) ? "" : dr.GetString(3),
                                dr.IsDBNull(4) ? "" : dr.GetString(4));
                _ret.Add(_t2v);
            }
            dr.Close();
            return _ret;
        }

        private const string SQL_GetView2GuideLineList = @"select ID,VIEWID,TARGETGL,TARGETCS,DISPLAYORDER,DISPLAYTITLE from MD_VIEW2GL where VIEWID=:VID order by DISPLAYORDER";
        public IList<MD_View_GuideLine> GetView2GuideLineList(string QueryModelID)
        {
            List<MD_View_GuideLine> _ret = new List<MD_View_GuideLine>();
            OracleParameter[] _Param = { new OracleParameter(":VID", QueryModelID) };
            OracleDataReader dr = OracleHelper.ExecuteReader(OracleHelper.ConnectionStringProfile, CommandType.Text, SQL_GetView2GuideLineList, _Param);
            while (dr.Read())
            {
                MD_View_GuideLine _mvg = new MD_View_GuideLine();
                _mvg.ID = dr.IsDBNull(0) ? "" : dr.GetString(0);
                _mvg.ViewID = dr.IsDBNull(1) ? "" : dr.GetString(1);
                _mvg.TargetGuideLineID = dr.IsDBNull(2) ? "" : dr.GetString(2);
                _mvg.RelationParam = dr.IsDBNull(3) ? "" : dr.GetString(3);
                _mvg.DisplayOrder = dr.IsDBNull(4) ? 0 : Convert.ToInt32(dr.GetDecimal(4));
                _mvg.DisplayTitle = dr.IsDBNull(5) ? "" : dr.GetString(5);
                _ret.Add(_mvg);
            }
            dr.Close();
            return _ret;
        }

        public bool SaveQueryModel_UserDefine(string _queryModelID, string _display, string _descript)
        {
            try
            {
                string _ups = "update MD_VIEW set displayname=:DISPLAYNAME, DESCRIPTION=:DESCRIPTION ";
                _ups += " where VIEWID=:VIEWID ";
                OracleParameter[] _params = {                            
                                        new OracleParameter(":DISPLAYNAME", OracleDbType.Varchar2,100),
                                        new OracleParameter(":DESCRIPTION",OracleDbType.Varchar2,100),
                                        new OracleParameter(":VIEWID",OracleDbType.Decimal)
                                 };
                _params[0].Value = _display;
                _params[1].Value = _descript;
                _params[2].Value = decimal.Parse(_queryModelID);

                OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionStringProfile, CommandType.Text, _ups, _params);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }


        public bool SaveViewTable_UserDefine(string _viewTableID, string _displayString, MDType_DisplayType _displayType, List<MD_ViewTableColumn> TableColumnDefine)
        {
            #region 更新MD_VIEWTABLE表
            string _ups = "update md_viewtable set DISPLAYNAME=:DISPLAYNAME,DISPLAYTYPE=:DISPLAYTYPE where VTID=:VTID";
            OracleParameter[] _param = {
                                new OracleParameter(":DISPLAYNAME", OracleDbType.Varchar2),
                                new OracleParameter(":DISPLAYTYPE",OracleDbType.Decimal),
                               new OracleParameter(":VTID",OracleDbType.Decimal)
                        };
            _param[0].Value = _displayString;
            _param[1].Value = (_displayType == MDType_DisplayType.FormType) ? (decimal)1 : (decimal)0;
            _param[2].Value = decimal.Parse(_viewTableID);
            OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionStringProfile, CommandType.Text, _ups, _param);

            #endregion

            #region 更新MD_TABLECOLUMN表
            string _up = "update md_tablecolumn set DISPLAYTITLE=:DISPLAYTITLE,DISPLAYLENGTH=:DISPLAYLENGTH,DISPLAYHEIGHT=:DISPLAYHEIGHT,DISPLAYORDER=:DISPLAYORDER,colwidth=:DISPLAYWIDTH ";
            _up += " WHERE TCID=:TCID ";
            foreach (MD_ViewTableColumn _tc in TableColumnDefine)
            {
                OracleParameter[] _param4 = {
                                        new OracleParameter(":DISPLAYTITLE", OracleDbType.Varchar2,50),
                                        new OracleParameter(":DISPLAYLENGTH", OracleDbType.Decimal),
                                        new OracleParameter(":DISPLAYHEIGHT", OracleDbType.Decimal),
                                        new OracleParameter(":DISPLAYORDER", OracleDbType.Decimal),  
                                        new OracleParameter(":DISPLAYWIDTH",OracleDbType.Decimal),
                                        new OracleParameter(":TCID",OracleDbType.Decimal)
                                };
                _param4[0].Value = _tc.TableColumn.DisplayTitle;
                _param4[1].Value = Convert.ToDecimal(_tc.TableColumn.DisplayLength);
                _param4[2].Value = Convert.ToDecimal(_tc.TableColumn.DisplayHeight);
                _param4[3].Value = Convert.ToDecimal(_tc.DisplayOrder);
                _param4[4].Value = Convert.ToDecimal(_tc.TableColumn.ColWidth);
                _param4[5].Value = decimal.Parse(_tc.ColumnID);
                OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionStringProfile, CommandType.Text, _up, _param4);
            }
            #endregion


            #region 更新MD_VIEWTABLECOLUMN表
            //清除所有字段定义
            string _del = "delete from MD_VIEWTABLECOLUMN where VTID=:VTID";
            OracleParameter[] _param2 = {
                               new OracleParameter(":VTID",OracleDbType.Decimal)
                        };
            _param2[0].Value = Convert.ToDecimal(_viewTableID);
            OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionStringProfile, CommandType.Text, _del, _param2);

            StringBuilder _sb = new StringBuilder();
            _sb.Append(" insert into MD_VIEWTABLECOLUMN (VTCID,VTID,TCID,");
            _sb.Append(" CANCONDITIONSHOW,CANRESULTSHOW,DEFAULTSHOW,");
            _sb.Append(" DWDM,FIXQUERYITEM,CANMODIFY,PRIORITY,DISPLAYORDER) ");
            _sb.Append(" VALUES (:VTCID,:VTID,:TCID,");
            _sb.Append(" :CANCONDITIONSHOW,:CANRESULTSHOW,:DEFAULTSHOW,");
            _sb.Append(" :DWDM,:FIXQUERYITEM,:CANMODIFY,:PRIORITY,:DISPLAYORDER) ");
            //保存字段定义信息
            foreach (MD_ViewTableColumn _tc in TableColumnDefine)
            {
                OracleParameter[] _param3 = {
                                        new OracleParameter(":VTCID", OracleDbType.Decimal),
                                        new OracleParameter(":VTID", OracleDbType.Decimal),
                                        new OracleParameter(":TCID", OracleDbType.Decimal),
                                        new OracleParameter(":CANCONDITIONSHOW", OracleDbType.Decimal),
                                        new OracleParameter(":CANRESULTSHOW", OracleDbType.Decimal),
                                        new OracleParameter(":DEFAULTSHOW", OracleDbType.Decimal),
                                        new OracleParameter(":DWDM",OracleDbType.Varchar2,12),
                                        new OracleParameter(":FIXQUERYITEM",OracleDbType.Decimal),
                                        new OracleParameter(":CANMODIFY",OracleDbType.Decimal),
                                        new OracleParameter(":PRIORITY",OracleDbType.Decimal),
                                        new OracleParameter(":DISPLAYORDER",OracleDbType.Decimal)
                                };
                _param3[0].Value = Convert.ToDecimal(_tc.ViewTableColumnID);
                _param3[1].Value = Convert.ToDecimal(_viewTableID);
                _param3[2].Value = Convert.ToDecimal(_tc.ColumnID);
                _param3[3].Value = _tc.CanShowAsCondition ? 1 : 0;
                _param3[4].Value = _tc.CanShowAsResult ? 1 : 0;
                _param3[5].Value = _tc.DefaultResult ? 1 : 0;
                _param3[6].Value = _tc.DWDM;
                _param3[7].Value = _tc.IsFixQueryItem ? 1 : 0;
                _param3[8].Value = _tc.CanModify ? 1 : 0;
                _param3[9].Value = Convert.ToDecimal(_tc.Priority);
                _param3[10].Value = Convert.ToDecimal(_tc.DisplayOrder);
                OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionStringProfile, CommandType.Text, _sb.ToString(), _param3);
            }
            #endregion

            OraMetaDataQueryFactroy.ModelLib.Clear();
            return true;
        }


        public void SaveViewTableOrder_UserDefine(Dictionary<string, int> ChildTableOrder)
        {
            string _ups = "update md_viewtable set DISPLAYORDER=:DISPLAYORDER where VTID=:VTID";

            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                OracleTransaction txn = cn.BeginTransaction();
                try
                {
                    foreach (string _s in ChildTableOrder.Keys)
                    {
                        OracleCommand _cmd = new OracleCommand(_ups, cn);
                        _cmd.Parameters.Add(":DISPLAYORDER", Convert.ToDecimal(ChildTableOrder[_s]));
                        _cmd.Parameters.Add(":VTID", decimal.Parse(_s));
                        _cmd.ExecuteNonQuery();
                    }
                    txn.Commit();
                }
                catch (Exception e)
                {
                    txn.Rollback();
                    string _errmsg = string.Format("执行保存查询模型子表的顺序数据时出错,错误信息为:{0}!",
                             e.Message);
                    OralceLogWriter.WriteSystemLog(_errmsg, "ERROR");
                }
                cn.Close();
            }
            return;
        }

        private const string SQL_GetInputModelOfNamespace = @"select IV_ID,NAMESPACE,IV_NAME,DESCRIPTION,DISPLAYNAME,DISPLAYORDER,IV_CS,TID,DELRULE,DWDM,INTEGRATEDAPP,RESTYPE
                                                                 from MD_INPUTVIEW where NAMESPACE = :NAMESPACE order by DISPLAYORDER";
        public IList<MD_InputModel> GetInputModelOfNamespace(string _namespace)
        {
            IList<MD_InputModel> _ret = new List<MD_InputModel>();

            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                OracleCommand _cmd = new OracleCommand(SQL_GetInputModelOfNamespace, cn);
                _cmd.Parameters.Add(":NAMESPACE", _namespace);

                OracleDataReader _dr = _cmd.ExecuteReader();
                while (_dr.Read())
                {
                    MD_InputModel _model = new MD_InputModel(
                                    _dr.IsDBNull(0) ? "" : _dr.GetDecimal(0).ToString(),
                                    _dr.IsDBNull(1) ? "" : _dr.GetString(1),
                                    _dr.IsDBNull(2) ? "" : _dr.GetString(2),
                                    _dr.IsDBNull(3) ? "" : _dr.GetString(3),
                                    _dr.IsDBNull(4) ? "" : _dr.GetString(4),
                                    _dr.IsDBNull(5) ? (int)0 : Convert.ToInt32(_dr.GetDecimal(5)),
                                    _dr.IsDBNull(6) ? "" : _dr.GetString(6),
                                    _dr.IsDBNull(8) ? "" : _dr.GetString(8),
                                    _dr.IsDBNull(9) ? "" : _dr.GetString(9),
                                    _dr.IsDBNull(10) ? "" : _dr.GetString(10),
                                    _dr.IsDBNull(11) ? "" : _dr.GetString(11)
                    );
                    _ret.Add(_model);
                }
                _dr.Close();

                foreach (MD_InputModel _model in _ret)
                {
                    string _tname = StrUtils.GetMetaByName2("TABLE", _model.Param);
                    string _orderField = StrUtils.GetMetaByName2("ORDER", _model.Param);
                    string _modelType = StrUtils.GetMetaByName2("TYPE", _model.Param);
                    string _paramType = StrUtils.GetMetaByName2("PARAMTYPE", _model.Param);
                    _model.ModelType = (_modelType == "") ? "GRID" : _modelType.ToUpper();
                    _model.ParamterType = (_paramType == "") ? "OTHER" : _paramType.ToUpper();
                    _model.InitGuideLine = StrUtils.GetMetaByName2("INITZB", _model.Param);
                    _model.GetDataGuideLine = StrUtils.GetMetaByName2("GETZB", _model.Param);
                    _model.GetNewRecordGuideLine = StrUtils.GetMetaByName2("NEWZB", _model.Param);
                    _model.OrderField = _orderField;
                    _model.TableName = _tname;
                    _model.Groups = GetInputColumnGroups(_model, cn);
                    _model.WriteTableNames = GetWriteDesTableOfInputModel(_model, cn);
                    _model.ChildInputModel = GetChildInputModel(_model, cn);

                }
                cn.Close();
            }

            return _ret;
        }

        private const string SQL_GetInputColumnGroups = @"select  IVG_ID,IV_ID,DISPLAYTITLE,DISPLAYORDER,GROUPTYPE,APPREGURL,GROUPCS
                                                            from md_inputgroup where IV_ID = :IVID order by DISPLAYORDER";
        private List<MD_InputModel_ColumnGroup> GetInputColumnGroups(MD_InputModel _model, OracleConnection cn)
        {
            List<MD_InputModel_ColumnGroup> _ret = new List<MD_InputModel_ColumnGroup>();
            StringBuilder _sb = new StringBuilder();
            OracleCommand _cmd = new OracleCommand(SQL_GetInputColumnGroups, cn);
            _cmd.Parameters.Add(":IVID", _model.ID);
            OracleDataReader _dr = _cmd.ExecuteReader();
            while (_dr.Read())
            {
                MD_InputModel_ColumnGroup _g = new MD_InputModel_ColumnGroup(
                                _dr.IsDBNull(0) ? "" : _dr.GetDecimal(0).ToString(),
                                _model.ID,
                                _dr.IsDBNull(2) ? "" : _dr.GetString(2),
                                _dr.IsDBNull(3) ? 0 : Convert.ToInt32(_dr.GetDecimal(3))
                );
                _g.GroupType = _dr.IsDBNull(4) ? "DEFAULT" : _dr.GetString(4).ToUpper();
                _g.AppRegUrl = _dr.IsDBNull(5) ? "" : _dr.GetString(5);
                _g.GroupParam = _dr.IsDBNull(6) ? "" : _dr.GetString(6);
                _ret.Add(_g);

            }
            _dr.Close();
            return _ret;
        }

        private const string SQL_GetWriteDesTableOfInputModel = @"select  ID,TABLENAME,TABLETITLE,ISLOCK,DISPLAYORDER,SAVEMODE
                                                                    from MD_INPUTTABLE where IV_ID = :IVID order by DISPLAYORDER";
        private List<MD_InputModel_SaveTable> GetWriteDesTableOfInputModel(MD_InputModel _model, OracleConnection cn)
        {
            List<MD_InputModel_SaveTable> _ret = new List<MD_InputModel_SaveTable>();
            OracleCommand _cmd = new OracleCommand(SQL_GetWriteDesTableOfInputModel, cn);
            _cmd.Parameters.Add(":IVID", _model.ID);
            OracleDataReader _dr = _cmd.ExecuteReader();
            while (_dr.Read())
            {
                MD_InputModel_SaveTable _tb = new MD_InputModel_SaveTable(
                                _dr.IsDBNull(0) ? "" : _dr.GetDecimal(0).ToString(),
                                _dr.IsDBNull(1) ? "" : _dr.GetString(1),
                                _dr.IsDBNull(2) ? "" : _dr.GetString(2),
                                _dr.IsDBNull(3) ? true : (_dr.GetDecimal(3) > 0),
                                _model.ID,
                                _dr.IsDBNull(4) ? 0 : Convert.ToInt32(_dr.GetDecimal(4)),
                                _dr.IsDBNull(5) ? "" : _dr.GetString(5)
                );
                GetInputModelSaveTableColumn(_tb, cn);
                _ret.Add(_tb);

            }
            _dr.Close();
            return _ret;
        }

        private const string SQL_GetInputModelSaveTableColumn = @"select ID,SRCCOL,DESCOL,METHOD,DESDES from MD_INPUTTABLECOLUMN where IVT_ID=:TID";
        private void GetInputModelSaveTableColumn(MD_InputModel_SaveTable _tb, OracleConnection cn)
        {
            OracleCommand _cmd = new OracleCommand(SQL_GetInputModelSaveTableColumn, cn);
            _cmd.Parameters.Add(":TID", decimal.Parse(_tb.ID));
            OracleDataReader _dr = _cmd.ExecuteReader();
            if (_tb.Columns == null) _tb.Columns = new List<MD_InputModel_SaveTableColumn>();
            while (_dr.Read())
            {
                MD_InputModel_SaveTableColumn _col = new MD_InputModel_SaveTableColumn(
                                _dr.IsDBNull(0) ? "" : _dr.GetDecimal(0).ToString(),
                                _dr.IsDBNull(1) ? "" : _dr.GetString(1),
                                _dr.IsDBNull(2) ? "" : _dr.GetString(2),
                                _dr.IsDBNull(3) ? "" : _dr.GetString(3),
                                 _dr.IsDBNull(4) ? "" : _dr.GetString(4)
                );
                _tb.Columns.Add(_col);
            }
            _dr.Close();
        }


        private const string SQL_GetInputModel = @"select IV_ID,NAMESPACE,IV_NAME,DESCRIPTION,DISPLAYNAME,DISPLAYORDER,IV_CS,TID,DELRULE,DWDM,INTEGRATEDAPP,RESTYPE
                                                    from MD_INPUTVIEW where NAMESPACE = :NAMESPACE and IV_NAME=:IVNAME order by DISPLAYORDER";
        public MD_InputModel GetInputModel(string _namespace, string ModelName)
        {
            MD_InputModel _model = null;
            StringBuilder _sb = new StringBuilder();
            _sb.Append("");
            _sb.Append(" ");

            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                OracleCommand _cmd = new OracleCommand(SQL_GetInputModel, cn);
                _cmd.Parameters.Add(":NAMESPACE", _namespace);
                _cmd.Parameters.Add(":IVNAME", ModelName);

                OracleDataReader _dr = _cmd.ExecuteReader();
                while (_dr.Read())
                {
                    _model = new MD_InputModel(
                                    _dr.IsDBNull(0) ? "" : _dr.GetDecimal(0).ToString(),
                                    _dr.IsDBNull(1) ? "" : _dr.GetString(1),
                                    _dr.IsDBNull(2) ? "" : _dr.GetString(2),
                                    _dr.IsDBNull(3) ? "" : _dr.GetString(3),
                                    _dr.IsDBNull(4) ? "" : _dr.GetString(4),
                                    _dr.IsDBNull(5) ? (int)0 : Convert.ToInt32(_dr.GetDecimal(5)),
                                    _dr.IsDBNull(6) ? "" : _dr.GetString(6),
                                    _dr.IsDBNull(8) ? "" : _dr.GetString(8),
                                    _dr.IsDBNull(9) ? "" : _dr.GetString(9),
                                    _dr.IsDBNull(10) ? "" : _dr.GetString(10),
                                    _dr.IsDBNull(11) ? "" : _dr.GetString(11)
                    );

                    string _tname = StrUtils.GetMetaByName2("TABLE", _model.Param);
                    string _orderField = StrUtils.GetMetaByName2("ORDER", _model.Param);
                    string _modelType = StrUtils.GetMetaByName2("TYPE", _model.Param);
                    string _paramType = StrUtils.GetMetaByName2("PARAMTYPE", _model.Param);
                    _model.ModelType = (_modelType == "") ? "GRID" : _modelType.ToUpper();
                    _model.ParamterType = (_paramType == "") ? "OTHER" : _paramType.ToUpper();
                    _model.InitGuideLine = StrUtils.GetMetaByName2("INITZB", _model.Param);
                    _model.GetDataGuideLine = StrUtils.GetMetaByName2("GETZB", _model.Param);
                    _model.GetNewRecordGuideLine = StrUtils.GetMetaByName2("NEWZB", _model.Param);
                    _model.OrderField = _orderField;
                    _model.TableName = _tname;
                    _model.WriteTableNames = GetWriteDesTableOfInputModel(_model, cn);
                    _model.ChildInputModel = GetChildInputModel(_model, cn);
                }
                _dr.Close();
                cn.Close();
            }

            return _model;
        }

        private const string SQL_GetChildInputModel = @"select  t.ID,t.IV_ID,t.CIV_ID,t.PARAM, iv.NAMESPACE CNS ,iv.IV_NAME CIVNAME,t. DISPLAYORDER,t.SHOWCONDITION,t.SELECTMODE
                                                        from MD_INPUTVIEWCHILD t,MD_INPUTVIEW iv  where t.IV_ID = :IVID and t.CIV_ID =iv.IV_ID 
                                                        order by t.DISPLAYORDER";
        public List<MD_InputModel_Child> GetChildInputModel(MD_InputModel _model, OracleConnection cn)
        {
            List<MD_InputModel_Child> _ret = new List<MD_InputModel_Child>();
            OracleCommand _cmd = new OracleCommand(SQL_GetChildInputModel, cn);
            _cmd.Parameters.Add(":IVID", _model.ID);
            OracleDataReader _dr = _cmd.ExecuteReader();
            while (_dr.Read())
            {
                string _cns = _dr.IsDBNull(4) ? "" : _dr.GetString(4);
                string _cname = _dr.IsDBNull(5) ? "" : _dr.GetString(5);
                string _paramstring = _dr.IsDBNull(3) ? "" : _dr.GetString(3);
                MD_InputModel_Child _child = new MD_InputModel_Child(
                                _dr.IsDBNull(0) ? "" : _dr.GetDecimal(0).ToString(),
                                string.Format("{0}.{1}", _model.NameSpace, _model.ModelName),
                                string.Format("{0}.{1}", _cns, _cname),
                                _dr.IsDBNull(6) ? 0 : Convert.ToInt32(_dr.GetDecimal(6))
                );
                _child.ShowCondition = _dr.IsDBNull(7) ? "" : _dr.GetString(7);
                _child.SelectMode = _dr.IsDBNull(8) ? 0 : Convert.ToInt16(_dr.GetDecimal(8));
                _child.ChildModel = GetInputModel(_cns, _cname);
                if (_child.Parameters == null) _child.Parameters = new List<MD_InputModel_ChildParam>();
                foreach (string _pstr in StrUtils.GetMetasByName2("PARAM", _paramstring))
                {
                    string[] _s = _pstr.Split(':');
                    MD_InputModel_ChildParam _p = new MD_InputModel_ChildParam(_s[0], _s[1], _s[2]);
                    _child.Parameters.Add(_p);
                }

                _ret.Add(_child);

            }
            _dr.Close();
            return _ret;
        }

        private const string SQL_SaveInputModel = @"update MD_INPUTVIEW
                                                    set IV_NAME=:IV_NAME,DESCRIPTION=:DESCRIPTION,
                                                    DISPLAYNAME=:DISPLAYNAME,DISPLAYORDER=:DISPLAYORDER,IV_CS=:IV_CS,
                                                    DELRULE=:DELRULE,DWDM=:DWDM,INTEGRATEDAPP=:INTEGRATEDAPP,RESTYPE=:RESTYPE,
                                                    BEFOREWRITE=:BEFOREWRITE,AFTERWRITE=:AFTERWRITE
                                                    where IV_ID =:IV_ID ";
        public bool SaveInputModel(MD_InputModel SaveModel)
        {
            try
            {
                using (OracleConnection cn = OracleHelper.OpenConnection())
                {
                    OracleCommand _cmd = new OracleCommand(SQL_SaveInputModel, cn);
                    _cmd.Parameters.Add(":IV_NAME", SaveModel.ModelName);
                    _cmd.Parameters.Add(":DESCRIPTION", SaveModel.Descript);
                    _cmd.Parameters.Add(":DISPLAYNAME", SaveModel.DisplayName);
                    _cmd.Parameters.Add(":DISPLAYORDER", Convert.ToDecimal(SaveModel.DisplayOrder));
                    StringBuilder _cs = new StringBuilder();
                    _cs.Append(string.Format("<TABLE>{0}</TABLE>", SaveModel.TableName));
                    _cs.Append(string.Format("<ORDER>{0}</ORDER>", SaveModel.OrderField));
                    _cs.Append(string.Format("<TYPE>{0}</TYPE>", SaveModel.ModelType));
                    _cs.Append(string.Format("<PARAMTYPE>{0}</PARAMTYPE>", SaveModel.ParamterType));
                    _cs.Append(string.Format("<INITZB>{0}</INITZB>", SaveModel.InitGuideLine));
                    _cs.Append(string.Format("<GETZB>{0}</GETZB>", SaveModel.GetDataGuideLine));
                    _cs.Append(string.Format("<NEWZB>{0}</NEWZB>", SaveModel.GetNewRecordGuideLine));
                    _cmd.Parameters.Add(":IV_CS", _cs.ToString());
                    _cmd.Parameters.Add(":DELRULE", SaveModel.DeleteRule);
                    _cmd.Parameters.Add(":DWDM", SaveModel.DWDM);
                    _cmd.Parameters.Add(":INTEGRATEDAPP", SaveModel.IntegretedApplication);
                    _cmd.Parameters.Add(":RESTYPE", SaveModel.ResourceType);
                    _cmd.Parameters.Add(":BEFOREWRITE", SaveModel.BeforeWrite);
                    _cmd.Parameters.Add(":AFTERWRITE", SaveModel.AfterWrite);
                    _cmd.Parameters.Add(":IV_ID", SaveModel.ID);
                    _cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        private const string SQL_SaveNewInputModel = @"INSERT INTO MD_INPUTVIEW
                                                        (IV_ID,NAMESPACE,IV_NAME,DESCRIPTION,
                                                        DISPLAYNAME,DISPLAYORDER,IV_CS,TID,
                                                        DELRULE,DWDM ) values 
                                                        (:IV_ID,:NAMESPACE,:IV_NAME,:DESCRIPTION,
                                                        :DISPLAYNAME,:DISPLAYORDER,:IV_CS,null,
                                                        :DELRULE,:DWDM ) ";
        public bool SaveNewInputModel(string _namespace, MD_InputModel SaveModel)
        {
            try
            {

                using (OracleConnection cn = OracleHelper.OpenConnection())
                {
                    OracleCommand _cmd = new OracleCommand(SQL_SaveNewInputModel, cn);
                    _cmd.Parameters.Add(":IV_ID", GetNewID());
                    _cmd.Parameters.Add(":NAMESPACE", _namespace);
                    _cmd.Parameters.Add(":IV_NAME", SaveModel.ModelName);
                    _cmd.Parameters.Add(":DESCRIPTION", SaveModel.Descript);

                    _cmd.Parameters.Add(":DISPLAYNAME", SaveModel.DisplayName);
                    _cmd.Parameters.Add(":DISPLAYORDER", Convert.ToDecimal(SaveModel.DisplayOrder));

                    StringBuilder _cs = new StringBuilder();
                    _cs.Append(string.Format("<TABLE>{0}</TABLE>", SaveModel.TableName));
                    _cs.Append(string.Format("<ORDER>{0}</ORDER>", SaveModel.OrderField));
                    _cs.Append(string.Format("<TYPE>{0}</TYPE>", SaveModel.ModelType));
                    _cs.Append(string.Format("<PARAMTYPE>{0}</PARAMTYPE>", SaveModel.ParamterType));
                    _cs.Append(string.Format("<INITZB>{0}</INITZB>", SaveModel.InitGuideLine));
                    _cs.Append(string.Format("<GETZB>{0}</GETZB>", SaveModel.GetDataGuideLine));
                    _cs.Append(string.Format("<NEWZB>{0}</NEWZB>", SaveModel.GetNewRecordGuideLine));

                    _cmd.Parameters.Add(":IV_CS", _cs.ToString());
                    _cmd.Parameters.Add(":DELRULE", SaveModel.DeleteRule);
                    _cmd.Parameters.Add(":DWDM", SaveModel.DWDM);
                    _cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception e)
            {
                SystemLogWriter.WriteLog(e.Message, EventLogEntryType.Error);
                return false;
            }
        }


        public bool DelInputModel(string InputModelID)
        {
            try
            {
                using (OracleConnection cn = OracleHelper.OpenConnection())
                {
                    OracleCommand _cmd = new OracleCommand("delete MD_INPUTVIEW  where IV_ID=:IVID", cn);
                    _cmd.Parameters.Add(":IV_ID", decimal.Parse(InputModelID));

                    _cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception e)
            {

                return false;
            }
        }

        private const string SQL_InputModel_MoveColumnToGroup = @"update MD_INPUTVIEWCOLUMN set IVG_ID=:IVGID where IVC_ID=:IVCID ";
        public bool InputModel_MoveColumnToGroup(MD_InputModel_Column _col, MD_InputModel_ColumnGroup InputModelColumnGroup)
        {
            try
            {
                using (OracleConnection cn = OracleHelper.OpenConnection())
                {
                    OracleCommand _cmd = new OracleCommand(SQL_InputModel_MoveColumnToGroup, cn);
                    _cmd.Parameters.Add(":IVGID", decimal.Parse(InputModelColumnGroup.GroupID));
                    _cmd.Parameters.Add(":IVCID", decimal.Parse(_col.ColumnID));

                    _cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception e)
            {

                return false;
            }
        }

        private const string SQL_DelInputModelColumnGroup_ups = @"update MD_INPUTVIEWCOLUMN set IVG_ID=0 where IV_ID=:IVID and IVG_ID=:IVGID";
        private const string SQL_DelInputModelColumnGroup_del = @"delete md_inputgroup where IVG_ID=:IVID";
        public bool DelInputModelColumnGroup(string InputModelID, string GroupID)
        {
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                OracleTransaction _txn = cn.BeginTransaction();
                try
                {
                    OracleCommand _cmd = new OracleCommand(SQL_DelInputModelColumnGroup_ups, cn);
                    _cmd.Parameters.Add(":IVID", decimal.Parse(InputModelID));
                    _cmd.Parameters.Add(":IVGID", decimal.Parse(GroupID));
                    _cmd.ExecuteNonQuery();


                    _cmd = new OracleCommand(SQL_DelInputModelColumnGroup_del, cn);
                    _cmd.Parameters.Add(":IV_ID", decimal.Parse(GroupID));
                    _cmd.ExecuteNonQuery();
                    _txn.Commit();
                    return true;
                }
                catch (Exception e)
                {
                    _txn.Rollback();
                    return false;
                }
            }

        }

        private const string SQL_AddNewInputModelGroup = @"INSERT INTO MD_INPUTGROUP
                                                            (IVG_ID,IV_ID,DISPLAYTITLE,DISPLAYORDER,GROUPTYPE,APPREGURL,GROUPCS) values
                                                            (:IVG_ID,:IV_ID,:DISPLAYTITLE,:DISPLAYORDER,:GROUPTYPE,:APPREGURL,:GROUPCS)";
        public bool AddNewInputModelGroup(MD_InputModel_ColumnGroup Group)
        {
            try
            {
                using (OracleConnection cn = OracleHelper.OpenConnection())
                {
                    OracleCommand _cmd = new OracleCommand(SQL_AddNewInputModelGroup, cn);
                    _cmd.Parameters.Add(":IVG_ID", Group.GroupID);
                    _cmd.Parameters.Add(":IV_ID", Group.ModelID);
                    _cmd.Parameters.Add(":DISPLAYTITLE", Group.DisplayTitle);
                    _cmd.Parameters.Add(":DISPLAYORDER", Convert.ToDecimal(Group.DisplayOrder));
                    _cmd.Parameters.Add(":GROUPTYPE", Group.GroupType);
                    _cmd.Parameters.Add(":APPREGURL", Group.AppRegUrl);
                    _cmd.Parameters.Add(":GROUPCS", Group.GroupParam);
                    _cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception e)
            {
                SystemLogWriter.WriteLog(string.Format("插入录入模型的分组[{0}]记录时出错！{1}", Group.GroupID, e.Message), EventLogEntryType.Error);
                return false;
            }
        }


        private const string SQL_SaveInputModelColumnGroup = @"update  MD_INPUTGROUP set  DISPLAYTITLE=:DISPLAYTITLE,GROUPTYPE=:GROUPTYPE,APPREGURL=:APPREGURL,GROUPCS=:GROUPCS,
                                                                        DISPLAYORDER=:DISPLAYORDER where IVG_ID=:IVGID ";
        private const string SQL_SaveInputModelColumnGroup_ups = @"update MD_INPUTVIEWCOLUMN 
                                    set DWDM=:DWDM,INPUTDEFAULT=:INPUTDEFAULT,INPUTRULE=:INPUTRULE,CANEDITRULE=:CANEDITRULE ,
                                    CANDISPLAY=:CANDISPLAY,COLUMNNAME=:COLUMNNAME,COLUMNORDER=:COLUMNORDER,COLUMNTYPE=:COLUMNTYPE ,
                                    READONLY=:READONLY,DISPLAYNAME=:DISPLAYNAME,ISCOMPUTE=:ISCOMPUTE,COLUMNWIDTH=:COLUMNWIDTH,
                                    COLUMNHEIGHT=:COLUMNHEIGHT,TEXTALIGNMENT=:TEXTALIGNMENT,EDITFORMAT=:EDITFORMAT,DISPLAYFORMAT=:DISPLAYFORMAT,
                                    REQUIRED=:REQUIRED,TOOLTIP=:TOOLTIP,DATACHANGEDEVENT=:DATACHANGEDEVENT,MAXLENGTH=:MAXLENGTH,DEFAULTSHOW=:DEFAULTSHOW 
                                     where IVC_ID=:IVC_ID";
        public bool SaveInputModelColumnGroup(MD_InputModel_ColumnGroup Group)
        {
            OracleCommand _cmd;

            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                OracleTransaction _txn = cn.BeginTransaction();
                try
                {

                    if (Group.GroupID != "0")
                    {
                        _cmd = new OracleCommand(SQL_SaveInputModelColumnGroup, cn);
                        _cmd.Parameters.Add(":DISPLAYTITLE", Group.DisplayTitle);
                        _cmd.Parameters.Add(":GROUPTYPE", Group.GroupType);
                        _cmd.Parameters.Add(":APPREGURL", Group.AppRegUrl);
                        _cmd.Parameters.Add(":GROUPCS", Group.GroupParam);
                        _cmd.Parameters.Add(":DISPLAYORDER", Convert.ToDecimal(Group.DisplayOrder));

                        _cmd.Parameters.Add(":IVG_ID", decimal.Parse(Group.GroupID));
                        _cmd.ExecuteNonQuery();
                    }


                    foreach (MD_InputModel_Column _col in Group.Columns)
                    {
                        _cmd = new OracleCommand(SQL_SaveInputModelColumnGroup_ups, cn);
                        _cmd.Parameters.Add(":DWDM", _col.DWDM);
                        _cmd.Parameters.Add(":INPUTDEFAULT", _col.DefaultValue);
                        _cmd.Parameters.Add(":INPUTRULE", _col.InputRule);
                        _cmd.Parameters.Add(":CANEDITRULE", _col.CanEditRule);

                        _cmd.Parameters.Add(":CANDISPLAY", (_col.CanDisplay) ? "Y" : "N");
                        _cmd.Parameters.Add(":COLUMNNAME", _col.ColumnName);
                        _cmd.Parameters.Add(":COLUMNORDER", Convert.ToInt32(_col.DisplayOrder));
                        _cmd.Parameters.Add(":COLUMNTYPE", _col.ColumnType);

                        _cmd.Parameters.Add(":READONLY", (_col.ReadOnly) ? (decimal)1 : (decimal)0);
                        _cmd.Parameters.Add(":DISPLAYNAME", _col.DisplayName);
                        _cmd.Parameters.Add(":ISCOMPUTE", (_col.IsCompute) ? (decimal)1 : (decimal)0);
                        _cmd.Parameters.Add(":COLUMNWIDTH", Convert.ToInt32(_col.Width));

                        _cmd.Parameters.Add(":COLUMNHEIGHT", Convert.ToInt32(_col.LineHeight));
                        _cmd.Parameters.Add(":TEXTALIGNMENT", Convert.ToInt32(_col.TextAlign));
                        _cmd.Parameters.Add(":EDITFORMAT", _col.EditFormat);
                        _cmd.Parameters.Add(":DISPLAYFORMAT", _col.DisplayFormat);

                        _cmd.Parameters.Add(":REQUIRED", (_col.Required) ? (decimal)1 : (decimal)0);
                        _cmd.Parameters.Add(":TOOLTIP", _col.ToolTipText);
                        _cmd.Parameters.Add(":DATACHANGEDEVENT", _col.DataChangedEvent);
                        _cmd.Parameters.Add(":MAXLENGTH", Convert.ToDecimal(_col.MaxInputLength));
                        _cmd.Parameters.Add(":DEFAULTSHOW", _col.DefaultShow ? (decimal)1 : (decimal)0);

                        _cmd.Parameters.Add(":IVC_ID", decimal.Parse(_col.ColumnID));
                        _cmd.ExecuteNonQuery();

                    }
                    _txn.Commit();
                    return true;
                }
                catch (Exception e)
                {
                    _txn.Rollback();
                    return false;
                }
            }



        }

        private const string SQL_FindInputModelColumnByName = @"select count(*) from  md_inputviewcolumn
                                                                where IV_ID=:IVID AND COLUMNNAME=:CNAME  ";
        public bool FindInputModelColumnByName(string InputModelID, string ColumnName)
        {
            decimal _ret = 0;
            try
            {

                using (OracleConnection cn = OracleHelper.OpenConnection())
                {
                    OracleCommand _cmd = new OracleCommand(SQL_FindInputModelColumnByName, cn);
                    _cmd.Parameters.Add(":IV_ID", decimal.Parse(InputModelID));
                    _cmd.Parameters.Add(":CNAME", ColumnName);
                    _ret = (decimal)_cmd.ExecuteScalar();
                }
                return _ret > 0;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        private const string SQL_AddNewInputModelColumn = @"INSERT INTO md_inputviewcolumn
                                                            (IVC_ID,IV_ID,TCID,COLUMNNAME,
                                                            CANDISPLAY,COLUMNORDER,COLUMNTYPE,READONLY,
                                                            DISPLAYNAME,ISCOMPUTE,COLUMNWIDTH,COLUMNHEIGHT,
                                                            TEXTALIGNMENT,IVG_ID ) values
                                                             (:IVC_ID,:IV_ID,0,:COLUMNNAME,
                                                             'Y',0,'VARCHAR',0,
                                                             :DISPLAYNAME,0,1,1,
                                                            0,:IVG_ID ) ";
        public bool AddNewInputModelColumn(string InputModelID, string GroupID, string ColumnName)
        {
            try
            {

                using (OracleConnection cn = OracleHelper.OpenConnection())
                {
                    OracleCommand _cmd = new OracleCommand(SQL_AddNewInputModelColumn, cn);
                    _cmd.Parameters.Add(":IVC_ID", decimal.Parse(GetNewID()));
                    _cmd.Parameters.Add(":IV_ID", decimal.Parse(InputModelID));
                    _cmd.Parameters.Add(":COLUMNNAME", ColumnName);
                    _cmd.Parameters.Add(":DISPLAYNAME", ColumnName);
                    _cmd.Parameters.Add(":IVG_ID", decimal.Parse(GroupID));
                    _cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception e)
            {

                return false;
            }
        }


        public bool OracleTableExist(string TableName)
        {
            try
            {
                return true;
            }
            catch (Exception e)
            {

                return false;
            }
        }

        private const string SQL_DelInputModelColumn = @"DELETE  FROM md_inputviewcolumn WHERE IVC_ID=:IVC_ID";
        public bool DelInputModelColumn(string ColumnID)
        {
            try
            {


                using (OracleConnection cn = OracleHelper.OpenConnection())
                {
                    OracleCommand _cmd = new OracleCommand(SQL_DelInputModelColumn, cn);
                    _cmd.Parameters.Add(":IVC_ID", decimal.Parse(ColumnID));

                    _cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception e)
            {

                return false;
            }
        }

        private const string SQL_AddNewInputModelSavedTable = @"insert into  md_inputtable
                                                                (ID,TABLENAME,IV_ID,ISLOCK,TABLETITLE,DISPLAYORDER) values 
                                                                (:ID,:TABLENAME,:IV_ID,1,:TABLETITLE,0)     ";
        public bool AddNewInputModelSavedTable(string InputModelID, string TableName)
        {
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                OracleTransaction _txn = cn.BeginTransaction();
                try
                {

                    OracleCommand _cmd = new OracleCommand(SQL_AddNewInputModelSavedTable, cn);
                    _cmd.Parameters.Add(":ID", decimal.Parse(GetNewID()));
                    _cmd.Parameters.Add(":TABLENAME", TableName);
                    _cmd.Parameters.Add(":IV_ID", decimal.Parse(InputModelID));
                    _cmd.Parameters.Add(":TABLETITLE", TableName);

                    _cmd.ExecuteNonQuery();
                    _txn.Commit();
                    return true;
                }
                catch (Exception e)
                {
                    _txn.Rollback();
                    return false;
                }
            }
        }

        public bool DelInputModelSavedTable(string TableID)
        {
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                OracleTransaction _txn = cn.BeginTransaction();
                try
                {
                    OracleCommand _delCmd = new OracleCommand("delete from md_inputtablecolumn where IVT_ID=:ID", cn);
                    _delCmd.Parameters.Add(":ID", decimal.Parse(TableID));
                    _delCmd.ExecuteNonQuery();

                    OracleCommand _cmd = new OracleCommand("delete from  md_inputtable where id=:ID", cn);
                    _cmd.Parameters.Add(":ID", decimal.Parse(TableID));
                    _cmd.ExecuteNonQuery();

                    _txn.Commit();
                    return true;
                }
                catch (Exception e)
                {
                    _txn.Rollback();
                    return false;
                }
            }
        }

        private const string SQL_SaveInputModelSaveTable = @"update MD_INPUTTABLE
                                                                    set TABLETITLE=:TABLETITLE,DISPLAYORDER=:DISPLAYORDER,ISLOCK=:ISLOCK,SAVEMODE=:SAVEMODE
                                                                    where ID=:ID ";
        private const string SQL_SaveInputModelSaveTable_ins = @"insert into MD_INPUTTABLECOLUMN
                                                            (ID,IVT_ID,DESCOL,SRCCOL,METHOD,DESDES) values
                                                            (:ID,:IVT_ID,:DESCOL,:SRCCOL,:METHOD,:DESDES)  ";
        public bool SaveInputModelSaveTable(MD_InputModel_SaveTable _newTable)
        {
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                OracleTransaction _txn = cn.BeginTransaction();
                try
                {
                    OracleCommand _upCmd = new OracleCommand(SQL_SaveInputModelSaveTable, cn);
                    _upCmd.Parameters.Add(":TABLETITLE", _newTable.TableTitle);
                    _upCmd.Parameters.Add(":DISPLAYORDER", Convert.ToDecimal(_newTable.DisplayOrder));
                    _upCmd.Parameters.Add(":ISLOCK", _newTable.IsLock ? (decimal)1 : (decimal)0);
                    _upCmd.Parameters.Add(":SAVEMODE", _newTable.SaveMode);
                    _upCmd.Parameters.Add(":ID", decimal.Parse(_newTable.ID));
                    _upCmd.ExecuteNonQuery();


                    OracleCommand _cmd = new OracleCommand("delete from  MD_INPUTTABLECOLUMN where IVT_ID=:ID", cn);
                    _cmd.Parameters.Add(":ID", decimal.Parse(_newTable.ID));
                    _cmd.ExecuteNonQuery();

                    foreach (MD_InputModel_SaveTableColumn _col in _newTable.Columns)
                    {
                        OracleCommand _insCmd = new OracleCommand(SQL_SaveInputModelSaveTable_ins, cn);
                        _insCmd.Parameters.Add(":ID", decimal.Parse(_col.ID));
                        _insCmd.Parameters.Add(":IVT_ID", decimal.Parse(_newTable.ID));
                        _insCmd.Parameters.Add(":DESCOL", _col.DesColumn);
                        _insCmd.Parameters.Add(":SRCCOL", _col.SrcColumn);
                        _insCmd.Parameters.Add(":METHOD", _col.Method);
                        _insCmd.Parameters.Add(":DESDES", _col.Descript);
                        _insCmd.ExecuteNonQuery();

                    }
                    _txn.Commit();
                    return true;
                }
                catch (Exception e)
                {
                    _txn.Rollback();
                    return false;
                }
            }
        }




        public bool AddInputModelTableColumn(string TableName, string AddFieldName, string DataType)
        {
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                OracleTransaction _txn = cn.BeginTransaction();
                try
                {
                    string _sql = string.Format("Alter Table {0} add {1} {2} ", TableName, AddFieldName, DataType);
                    OracleHelper.ExecuteNonQuery(cn, CommandType.Text, _sql);
                    _txn.Commit();
                    return true;
                }
                catch (Exception e)
                {
                    _txn.Rollback();
                    return false;
                }
            }
        }


        public bool DelInputModelTableColumn(string TableName, string DelFieldName)
        {
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                OracleTransaction _txn = cn.BeginTransaction();
                try
                {
                    string _sql = string.Format("Alter Table {0} drop column {1} ", TableName, DelFieldName);
                    OracleHelper.ExecuteNonQuery(cn, CommandType.Text, _sql);
                    _txn.Commit();
                    return true;
                }
                catch (Exception e)
                {
                    _txn.Rollback();
                    return false;
                }
            }
        }


        private const string SQL_GetDBPrimayKeyList = @"SELECT TABLE_NAME,COLUMN_NAME,COLUMN_POSITION  FROM XTV_PK_COLUMNS T
                                                        WHERE T.TABLE_NAME=UPPER(:TNAME) )";
        public List<string> GetDBPrimayKeyList(string TableName)
        {
            List<string> _ret = new List<string>();

            using (OracleConnection cn = OracleHelper.OpenConnection())
            {

                try
                {
                    OracleParameter[] _param = {
                                        new OracleParameter(":TNAME", OracleDbType.Varchar2)};
                    _param[0].Value = TableName;
                    using (OracleDataReader _dr = OracleHelper.ExecuteReader(cn, CommandType.Text, SQL_GetDBPrimayKeyList, _param))
                    {
                        while (_dr.Read())
                        {
                            string _cname = _dr.IsDBNull(1) ? "" : _dr.GetString(1);
                            _ret.Add(_cname);
                        }
                    }
                }
                catch (Exception e)
                {
                    OralceLogWriter.WriteSystemLog(string.Format("在取数据表的主键时发生错误，错误信息：{0}", e.Message), "ERROR");
                    return _ret;
                }
            }
            return _ret;
        }

        public bool AddChildInputModel(string MainModelID, string ChildModelID)
        {
            string _sql = "insert into md_inputviewchild (id,iv_id,civ_id,param,displayorder) values (sequences_meta.nextval,:IV_ID,:CIV_ID,'',0)";
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                try
                {
                    OracleCommand _cmd = new OracleCommand(_sql, cn);
                    _cmd.Parameters.Add(":IV_ID", decimal.Parse(MainModelID));
                    _cmd.Parameters.Add(":CIV_ID", decimal.Parse(ChildModelID));
                    _cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }

        public bool SaveInputModelChildDefine(MD_InputModel_Child InputModelChild)
        {
            string _sql = "update md_inputviewchild  set param=:PARAM ,displayorder=:DISPLAYORDER,SHOWCONDITION=:SHOWCONDITION,SELECTMODE=:SELECTMODE where ID=:ID";
            string _pstr = "";
            foreach (MD_InputModel_ChildParam _p in InputModelChild.Parameters)
            {
                _pstr += string.Format("<PARAM>{0}:{1}:{2}</PARAM>", _p.Name, _p.DataType, _p.Value);
            }

            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                try
                {
                    OracleCommand _cmd = new OracleCommand(_sql, cn);
                    _cmd.Parameters.Add(":PARAM", _pstr);
                    _cmd.Parameters.Add(":DISPLAYORDER", Convert.ToDecimal(InputModelChild.DisplayOrder));
                    _cmd.Parameters.Add(":SHOWCONDITION", InputModelChild.ShowCondition);
                    _cmd.Parameters.Add(":SELECTMODE", Convert.ToDecimal(InputModelChild.SelectMode));
                    _cmd.Parameters.Add(":ID", decimal.Parse(InputModelChild.ID));
                    _cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }

        private const string SQL_DelRefTable = @"delete from md_reftablelist  where RTID=:RTID";
        public bool DelRefTable(string RefTableID)
        {
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                try
                {
                    OracleCommand _cmd = new OracleCommand(SQL_DelRefTable, cn);
                    _cmd.Parameters.Add(":RTID", decimal.Parse(RefTableID));
                    _cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }

        #endregion


        #region 私有方法
        private OracleConnection OpenConnection()
        {
            OracleConnection conn = new OracleConnection(OracleHelper.ConnectionStringProfile);
            conn.Open();
            return conn;
        }



        #endregion



        /// <summary>
        /// 取录入模型定义数据
        /// </summary>
        /// <param name="InputModelID"></param>
        /// <returns></returns>
        public DataSet GetInputModelDefineData(string InputModelID)
        {
            DataSet _ret = new DataSet();
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                try
                {
                    OracleCommand _cmd = new OracleCommand("select * from md_inputview  where IV_ID=:IVID", cn);
                    _cmd.Parameters.Add(":IVID", decimal.Parse(InputModelID));
                    OracleDataAdapter _oda = new OracleDataAdapter(_cmd);
                    _oda.Fill(_ret, "MD_INPUTVIEW");

                    _cmd = new OracleCommand("select * from md_inputviewcolumn where IV_ID=:IVID", cn);
                    _cmd.Parameters.Add(":IVID", decimal.Parse(InputModelID));
                    _oda = new OracleDataAdapter(_cmd);
                    _oda.Fill(_ret, "MD_INPUTVIEWCOLUMN");


                    _cmd = new OracleCommand("select * from md_inputgroup where IV_ID=:IVID", cn);
                    _cmd.Parameters.Add(":IVID", decimal.Parse(InputModelID));
                    _oda = new OracleDataAdapter(_cmd);
                    _oda.Fill(_ret, "MD_INPUTGROUP");

                    _cmd = new OracleCommand("select * from md_inputtable  where IV_ID=:IVID", cn);
                    _cmd.Parameters.Add(":IVID", decimal.Parse(InputModelID));
                    _oda = new OracleDataAdapter(_cmd);
                    _oda.Fill(_ret, "MD_INPUTTABLE");


                    string _sql = @"select * from md_inputtablecolumn t
									WHERE IVT_ID IN
									(select ID from md_inputtable  where IV_ID=:IVID) ";
                    _cmd = new OracleCommand(_sql, cn);
                    _cmd.Parameters.Add(":IVID", decimal.Parse(InputModelID));
                    _oda = new OracleDataAdapter(_cmd);
                    _oda.Fill(_ret, "MD_INPUTTABLECOLUMN");

                    _cmd = new OracleCommand("select * from md_inputviewchild  where IV_ID=:IVID", cn);
                    _cmd.Parameters.Add(":IVID", decimal.Parse(InputModelID));
                    _oda = new OracleDataAdapter(_cmd);
                    _oda.Fill(_ret, "MD_INPUTVIEWCHILD");

                    return _ret;
                }
                catch (Exception e)
                {
                    OralceLogWriter.WriteSystemLog(string.Format("在导出录入模型时取录入模型定义数据时发生错误，错误信息：{0}", e.Message), "ERROR");
                    return null;
                }
            }
        }

        private const string SQL_DelInputModelChild = @"delete from md_inputviewchild  where ID=:IVID";
        public bool DelInputModelChild(string ChildModelID)
        {
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                try
                {
                    OracleCommand _cmd = new OracleCommand(SQL_DelInputModelChild, cn);
                    _cmd.Parameters.Add(":IVID", decimal.Parse(ChildModelID));
                    _cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception e)
                {
                    OralceLogWriter.WriteSystemLog(string.Format("在删除子录入模型时发生错误，错误信息：{0}", e.Message), "ERROR");
                    return false;
                }
            }
        }




        #region IMetaDataFactroy Members


        public bool IsExistID(string _oldid, string _tname, string _colname)
        {
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                try
                {
                    string _sql = string.Format("select count({0}) from {1} where {2}='{3}'", _colname, _tname, _colname, _oldid);
                    decimal _ret = (decimal)OracleHelper.ExecuteScalar(cn, CommandType.Text, _sql);

                    return (_ret > 0);
                }
                catch (Exception e)
                {
                    OralceLogWriter.WriteSystemLog(string.Format("在检查{0}表中是否存在{1}的序列值为{2}时发生错误，错误信息：{3}", _tname, _colname, _oldid, e.Message), "ERROR");
                    return false;
                }
            }
        }


        private const string SQL_GetView2ViewGroupOfQueryModel = @"select ID,VIEWID,DISPLAYTITLE,DISPLAYORDER from MD_VIEW2VIEWGROUP where VIEWID=:VIEWID order by DISPLAYORDER";
        public List<MD_View2ViewGroup> GetView2ViewGroupOfQueryModel(string ViewID)
        {
            List<MD_View2ViewGroup> _ret = new List<MD_View2ViewGroup>();
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                try
                {
                    OracleCommand _cmd = new OracleCommand(SQL_GetView2ViewGroupOfQueryModel, cn);
                    _cmd.Parameters.Add(":VIEWID", decimal.Parse(ViewID));
                    using (OracleDataReader _dr = _cmd.ExecuteReader())
                    {
                        while (_dr.Read())
                        {
                            MD_View2ViewGroup _g = new MD_View2ViewGroup();
                            _g.ID = _dr.IsDBNull(0) ? "" : _dr.GetString(0);
                            _g.DisplayTitle = _dr.IsDBNull(2) ? "" : _dr.GetString(2);
                            _g.DisplayOrder = _dr.IsDBNull(3) ? 0 : Convert.ToInt32(_dr.GetDecimal(3));
                            _ret.Add(_g);
                        }
                    }
                }
                catch (Exception e)
                {
                    OralceLogWriter.WriteSystemLog(string.Format("在取查询模型{0}相关联模型分组信息时发生错误，错误信息：{1} ", ViewID, e.Message), "ERROR");
                    return null;
                }
            }
            return _ret;
        }

        private const string SQL_AddView2ViewGroup = "insert into MD_VIEW2VIEWGROUP (ID,VIEWID,DISPLAYORDER,DISPLAYTITLE) values (:ID,:VIEWID,0,'未命名分组')";
        public string AddView2ViewGroup(string ViewID)
        {
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                try
                {
                    OracleCommand _cmd = new OracleCommand(SQL_AddView2ViewGroup, cn);
                    _cmd.Parameters.Add(":ID", Guid.NewGuid().ToString());
                    _cmd.Parameters.Add(":VIEWID", decimal.Parse(ViewID));
                    _cmd.ExecuteNonQuery();
                    return "";
                }
                catch (Exception e)
                {
                    string _msg = string.Format("在新建查询模型{0}相关联模型分组信息时发生错误，错误信息：{1} ", ViewID, e.Message);
                    OralceLogWriter.WriteSystemLog(_msg, "ERROR");
                    return _msg;
                }
            }
        }


        private const string SQL_SaveView2ViewGroup = "update MD_VIEW2VIEWGROUP set DISPLAYORDER=:DISPLAYORDER,DISPLAYTITLE=:DISPLAYTITLE where ID=:ID";
        public bool SaveView2ViewGroup(MD_View2ViewGroup View2ViewGroup)
        {
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                try
                {
                    OracleCommand _cmd = new OracleCommand(SQL_SaveView2ViewGroup, cn);
                    _cmd.Parameters.Add(":DISPLAYORDER", Convert.ToDecimal(View2ViewGroup.DisplayOrder));
                    _cmd.Parameters.Add(":DISPLAYTITLE", View2ViewGroup.DisplayTitle);
                    _cmd.Parameters.Add(":ID", View2ViewGroup.ID);
                    _cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception e)
                {
                    string _msg = string.Format("在保存查询模型{0}相关联模型分组信息时发生错误，错误信息：{1} ", View2ViewGroup.QueryModelID, e.Message);
                    OralceLogWriter.WriteSystemLog(_msg, "ERROR");
                    return false;
                }
            }
        }

        private const string SQL_GetView2ViewList = @"select ID,VIEWID,TARGETVIEWNAME,RELATIONSTR,DISPLAYORDER,DISPLAYTITLE,GROUPID from MD_VIEW2VIEW WHERE VIEWID=:VIEWID and GROUPID=:GROUPID";
        public List<MD_View2View> GetView2ViewList(string GroupID, string ViewID)
        {
            List<MD_View2View> _ret = new List<MD_View2View>();
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                try
                {
                    OracleCommand _cmd = new OracleCommand(SQL_GetView2ViewList, cn);
                    _cmd.Parameters.Add(":VIEWID", decimal.Parse(ViewID));
                    _cmd.Parameters.Add(":GROUPID", GroupID);
                    using (OracleDataReader _dr = _cmd.ExecuteReader())
                    {
                        while (_dr.Read())
                        {
                            MD_View2View _g = new MD_View2View();
                            _g.ID = _dr.IsDBNull(0) ? "" : _dr.GetString(0);
                            _g.TargetViewName = _dr.IsDBNull(2) ? "" : _dr.GetString(2);
                            _g.RelationString = _dr.IsDBNull(3) ? "" : _dr.GetString(3);
                            _g.DisplayOrder = _dr.IsDBNull(4) ? 0 : Convert.ToInt32(_dr.GetDecimal(4));
                            _g.DisplayTitle = _dr.IsDBNull(5) ? "" : _dr.GetString(5);
                            _ret.Add(_g);
                        }
                    }
                }
                catch (Exception e)
                {
                    OralceLogWriter.WriteSystemLog(string.Format("在取查询模型{0}相关联模型分组信息时发生错误，错误信息：{1} ", ViewID, e.Message), "ERROR");
                    return null;
                }
            }
            return _ret;
        }

        private const string SQL_DelView2ViewGroup = @"delete from MD_VIEW2VIEWGROUP where ID=:ID";
        private const string SQL_DelView2ViewGroup2 = @"delete from MD_VIEW2VIEW where GROUPID=:ID";
        public string DelView2ViewGroup(string GroupID)
        {
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                OracleTransaction txn = cn.BeginTransaction();
                try
                {
                    OracleCommand _cmd = new OracleCommand(SQL_DelView2ViewGroup2, cn);
                    _cmd.Parameters.Add(":ID", GroupID);
                    _cmd.ExecuteNonQuery();

                    OracleCommand _cmd2 = new OracleCommand(SQL_DelView2ViewGroup, cn);
                    _cmd2.Parameters.Add(":ID", GroupID);
                    _cmd2.ExecuteNonQuery();
                    txn.Commit();
                    return "";
                }
                catch (Exception e)
                {
                    txn.Rollback();
                    string _msg = string.Format("删除查询相关联模型分组{0}信息时发生错误，错误信息：{1} ", GroupID, e.Message);
                    OralceLogWriter.WriteSystemLog(_msg, "ERROR");
                    return _msg;
                }
            }
        }

        private const string SQL_AddView2View = @"insert into MD_VIEW2VIEW (ID,VIEWID,DISPLAYORDER,DISPLAYTITLE,GROUPID) values (:ID,:VIEWID,0,'未设置的关联模型',:GROUPID)";
        public string AddView2View(string ViewID, string GroupID)
        {
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                try
                {
                    OracleCommand _cmd = new OracleCommand(SQL_AddView2View, cn);
                    _cmd.Parameters.Add(":ID", Guid.NewGuid().ToString());
                    _cmd.Parameters.Add(":VIEWID", decimal.Parse(ViewID));
                    _cmd.Parameters.Add(":GROUPID", GroupID);
                    _cmd.ExecuteNonQuery();
                    return "";
                }
                catch (Exception e)
                {
                    string _msg = string.Format("在新建查询模型{0}相关联的模型信息时发生错误，错误信息：{1} ", ViewID, e.Message);
                    OralceLogWriter.WriteSystemLog(_msg, "ERROR");
                    return _msg;
                }
            }
        }

        private const string SQL_SaveView2View = @"update MD_VIEW2VIEW set TARGETVIEWNAME=:VIEWNAME,RELATIONSTR=:STR,DISPLAYORDER=:DISPORDER,DISPLAYTITLE=:TITLE where ID=:ID";
        public bool SaveView2View(MD_View2View View2View)
        {
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                try
                {
                    OracleCommand _cmd = new OracleCommand(SQL_SaveView2View, cn);
                    _cmd.Parameters.Add(":VIEWNAME", View2View.TargetViewName);
                    _cmd.Parameters.Add(":STR", View2View.RelationString);
                    _cmd.Parameters.Add(":DISPORDER", Convert.ToDecimal(View2View.DisplayOrder));
                    _cmd.Parameters.Add(":TITLE", View2View.DisplayTitle);
                    _cmd.Parameters.Add(":ID", View2View.ID);
                    _cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception e)
                {
                    string _msg = string.Format("在保存关联的模型信息{0}时发生错误，错误信息：{1} ", View2View.ID, e.Message);
                    OralceLogWriter.WriteSystemLog(_msg, "ERROR");
                    return false;
                }
            }
        }

        private const string SQL_DelView2View = @"delete from MD_VIEW2VIEW where ID=:ID";
        public string CMD_DelView2View(string v2vid)
        {
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                try
                {
                    OracleCommand _cmd = new OracleCommand(SQL_DelView2View, cn);
                    _cmd.Parameters.Add(":ID", v2vid);
                    _cmd.ExecuteNonQuery();
                    return "";
                }
                catch (Exception e)
                {
                    string _msg = string.Format("在删除查询模型相关联的模型信息{0}时发生错误，错误信息：{1} ", v2vid, e.Message);
                    OralceLogWriter.WriteSystemLog(_msg, "ERROR");
                    return _msg;
                }
            }
        }
        private const string SQL_GetQueryModelExRights = @"select ID,rvalue,rtitle,viewid,fid from md_view_exright where viewid=:VIEWID and fid=:FID ";
        public List<MD_QueryModel_ExRight> GetQueryModelExRights(string QueryModelID, string FatherID)
        {
            List<MD_QueryModel_ExRight> _ret = new List<MD_QueryModel_ExRight>();
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                try
                {
                    OracleCommand _cmd = new OracleCommand(SQL_GetQueryModelExRights, cn);
                    _cmd.Parameters.Add(":VIEWID", Decimal.Parse(QueryModelID));
                    _cmd.Parameters.Add(":FID", FatherID);
                    using (OracleDataReader _dr = _cmd.ExecuteReader())
                    {
                        while (_dr.Read())
                        {
                            MD_QueryModel_ExRight _ritem = new MD_QueryModel_ExRight();
                            _ritem.ID = _dr.IsDBNull(0) ? "" : _dr.GetString(0);
                            _ritem.RightName = _dr.IsDBNull(1) ? "" : _dr.GetString(1);
                            _ritem.RightTitle = _dr.IsDBNull(2) ? "" : _dr.GetString(2);
                            _ritem.ModelID = _dr.IsDBNull(3) ? "" : _dr.GetDecimal(3).ToString();
                            _ritem.FatherRightID = _dr.IsDBNull(4) ? "" : _dr.GetString(4);
                            _ret.Add(_ritem);
                        }
                    }
                }
                catch (Exception e)
                {
                    string _msg = string.Format("在取查询模型[{0}]相关联的模型扩展权限信息时发生错误，错误信息：{1} ", QueryModelID, e.Message);
                    OralceLogWriter.WriteSystemLog(_msg, "ERROR");
                }
            }
            return _ret;
        }


        private const string SQL_AddNewViewExRight = "insert into md_view_exright (id,rvalue,rtitle,viewid,fid,displayorder) values (:ID,:RVALUE,:RTITLE,:VIEWID,:FID,0)";
        public bool AddNewViewExRight(string RightValue, string RightTitle, string ViewID, MD_QueryModel_ExRight FatherRight)
        {
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                try
                {
                    OracleCommand _cmd = new OracleCommand(SQL_AddNewViewExRight, cn);
                    _cmd.Parameters.Add(":ID", Guid.NewGuid().ToString());
                    _cmd.Parameters.Add(":RVALUE", RightValue);
                    _cmd.Parameters.Add(":RTITLE", RightTitle);
                    _cmd.Parameters.Add(":VIEWID", decimal.Parse(ViewID));
                    _cmd.Parameters.Add(":FID", (FatherRight == null) ? "0" : FatherRight.ID);
                    _cmd.ExecuteNonQuery();
                    return true;

                }
                catch (Exception e)
                {
                    string _msg = string.Format("新建查询模型[{0}]相关联的模型扩展权限信息时发生错误，错误信息：{1} ", ViewID, e.Message);
                    OralceLogWriter.WriteSystemLog(_msg, "ERROR");
                    return false;
                }
            }
        }


        private const string SQL_SaveQueryModelExRight = "update md_view_exright  set rvalue=:RVALUE,rtitle=:RTITLE,displayorder=:DISPLAYORDER where ID=:ID";
        public bool SaveQueryModelExRight(MD_QueryModel_ExRight ExRight)
        {
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                try
                {
                    OracleCommand _cmd = new OracleCommand(SQL_SaveQueryModelExRight, cn);
                    _cmd.Parameters.Add(":RVALUE", ExRight.RightName);
                    _cmd.Parameters.Add(":RTITLE", ExRight.RightTitle);
                    _cmd.Parameters.Add(":DISPLAYORDER", Convert.ToDecimal(ExRight.DisplayOrder));
                    _cmd.Parameters.Add(":ID", ExRight.ID);
                    _cmd.ExecuteNonQuery();
                    return true;

                }
                catch (Exception e)
                {
                    string _msg = string.Format("保存查询模型[{0}]相关联的模型扩展权限信息时发生错误，错误信息：{1} ", ExRight.ModelID, e.Message);
                    OralceLogWriter.WriteSystemLog(_msg, "ERROR");
                    return false;
                }
            }
        }


        private const string SQL_CheckDelViewExRight = @"select count(*) from md_view_exright where FID=:FID ";
        private const string SQL_DelViewExRight = @"DELETE from md_view_exright where ID=:ID";
        public string CMD_DelViewExRight(MD_QueryModel_ExRight ExRight)
        {
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                try
                {
                    OracleCommand _cmdCheck = new OracleCommand(SQL_CheckDelViewExRight, cn);
                    _cmdCheck.Parameters.Add(":FID", ExRight.ID);
                    decimal _ret = (decimal)_cmdCheck.ExecuteScalar();
                    if (_ret > 0) return "请先删除子权限！";

                    OracleCommand _cmdDel = new OracleCommand(SQL_DelViewExRight, cn);
                    _cmdDel.Parameters.Add(":ID", ExRight.ID);
                    _cmdDel.ExecuteNonQuery();
                    return "";
                }
                catch (Exception e)
                {
                    string _msg = string.Format("删除查询模型[{0}]的模型扩展权限信息时发生错误，错误信息：{1} ", ExRight.ModelID, e.Message);
                    OralceLogWriter.WriteSystemLog(_msg, "ERROR");
                    return _msg;
                }
            }
        }


        private const string SQL_CheckExistV2G = @"select count(*) from md_view2gl where id=:ID";
        private const string SQL_InsertV2G = @"insert into md_view2gl (id,viewid,targetgl,targetcs,displayorder,displaytitle) values (:ID,:VIEWID,:TARGETGL,:TARGETCS,:DISPLAYORDER,:DISPLAYTITLE)";
        private const string SQL_UpdateV2G = @"update md_view2gl set viewid=:VIEWID,targetgl=:TARGETGL,targetcs=:TARGETCS,displayorder=:DISPLAYORDER,displaytitle=:DISPLAYTITLE where id=:ID";
        public bool SaveView2GL(string V2GID, string VIEWID, string GuideLineID, string Params, int DisplayOrder, string DisplayTitle)
        {
            OracleCommand SaveCmd;
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                OracleTransaction _txn = cn.BeginTransaction();
                try
                {
                    OracleCommand _cmd = new OracleCommand(SQL_CheckExistV2G, cn);
                    _cmd.Parameters.Add(":ID", V2GID);
                    decimal _count = (decimal)_cmd.ExecuteScalar();
                    if (_count > 0)
                    {
                        SaveCmd = new OracleCommand(SQL_UpdateV2G, cn);
                        SaveCmd.Parameters.Add(":VIEWID", VIEWID);
                        SaveCmd.Parameters.Add(":TARGETGL", GuideLineID);
                        SaveCmd.Parameters.Add(":TARGETCS", Params);
                        SaveCmd.Parameters.Add(":DISPLAYORDER", Convert.ToDecimal(DisplayOrder));
                        SaveCmd.Parameters.Add(":DISPLAYTITLE", DisplayTitle);
                        SaveCmd.Parameters.Add(":ID", V2GID);
                        SaveCmd.ExecuteNonQuery();
                    }
                    else
                    {
                        SaveCmd = new OracleCommand(SQL_InsertV2G, cn);
                        SaveCmd.Parameters.Add(":ID", V2GID);
                        SaveCmd.Parameters.Add(":VIEWID", VIEWID);
                        SaveCmd.Parameters.Add(":TARGETGL", GuideLineID);
                        SaveCmd.Parameters.Add(":TARGETCS", Params);
                        SaveCmd.Parameters.Add(":DISPLAYORDER", Convert.ToDecimal(DisplayOrder));
                        SaveCmd.Parameters.Add(":DISPLAYTITLE", DisplayTitle);
                        SaveCmd.ExecuteNonQuery();
                    }
                    _txn.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    string _msg = string.Format("保存查询模型的关联指标定义时发生错误，错误信息：{0} ", ex.Message);
                    OralceLogWriter.WriteSystemLog(_msg, "ERROR");
                    _txn.Rollback();
                    return false;
                }
            }

        }

        private const string SQL_CMD_DelView2GL = @"delete from md_view2gl where ID=:ID";
        public string CMD_DelView2GL(MD_View_GuideLine View2GL)
        {
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                try
                {
                    OracleCommand _cmdDel = new OracleCommand(SQL_CMD_DelView2GL, cn);
                    _cmdDel.Parameters.Add(":ID", View2GL.ID);
                    _cmdDel.ExecuteNonQuery();
                    return "";
                }
                catch (Exception e)
                {
                    string _msg = string.Format("删除查询模型[{0}]的关联指标扩展信息时发生错误，错误信息：{1} ", View2GL.ViewID, e.Message);
                    OralceLogWriter.WriteSystemLog(_msg, "ERROR");
                    return _msg;
                }
            }
        }

        #endregion

        private const string SQL_GetView2ApplicationList = @"select ID,VIEWID,TITLE,INTEGRATEDAPP,DISPLAYHEIGHT,URL,DISPLAYORDER,META 
                                                                from MD_VIEW2APP where VIEWID=:VIEWID order by DISPLAYORDER";
        public List<MD_View2App> GetView2ApplicationList(string QueryModelID)
        {
            List<MD_View2App> _ret = new List<MD_View2App>();
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                try
                {
                    OracleCommand _cmd = new OracleCommand(SQL_GetView2ApplicationList, cn);
                    _cmd.Parameters.Add(":VIEWID", decimal.Parse(QueryModelID));
                    using (OracleDataReader _dr = _cmd.ExecuteReader())
                    {
                        while (_dr.Read())
                        {
                            MD_View2App _app = new MD_View2App();
                            _app.ID = _dr.IsDBNull(0) ? "" : _dr.GetString(0);
                            _app.ViewID = _dr.IsDBNull(1) ? "" : _dr.GetString(1);
                            _app.Title = _dr.IsDBNull(2) ? "" : _dr.GetString(2);
                            _app.AppName = _dr.IsDBNull(3) ? "" : _dr.GetString(3);
                            _app.DisplayHeight = _dr.IsDBNull(4) ? 40 : Convert.ToInt32(_dr.GetDecimal(4));
                            _app.RegURL = _dr.IsDBNull(5) ? "" : _dr.GetString(5);
                            _app.DisplayOrder = _dr.IsDBNull(6) ? 40 : Convert.ToInt32(_dr.GetDecimal(6));
                            _app.Meta = _dr.IsDBNull(7) ? "" : _dr.GetString(7);

                            _ret.Add(_app);
                        }
                    }

                }
                catch (Exception e)
                {
                    string _err = string.Format("在获取查询模型的集成应用展示定义时发生错误，错误信息：{0}", e.Message);
                    OralceLogWriter.WriteSystemLog(_err, "ERROR");

                }
            }
            return _ret;
        }

        private const string SQL_SaveView2App_Insert = @"insert into MD_VIEW2APP (ID,VIEWID,TITLE,INTEGRATEDAPP,DISPLAYHEIGHT,URL,DISPLAYORDER,META)
                                                            values (:ID,:VIEWID,:TITLE,:INTEGRATEDAPP,:DISPLAYHEIGHT,:URL,:DISPLAYORDER,:META)";
        public bool SaveView2App(string V2AID, MD_View2App View2AppData)
        {
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                OracleTransaction _txn = cn.BeginTransaction();
                try
                {
                    OracleCommand _cmd = new OracleCommand(SQL_CMD_DelView2App, cn);
                    _cmd.Parameters.Add(":ID", decimal.Parse(V2AID));
                    _cmd.ExecuteNonQuery();

                    OracleCommand _ins = new OracleCommand(SQL_SaveView2App_Insert, cn);
                    _ins.Parameters.Add(":ID", decimal.Parse(V2AID));
                    _ins.Parameters.Add(":VIEWID", decimal.Parse(View2AppData.ViewID));
                    _ins.Parameters.Add(":TITLE", View2AppData.Title);
                    _ins.Parameters.Add(":INTEGRATEDAPP", View2AppData.AppName);
                    _ins.Parameters.Add(":DISPLAYHEIGHT", Convert.ToDecimal(View2AppData.DisplayHeight));
                    _ins.Parameters.Add(":URL", View2AppData.RegURL);
                    _ins.Parameters.Add(":DISPLAYORDER", Convert.ToDecimal(View2AppData.DisplayOrder));
                    _ins.Parameters.Add(":META", View2AppData.Meta);
                    _ins.ExecuteNonQuery();

                    _txn.Commit();
                    return true;
                }
                catch (Exception e)
                {
                    string _err = string.Format("在保存查询模型的集成应用展示定义时发生错误，错误信息：{0}", e.Message);
                    OralceLogWriter.WriteSystemLog(_err, "ERROR");
                    return false;
                }
            }
        }

        private const string SQL_CMD_DelView2App = @"DELETE FROM MD_VIEW2APP where id=:ID";
        public string CMD_DelView2App(string V2AID)
        {
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                try
                {
                    OracleCommand _cmd = new OracleCommand(SQL_CMD_DelView2App, cn);
                    _cmd.Parameters.Add(":ID", decimal.Parse(V2AID));
                    _cmd.ExecuteNonQuery();
                    return "";
                }
                catch (Exception e)
                {
                    string _err = string.Format("在删除查询模型的集成应用展示定义时发生错误，错误信息：{0}", e.Message);
                    OralceLogWriter.WriteSystemLog(_err, "ERROR");
                    return _err;
                }
            }
        }

        private const string SQL_CMD_ClearView2App = @"DELETE FROM MD_VIEW2APP where VIEWID=:VIEWID";
        public string CMD_ClearView2App(string QueryModelID)
        {
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                try
                {
                    OracleCommand _cmd = new OracleCommand(SQL_CMD_ClearView2App, cn);
                    _cmd.Parameters.Add(":VIEWID", QueryModelID);
                    _cmd.ExecuteNonQuery();
                    return "";
                }
                catch (Exception e)
                {
                    string _err = string.Format("在清空查询模型的集成应用展示定义时发生错误，错误信息：{0}", e.Message);
                    OralceLogWriter.WriteSystemLog(_err, "ERROR");
                    return _err;
                }
            }
        }
    }
}
