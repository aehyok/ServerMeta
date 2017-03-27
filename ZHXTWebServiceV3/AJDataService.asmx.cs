using System;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Web.Security;
using System.Web.Services;
using DIReport.ZHXTWebService;
using Oracle.DataAccess.Client;
using SinoSZJS.DataAccess;
using ZHXTWebServiceV3.DAL;

namespace ZHXTWebService
{
    /// <summary>
    /// Service1 的摘要说明。
    /// </summary>
    /// 
    [WebService(Namespace = "http://tempuri.org/")]
    public class AJDataService : System.Web.Services.WebService
    {
        public AJDataService()
        {
            //CODEGEN: 该调用是 ASP.NET Web 服务设计器所必需的
            InitializeComponent();
        }

        #region 组件设计器生成的代码

        //Web 服务设计器所必需的
        private IContainer components = null;

        /// <summary>
        /// 设计器支持所需的方法 - 不要使用代码编辑器修改
        /// 此方法的内容。
        /// </summary>
        private void InitializeComponent() { }

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #endregion

        // WEB 服务示例
        // HelloWorld() 示例服务返回字符串 Hello World
        // 若要生成，请取消注释下列行，然后保存并生成项目
        // 若要测试此 Web 服务，请按 F5 键

        //作者：林添喜 2005-03-14  说明：1.获取服务版本号
        [WebMethod]
        public string GetVersion()
        {
            return Config.Version;
        }

        #region 用户验证相关，包括Login,ChangePassword,IsTicketValid

        /// <summary>
        /// 2.登录系统
        /// </summary>
        /// <param name="UserName">用户名称</param>
        /// <param name="Password">用户口令</param>
        /// <returns>如果登录成功，则返回Ticket字串;如果失败，则返回null</returns>
        [WebMethod()]
        public string Login(string UserName, string Password)
        {
            decimal _FindRes = AJDataCommon.CheckUser(UserName, Password);

            if (_FindRes == 1)
            {
                decimal userID = AJDataCommon.GetUserID(UserName, Password);

                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(userID.ToString(), false, 1);
                string encryptedTicket = FormsAuthentication.Encrypt(ticket);

                // get the ticket timeout in minutes
                AppSettingsReader configurationAppSettings = new AppSettingsReader();
                int timeout = (int)configurationAppSettings.GetValue("AuthenticationTicket.Timeout", typeof(int));
                // cache the ticket
                Context.Cache.Insert(encryptedTicket, userID, null, DateTime.Now.AddMinutes(timeout), TimeSpan.Zero);
                return encryptedTicket;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 3.修改口令
        /// </summary>
        /// <param name="ticket">验证票</param>
        /// <param name="UserName">用户名称</param>
        /// <param name="OldPassword">旧口令</param>
        /// <param name="NewPassword">新口令</param>
        /// <returns>0:	成功;	-1:失败</returns>
        [WebMethod()]
        public int ChangePassword(string ticket, string UserName, string OldPassword, string NewPassword)
        {
            UserInformation userInfo = null;
            if (!IsTicketValid(ticket, false, out userInfo))
                return -1;

            int userID = int.Parse(FormsAuthentication.Decrypt(ticket).Name);

            int result = 0;

            //修改口令，待实现

            if (result == 1)
                return 0;
            else
                return -1;
        }

        /// <summary>
        /// 验证用户提供的票据
        /// </summary>
        /// <param name="ticket">标据字串</param>
        /// <param name="IsAdminCall">是否超级用户</param>
        /// <returns>true:通过验证    false:不通过验证</returns>
        private bool IsTicketValid(string ticket, bool IsAdminCall, out UserInformation userInfo)
        {
            userInfo = null;
            if (ticket == null || Context.Cache[ticket] == null)
            {
                // not authenticated
                return false;
            }
            else
            {
                // check the user authorization
                int userID = int.Parse(FormsAuthentication.Decrypt(ticket).Name);


                //从数据库中取用户信息，待实现
                string _userSelect = string.Format("select * from jsods.sjjh_yhb where yhid ={0}", userID);
                DataSet ds = ServerCommon.GetDataBySql(_userSelect);

                userInfo = new UserInformation();
                DataRow dr = ds.Tables[0].Rows[0];

                userInfo.UserName = dr["YHM"].ToString();
                userInfo.UserID = int.Parse(userID.ToString());

                if (userInfo.IsAccountLocked)
                    return false;
                else
                {
                    // check admin status (for admin required calls)
                    if (IsAdminCall && !userInfo.IsAdministrator)
                        return false;
                    return true;
                }
            }
        }

        #endregion

        #region 获取变更的数据 GetNewData,GetDeletedData

        /// <summary>
        /// 4.1获得某实体增量数据，包括新增和修改的数据
        /// </summary>
        /// <param name="ticket">验证票</param>
        /// <param name="_tname">实体名称</param>
        /// <returns>null　失败;　　如果成功，则DataSet中有一个DataTable</returns>
        [WebMethod(MessageName = "GetNewDataNoWHXH")]
        public DataSet GetNewData(string ticket, string _tname)
        {
            UserInformation userInfo;
            if (!IsTicketValid(ticket, false, out userInfo))
                return null;

            DataSet _ds = new DataSet();
            DataTable _dt = new DataTable();

            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                try
                {
                    OracleCommand _cmd = new OracleCommand();
                    _cmd.CommandText = "ZHTJ_SJJH.GetNewData";
                    _cmd.CommandType = CommandType.StoredProcedure;
                    _cmd.Connection = cn;

                    _cmd.Parameters.Add("STRYHM", userInfo.UserName);
                    _cmd.Parameters.Add("STRTNAME", _tname);
                    _cmd.Parameters.Add("NMAX", (decimal)1000);
                    _cmd.Parameters.Add("RCRET", OracleDbType.RefCursor, 2000, ParameterDirection.Output);


                    OracleDataAdapter _adapter = new OracleDataAdapter(_cmd);
                    _adapter.Fill(_dt);
                    _dt.TableName = _tname;
                    _ds.Tables.Add(_dt);

                }
                catch (Exception e)
                {
                    Exception exp = e;
                    ServerCommon.WriteLog(string.Format("GetNewData({0},{1}) 时发出错误如下：\n{2}", "ticket", _tname, e.Message), EventLogEntryType.Error);
                    return null;
                }
            }
            return _ds;

        }

        /// <summary>
        /// 4.2获得某实体维护序号大于_whxh的增量数据，包括新增和修改的数据
        /// </summary>
        /// <param name="ticket">验证票</param>
        /// <param name="_tname">实体名称</param>
        /// <param name="_whxh">维护序号</param>
        /// <returns>null　失败;　　如果成功，则DataSet中有一个DataTable</returns>
        [WebMethod(MessageName = "GetNewDataWithWHXH")]
        public DataSet GetNewData(string ticket, string _tname, decimal _whxh)
        {
            UserInformation userInfo;
            if (!IsTicketValid(ticket, false, out userInfo))
                return null;

            DataSet _ds = new DataSet();
            DataTable _dt = new DataTable();
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                try
                {
                    OracleCommand _cmd = new OracleCommand();
                    _cmd.CommandText = "ZHTJ_SJJH.GetNewData_WHXH";
                    _cmd.CommandType = CommandType.StoredProcedure;
                    _cmd.Connection = cn;

                    _cmd.Parameters.Add("STRYHM", userInfo.UserName);
                    _cmd.Parameters.Add("STRTNAME", _tname);
                    _cmd.Parameters.Add("NWHXH", _whxh);
                    _cmd.Parameters.Add("NMAX", (decimal)1000);
                    _cmd.Parameters.Add("RCRET", OracleDbType.RefCursor, 2000, ParameterDirection.Output);


                    OracleDataAdapter _adapter = new OracleDataAdapter(_cmd);
                    _adapter.Fill(_dt);
                    _dt.TableName = _tname;
                    _ds.Tables.Add(_dt);

                }
                catch (Exception e)
                {
                    Exception exp = e;
                    ServerCommon.WriteLog(string.Format("GetNewData({0},{1},{2}) 时发出错误如下：\n{3}", "ticket", _tname, _whxh, e.Message), EventLogEntryType.Error);
                    return null;
                }
            }
            return _ds;

        }

        /// <summary>
        /// 5.1返回删除的实体标识
        /// </summary>
        /// <param name="ticket">验证票</param>
        /// <param name="_tname">实体名称</param>
        /// <returns>null　失败;　　如果成功，则DataSet中有一个DataTable</returns>
        [WebMethod(MessageName = "GetDeleteDataNoWHXH")]
        public DataSet GetDeletedData(string ticket, string _tname)
        {
            UserInformation userInfo;
            if (!IsTicketValid(ticket, false, out userInfo))
                return null;

            DataSet _ds = new DataSet();
            DataTable _dt = new DataTable();

            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                try
                {
                    OracleCommand _cmd = new OracleCommand();
                    _cmd.CommandText = "ZHTJ_SJJH.GetDeletedData";
                    _cmd.CommandType = CommandType.StoredProcedure;
                    _cmd.Connection = cn;

                    _cmd.Parameters.Add("STRYHM", userInfo.UserName);
                    _cmd.Parameters.Add("STRTNAME", _tname);
                    _cmd.Parameters.Add("NMAX", (decimal)1000);
                    _cmd.Parameters.Add("RCRET", OracleDbType.RefCursor, 2000, ParameterDirection.Output);


                    OracleDataAdapter _adapter = new OracleDataAdapter(_cmd);
                    _adapter.Fill(_dt);
                    _dt.TableName = _tname;
                    _ds.Tables.Add(_dt);

                }
                catch (Exception e)
                {
                    Exception exp = e;
                    ServerCommon.WriteLog(string.Format("GetDeletedData({0},{1}) 时发出错误如下：\n{2}", "ticket", _tname, e.Message), EventLogEntryType.Error);
                    return null;
                }
            }
            return _ds;

        }

        /// <summary>
        /// 5.2返回维护序号大于_whxh的需要删除的实体标识
        /// </summary>
        /// <param name="ticket">验证票</param>
        /// <param name="_tname">实体名称</param>
        /// <param name="_whxh">维护序号</param>
        /// <returns>null　失败;　　如果成功，则DataSet中有一个DataTable</returns>
        [WebMethod(MessageName = "GetDeleteDataWithWHXH")]
        public DataSet GetDeletedData(string ticket, string _tname, decimal _whxh)
        {
            UserInformation userInfo;
            if (!IsTicketValid(ticket, false, out userInfo))
                return null;

            DataSet _ds = new DataSet();
            DataTable _dt = new DataTable();

            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                try
                {
                    OracleCommand _cmd = new OracleCommand();
                    _cmd.CommandText = "ZHTJ_SJJH.GetDeletedData_WHXH";
                    _cmd.CommandType = CommandType.StoredProcedure;
                    _cmd.Connection = cn;

                    _cmd.Parameters.Add("STRYHM", userInfo.UserName);
                    _cmd.Parameters.Add("STRTNAME", _tname);
                    _cmd.Parameters.Add("NWHXH", _whxh);
                    _cmd.Parameters.Add("NMAX", (decimal)1000);
                    _cmd.Parameters.Add("RCRET", OracleDbType.RefCursor, 2000, ParameterDirection.Output);


                    OracleDataAdapter _adapter = new OracleDataAdapter(_cmd);
                    _adapter.Fill(_dt);
                    _dt.TableName = _tname;
                    _ds.Tables.Add(_dt);



                }
                catch (Exception e)
                {
                    Exception exp = e;
                    ServerCommon.WriteLog(string.Format("GetDeletedData({0},{1},{3}) 时发出错误如下：\n{2}", "ticket", _tname, e.Message, _whxh), EventLogEntryType.Error);
                    return null;
                }
            }
            return _ds;

        }

        #endregion

        #region 获取案件数据，包括GetAJList,GetAJData

        /// <summary>
        /// 6.用于获取案件列表
        /// </summary>
        /// <param name="ticket">验证票</param>
        /// <param name="_isAll">0:最新案件列表		1:所有案件列表</param>
        /// <param name="_type">0:刑事案件			1:行政案件</param>
        /// <returns>返回案件数据的DataSet,，如果为NULL，则查询失败。如果查询成功，DataSet中有一个DataTable</returns>
        [WebMethod()]
        public DataSet GetAJList(string ticket, int _isAll, int _type)
        {
            UserInformation userInfo;
            if (!IsTicketValid(ticket, false, out userInfo))
                return null;

            DataSet _ds = new DataSet();
            DataTable _dt = new DataTable();
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                try
                {
                    OracleCommand _cmd = new OracleCommand();
                    _cmd.CommandText = "ZHTJ_SJJH.GetAJList";
                    _cmd.CommandType = CommandType.StoredProcedure;
                    _cmd.Connection = cn;

                    _cmd.Parameters.Add("STRYHM", userInfo.UserName);
                    _cmd.Parameters.Add("NISALL", (decimal)_isAll);
                    _cmd.Parameters.Add("NTYPE", (decimal)_type);
                    _cmd.Parameters.Add("NMAX", (decimal)1000);
                    _cmd.Parameters.Add("RCRET", OracleDbType.RefCursor, 2000, ParameterDirection.Output);


                    OracleDataAdapter _adapter = new OracleDataAdapter(_cmd);
                    _adapter.Fill(_dt);
                    _dt.TableName = "AJLIST";
                    _ds.Tables.Add(_dt);
                }
                catch (Exception e)
                {
                    Exception exp = e;
                    ServerCommon.WriteLog(string.Format("GetAJList({0},{1},{3}) 时发出错误如下：\n{2}", "ticket", _isAll, e.Message, _type), EventLogEntryType.Error);
                    return null;
                }
            }
            return _ds;


        }

        /// <summary>
        /// 7.获取案件数据，本方法不记录数据下载进度
        /// </summary>
        /// <param name="ticket">验证票</param>
        /// <param name="_tname">表名称</param>
        /// <param name="ODS_ID">案件基本信息表唯一关键字</param>
        /// <returns>案件相关结果集，包括嫌疑人单位、运输工具、走私物品、案件等</returns>
        [WebMethod()]
        public DataSet GetAJData(string ticket, string _tname, decimal ODS_ID)
        {
            UserInformation userInfo;
            if (!IsTicketValid(ticket, false, out userInfo))
                return null;

            DataSet _ds = new DataSet();
            DataTable _dt = new DataTable();
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                try
                {
                    OracleCommand _cmd = new OracleCommand();
                    _cmd.CommandText = "ZHTJ_SJJH.GetAJData";
                    _cmd.CommandType = CommandType.StoredProcedure;
                    _cmd.Connection = cn;

                    _cmd.Parameters.Add("STRYHM", userInfo.UserName);
                    _cmd.Parameters.Add("STRTNAME", _tname);
                    _cmd.Parameters.Add("NODS_ID", ODS_ID);
                    _cmd.Parameters.Add("RCRET", OracleDbType.RefCursor, 2000, ParameterDirection.Output);


                    OracleDataAdapter _adapter = new OracleDataAdapter(_cmd);
                    _adapter.Fill(_dt);
                    _dt.TableName = "AJDATA";
                    _ds.Tables.Add(_dt);

                }
                catch (Exception e)
                {
                    Exception exp = e;
                    ServerCommon.WriteLog(string.Format("GetAJData({0},{1},{3}) 时发出错误如下：\n{2}", "ticket", _tname, e.Message, ODS_ID), EventLogEntryType.Error);
                    return null;
                }
            }
            return _ds;

        }

        #endregion

        #region 获取元数据，包括GetTableMeta,GetRefTable,GetRefString,GetChangedRefTable

        /// <summary>
        /// 8.用于获取一个表的元数据
        /// </summary>
        /// <param name="ticket">验证票</param>
        /// <param name="_tname">需获取元数据描述的表名称</param>
        /// <returns>表描述的结果集</returns>
        [WebMethod()]
        public DataSet GetTableMeta(string ticket, string _tname)
        {
            UserInformation userInfo;
            if (!IsTicketValid(ticket, false, out userInfo))
                return null;

            DataSet _ds = new DataSet();
            DataTable _dt = new DataTable();
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                try
                {
                    OracleCommand _cmd = new OracleCommand();
                    _cmd.CommandText = "ZHTJ_SJJH.GetTableMeta";
                    _cmd.CommandType = CommandType.StoredProcedure;
                    _cmd.Connection = cn;

                    _cmd.Parameters.Add("STRYHM", userInfo.UserName);
                    _cmd.Parameters.Add("STRTNAME", _tname);
                    _cmd.Parameters.Add("RCRET", OracleDbType.RefCursor, 2000, ParameterDirection.Output);


                    OracleDataAdapter _adapter = new OracleDataAdapter(_cmd);
                    _adapter.Fill(_dt);
                    _dt.TableName = "TABLEMETA";
                    _ds.Tables.Add(_dt);

                }
                catch (Exception e)
                {
                    Exception exp = e;
                    ServerCommon.WriteLog(string.Format("GetTableMeta({0},{1}) 时发出错误如下：\n{2}", "ticket", _tname, e.Message), EventLogEntryType.Error);
                    return null;
                }
            }
            return _ds;

        }

        /// <summary>
        /// 9.本方法用于获取一个代码表
        /// </summary>
        /// <param name="ticket">验证票</param>
        /// <param name="_tname">需获取的代码表的名称</param>
        /// <returns>代码表结果集</returns>
        [WebMethod()]
        public DataSet GetRefTable(string ticket, string _tname)
        {
            UserInformation userInfo;
            if (!IsTicketValid(ticket, false, out userInfo))
                return null;

            DataSet _ds = new DataSet();

            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                try
                {
                    string _sql = string.Format("select a.dm,a.mc from jsods.{0} a order by a.px", _tname);

                    _ds = OracleHelper.FillDataSet(_sql, _tname);

                }
                catch (Exception e)
                {
                    Exception exp = e;
                    ServerCommon.WriteLog(string.Format("GetRefTable({0},{1}) 时发出错误如下：\n{2}", "ticket", _tname, e.Message), EventLogEntryType.Error);
                    return null;
                }
            }
            return _ds;

        }

        /// <summary>
        /// 10.用于获取一个代码中某代码的值
        /// </summary>
        /// <param name="ticket">验证票</param>
        /// <param name="_tname">采用的代码表的名称</param>
        /// <param name="_code">需转换的代码值</param>
        /// <returns>返回此代码对应的值</returns>
        [WebMethod()]
        public string GetRefString(string ticket, string _tname, string _code)
        {
            string _ret = null;
            UserInformation userInfo;
            if (!IsTicketValid(ticket, false, out userInfo))
                return null;


            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                try
                {
                    OracleCommand _cmd = new OracleCommand();
                    _cmd.CommandText = "ZHTJ_SJJH.GetRefString";
                    _cmd.CommandType = CommandType.StoredProcedure;
                    _cmd.Connection = cn;
                    OracleParameter _op_tname = _cmd.Parameters.Add(new OracleParameter("STRDMB", OracleDbType.Varchar2, 1000));
                    _op_tname.Value = _tname;

                    OracleParameter _op_dm = _cmd.Parameters.Add(new OracleParameter("STRDM", OracleDbType.Varchar2, 1000));
                    _op_dm.Value = _code;

                    OracleParameter _opRET = _cmd.Parameters.Add(new OracleParameter("STRCT", OracleDbType.Varchar2, 1000));
                    _opRET.Direction = ParameterDirection.Output;

                    _cmd.ExecuteNonQuery();

                    _ret = (string)_opRET.Value;

                }
                catch (Exception e)
                {
                    Exception exp = e;
                    ServerCommon.WriteLog(string.Format("GetRefString({0},{1},{3}) 时发出错误如下：\n{2}", "ticket", _tname, e.Message, _code), EventLogEntryType.Error);
                    return null;
                }
            }
            return _ret;

        }

        /// <summary>
        /// 11.获得代码表新增内容
        /// </summary>
        /// <param name="ticket">验证票</param>
        /// <returns>返回代码表维护用的DataSet,如果为NULL，则查询失败。如果查询成功，DataSet中有1个DataTable</returns>
        [WebMethod(MessageName = "GetChangedRefTableNoWHXH")]
        public DataSet GetChangedRefTable(string ticket)
        {
            UserInformation userInfo;
            if (!IsTicketValid(ticket, false, out userInfo))
                return null;

            DataSet _ds = new DataSet();
            DataTable _dt = new DataTable();

            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                try
                {
                    OracleCommand _cmd = new OracleCommand();
                    _cmd.CommandText = "ZHTJ_SJJH.GetChangedRefTable";
                    _cmd.CommandType = CommandType.StoredProcedure;
                    _cmd.Connection = cn;

                    _cmd.Parameters.Add("STRYHM", userInfo.UserName);
                    _cmd.Parameters.Add("NMAX", (decimal)1000);
                    _cmd.Parameters.Add("RCRET", OracleDbType.RefCursor, 2000, ParameterDirection.Output);


                    OracleDataAdapter _adapter = new OracleDataAdapter(_cmd);
                    _adapter.Fill(_dt);
                    _dt.TableName = "REFDATA";
                    _ds.Tables.Add(_dt);


                }
                catch (Exception e)
                {
                    Exception exp = e;
                    ServerCommon.WriteLog(string.Format("GetChangedRefTable({0}) 时发出错误如下：\n{1}", "ticket", e.Message), EventLogEntryType.Error);
                    return null;
                }
            }
            return _ds;

        }

        /// <summary>
        /// 12.获得维护ID大于clid的代码表新增内容
        /// </summary>
        /// <param name="ticket">验证票</param>
        /// <param name="clid">处理ID</param>
        /// <returns>返回代码表维护用的DataSet,，如果为NULL，则查询失败。如果查询成功，DataSet中有1个DataTable</returns>
        [WebMethod(MessageName = "GetChangedRefTableWithWHXH")]
        public DataSet GetChangedRefTable(string ticket, decimal clid)
        {
            UserInformation userInfo;
            if (!IsTicketValid(ticket, false, out userInfo))
                return null;

            DataSet _ds = new DataSet();
            DataTable _dt = new DataTable();
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                try
                {
                    OracleCommand _cmd = new OracleCommand();
                    _cmd.CommandText = "ZHTJ_SJJH.GetChangedRefTable_WHXH";
                    _cmd.CommandType = CommandType.StoredProcedure;
                    _cmd.Connection = cn;

                    _cmd.Parameters.Add("STRYHM", userInfo.UserName);
                    _cmd.Parameters.Add("NCLID", clid);
                    _cmd.Parameters.Add("NMAX", (decimal)1000);
                    _cmd.Parameters.Add("RCRET", OracleDbType.RefCursor, 2000, ParameterDirection.Output);


                    OracleDataAdapter _adapter = new OracleDataAdapter(_cmd);
                    _adapter.Fill(_dt);
                    _dt.TableName = "REFDATA";
                    _ds.Tables.Add(_dt);

                }
                catch (Exception e)
                {
                    Exception exp = e;
                    ServerCommon.WriteLog(string.Format("GetChangedRefTable({0},{2}) 时发出错误如下：\n{1}", "ticket", e.Message, clid), EventLogEntryType.Error);
                    return null;
                }
            }
            return _ds;
        }

        #endregion
    }
}