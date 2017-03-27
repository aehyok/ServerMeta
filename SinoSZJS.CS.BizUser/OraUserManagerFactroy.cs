using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SinoSZJS.Base.Misc;
using SinoSZJS.Base.Authorize;
using SinoSZJS.Base.User;
using Oracle.DataAccess.Client;
using SinoSZJS.DataAccess;

namespace SinoSZJS.CS.BizUser
{
    public class OraUserManagerFactroy : IUserManager
    {
        #region IUserManager Members

        public List<UserMappingInfo> GetUserListMapping(decimal _orgid, decimal _levelNum)
        {
            List<UserMappingInfo> _ret = new List<UserMappingInfo>();
            string _sql = "jsyw_jsaj.get_trd_yhdzxx_js_qx";

            OracleParameter[] _param = {
                                        new OracleParameter("nParent", OracleDbType.Decimal),
                                        new OracleParameter("nLevel",OracleDbType.Decimal),                              
                                        new OracleParameter("curyhxx",OracleDbType.RefCursor,DBNull.Value,ParameterDirection.Output)
                                 };
            _param[0].Value = _orgid;
            _param[1].Value = _levelNum;

            OracleDataReader dr = OracleHelper.ExecuteReader(OracleHelper.ConnectionStringProfile, CommandType.StoredProcedure,
                        _sql, _param);

            while (dr.Read())
            {
                UserMappingInfo _mitem = new UserMappingInfo(
                    dr.IsDBNull(0) ? "" : dr.GetDecimal(0).ToString(),
                    dr.IsDBNull(1) ? "" : dr.GetString(1),
                    dr.IsDBNull(2) ? "" : dr.GetDecimal(2).ToString(),
                    dr.IsDBNull(3) ? "" : dr.GetDecimal(3).ToString(),
                    dr.IsDBNull(16) ? "" : dr.GetString(16),
                    dr.IsDBNull(15) ? "" : dr.GetString(15),
                    dr.IsDBNull(5) ? "" : dr.GetString(5),
                    dr.IsDBNull(6) ? "" : dr.GetString(6),
                    dr.IsDBNull(7) ? "" : dr.GetString(7),
                    dr.IsDBNull(8) ? "" : dr.GetString(8),
                    dr.IsDBNull(9) ? "" : dr.GetString(9),
                    dr.IsDBNull(10) ? "" : dr.GetString(10),
                    dr.IsDBNull(11) ? "" : dr.GetString(11),
                    dr.IsDBNull(12) ? "" : dr.GetString(12),
                    dr.IsDBNull(13) ? "" : dr.GetDecimal(13).ToString(),
                    dr.IsDBNull(14) ? "" : dr.GetString(14)
                );
                _mitem.TRD_YHID = dr.IsDBNull(17) ? "" : dr.GetDecimal(17).ToString();
                _mitem.TRD_LoginName = dr.IsDBNull(18) ? "" : dr.GetString(18).ToString();
                _mitem.TRD_XM = dr.IsDBNull(19) ? "" : dr.GetString(19);
                _ret.Add(_mitem);
            }
            dr.Close();
            return _ret;
        }

        public List<UserBaseInfo> GetUserListInOrg(decimal _orgid, decimal _levelNum)
        {
            List<UserBaseInfo> _ret = new List<UserBaseInfo>();
            string _sql = "zhtj_zzjg2.Get_yhxx_JS_qx";

            OracleParameter[] _param = {
                                        new OracleParameter("nParent", OracleDbType.Decimal),
                                        new OracleParameter("nLevel",OracleDbType.Decimal),                              
                                        new OracleParameter("curyhxx",OracleDbType.RefCursor,DBNull.Value,ParameterDirection.Output)
                                 };
            _param[0].Value = _orgid;
            _param[1].Value = _levelNum;

            OracleDataReader dr = OracleHelper.ExecuteReader(OracleHelper.ConnectionStringProfile, CommandType.StoredProcedure,
                        _sql, _param);

            while (dr.Read())
            {
                UserBaseInfo _mitem = new UserBaseInfo(
                    dr.IsDBNull(0) ? "" : dr.GetDecimal(0).ToString(),
                    dr.IsDBNull(1) ? "" : dr.GetString(1),
                    dr.IsDBNull(2) ? "" : dr.GetDecimal(2).ToString(),
                    dr.IsDBNull(3) ? "" : dr.GetDecimal(3).ToString(),
                    dr.IsDBNull(16) ? "" : dr.GetString(16),
                    dr.IsDBNull(15) ? "" : dr.GetString(15),
                    dr.IsDBNull(5) ? "" : dr.GetString(5),
                    dr.IsDBNull(6) ? "" : dr.GetString(6),
                    dr.IsDBNull(7) ? "" : dr.GetString(7),
                    dr.IsDBNull(8) ? "" : dr.GetString(8),
                    dr.IsDBNull(9) ? "" : dr.GetString(9),
                    dr.IsDBNull(10) ? "" : dr.GetString(10),
                    dr.IsDBNull(11) ? "" : dr.GetString(11),
                    dr.IsDBNull(12) ? "" : dr.GetString(12),
                    dr.IsDBNull(13) ? "" : dr.GetDecimal(13).ToString(),
                    dr.IsDBNull(14) ? "" : dr.GetString(14)
                );
                _ret.Add(_mitem);
            }
            dr.Close();
            return _ret;
        }

        public List<UserExtInfo> GetUserMobileList(decimal _orgid, decimal _LevelNum)
        {
            List<UserExtInfo> _ret = new List<UserExtInfo>();
            string _sql = "zhtj_zzjg2.Get_yhxx_JS_qx_userext";

            OracleParameter[] _param = {
                                        new OracleParameter("nParent", OracleDbType.Decimal),
                                        new OracleParameter("nLevel",OracleDbType.Decimal),                              
                                        new OracleParameter("curyhxx",OracleDbType.RefCursor,DBNull.Value,ParameterDirection.Output)
                                 };
            _param[0].Value = _orgid;
            _param[1].Value = _LevelNum;

            OracleDataReader dr = OracleHelper.ExecuteReader(OracleHelper.ConnectionStringProfile, CommandType.StoredProcedure,
                        _sql, _param);

            while (dr.Read())
            {
                UserExtInfo _mitem = new UserExtInfo(
                    dr.IsDBNull(0) ? "" : dr.GetDecimal(0).ToString(),
                    dr.IsDBNull(1) ? "" : dr.GetString(1),
                    dr.IsDBNull(2) ? "" : dr.GetString(2),
                    dr.IsDBNull(3) ? "" : dr.GetString(3),
                    dr.IsDBNull(4) ? "" : dr.GetString(4)
                );
                _ret.Add(_mitem);
            }
            dr.Close();
            return _ret;
        }

        public List<PersonBaseInfo> GetPersionListInOrg(decimal _orgid, decimal _levelNum)
        {
            List<PersonBaseInfo> _ret = new List<PersonBaseInfo>();
            string _sql = "zhtj_zzjg2.Get_ryxx_JS_qx";

            OracleParameter[] _param = {
                                        new OracleParameter("nParent", OracleDbType.Decimal),
                                        new OracleParameter("nLevel",OracleDbType.Decimal),                              
                                        new OracleParameter("curyhxx",OracleDbType.RefCursor,DBNull.Value,ParameterDirection.Output)
                                 };
            _param[0].Value = _orgid;
            _param[1].Value = _levelNum;

            OracleDataReader dr = OracleHelper.ExecuteReader(OracleHelper.ConnectionStringProfile, CommandType.StoredProcedure,
                        _sql, _param);

            while (dr.Read())
            {
                PersonBaseInfo _mitem = new PersonBaseInfo(
                    dr.IsDBNull(2) ? "" : dr.GetDecimal(2).ToString(),
                    dr.IsDBNull(0) ? "" : dr.GetDecimal(0).ToString(),
                    dr.IsDBNull(5) ? "" : dr.GetString(5),
                    dr.IsDBNull(1) ? "" : dr.GetString(1),
                    dr.IsDBNull(3) ? "" : dr.GetDecimal(3).ToString(),
                    dr.IsDBNull(12) ? "" : dr.GetString(12),
                    dr.IsDBNull(12) ? "" : dr.GetString(12),
                    dr.IsDBNull(10) ? "" : dr.GetString(10)
                );
                _ret.Add(_mitem);
            }
            dr.Close();
            return _ret;

        }


        private const string SQL_RegisterUser = "insert into QX_TJYHB (YHID,YHM,KL,XDJB,AQJB) values (:YHID,:YHM,:KL,'科室级',0)";
        public bool RegisterUser(PersonBaseInfo _personBaseInfo)
        {
            string _selectStr = "select count(*) from QX_TJYHB WHERE YHID =:YHID and YHM = :YHM";
            OracleParameter[] _param = {
                                        new OracleParameter(":YHID", OracleDbType.Decimal),
                                        new OracleParameter(":YHM",OracleDbType.Varchar2)
                                 };
            _param[0].Value = decimal.Parse(_personBaseInfo.UserID);
            _param[1].Value = _personBaseInfo.LoginName;

            Decimal i = (decimal)OracleHelper.ExecuteScalar(OracleHelper.ConnectionStringProfile, CommandType.Text, _selectStr, _param);
            if (i > 0) return false;


            OracleParameter[] _param2 = {
                                        new OracleParameter(":YHID", OracleDbType.Decimal),
                                        new OracleParameter(":YHM",OracleDbType.Varchar2),
                                        new OracleParameter(":KL",OracleDbType.Varchar2)
                                 };
            _param2[0].Value = decimal.Parse(_personBaseInfo.UserID);
            _param2[1].Value = _personBaseInfo.LoginName;
            _param2[2].Value = MD5Base64.Encode(_personBaseInfo.LoginName);

            OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionStringProfile, CommandType.Text, SQL_RegisterUser, _param2);
            return true;
        }


        public List<SinoRole> GetRoleList()
        {
            List<SinoRole> _ret = new List<SinoRole>();
            string _selectsql = "select JSID,JSMC,JSSM,SSDWID from qx_jsdyb where (SSDWID is null) or (SSDWID=:SYSTEMID)";
            OracleParameter[] _param = {
                                        new OracleParameter(":SYSTEMID", OracleDbType.Decimal) };
            _param[0].Value = Decimal.Parse(ConfigFile.SystemID);

            OracleDataReader dr = OracleHelper.ExecuteReader(OracleHelper.ConnectionStringProfile, CommandType.Text, _selectsql, _param);

            while (dr.Read())
            {
                SinoRole _mitem = new SinoRole();
                _mitem.RoleID = dr.IsDBNull(0) ? "" : dr.GetDecimal(0).ToString();
                _mitem.RoleName = dr.IsDBNull(1) ? "" : dr.GetString(1);
                _mitem.Descript = dr.IsDBNull(2) ? "" : dr.GetString(2);
                _mitem.RoleDwid = dr.IsDBNull(3) ? "" : dr.GetDecimal(3).ToString();
                _ret.Add(_mitem);
            }
            dr.Close();
            return _ret;
        }



        public bool AddNewRole(SinoRole _newRole)
        {
            string _insSql = "insert into qx_jsdyb (JSID,JSMC,JSSM,SSDWID) values (seq_qx2.nextval,:JSMC,:JSDM,:SSDWID)";
            OracleParameter[] _param = {
                                        new OracleParameter(":JSMC", OracleDbType.Varchar2),
                                        new OracleParameter(":JSDM",OracleDbType.Varchar2),
					new OracleParameter(":SSDWID",OracleDbType.Decimal)
                                 };
            _param[0].Value = _newRole.RoleName;
            _param[1].Value = _newRole.Descript;
            _param[2].Value = decimal.Parse(ConfigFile.SystemID);
            OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionStringProfile, CommandType.Text, _insSql, _param);
            return true;
        }



        public List<UserRightInfo> GetRightListByRoleID(string _roleID)
        {
            List<UserRightInfo> _ret = new List<UserRightInfo>();
            string _sql = "zhtj_zzjg2.get_jslb";
            OracleParameter[] _param = {
                                        new OracleParameter("njsid", OracleDbType.Decimal),                                                    
                                        new OracleParameter("curqx",OracleDbType.RefCursor,DBNull.Value,ParameterDirection.Output)
                                 };
            _param[0].Value = decimal.Parse(_roleID);

            OracleDataReader dr = OracleHelper.ExecuteReader(OracleHelper.ConnectionStringProfile, CommandType.StoredProcedure,
                        _sql, _param);

            while (dr.Read())
            {
                UserRightInfo _uf = new UserRightInfo(
                    dr.IsDBNull(2) ? "" : dr.GetDecimal(2).ToString(),
                    dr.IsDBNull(3) ? "" : dr.GetString(3),
                    dr.IsDBNull(6) ? "-1" : dr.GetDecimal(6).ToString(),
                    dr.IsDBNull(1) ? 0 : Convert.ToInt32(dr.GetDecimal(1)),
                    dr.IsDBNull(9) ? false : (dr.GetDecimal(9) > 0)
                );
                _ret.Add(_uf);
            }
            dr.Close();
            return _ret;
        }


        public List<UserQueryModelInfo> GetModelRightListByRoleID(string _roleID)
        {
            List<UserQueryModelInfo> _ret = new List<UserQueryModelInfo>();
            StringBuilder _sb = new StringBuilder();
            _sb.Append("select t1.viewid,t1.namespace,t1.viewname,t1.displayname, ");
            _sb.Append("  (select DISPLAYTITLE from md_tbnamespace t2 where t2.namespace=t1.namespace) nstitle, ");
            _sb.Append(" case when t3.id is null then 0 else 1 end SFY ");
            _sb.Append(" from md_view t1 ");
            _sb.Append(" left join (select id,viewid from qx_jscxmxgxb where jsid = :JSID )t3 on t3.viewid = t1.viewid ");
            _sb.Append("  ORDER BY T1.DISPLAYORDER ");

            OracleParameter[] _param = {
                                        new OracleParameter(":JSID", OracleDbType.Decimal)
                                 };
            _param[0].Value = decimal.Parse(_roleID);
            OracleDataReader dr = OracleHelper.ExecuteReader(OracleHelper.ConnectionStringProfile, CommandType.Text,
                      _sb.ToString(), _param);

            while (dr.Read())
            {
                UserQueryModelInfo _uf = new UserQueryModelInfo(
                    dr.IsDBNull(0) ? "" : dr.GetDecimal(0).ToString(),
                    dr.IsDBNull(1) ? "" : dr.GetString(1),
                    dr.IsDBNull(2) ? "" : dr.GetString(2),
                    dr.IsDBNull(3) ? "" : dr.GetString(3),
                    dr.IsDBNull(5) ? false : (dr.GetDecimal(5) > 0)
                );
                _ret.Add(_uf);
            }
            dr.Close();
            return _ret;
        }


        public bool SaveRightsOfRole(SinoRole _role, List<UserRightInfo> _functionRights, List<UserQueryModelInfo> _modelRights)
        {
            //保存角色信息
            string _updateSql = "update qx_jsdyb set JSMC=:JSMC,JSSM=:JSSM where JSID=:JSID";
            OracleParameter[] _param = {
                                        new OracleParameter(":JSMC", OracleDbType.Varchar2),
                                        new OracleParameter(":JSDM",OracleDbType.Varchar2),
                                        new OracleParameter(":JSID",OracleDbType.Decimal)
                                 };
            _param[0].Value = _role.RoleName;
            _param[1].Value = _role.Descript;
            _param[2].Value = decimal.Parse(_role.RoleID);
            OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionStringProfile, CommandType.Text, _updateSql, _param);

            //清除角色的原功能授权
            string _del = "delete from qx_jsqxgxb where jsid = :JSID";
            OracleParameter[] _delParam = {
                                        new OracleParameter(":JSID", OracleDbType.Decimal)
                                 };
            _delParam[0].Value = decimal.Parse(_role.RoleID);
            OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionStringProfile, CommandType.Text, _del, _delParam);

            //清除角色的原模型授权
            string _delModelRight = "delete from qx_jscxmxgxb where jsid=:JSID";
            OracleParameter[] _delParam2 = {
                                        new OracleParameter(":JSID", OracleDbType.Decimal)
                                 };
            _delParam2[0].Value = decimal.Parse(_role.RoleID);
            OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionStringProfile, CommandType.Text, _delModelRight, _delParam2);

            //添加功能授权
            string _insertFunRight = "insert into qx_jsqxgxb (ID,JSID,QXID,QXJB) values ";
            _insertFunRight += " (seq_qx2.nextval,:JSID,:QXID,:QXJB) ";
            foreach (UserRightInfo _ur in _functionRights)
            {
                OracleParameter[] _InsertParam = {
                                        new OracleParameter(":JSID", OracleDbType.Decimal),
                                        new OracleParameter(":QXID", OracleDbType.Decimal),
                                        new OracleParameter(":QXJB", OracleDbType.Decimal)
                                 };
                _InsertParam[0].Value = decimal.Parse(_role.RoleID);
                _InsertParam[1].Value = decimal.Parse(_ur.RightID);
                _InsertParam[2].Value = (decimal)0;
                OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionStringProfile, CommandType.Text, _insertFunRight, _InsertParam);
            }

            //添加模型授权
            string _insertModelRight = "insert into qx_jscxmxgxb (ID,JSID,NAMESPACE,VIEWID) values ";
            _insertModelRight += " (seq_qx2.nextval,:JSID,:NAMESPACE,:VIEWID) ";
            foreach (UserQueryModelInfo _qvr in _modelRights)
            {
                OracleParameter[] _InsertParam = {
                                        new OracleParameter(":JSID", OracleDbType.Decimal),
                                        new OracleParameter(":NAMESPACE", OracleDbType.Varchar2),
                                        new OracleParameter(":VIEWID", OracleDbType.Decimal)
                                 };
                _InsertParam[0].Value = decimal.Parse(_role.RoleID);
                _InsertParam[1].Value = _qvr.QueryModelNamespace;
                _InsertParam[2].Value = decimal.Parse(_qvr.QueryModelID);
                OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionStringProfile, CommandType.Text, _insertModelRight, _InsertParam);
            }

            return true;

        }



        public bool DeleteRole(SinoRole _role)
        {
            string _delSql = "delete from qx_jsdyb  where JSID=:JSID";
            OracleParameter[] _param = {
                                        new OracleParameter(":JSID",OracleDbType.Decimal)
                                 };

            _param[0].Value = decimal.Parse(_role.RoleID);
            OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionStringProfile, CommandType.Text, _delSql, _param);
            return true;
        }

        public List<SinoPost> GetPostListInOrg(SinoOrganize CurrentOrg)
        {
            List<SinoPost> _ret = new List<SinoPost>();
            string _sql = @"select a.GWMC,a.GWID,a.GWDWID,zhtj_zzjg2.GETDWMC(a.gwdwid) dwmc,zhtj_zzjg2.GETDWDM_hgjs(a.gwdwid) DWDM,
								a.GWMS,a.SECRETLEVEL,0 SFMR from QX2_GWDYB a where a.gwdwid =:DWID and ( (a.SSDWID IS NULL) or (a.SSDWID=:SSDWID))";
            OracleParameter[] _param = {
                                        new OracleParameter(":DWID",OracleDbType.Decimal),
					new OracleParameter(":SSDWID",OracleDbType.Decimal)
                                 };
            _param[0].Value = CurrentOrg.Code;
            _param[1].Value = decimal.Parse(ConfigFile.SystemID);
            OracleDataReader dr = OracleHelper.ExecuteReader(OracleHelper.ConnectionStringProfile, CommandType.Text,
                        _sql, _param);

            while (dr.Read())
            {
                SinoPost _uf = new SinoPost(
                    dr.IsDBNull(0) ? "" : dr.GetString(0),
                    dr.IsDBNull(1) ? "" : dr.GetDecimal(1).ToString(),
                    dr.IsDBNull(2) ? "" : dr.GetDecimal(2).ToString(),
                    dr.IsDBNull(3) ? "" : dr.GetString(3),
                    dr.IsDBNull(4) ? "" : dr.GetString(4),
                    dr.IsDBNull(5) ? "" : dr.GetString(5),
                     dr.IsDBNull(6) ? (int)0 : Convert.ToInt32(dr.GetDecimal(6)),
                    false
                      );

                _ret.Add(_uf);
            }
            dr.Close();
            return _ret;
        }

        public bool AddPostOfOrg(string _postName, string _postDescript, int _PostLevel, decimal _orgID)
        {
            string _ins = "insert into qx2_gwdyb (gwid,gwmc,gwms,gwdwid,secretlevel,SSDWID) values ";
            _ins += " (seq_qx2.nextval,:GWMC,:GWMS,:GWDWID,:SECRETLEVEL,:SSDWID) ";
            OracleParameter[] _param = {
                                        new OracleParameter(":GWMC",OracleDbType.Varchar2),
                                        new OracleParameter(":GWMS",OracleDbType.Varchar2),
                                        new OracleParameter(":GWDWID",OracleDbType.Decimal),
                                        new OracleParameter(":SECRETLEVEL",OracleDbType.Decimal),
					new OracleParameter (":SSDWID",OracleDbType.Decimal)
                                 };
            _param[0].Value = _postName;
            _param[1].Value = _postDescript;
            _param[2].Value = _orgID;
            _param[3].Value = Convert.ToDecimal(_PostLevel);
            _param[4].Value = decimal.Parse(ConfigFile.SystemID);

            OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionStringProfile, CommandType.Text, _ins, _param);
            return true;
        }

        public bool DelPostOfOrg(string _postID)
        {
            string _delStr = "delete from qx2_gwdyb where gwid=:GWID";
            OracleParameter[] _param = { new OracleParameter(":GWID", OracleDbType.Decimal) };
            _param[0].Value = decimal.Parse(_postID);
            OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionStringProfile, CommandType.Text, _delStr, _param);
            return true;
        }




        public bool ModifyPostOfOrg(string _postName, string _postDescript, int _PostLevel, string _postID)
        {
            string _upStr = "update qx2_gwdyb set GWMC=:GWMC,GWMS=:GWMS,SECRETLEVEL=:SLEVEL ";
            _upStr += " where GWID=:GWID ";
            OracleParameter[] _param = {
                                        new OracleParameter(":GWMC",OracleDbType.Varchar2),
                                        new OracleParameter(":GWMS",OracleDbType.Varchar2),                                       
                                        new OracleParameter(":SLEVEL",OracleDbType.Decimal),
                                        new OracleParameter(":GWID",OracleDbType.Decimal),
                                 };
            _param[0].Value = _postName;
            _param[1].Value = _postDescript;
            _param[2].Value = Convert.ToDecimal(_PostLevel);
            _param[3].Value = decimal.Parse(_postID);

            OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionStringProfile, CommandType.Text, _upStr, _param);
            return true;
        }


        public List<SinoRole> GetRoleOfPost(string _postID)
        {
            string _sql = string.Format(" select a.jsid,a.jsmc,a.jssm,a.ssdwid from qx2_gwjsgxb t,qx_jsdyb a ");
            _sql += string.Format("where a.jsid = t.jsid and t.gwid = :GWID");
            OracleParameter[] _param = {
                                new OracleParameter(":GWID", OracleDbType.Decimal),
                        };
            _param[0].Value = decimal.Parse(_postID);

            List<SinoRole> roles = new List<SinoRole>();

            OracleDataReader dr = OracleHelper.ExecuteReader(OracleHelper.ConnectionStringProfile, CommandType.Text, _sql, _param);

            while (dr.Read())
            {

                SinoRole _sr = RightFunctions.CreateRoleItem(dr.GetDecimal(0).ToString(),
                    dr.IsDBNull(1) ? "" : dr.GetString(1),
                    dr.IsDBNull(2) ? "" : dr.GetString(2),
                    dr.IsDBNull(3) ? "" : dr.GetDecimal(3).ToString()
                    );
                roles.Add(_sr);
            }
            dr.Close();

            return roles;
        }



        public bool SaveRolesOfPost(List<SinoRole> _roleList, string _postID)
        {
            string _del = "delete from qx2_gwjsgxb where gwid=:GWID ";
            OracleParameter[] _param2 = {
                                        new OracleParameter(":GWID", OracleDbType.Decimal)
                                        };
            _param2[0].Value = decimal.Parse(_postID);
            OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionStringProfile, CommandType.Text, _del, _param2);

            string _ins = "insert into qx2_gwjsgxb (id,gwid,jsid) values (seq_qx2.nextval,:GWID,:JSID) ";
            foreach (SinoRole _sr in _roleList)
            {
                OracleParameter[] _param = {
                                        new OracleParameter(":GWID", OracleDbType.Decimal),
                                        new OracleParameter(":JSID", OracleDbType.Decimal)
                                        };
                _param[0].Value = decimal.Parse(_postID);
                _param[1].Value = decimal.Parse(_sr.RoleID);

                OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionStringProfile, CommandType.Text, _ins, _param);
            }
            return true;
        }



        public bool PastePostToOrg(List<SinoPost> _clipPad, SinoOrganize _org)
        {
            string _cmdStr = "zhtj_zzjg2.replicategw";
            foreach (SinoPost _post in _clipPad)
            {
                OracleParameter[] _param = {
                                        new OracleParameter("ngwid", OracleDbType.Decimal),
                                        new OracleParameter("nnewdwid", OracleDbType.Decimal),
                                        new OracleParameter("nnewgwid",OracleDbType.Decimal)
                                        };

                _param[0].Value = decimal.Parse(_post.PostID);
                _param[1].Value = _org.Code;
                _param[2].Direction = ParameterDirection.Output;
                OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionStringProfile, CommandType.StoredProcedure, _cmdStr, _param);
            }
            return true;
        }


        public List<UserRightInfo> GetRightListByPostID(string _postID)
        {
            List<UserRightInfo> _ret = new List<UserRightInfo>();
            string _sql = "zhtj_zzjg2.Get_GWCZQX";
            OracleParameter[] _param = {
                                        new OracleParameter("nGWID", OracleDbType.Decimal),                                                    
                                        new OracleParameter("curQXDW",OracleDbType.RefCursor,DBNull.Value,ParameterDirection.Output)
                                 };
            _param[0].Value = decimal.Parse(_postID);

            OracleDataReader dr = OracleHelper.ExecuteReader(OracleHelper.ConnectionStringProfile, CommandType.StoredProcedure,
                        _sql, _param);

            while (dr.Read())
            {
                UserRightInfo _uf = new UserRightInfo(
                    dr.IsDBNull(2) ? "" : dr.GetDecimal(2).ToString(),
                    dr.IsDBNull(3) ? "" : dr.GetString(3),
                    dr.IsDBNull(6) ? "" : dr.GetDecimal(6).ToString(),
                    dr.IsDBNull(1) ? 0 : Convert.ToInt32(dr.GetDecimal(1)),
                    dr.IsDBNull(9) ? false : (dr.GetDecimal(9) > 0)
                );
                _ret.Add(_uf);
            }
            dr.Close();
            return _ret;
        }

        public List<UserQueryModelInfo> GetModelRightListByPostID(string _postID)
        {
            List<UserQueryModelInfo> _ret = new List<UserQueryModelInfo>();
            StringBuilder _sb = new StringBuilder();
            _sb.Append("select t1.viewid,t1.namespace,t1.viewname,t1.displayname, ");
            _sb.Append("  (select DISPLAYTITLE from md_tbnamespace t2 where t2.namespace=t1.namespace) nstitle, ");
            _sb.Append(" zhtj_zzjg2.GWRightWithViewID(:GWID,t1.viewid) SFY ");
            _sb.Append(" from md_view t1 ");
            _sb.Append("  ORDER BY T1.DISPLAYORDER ");

            OracleParameter[] _param = {
                                        new OracleParameter(":GWID", OracleDbType.Decimal)
                                 };
            _param[0].Value = decimal.Parse(_postID);
            OracleDataReader dr = OracleHelper.ExecuteReader(OracleHelper.ConnectionStringProfile, CommandType.Text,
                      _sb.ToString(), _param);

            while (dr.Read())
            {
                UserQueryModelInfo _uf = new UserQueryModelInfo(
                    dr.IsDBNull(0) ? "" : dr.GetDecimal(0).ToString(),
                    dr.IsDBNull(1) ? "" : dr.GetString(1),
                    dr.IsDBNull(2) ? "" : dr.GetString(2),
                    dr.IsDBNull(3) ? "" : dr.GetString(3),
                    dr.IsDBNull(5) ? false : (dr.GetDecimal(5) > 0)
                );
                _ret.Add(_uf);
            }
            dr.Close();
            return _ret;
        }


        public List<UserPostInfo> GetPostListByUserID(string _userID)
        {
            List<UserPostInfo> _ret = new List<UserPostInfo>();

            string _sql = @"select a.gwmc,a.gwid,a.gwdwid,zhtj_zzjg2.GETDWMC(a.gwdwid) dwmc,zhtj_zzjg2.GETDWDM_hgjs(a.gwdwid) DWDM,
							a.gwms,b.IS_DEFAULT SFMR,a.SECRETLEVEL from qx2_gwdyb a,QX_YHGWGXB b where b.gwid=a.gwid and b.yhid=:YHID
							and  ( (a.SSDWID IS NULL) or (a.SSDWID=:SSDWID))";
            OracleParameter[] _param = {
                                        new OracleParameter(":GWID", OracleDbType.Decimal),
					new OracleParameter(":SSDWID",OracleDbType.Decimal)
                                 };
            _param[0].Value = decimal.Parse(_userID);
            _param[1].Value = decimal.Parse(ConfigFile.SystemID);
            OracleDataReader dr = OracleHelper.ExecuteReader(OracleHelper.ConnectionStringProfile, CommandType.Text, _sql, _param);
            while (dr.Read())
            {
                SinoPost _sp = new SinoPost(dr.GetString(0),
                    dr.IsDBNull(1) ? "" : dr.GetDecimal(1).ToString(),
                    dr.IsDBNull(2) ? "" : dr.GetDecimal(2).ToString(),
                    dr.IsDBNull(3) ? "" : dr.GetString(3),
                    dr.IsDBNull(4) ? "" : dr.GetString(4),
                    dr.IsDBNull(5) ? "" : dr.GetString(5),
                    dr.IsDBNull(7) ? (int)0 : Convert.ToInt32(dr.GetDecimal(7)),
                    dr.IsDBNull(6) ? false : (((decimal)dr.GetOracleDecimal(6).Value == 1) ? true : false));
                _ret.Add(new UserPostInfo(_sp));
            }
            dr.Close();

            return _ret;
        }

        public bool IsExistUserPost(string _userID, string _postID)
        {
            string _sql = "select count(id)  from QX_YHGWGXB b where b.gwid=:GWID and b.yhid=:YHID";
            OracleParameter[] _param = {
                                        new OracleParameter(":GWID", OracleDbType.Decimal),
                                        new OracleParameter(":YHID",OracleDbType.Decimal)
                                 };
            _param[0].Value = decimal.Parse(_postID);
            _param[1].Value = decimal.Parse(_userID);
            decimal _ret = (decimal)OracleHelper.ExecuteScalar(OracleHelper.ConnectionStringProfile, CommandType.Text, _sql, _param);
            return _ret > 0;
        }

        public bool AddUserPost(string _userID, string _postID)
        {
            string _sql = "insert into QX_YHGWGXB (ID,GWID,YHID,IS_DEFAULT) values (seq_qx2.nextval,:GWID,:YHID,0) ";
            OracleParameter[] _param = {
                                        new OracleParameter(":GWID", OracleDbType.Decimal),
                                        new OracleParameter(":YHID",OracleDbType.Decimal)
                                 };
            _param[0].Value = decimal.Parse(_postID);
            _param[1].Value = decimal.Parse(_userID);
            OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionStringProfile, CommandType.Text, _sql, _param);
            return true;
        }

        public bool UnRegisterUser(string _userID)
        {
            string _del = "delete from qx_yhjsgxb where yhid=:YHID";
            OracleParameter[] _param =  {                                       
                                        new OracleParameter(":YHID",OracleDbType.Decimal)
                                 };
            _param[0].Value = decimal.Parse(_userID);
            OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionStringProfile, CommandType.Text, _del, _param);

            _del = "delete from qx_yhqxb where yhid = :YHID";
            _param = new OracleParameter[]  {                                       
                                        new OracleParameter(":YHID",OracleDbType.Decimal)
                                 };
            _param[0].Value = decimal.Parse(_userID);
            OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionStringProfile, CommandType.Text, _del, _param);

            _del = "delete from qx_tjyhb where yhid =:YHID";
            _param = new OracleParameter[] {                                       
                                        new OracleParameter(":YHID",OracleDbType.Decimal)
                                 };
            _param[0].Value = decimal.Parse(_userID);
            OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionStringProfile, CommandType.Text, _del, _param);

            return true;
        }



        public bool DeleteUserPost(string _userID, string _postID)
        {
            string _sql = "delete from QX_YHGWGXB where GWID = :GWID AND YHID=:YHID ";
            OracleParameter[] _param = {
                                        new OracleParameter(":GWID", OracleDbType.Decimal),
                                        new OracleParameter(":YHID",OracleDbType.Decimal)
                                 };
            _param[0].Value = decimal.Parse(_postID);
            _param[1].Value = decimal.Parse(_userID);
            OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionStringProfile, CommandType.Text, _sql, _param);
            return true;
        }

        public bool SetDefaultUserPost(string _userID, string _postID)
        {
            string _sql = "update QX_YHGWGXB set IS_DEFAULT=0  where YHID=:YHID ";
            OracleParameter[] _param = {                                      
                                        new OracleParameter(":YHID",OracleDbType.Decimal)
                                 };
            _param[0].Value = decimal.Parse(_userID);
            OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionStringProfile, CommandType.Text, _sql, _param);

            string _sql2 = "update QX_YHGWGXB set IS_DEFAULT=1  where  GWID = :GWID AND YHID=:YHID ";
            OracleParameter[] _param2 = {
                                        new OracleParameter(":GWID", OracleDbType.Decimal),
                                        new OracleParameter(":YHID",OracleDbType.Decimal)
                                 };
            _param2[0].Value = decimal.Parse(_postID);
            _param2[1].Value = decimal.Parse(_userID);
            OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionStringProfile, CommandType.Text, _sql2, _param2);
            return true;
        }


        private const string SQL_GetUsersOfPost = @"  select ry.yhid, ry.yhm, ry.ryid, ry.dwid, ry.djsfzh, ry.xm, ry.xb, ry.hggh, ry.jh, ry.yjdz,ry.zwmc,ry.zwjb
                                                                              ,tjyh.xdjb,tjyh.aqjb,tjyh.lx,jg.zzjgmc ,jg.jgqc
                                                                              from qx2_yhxx ry, qx_tjyhb tjyh ,qx2_zzjg jg
                                                                              where tjyh.yhid=ry.yhid
                                                                                    and ry.dwid=jg.zzjgid
                                                                                    and ry.yhid in  (select yhid from qx_yhgwgxb where gwid=:GWID) ";
        public List<UserBaseInfo> GetUsersOfPost(string _postID)
        {
            List<UserBaseInfo> _ret = new List<UserBaseInfo>();
            OracleParameter[] _param = {
                                        new OracleParameter(":GWID", OracleDbType.Decimal)                                  
                                 };
            _param[0].Value = decimal.Parse(_postID);


            OracleDataReader dr = OracleHelper.ExecuteReader(OracleHelper.ConnectionStringProfile, CommandType.Text,
                        SQL_GetUsersOfPost, _param);

            while (dr.Read())
            {
                UserBaseInfo _mitem = new UserBaseInfo(
                    dr.IsDBNull(0) ? "" : dr.GetDecimal(0).ToString(),
                    dr.IsDBNull(1) ? "" : dr.GetString(1),
                    dr.IsDBNull(2) ? "" : dr.GetDecimal(2).ToString(),
                    dr.IsDBNull(3) ? "" : dr.GetDecimal(3).ToString(),
                    dr.IsDBNull(16) ? "" : dr.GetString(16),
                    dr.IsDBNull(15) ? "" : dr.GetString(15),
                    dr.IsDBNull(5) ? "" : dr.GetString(5),
                    dr.IsDBNull(6) ? "" : dr.GetString(6),
                    dr.IsDBNull(7) ? "" : dr.GetString(7),
                    dr.IsDBNull(8) ? "" : dr.GetString(8),
                    dr.IsDBNull(9) ? "" : dr.GetString(9),
                    dr.IsDBNull(10) ? "" : dr.GetString(10),
                    dr.IsDBNull(11) ? "" : dr.GetString(11),
                    dr.IsDBNull(12) ? "" : dr.GetString(12),
                    dr.IsDBNull(13) ? "" : dr.GetDecimal(13).ToString(),
                    dr.IsDBNull(14) ? "" : dr.GetString(14)
                );
                _ret.Add(_mitem);
            }
            dr.Close();
            return _ret;
        }



        private const string SQL_DeleteUserOfPost = @"delete from qx_yhgwgxb where gwid=:GWID and yhid=:YHID";
        public bool DeleteUserOfPost(string _postID, string _userID)
        {
            try
            {
                OracleParameter[] _param = {
                                        new OracleParameter(":GWID", OracleDbType.Decimal) ,
                                        new OracleParameter(":YHID", OracleDbType.Decimal)   
                                 };
                _param[0].Value = decimal.Parse(_postID);
                _param[1].Value = decimal.Parse(_userID);

                OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionStringProfile, CommandType.Text, SQL_DeleteUserOfPost, _param);
                return true;
            }
            catch (Exception e)
            {
                string _errmsg = string.Format("删除指定岗位下的用户出错!GWID={0} YHID={1} \n 错误信息:{2}",
                          _postID, _userID, e.Message);
                OralceLogWriter.WriteSystemLog(_errmsg, "ERROR");
                return false;
            }

        }

        private const string SQL_IsExistYHM = @"select count(*) from QX2_HGYH  where YHM=:YHM";
        public bool IsExistYHM(string _yhm)
        {
            try
            {
                OracleParameter[] _param = {
                                        new OracleParameter(":YHM", OracleDbType.Varchar2) 
                                 };
                _param[0].Value = _yhm;


                object _ret = OracleHelper.ExecuteScalar(OracleHelper.ConnectionStringProfile, CommandType.Text, SQL_IsExistYHM, _param);
                decimal _retDecimal = (decimal)_ret;
                return (_retDecimal > 0);
            }
            catch (Exception e)
            {
                string _errmsg = string.Format("判断指定的用户名是否存在时出现错误! YHM={0} \n 错误信息:{1}",
                          _yhm, e.Message);
                OralceLogWriter.WriteSystemLog(_errmsg, "ERROR");
                return true;
            }
        }



        private const string SQL_AddUserInfo = @" insert into QX2_HGYH (YHID,YHM,RYID,DWID,DJSFZH,XM,XB,HGGH,JH,YJDZ,YHGUID,DWGUID,GXSJ,ZWMC,ZWJB)
												VALUES (:YHID,:YHM,SEQ_QX2.nextval,:DWID,:DJSFZH,:XM,:XB,:HGGH,:JH,:YJDZ,:YHGUID,:DWGUID,sysdate,:ZWMC,:ZWJB)";
        public bool AddUserInfo(string YHM, string XM, string XB, string SFZH, decimal SSDW, string DWGUID, string HGGH, string JH, string ZWMC, string ZWJB, string EMAIL)
        {

            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                OracleTransaction _txn = cn.BeginTransaction();
                try
                {
                    decimal yhid = decimal.Parse(GetNewID());
                    //添加用户信息
                    OracleCommand _cmd = new OracleCommand(SQL_AddUserInfo, cn);
                    _cmd.Parameters.Add(":YHID", yhid);
                    _cmd.Parameters.Add(":YHM", YHM);
                    _cmd.Parameters.Add(":DWID", SSDW);
                    _cmd.Parameters.Add(":DJSFZH", SFZH);
                    _cmd.Parameters.Add(":XM", XM);
                    _cmd.Parameters.Add(":XB", XB);
                    _cmd.Parameters.Add(":HGGH", HGGH);
                    _cmd.Parameters.Add(":JH", JH);
                    _cmd.Parameters.Add(":YJDZ", EMAIL);
                    _cmd.Parameters.Add(":YHGUID", Guid.NewGuid().ToString());
                    _cmd.Parameters.Add(":DWGUID", DWGUID);
                    _cmd.Parameters.Add(":ZWMC", ZWMC);
                    _cmd.Parameters.Add(":ZWJB", ZWJB);
                    _cmd.ExecuteNonQuery();

                    //将用户加入系统用户表
                    OracleCommand _cmd2 = new OracleCommand(SQL_RegisterUser, cn);
                    _cmd2.Parameters.Add(":YHID", yhid);
                    _cmd2.Parameters.Add(":YHM", YHM);
                    _cmd2.Parameters.Add(":KL", MD5Base64.Encode(YHM));
                    _cmd2.ExecuteNonQuery();

                    _txn.Commit();
                    return true;
                }
                catch (Exception e)
                {
                    _txn.Rollback();
                    string _errmsg = string.Format("添加用户信息时出现错误! YHM={0} \n 错误信息:{1}",
                              YHM, e.Message);
                    OralceLogWriter.WriteSystemLog(_errmsg, "ERROR");
                    return false;
                }
            }



        }

        private const string SQL_GetNewID = "SELECT SEQ_QX2.nextval FROM DUAL";
        public string GetNewID()
        {
            object _ret = OracleHelper.ExecuteScalar(OracleHelper.ConnectionStringProfile, CommandType.Text, SQL_GetNewID);

            return _ret.ToString();
        }


        private const string SQL_GetDWGUID = @"select DWGUID from qx2_hgjg where zzjgid=:ZZJGID";
        public string GetDWGUID(decimal DWID)
        {
            try
            {
                OracleParameter[] _param = {
                                        new OracleParameter(":ZZJGID", OracleDbType.Decimal) 
                                 };
                _param[0].Value = DWID;


                object _ret = OracleHelper.ExecuteScalar(OracleHelper.ConnectionStringProfile, CommandType.Text, SQL_GetDWGUID, _param);
                return _ret.ToString();
            }
            catch (Exception e)
            {
                string _errmsg = string.Format("取指定单位的GUID时出现错误! ZZJGID={0} \n 错误信息:{1}",
                          DWID, e.Message);
                OralceLogWriter.WriteSystemLog(_errmsg, "ERROR");
                return "";
            }
        }

        private const string SQL_AddOrgInfo = @"insert into qx2_hgjg (ZZJGID,SJDWID,ZZJGMC,JGQC,ZZJGDM,DWGUID,PARENNT_GUID,GLOBAL_SORT)
												values (:ZZJGID,:SJDWID,:ZZJGMC,:JGQC,:ZZJGDM,:DWGUID,:PARENNT_GUID,'0')";
        private const string SQL_AddOrgExt = @"insert into qx2_jgfjxx (zzjgid) values (:ZZJGID) ";
        public bool AddNewOrg(string ShotName, string FullName, SinoOrganize FatherOrg)
        {
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                OracleTransaction _txn = cn.BeginTransaction();
                try
                {
                    decimal zzjgid = decimal.Parse(GetNewID());
                    //添加机构信息
                    OracleCommand _cmd = new OracleCommand(SQL_AddOrgInfo, cn);
                    _cmd.Parameters.Add(":ZZJGID", zzjgid);
                    _cmd.Parameters.Add(":SJDWID", FatherOrg.Code);
                    _cmd.Parameters.Add(":ZZJGMC", ShotName);
                    _cmd.Parameters.Add(":JGQC", FullName);
                    _cmd.Parameters.Add(":ZZJGDM", GetZZJGDM(zzjgid));
                    _cmd.Parameters.Add(":DWGUID", Guid.NewGuid().ToString());
                    _cmd.Parameters.Add(":PARENNT_GUID", GetDWGUID(FatherOrg.Code));
                    _cmd.ExecuteNonQuery();

                    //添加机构附加信息表
                    OracleCommand _cmd2 = new OracleCommand(SQL_AddOrgExt, cn);
                    _cmd2.Parameters.Add(":ZZJGID", zzjgid);
                    _cmd2.ExecuteNonQuery();

                    _txn.Commit();
                    return true;
                }
                catch (Exception e)
                {
                    _txn.Rollback();
                    string _errmsg = string.Format("添加组织机构信息时出现错误! SHOTNAME={0} FULLNAME={1} \n 错误信息:{2}",
                              ShotName, FullName, e.Message);
                    OralceLogWriter.WriteSystemLog(_errmsg, "ERROR");
                    return false;
                }
            }

        }

        private const string SQL_GetZZJGDM = @"SELECT zhtj_zzjg2.to_dwdm(:ZZJGID) from dual";
        private string GetZZJGDM(decimal DWID)
        {
            try
            {
                OracleParameter[] _param = {
                                        new OracleParameter(":ZZJGID", OracleDbType.Decimal) 
                                 };
                _param[0].Value = DWID;


                object _ret = OracleHelper.ExecuteScalar(OracleHelper.ConnectionStringProfile, CommandType.Text, SQL_GetZZJGDM, _param);
                return _ret.ToString();
            }
            catch (Exception e)
            {
                string _errmsg = string.Format("取指定单位的ZZJGDM时出现错误! ZZJGID={0} \n 错误信息:{1}",
                          DWID, e.Message);
                OralceLogWriter.WriteSystemLog(_errmsg, "ERROR");
                return "";
            }
        }

        private const string SQL_DelOrgYHB = @"delete from QX_TJYHB where YHID in (select YHID from qx2_hgyh where DWID=:ZZJGID)";
        private const string SQL_DelOrg = @"delete from qx2_hgjg where ZZJGID=:ZZJGID";
        private const string SQL_DelOrgExt = @"delete from qx2_jgfjxx where ZZJGID=:ZZJGID";
        private const string SQL_DelOrgUser = @"delete from qx2_hgyh where DWID=:ZZJGID";
        public bool DelOrg(SinoOrganize sinoOrganize)
        {
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                OracleTransaction _txn = cn.BeginTransaction();
                try
                {
                    //删除系统用户表
                    OracleCommand _cmd4 = new OracleCommand(SQL_DelOrgYHB, cn);
                    _cmd4.Parameters.Add(":ZZJGID", sinoOrganize.Code);
                    _cmd4.ExecuteNonQuery();

                    //删除机构人员
                    OracleCommand _cmd3 = new OracleCommand(SQL_DelOrgUser, cn);
                    _cmd3.Parameters.Add(":ZZJGID", sinoOrganize.Code);
                    _cmd3.ExecuteNonQuery();

                    //删除机构附加信息
                    OracleCommand _cmd = new OracleCommand(SQL_DelOrgExt, cn);
                    _cmd.Parameters.Add(":ZZJGID", sinoOrganize.Code);
                    _cmd.ExecuteNonQuery();

                    //删除机构信息表
                    OracleCommand _cmd2 = new OracleCommand(SQL_DelOrg, cn);
                    _cmd2.Parameters.Add(":ZZJGID", sinoOrganize.Code);
                    _cmd2.ExecuteNonQuery();

                    _txn.Commit();
                    return true;
                }
                catch (Exception e)
                {
                    _txn.Rollback();
                    string _errmsg = string.Format("删除组织机构信息时出现错误! ZZJGID={0} \n 错误信息:{1}",
                              sinoOrganize.Code, e.Message);
                    OralceLogWriter.WriteSystemLog(_errmsg, "ERROR");
                    return false;
                }
            }
        }


        private const string SQL_IsExistChildOrg = @"select count(*) from qx2_hgjg where SJDWID=:ZZJGID";
        public bool IsExistChildOrg(decimal DWID)
        {
            try
            {
                OracleParameter[] _param = {
                                        new OracleParameter(":ZZJGID", OracleDbType.Decimal) 
                                 };
                _param[0].Value = DWID;


                decimal _ret = (decimal)OracleHelper.ExecuteScalar(OracleHelper.ConnectionStringProfile, CommandType.Text, SQL_IsExistChildOrg, _param);
                return (_ret > 0);
            }
            catch (Exception e)
            {
                string _errmsg = string.Format("取指定单位的是否有下级组织机构时出现错误! ZZJGID={0} \n 错误信息:{1}",
                          DWID, e.Message);
                OralceLogWriter.WriteSystemLog(_errmsg, "ERROR");
                return true;
            }
        }



        private const string SQL_SaveUserExtInfo = @"update qx_userext set MOBILE=:MOBILE,EMAIL=:EMAIL where LOGONNAME=:NAME";
        public bool SaveUserExtInfo(string LogonName, string Mobile, string Email)
        {
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                OracleTransaction _txn = cn.BeginTransaction();
                try
                {
                    //删除系统用户表
                    OracleCommand _cmd = new OracleCommand(SQL_SaveUserExtInfo, cn);
                    _cmd.Parameters.Add(":MOBILE", Mobile);
                    _cmd.Parameters.Add(":EMAIL", Email);
                    _cmd.Parameters.Add(":NAME", LogonName);
                    _cmd.ExecuteNonQuery();

                    _txn.Commit();
                    return true;
                }
                catch (Exception e)
                {
                    _txn.Rollback();
                    string _errmsg = string.Format("更新用户的扩展信息时出现错误! LOGONNAME={0} \n 错误信息:{1}",
                              LogonName, e.Message);
                    OralceLogWriter.WriteSystemLog(_errmsg, "ERROR");
                    return false;
                }
            }
        }

        #endregion



        public string GetTRDUserInfo(string _logonName, string dwid)
        {
            string _addr = GetTrdServiceURL(dwid);

            if (_addr != null && _addr != "")
            {
                SinoTRDWebService _ws = new SinoTRDWebService();
                _ws.Url = _addr;
                string _ret = _ws.QueryUserSimpleData(_logonName);

                return _ret;
            }
            else
            {
                return null;
            }

        }

        private const string SQL_GetTrdServiceUrl = @"select APPURL from JSYW_XT_LINKS where APPNAME='Thread_WebService' AND DWID= ZHTJ_ZZJG2.GETDWID_jb_hgjs(:DWID,'直属海关级') ";
        private string GetTrdServiceURL(string dwid)
        {
            string _ret = "";
            OracleParameter _p = new OracleParameter(":DWID", decimal.Parse(dwid));
            using (OracleDataReader _dr = OracleHelper.ExecuteReader(OracleHelper.ConnectionStringProfile, CommandType.Text, SQL_GetTrdServiceUrl, _p))
            {
                while (_dr.Read())
                {
                    _ret = _dr.IsDBNull(0) ? "" : _dr.GetString(0);
                }
            }

            return _ret;
        }

        private const string SQL_DelMapping = @"delete from JSYW_XT_YHDZB where JSYW_YHID=:YHID";
        private const string SQL_InsertMapping = @"insert into JSYW_XT_YHDZB (TRD_YHID,JSYW_YHID,TRD_YHM,TRD_XM,JSYW_XM) values (:TRD_YHID,:JSYW_YHID,:TRD_YHM,:TRD_XM,:JSYW_XM)";
        public bool SaveUserMapping(string TRD_YHID, string JSYW_YHID, string TRD_YHM, string TRD_XM, string JSYW_XM)
        {
            using (OracleConnection _cn = OracleHelper.OpenConnection())
            {
                OracleTransaction _txn = _cn.BeginTransaction();
                try
                {
                    OracleParameter _p = new OracleParameter(":YHID", decimal.Parse(JSYW_YHID));
                    OracleHelper.ExecuteNonQuery(_cn, CommandType.Text, SQL_DelMapping, _p);

                    if (TRD_YHID != null && TRD_YHID != "")
                    {
                        OracleParameter[] _param = {
                                        new OracleParameter(":TRD_YHID", OracleDbType.Decimal),
                                        new OracleParameter(":JSYW_YHID",OracleDbType.Decimal),
                                        new OracleParameter(":TRD_YHM",OracleDbType.Varchar2,50),
                                        new OracleParameter(":TRD_XM",OracleDbType.Varchar2,100),
                                        new OracleParameter(":JSYW_XM",OracleDbType.Varchar2,100)
                                 };
                        _param[0].Value = decimal.Parse(TRD_YHID);
                        _param[1].Value = decimal.Parse(JSYW_YHID);
                        _param[2].Value = TRD_YHM;
                        _param[3].Value = TRD_XM;
                        _param[4].Value = JSYW_XM;

                        OracleHelper.ExecuteNonQuery(_cn, CommandType.Text, SQL_InsertMapping, _param);
                    }

                    _txn.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    string _errmsg = string.Format("保存用户映身信息时出现错误! TRD_YHID={0} \n 错误信息:{1}",
                              TRD_YHID, ex.Message);
                    OralceLogWriter.WriteSystemLog(_errmsg, "ERROR");
                    _txn.Rollback();
                    return false;
                }
            }
        }
    }
}
