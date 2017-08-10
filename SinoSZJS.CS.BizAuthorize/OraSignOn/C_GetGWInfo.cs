using System;
using System.Collections;
using System.Data;
using System.Text;
using System.Collections.Generic;
using SinoSZJS.Base.Authorize;
using SinoSZJS.Base.Misc;
using System.Data.SqlClient;
using SinoSZJS.DataAccess.Sql;

namespace SinoSZJS.CS.BizAuthorize.OraSignOn
{
	/// <summary>
	/// C_GetGWInfo 处理岗位信息的业务逻辑类
	/// </summary>
	public class C_GetGWInfo
	{
		public C_GetGWInfo()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}



		/// <summary>
		/// 取指定岗位下的所有角色
		/// </summary>
		/// <param name="_postid"></param>
		/// <returns></returns>
		public static List<SinoRole> Get_RolesOfGW(string _postid)
		{
			string _sql = string.Format(" select a.jsid,a.jsmc,a.jssm,a.ssdwid from qx2_gwjsgxb t,qx_jsdyb a ");
			_sql += string.Format("where a.jsid = t.jsid and t.gwid = :GWID");
			SqlParameter[] _param = {
                                new SqlParameter(":GWID", SqlDbType.Decimal),
                        };
			_param[0].Value = decimal.Parse(_postid);

			List<SinoRole> roles = new List<SinoRole>();

			SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringProfile, CommandType.Text, _sql, _param);

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

		/// <summary>
		/// 添加岗位
		/// </summary>
		/// <param name="gwmc"></param>
		/// <param name="gwms"></param>
		/// <param name="_dwid"></param>
		/// <returns></returns>
		public static bool Add_Post(string gwmc, string gwms, string _dwid)
		{
			string _sql = string.Format("insert into QX2_GWDYB (GWID,GWDWID,GWMC,GWMS,SSDWID) values ");
			_sql += " (SEQ_QX2.NEXTVAL,:GWDWID,:GWMC,:GWMS,null) ";
			SqlParameter[] _param = {
                                new SqlParameter(":GWDWID", SqlDbType.Decimal),
                                new SqlParameter(":GWMC",SqlDbType.VarChar),
                                new SqlParameter(":GWMS",SqlDbType.VarChar)                           
                        };
			_param[0].Value = decimal.Parse(_dwid);
			_param[1].Value = gwmc;
			_param[2].Value = gwms;
			SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringProfile, CommandType.Text, _sql, _param);
			return true;
		}

		/// <summary>
		/// 删除岗位
		/// </summary>
		/// <param name="_gwids"></param>
		/// <returns></returns>
		public static bool Del_Posts(string _gwids)
		{
			string _sql = string.Format("delete QX2_GWDYB where GWID in ({0})", _gwids);
			SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringProfile, CommandType.Text, _sql);
			return true;
		}
		/// <summary>
		/// 为岗位添加角色
		/// </summary>
		/// <param name="postid"></param>
		/// <param name="_roles"></param>
		/// <returns></returns>
		public static bool Add_RoleToPost(string postid, ArrayList _roles)
		{
			foreach (SinoRole _sr in _roles)
			{
				string _ins = string.Format("insert into qx2_gwjsgxb (id,gwid,jsid) values (seq_qx2.nextval,{0},{1}) ", postid, _sr.RoleID);
				SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringProfile, CommandType.Text, _ins);
			}
			return true;
		}
		/// <summary>
		/// 从岗位中删除角色
		/// </summary>
		/// <param name="postid"></param>
		/// <param name="roleid"></param>
		/// <returns></returns>
		public static bool Del_RoleFromPost(string postid, string roleid)
		{
			string _sql = "delete from qx2_gwjsgxb where gwid=:GWID and jsid=:JSID";
			SqlParameter[] _param = {
                                new SqlParameter(":GWID", SqlDbType.Decimal),
                                new SqlParameter(":JSID",SqlDbType.VarChar)                  
                        };
			_param[0].Value = decimal.Parse(postid);
			_param[1].Value = decimal.Parse(roleid);

			SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringProfile, CommandType.Text, _sql, _param);
			return true;
		}

		/// <summary>
		/// 取指定岗位下的指定类型的授权
		/// </summary>
		/// <param name="postid"></param>
		/// <param name="_qxlx"></param>
		/// <returns></returns>
		public static Dictionary<string, UserRightItem> GetRightsOfPost(string postid, string _qxlx)
		{
			Dictionary<string, UserRightItem> _ret = new Dictionary<string, UserRightItem>();
			DataTable _dt = new DataTable();
			using (SqlConnection cn = SqlHelper.OpenConnection())
			{
				SqlCommand _cmd = new SqlCommand();
				_cmd.CommandText = "zhtj_zzjg2.Get_GWCZQX_OWN";
				_cmd.CommandType = CommandType.StoredProcedure;
				_cmd.Connection = cn;

				SqlParameter _p1 = _cmd.Parameters.Add("ngwid", SqlDbType.Decimal);
				_p1.Value = decimal.Parse(postid);

				SqlParameter _p2 = _cmd.Parameters.Add("strqxlx", SqlDbType.VarChar, 1000);
				_p2.Value = _qxlx;

				//_cmd.Parameters.Add("curQXDW", SqlDbType.RefCursor, DBNull.Value, ParameterDirection.Output);

				SqlDataAdapter _adapter = new SqlDataAdapter(_cmd);
				_adapter.Fill(_dt);
				cn.Close();
			}
			foreach (DataRow _dr in _dt.Rows)
			{
				UserRightItem _item = RightFunctions.CreateUserRightItem(_dr);
				_ret.Add(_item.Right.RightID, _item);
			}
			return _ret;
		}

	
		/// <summary>
		/// 取指定岗位下的所有授权
		/// </summary>
		/// <param name="postid"></param>
		/// <returns></returns>
		public static DataTable GetRightsFromPost(string postid)
		{
			DataTable _dt = new DataTable();
			using (SqlConnection cn = SqlHelper.OpenConnection())
			{
				SqlCommand _cmd = new SqlCommand();
				_cmd.CommandText = "zhtj_zzjg2.Get_GWCZQX";
				_cmd.CommandType = CommandType.StoredProcedure;
				_cmd.Connection = cn;

				SqlParameter _p1 = _cmd.Parameters.Add("ngwid", SqlDbType.Decimal);
				_p1.Value = decimal.Parse(postid);

				//_cmd.Parameters.Add("curQX", SqlDbType.RefCursor, DBNull.Value, ParameterDirection.Output);

				SqlDataAdapter _adapter = new SqlDataAdapter(_cmd);
				_adapter.Fill(_dt);
				return _dt;
				cn.Close();
			}
		}

		private const string SQL_Get_PostsByYHID = @"select a.gwmc,a.gwid,a.gwdwid,zhtj_zzjg2.GETDWMC(a.gwdwid) dwmc, 
													zhtj_zzjg2.GETDWDM_hgjs(a.gwdwid) DWDM,a.gwms,b.IS_DEFAULT SFMR,a.SECRETLEVEL
													 from qx2_gwdyb a,QX_YHGWGXB b where b.gwid=a.gwid and b.yhid=:YHID 
														and  ( (a.SSDWID IS NULL) or (a.SSDWID=:SSDWID))";
		/// <summary>
		/// 取用户的岗位列表
		/// </summary>
		/// <param name="yhid"></param>
		/// <returns></returns>
		public static List<SinoPost> Get_PostsByYHID(string yhid)
		{
			List<SinoPost> _ret = new List<SinoPost>();

			SqlParameter[] _param = {
                                new SqlParameter(":YHID", SqlDbType.Decimal),
				new SqlParameter(":SSDWID",SqlDbType.Decimal)
                        };
			_param[0].Value = decimal.Parse(yhid);
			_param[1].Value = decimal.Parse(ConfigFile.SystemID);
			SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringProfile, CommandType.Text, SQL_Get_PostsByYHID, _param);
			while (dr.Read())
			{
				SinoPost _sp = new SinoPost(dr.GetString(0),
					dr.IsDBNull(1) ? "" : dr.GetDecimal(1).ToString(),
					dr.IsDBNull(2) ? "" : dr.GetDecimal(2).ToString(),
					dr.IsDBNull(3) ? "" : dr.GetString(3),
					dr.IsDBNull(4) ? "" : dr.GetString(4),
					dr.IsDBNull(5) ? "" : dr.GetString(5),
					dr.IsDBNull(7) ? (int)0 : Convert.ToInt32(dr.GetDecimal(7)),
					dr.IsDBNull(6) ? false : (((decimal)dr.GetSqlDecimal(6).Value == 1) ? true : false));
				_sp.Roles = Get_RolesOfGW(_sp.PostID);
				_ret.Add(_sp);
			}
			dr.Close();

			return _ret;
		}


		
			
		

		/// <summary>
		/// 为用户添加岗位
		/// </summary>
		/// <param name="postid"></param>
		/// <param name="yhid"></param>
		/// <returns></returns>
		public static bool Add_PostToYH(string postid, string yhid)
		{
			string _sql = "insert into QX_YHGWGXB (ID,GWID,YHID,IS_DEFAULT) values (seq_qx2.nextval,:GWID,:YHID,0) ";
			SqlParameter[] _param = {
                                  new SqlParameter(":GWID",SqlDbType.Decimal),
                                new SqlParameter(":YHID", SqlDbType.Decimal)          
                        };
			_param[0].Value = decimal.Parse(postid);
			_param[1].Value = decimal.Parse(yhid);

			SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringProfile, CommandType.Text, _sql, _param);
			return true;
		}

		/// <summary>
		/// 删除用户的岗位
		/// </summary>
		/// <param name="_gwids"></param>
		/// <param name="yhid"></param>
		/// <returns></returns>
		public static bool Del_PostsOfUser(string _gwids, string yhid)
		{
			string _sql = string.Format("delete QX_YHGWGXB where GWID in ({0}) and YHID=:YHID", _gwids);
			SqlParameter[] _param = {
                                  new SqlParameter(":YHID",SqlDbType.Decimal)
                        };
			_param[0].Value = decimal.Parse(yhid);
			SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringProfile, CommandType.Text, _sql, _param);
			return true;
		}

		/// <summary>
		/// 设置用户的默认岗位
		/// </summary>
		/// <param name="postid"></param>
		/// <param name="yhid"></param>
		/// <returns></returns>
		public static bool Set_UserDefaultPost(string postid, string yhid)
		{
			string _clear = "update QX_YHGWGXB set IS_DEFAULT = 0 where yhid = :YHID ";
			SqlParameter[] _param = {
                                  new SqlParameter(":YHID",SqlDbType.Decimal)
                        };
			_param[0].Value = decimal.Parse(yhid);
			SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringProfile, CommandType.Text, _clear, _param);

			string _sql = "update QX_YHGWGXB set IS_DEFAULT = 1 where gwid=:GWID and yhid =:YHID";
			SqlParameter[] _param2 = {
                                  new SqlParameter(":GWID",SqlDbType.Decimal),
                                new SqlParameter(":YHID", SqlDbType.Decimal)          
                        };
			_param2[0].Value = decimal.Parse(postid);
			_param2[1].Value = decimal.Parse(yhid);
			SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringProfile, CommandType.Text, _sql, _param2);
			return true;
		}

		/// <summary>
		/// 将岗位复制到其它单位中
		/// </summary>
		/// <param name="_spid">原岗位ID</param>
		/// <param name="_dwid">新单位ID</param>
		/// <returns>新岗位ID</returns>
		public static string CopyPost(string _spid, string _dwid)
		{
			using (SqlConnection cn = SqlHelper.OpenConnection())
			{
				SqlCommand _cmd = new SqlCommand();
				_cmd.CommandText = "zhtj_zzjg2.replicategw";
				_cmd.CommandType = CommandType.StoredProcedure;
				_cmd.Connection = cn;

				_cmd.Parameters.Add("ngwid", decimal.Parse(_spid));
				_cmd.Parameters.Add("nnewdwid", decimal.Parse(_dwid));

				SqlParameter _p1 = _cmd.Parameters.Add("nnewgwid", SqlDbType.Decimal);
				_p1.Direction = ParameterDirection.Output;
				_cmd.ExecuteNonQuery();
				cn.Close();
				return _p1.Value.ToString();
			}
		}

		/// <summary>
		/// 取指定岗位下是否有查看指定查询模型的授权
		/// </summary>
		/// <param name="_postid">岗位ID</param>
		/// <param name="_viewname">查询模型名称</param>
		/// <returns></returns>
		public static bool Get_QVRightOfPost(string _postid, string _viewname)
		{
			string _sql = "select zhtj_zzjg2.GWRightWithViewName(:POSTID,:NS,:VIEWNAME) from dual ";
			string[] vs = _viewname.Split('.');
			using (SqlConnection cn = SqlHelper.OpenConnection())
			{
				SqlCommand _cmd = new SqlCommand(_sql, cn);
				_cmd.CommandType = CommandType.Text;
				_cmd.Parameters.Add(":POSTID", decimal.Parse(_postid));
				_cmd.Parameters.Add(":NS", vs[0]);
				_cmd.Parameters.Add(":VIEWNAME", vs[1]);
				decimal _ret = (decimal)_cmd.ExecuteScalar();
				cn.Close();
				return _ret > 0;
			}
		}

		/// <summary>
		/// 重命名岗位
		/// </summary>
		/// <param name="_postid"></param>
		/// <param name="_gwmc"></param>
		/// <param name="_gwms"></param>
		/// <returns></returns>
		public static bool Rename_Post(string _postid, string _gwmc, string _gwms)
		{
			string _sql = "update QX2_GWDYB set GWMC=:GWMC,GWMS=:GWMS where GWID=:GWID";
			using (SqlConnection cn = SqlHelper.OpenConnection())
			{
				SqlCommand _cmd = new SqlCommand(_sql, cn);
				_cmd.Parameters.Add(":GWMC", _gwmc);
				_cmd.Parameters.Add(":GWMS", _gwms);
				_cmd.Parameters.Add(":GWID", decimal.Parse(_postid));
				_cmd.ExecuteNonQuery();
				cn.Close();
				return true;
			}
		}

        private const string SQL_Get_QVRightsOfPost = @"select v.viewid,v.namespace,v.viewname,v.displayname from md_view v
                                                        join qx_jscxmxgxb  jsv on  v.viewid=jsv.viewid
                                                        join qx2_gwjsgxb gwjs on gwjs.jsid=jsv.jsid
                                                        where gwjs.gwid=:GWID
                                                         order by displayorder";
		/// <summary>
		/// 取指定岗位下可以使用的查询模型列表
		/// </summary>
		/// <param name="_postid"></param>
		/// <returns></returns>
		public static DataTable Get_QVRightsOfPost(string _postid)
		{
			
			DataTable _dt = new DataTable();
			using (SqlConnection cn = SqlHelper.OpenConnection())
			{
                SqlCommand _cmd = new SqlCommand(SQL_Get_QVRightsOfPost, cn);
				_cmd.Parameters.Add(":GWID", decimal.Parse(_postid));
				SqlDataAdapter _adapter = new SqlDataAdapter(_cmd);
				_adapter.Fill(_dt);
				cn.Close();
			}
			return _dt;
		}

        private const string SQL_GetUserOfPost = @"select a.*,zhtj_zzjg2.getdwmc(a.dwid) ZZJGMC from qx2_yhxx a where
                                                   a.yhid in ( 
                                                   select t.yhid from qx_yhgwgxb t where t.gwid = :GWID )";
		/// <summary>
		/// 取指定岗位下的用户列表
		/// </summary>
		/// <param name="_postid"></param>
		/// <returns></returns>
		public static DataTable GetUserOfPost(string _postid)
		{			
			DataTable _dt = new DataTable();
			using (SqlConnection cn = SqlHelper.OpenConnection())
			{
                SqlCommand _cmd = new SqlCommand(SQL_GetUserOfPost, cn);
				_cmd.Parameters.Add(":GWID", decimal.Parse(_postid));
				SqlDataAdapter _adapter = new SqlDataAdapter(_cmd);
				_adapter.Fill(_dt);
				cn.Close();
			}
			return _dt;
		}







	
	}
}
