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
    /// Service1 ��ժҪ˵����
    /// </summary>
    /// 
    [WebService(Namespace = "http://tempuri.org/")]
    public class AJDataService : System.Web.Services.WebService
    {
        public AJDataService()
        {
            //CODEGEN: �õ����� ASP.NET Web ����������������
            InitializeComponent();
        }

        #region �����������ɵĴ���

        //Web ����������������
        private IContainer components = null;

        /// <summary>
        /// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
        /// �˷��������ݡ�
        /// </summary>
        private void InitializeComponent() { }

        /// <summary>
        /// ������������ʹ�õ���Դ��
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

        // WEB ����ʾ��
        // HelloWorld() ʾ�����񷵻��ַ��� Hello World
        // ��Ҫ���ɣ���ȡ��ע�������У�Ȼ�󱣴沢������Ŀ
        // ��Ҫ���Դ� Web �����밴 F5 ��

        //���ߣ�����ϲ 2005-03-14  ˵����1.��ȡ����汾��
        [WebMethod]
        public string GetVersion()
        {
            return Config.Version;
        }

        #region �û���֤��أ�����Login,ChangePassword,IsTicketValid

        /// <summary>
        /// 2.��¼ϵͳ
        /// </summary>
        /// <param name="UserName">�û�����</param>
        /// <param name="Password">�û�����</param>
        /// <returns>�����¼�ɹ����򷵻�Ticket�ִ�;���ʧ�ܣ��򷵻�null</returns>
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
        /// 3.�޸Ŀ���
        /// </summary>
        /// <param name="ticket">��֤Ʊ</param>
        /// <param name="UserName">�û�����</param>
        /// <param name="OldPassword">�ɿ���</param>
        /// <param name="NewPassword">�¿���</param>
        /// <returns>0:	�ɹ�;	-1:ʧ��</returns>
        [WebMethod()]
        public int ChangePassword(string ticket, string UserName, string OldPassword, string NewPassword)
        {
            UserInformation userInfo = null;
            if (!IsTicketValid(ticket, false, out userInfo))
                return -1;

            int userID = int.Parse(FormsAuthentication.Decrypt(ticket).Name);

            int result = 0;

            //�޸Ŀ����ʵ��

            if (result == 1)
                return 0;
            else
                return -1;
        }

        /// <summary>
        /// ��֤�û��ṩ��Ʊ��
        /// </summary>
        /// <param name="ticket">����ִ�</param>
        /// <param name="IsAdminCall">�Ƿ񳬼��û�</param>
        /// <returns>true:ͨ����֤    false:��ͨ����֤</returns>
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


                //�����ݿ���ȡ�û���Ϣ����ʵ��
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

        #region ��ȡ��������� GetNewData,GetDeletedData

        /// <summary>
        /// 4.1���ĳʵ���������ݣ������������޸ĵ�����
        /// </summary>
        /// <param name="ticket">��֤Ʊ</param>
        /// <param name="_tname">ʵ������</param>
        /// <returns>null��ʧ��;��������ɹ�����DataSet����һ��DataTable</returns>
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
                    ServerCommon.WriteLog(string.Format("GetNewData({0},{1}) ʱ�����������£�\n{2}", "ticket", _tname, e.Message), EventLogEntryType.Error);
                    return null;
                }
            }
            return _ds;

        }

        /// <summary>
        /// 4.2���ĳʵ��ά����Ŵ���_whxh���������ݣ������������޸ĵ�����
        /// </summary>
        /// <param name="ticket">��֤Ʊ</param>
        /// <param name="_tname">ʵ������</param>
        /// <param name="_whxh">ά�����</param>
        /// <returns>null��ʧ��;��������ɹ�����DataSet����һ��DataTable</returns>
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
                    ServerCommon.WriteLog(string.Format("GetNewData({0},{1},{2}) ʱ�����������£�\n{3}", "ticket", _tname, _whxh, e.Message), EventLogEntryType.Error);
                    return null;
                }
            }
            return _ds;

        }

        /// <summary>
        /// 5.1����ɾ����ʵ���ʶ
        /// </summary>
        /// <param name="ticket">��֤Ʊ</param>
        /// <param name="_tname">ʵ������</param>
        /// <returns>null��ʧ��;��������ɹ�����DataSet����һ��DataTable</returns>
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
                    ServerCommon.WriteLog(string.Format("GetDeletedData({0},{1}) ʱ�����������£�\n{2}", "ticket", _tname, e.Message), EventLogEntryType.Error);
                    return null;
                }
            }
            return _ds;

        }

        /// <summary>
        /// 5.2����ά����Ŵ���_whxh����Ҫɾ����ʵ���ʶ
        /// </summary>
        /// <param name="ticket">��֤Ʊ</param>
        /// <param name="_tname">ʵ������</param>
        /// <param name="_whxh">ά�����</param>
        /// <returns>null��ʧ��;��������ɹ�����DataSet����һ��DataTable</returns>
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
                    ServerCommon.WriteLog(string.Format("GetDeletedData({0},{1},{3}) ʱ�����������£�\n{2}", "ticket", _tname, e.Message, _whxh), EventLogEntryType.Error);
                    return null;
                }
            }
            return _ds;

        }

        #endregion

        #region ��ȡ�������ݣ�����GetAJList,GetAJData

        /// <summary>
        /// 6.���ڻ�ȡ�����б�
        /// </summary>
        /// <param name="ticket">��֤Ʊ</param>
        /// <param name="_isAll">0:���°����б�		1:���а����б�</param>
        /// <param name="_type">0:���°���			1:��������</param>
        /// <returns>���ذ������ݵ�DataSet,�����ΪNULL�����ѯʧ�ܡ������ѯ�ɹ���DataSet����һ��DataTable</returns>
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
                    ServerCommon.WriteLog(string.Format("GetAJList({0},{1},{3}) ʱ�����������£�\n{2}", "ticket", _isAll, e.Message, _type), EventLogEntryType.Error);
                    return null;
                }
            }
            return _ds;


        }

        /// <summary>
        /// 7.��ȡ�������ݣ�����������¼�������ؽ���
        /// </summary>
        /// <param name="ticket">��֤Ʊ</param>
        /// <param name="_tname">������</param>
        /// <param name="ODS_ID">����������Ϣ��Ψһ�ؼ���</param>
        /// <returns>������ؽ���������������˵�λ�����乤�ߡ���˽��Ʒ��������</returns>
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
                    ServerCommon.WriteLog(string.Format("GetAJData({0},{1},{3}) ʱ�����������£�\n{2}", "ticket", _tname, e.Message, ODS_ID), EventLogEntryType.Error);
                    return null;
                }
            }
            return _ds;

        }

        #endregion

        #region ��ȡԪ���ݣ�����GetTableMeta,GetRefTable,GetRefString,GetChangedRefTable

        /// <summary>
        /// 8.���ڻ�ȡһ�����Ԫ����
        /// </summary>
        /// <param name="ticket">��֤Ʊ</param>
        /// <param name="_tname">���ȡԪ���������ı�����</param>
        /// <returns>�������Ľ����</returns>
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
                    ServerCommon.WriteLog(string.Format("GetTableMeta({0},{1}) ʱ�����������£�\n{2}", "ticket", _tname, e.Message), EventLogEntryType.Error);
                    return null;
                }
            }
            return _ds;

        }

        /// <summary>
        /// 9.���������ڻ�ȡһ�������
        /// </summary>
        /// <param name="ticket">��֤Ʊ</param>
        /// <param name="_tname">���ȡ�Ĵ���������</param>
        /// <returns>���������</returns>
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
                    ServerCommon.WriteLog(string.Format("GetRefTable({0},{1}) ʱ�����������£�\n{2}", "ticket", _tname, e.Message), EventLogEntryType.Error);
                    return null;
                }
            }
            return _ds;

        }

        /// <summary>
        /// 10.���ڻ�ȡһ��������ĳ�����ֵ
        /// </summary>
        /// <param name="ticket">��֤Ʊ</param>
        /// <param name="_tname">���õĴ���������</param>
        /// <param name="_code">��ת���Ĵ���ֵ</param>
        /// <returns>���ش˴����Ӧ��ֵ</returns>
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
                    ServerCommon.WriteLog(string.Format("GetRefString({0},{1},{3}) ʱ�����������£�\n{2}", "ticket", _tname, e.Message, _code), EventLogEntryType.Error);
                    return null;
                }
            }
            return _ret;

        }

        /// <summary>
        /// 11.��ô������������
        /// </summary>
        /// <param name="ticket">��֤Ʊ</param>
        /// <returns>���ش����ά���õ�DataSet,���ΪNULL�����ѯʧ�ܡ������ѯ�ɹ���DataSet����1��DataTable</returns>
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
                    ServerCommon.WriteLog(string.Format("GetChangedRefTable({0}) ʱ�����������£�\n{1}", "ticket", e.Message), EventLogEntryType.Error);
                    return null;
                }
            }
            return _ds;

        }

        /// <summary>
        /// 12.���ά��ID����clid�Ĵ������������
        /// </summary>
        /// <param name="ticket">��֤Ʊ</param>
        /// <param name="clid">����ID</param>
        /// <returns>���ش����ά���õ�DataSet,�����ΪNULL�����ѯʧ�ܡ������ѯ�ɹ���DataSet����1��DataTable</returns>
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
                    ServerCommon.WriteLog(string.Format("GetChangedRefTable({0},{2}) ʱ�����������£�\n{1}", "ticket", e.Message, clid), EventLogEntryType.Error);
                    return null;
                }
            }
            return _ds;
        }

        #endregion
    }
}