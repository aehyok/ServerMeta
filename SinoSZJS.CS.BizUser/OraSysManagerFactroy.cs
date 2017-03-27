using System;
using System.Collections.Generic;
using System.Text;
using Oracle.DataAccess.Client;
using System.Data;
using SinoSZJS.Base.UserLog;
using SinoSZJS.DataAccess;
using SinoSZJS.Base.SystemLog;
using SinoSZJS.Base.Notify;
using SinoSZJS.Base.SystemInterface;
using SinoSZJS.Base.OrganizeExt;
using SinoSZJS.Base.TaskInfo;
using SinoSZJS.Base.Authorize;
using SinoSZJS.Base.MetaData.QueryModel;
using SinoSZJS.CS.BizMetaDataManager.DAL;
using SinoSZJS.Base.WorkCalendar;
using System.Diagnostics;
using SinoSZJS.Base.JSGDS;


namespace SinoSZJS.CS.BizUser
{
    public class OraSysManagerFactroy : IUserLog
    {
        #region IUserLog Members

        public bool WriteUserLog(decimal _yhid, string _czlx, string _cxnr, decimal _resulttype, string _ipaddr, string _hostName, string _systemID)
        {
            return false;
        }

        private const string SQL_GetUserLog = @"select ID,YHID,CZSJ,CZLX,CZXXNR,FROMIP,FROMHOST,RESULTTYPE,
                                                    (select yhm from qx2_yhxx yh where yh.yhid=t.YHID) YHM,
                                                    ZHTJ_ZZJG2.Get_YHXM(YHID) YHXM from XT_USERLOG t 
                                                    where (CZSJ between :KSRQ and :JSRQ )";
        public List<UserLogRecord> GetUserLog(DateTime _startDate, DateTime _endDate, string _userName, string _context)
        {
            List<UserLogRecord> _ret = new List<UserLogRecord>();
            string _sql = SQL_GetUserLog;

            if (_userName.Trim().Length > 0)
            {
                _sql += string.Format(" and yhid in (select yhid from qx2_yhxx t where yhm = '{0}' or xm = '{1}') ", _userName, _userName);
            }

            if (_context.Trim().Length > 0)
            {
                _sql += " and (CZXXNR like '%" + _context + "%' ) ";
            }

            _sql += " order by CZSJ DESC ";
            OracleParameter[] _param = {
                                        new OracleParameter(":KSRQ", OracleDbType.Date),
                                        new OracleParameter(":JSRQ",OracleDbType.Date)
                                 };
            _param[0].Value = _startDate;
            _param[1].Value = _endDate;

            OracleDataReader dr = OracleHelper.ExecuteReader(OracleHelper.ConnectionStringProfile, CommandType.Text,
                                _sql, _param);

            while (dr.Read())
            {
                UserLogRecord _mitem = new UserLogRecord(
                        dr.IsDBNull(0) ? "" : dr.GetString(0),
                        dr.IsDBNull(1) ? "" : dr.GetDecimal(1).ToString(),
                        dr.IsDBNull(9) ? "" : dr.GetString(9),
                        dr.IsDBNull(3) ? "" : dr.GetString(3),
                        dr.IsDBNull(4) ? "" : dr.GetString(4),
                        dr.IsDBNull(5) ? "" : dr.GetString(5),
                        dr.IsDBNull(6) ? "" : dr.GetString(6),
                        dr.IsDBNull(2) ? DateTime.MinValue : dr.GetDateTime(2),
                        dr.IsDBNull(7) ? 0 : Convert.ToInt32(dr.GetDecimal(7)),
                        dr.IsDBNull(8) ? "" : dr.GetString(8)

                );
                _ret.Add(_mitem);
            }
            dr.Close();
            return _ret;

        }


        public List<SystemLogRecord> GetSystemLog(DateTime _startDate, DateTime _endDate, string _logtype, string _context)
        {
            List<SystemLogRecord> _ret = new List<SystemLogRecord>();
            string _sql = " select ID,CZSJ,LOGTYPE,LOGTEXT ";
            _sql += " from xt_systemlog t ";
            _sql += " where (CZSJ between :KSRQ and :JSRQ ) ";

            if (_logtype.Trim().Length > 0)
            {
                _sql += string.Format(" and LOGTYPE='{0}' ", _logtype);
            }

            if (_context.Trim().Length > 0)
            {
                _sql += " and (LOGTEXT like '%" + _context + "%' ) ";
            }

            _sql += " order by CZSJ DESC ";
            OracleParameter[] _param = {
                                        new OracleParameter(":KSRQ", OracleDbType.Date),
                                        new OracleParameter(":JSRQ",OracleDbType.Date)
                                 };
            _param[0].Value = _startDate;
            _param[1].Value = _endDate;

            OracleDataReader dr = OracleHelper.ExecuteReader(OracleHelper.ConnectionStringProfile, CommandType.Text,
                                _sql, _param);

            while (dr.Read())
            {
                SystemLogRecord _mitem = new SystemLogRecord(
                        dr.IsDBNull(0) ? "" : dr.GetString(0),
                        dr.IsDBNull(1) ? DateTime.MinValue : dr.GetDateTime(1),
                        dr.IsDBNull(2) ? "" : dr.GetString(2),
                        dr.IsDBNull(3) ? "" : dr.GetString(3)
                );
                _ret.Add(_mitem);
            }
            dr.Close();
            return _ret;
        }


        public DataTable GetNotifyList(int _num)
        {
            string _select = string.Format("select ID,(select ZZJGMC from QX2_ZZJG WHERE ZZJGDM = FBDW) FBDWMC, FBDW,FBR,FBSJ,XXBT from XT_GGXX where  ZH_SHANGJI('{0}',FBDW) ='1' ORDER BY FBSJ DESC", SinoUserCtx.CurUser.CurrentPost.PostDWDM);
            string _sql = string.Format(" select * from ({0}) where rownum<={1}", _select, _num);
            DataTable _ret = OracleHelper.Get_Data(_sql, "TZTG");
            return _ret;
        }



        public NotifyInfo GetNotifyInfo(string _msgid)
        {
            NotifyInfo _ret = null;
            StringBuilder _sb = new StringBuilder();
            _sb.Append(" select ID,XXBT,XXNR,FBDW,(select ZZJGMC from QX2_ZZJG WHERE ZZJGDM = FBDW) FBDWMC,FBR,LXDH,DZYJ,FBSJ from XT_GGXX");
            _sb.Append(" where id=:ID ");
            OracleParameter[] _param = {
                                        new OracleParameter(":ID", OracleDbType.Decimal)                                      
                                 };
            _param[0].Value = Decimal.Parse(_msgid);
            OracleDataReader dr = OracleHelper.ExecuteReader(OracleHelper.ConnectionStringProfile, CommandType.Text,
                             _sb.ToString(), _param);

            while (dr.Read())
            {
                _ret = new NotifyInfo(dr.IsDBNull(0) ? "0" : dr.GetDecimal(0).ToString(),
                        dr.IsDBNull(1) ? "" : dr.GetString(1),
                        dr.IsDBNull(2) ? "" : dr.GetString(2),
                        dr.IsDBNull(3) ? "" : dr.GetString(3),
                        dr.IsDBNull(4) ? "" : dr.GetString(4),
                        "",
                        dr.IsDBNull(5) ? "" : dr.GetString(5),
                        dr.IsDBNull(6) ? "" : dr.GetString(6),
                        dr.IsDBNull(7) ? "" : dr.GetString(7),
                        dr.IsDBNull(8) ? DateTime.MinValue : dr.GetDateTime(8)
                );
            }
            dr.Close();
            return _ret;

        }

        private const string SQL_SaveNotifyInfo = @"update XT_GGXX set
                                                    FBSJ=sysdate,LXDH=:LXDH,DZYJ=:DZYJ,XXBT=:XXBT,XXNR=:XXNR,FBR=:FBR 
                                                     WHERE ID=:ID and FBDW=:FBDW ";
        public bool SaveNotifyInfo(NotifyInfo _info)
        {
            if (_info.ID == "")
            {
                return SaveNewNotifyInfo(_info);
            }
            else
            {
                using (OracleConnection cn = OracleHelper.OpenConnection())
                {
                    OracleTransaction _txn = cn.BeginTransaction();

                    try
                    {
                        OracleCommand _cmd = new OracleCommand(SQL_SaveNotifyInfo, cn);
                        _cmd.Parameters.Add(":LXDH", _info.TelNum);
                        _cmd.Parameters.Add(":DZYJ", _info.Email);
                        _cmd.Parameters.Add(":XXBT", _info.Title);
                        _cmd.Parameters.Add(":XXNR", _info.Context);
                        _cmd.Parameters.Add(":FBR", SinoUserCtx.CurUser.UserName);
                        _cmd.Parameters.Add(":ID", decimal.Parse(_info.ID));
                        _cmd.Parameters.Add(":FBDW", SinoUserCtx.CurUser.CurrentPost.PostDWDM);

                        _cmd.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        string _errmsg = string.Format("修改ID={1}的通知通告信息时出错,错误信息为:{0}!",
                              e.Message, _info.ID);
                        OralceLogWriter.WriteSystemLog(_errmsg, "ERROR");
                        _txn.Rollback();
                        return false;
                    }

                    _txn.Commit();
                    cn.Close();
                }
                return true;
            }
        }

        private const string SQL_SaveNewNotifyInfo = @"INSERT INTO XT_GGXX 
                                                       (ID,FBDW,FBSJ,FBR,LXDH,DZYJ,XXBT,XXNR) values
                                                         (SEQUENCES_META.NEXTVAL,:FBDW,sysdate,:FBR,:LXDH,:DZYJ,:XXBT,:XXNR) ";
        private bool SaveNewNotifyInfo(NotifyInfo _info)
        {

            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                OracleTransaction _txn = cn.BeginTransaction();

                try
                {
                    OracleCommand _cmd = new OracleCommand(SQL_SaveNewNotifyInfo, cn);
                    _cmd.Parameters.Add(":FBDW", SinoUserCtx.CurUser.CurrentPost.PostDWDM);
                    _cmd.Parameters.Add(":FBR", SinoUserCtx.CurUser.UserName);
                    _cmd.Parameters.Add(":LXDH", _info.TelNum);
                    _cmd.Parameters.Add(":DZYJ", _info.Email);
                    _cmd.Parameters.Add(":XXBT", _info.Title);
                    _cmd.Parameters.Add(":XXNR", _info.Context);
                    _cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    string _errmsg = string.Format("删除ID={1}的通知通告信息时出错,错误信息为:{0}!",
                          e.Message, _info.ID);
                    OralceLogWriter.WriteSystemLog(_errmsg, "ERROR");
                    _txn.Rollback();
                    return false;
                }

                _txn.Commit();
                cn.Close();
            }
            return true;

        }

        public bool DeleteNotifyInfo(NotifyInfo CurrentInfo)
        {
            string _sql = " delete from XT_GGXX where ID=:ID AND FBDW=:FBDWDM ";

            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                OracleTransaction _txn = cn.BeginTransaction();

                try
                {
                    OracleCommand _cmd = new OracleCommand(_sql, cn);
                    _cmd.Parameters.Add(":ID", decimal.Parse(CurrentInfo.ID));
                    _cmd.Parameters.Add(":FBDWDM", SinoUserCtx.CurUser.CurrentPost.PostDWDM);
                    _cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    string _errmsg = string.Format("删除ID={1}的通知通告信息时出错,错误信息为:{0}!",
                          e.Message, CurrentInfo.ID);
                    OralceLogWriter.WriteSystemLog(_errmsg, "ERROR");
                    _txn.Rollback();
                    return false;
                }

                _txn.Commit();
                cn.Close();
            }
            return true;
        }

        public List<SystemICS_SJJH> GetSJJHInterfaceList()
        {
            List<SystemICS_SJJH> _ret = new List<SystemICS_SJJH>();
            StringBuilder _sb = new StringBuilder();
            _sb.Append(" select YHID,DISPLAYNAME,YHM,DWID, ZHTJ_ZZJG2.GETDWMC(DWID) DWMC,METADATA from sjjh_yhb");
            _sb.Append(" order by dwid ");

            OracleDataReader dr = OracleHelper.ExecuteReader(OracleHelper.ConnectionStringProfile, CommandType.Text, _sb.ToString());

            while (dr.Read())
            {
                SystemICS_SJJH _item = new SystemICS_SJJH(
                        dr.IsDBNull(0) ? "" : dr.GetDecimal(0).ToString(),
                        dr.IsDBNull(1) ? "" : dr.GetString(1),
                        dr.IsDBNull(2) ? "" : dr.GetString(2),
                        dr.IsDBNull(3) ? "" : dr.GetDecimal(3).ToString(),
                        dr.IsDBNull(4) ? "" : dr.GetString(4),
                        dr.IsDBNull(5) ? "" : dr.GetString(5));
                _ret.Add(_item);
            }
            dr.Close();
            return _ret;
        }


        public List<SystemICS_SJJH_DataTable> GetSJJHTableList(string _yhm)
        {
            List<SystemICS_SJJH_DataTable> _ret = new List<SystemICS_SJJH_DataTable>();
            StringBuilder _sb = new StringBuilder();
            _sb.Append(" select YHM,TABLENAME,WHERECONDITION,SECRETFUN from sjjh_dcsjblb");
            _sb.Append(" where YHM=:YHM ");
            OracleParameter[] _param = {
                                        new OracleParameter(":YHM", OracleDbType.Varchar2)                                      
                                 };
            _param[0].Value = _yhm;

            OracleDataReader dr = OracleHelper.ExecuteReader(OracleHelper.ConnectionStringProfile, CommandType.Text, _sb.ToString(), _param);

            while (dr.Read())
            {
                SystemICS_SJJH_DataTable _item = new SystemICS_SJJH_DataTable(
                        dr.IsDBNull(0) ? "" : dr.GetString(0),
                        dr.IsDBNull(1) ? "" : dr.GetString(1),
                        dr.IsDBNull(2) ? "" : dr.GetString(2),
                        dr.IsDBNull(3) ? "" : dr.GetString(3),
                        "");
                _item.Columns = GetSJJHTableColumns(_item.TableName);
                _ret.Add(_item);

            }
            dr.Close();
            return _ret;
        }

        public List<SystemICS_SJJH_Node> GetSJJHNodeList()
        {
            List<SystemICS_SJJH_Node> _ret = new List<SystemICS_SJJH_Node>();
            StringBuilder _sb = new StringBuilder();
            _sb.Append(" select id,fid,displayName,yhm,lx,xh from sjjh_nodes");
            _sb.Append(" order by xh ");

            OracleDataReader dr = OracleHelper.ExecuteReader(OracleHelper.ConnectionStringProfile, CommandType.Text, _sb.ToString());

            while (dr.Read())
            {
                SystemICS_SJJH_Node _item = new SystemICS_SJJH_Node(
                        dr.IsDBNull(0) ? "" : dr.GetString(0),
                        dr.IsDBNull(1) ? "" : dr.GetString(1),
                        dr.IsDBNull(2) ? "" : dr.GetString(2),
                        dr.IsDBNull(3) ? "" : dr.GetString(3),
                        dr.IsDBNull(4) ? "" : dr.GetString(4),
                        dr.IsDBNull(5) ? 0 : Convert.ToInt32(dr.GetDecimal(5))
                        );

                _ret.Add(_item);

            }
            dr.Close();
            return _ret;
        }


        private List<SystemICS_SJJH_TableColumn> GetSJJHTableColumns(string _tableName)
        {
            List<SystemICS_SJJH_TableColumn> _ret = new List<SystemICS_SJJH_TableColumn>();
            StringBuilder _sb = new StringBuilder();
            _sb.Append(" select TABLENAME,COLUMNNAME,TYPE,LENGTH,REFDMB from sjjh_tablecolumn");
            _sb.Append(" where TABLENAME=:TABLENAME ");
            OracleParameter[] _param = {
                                        new OracleParameter(":TABLENAME", OracleDbType.Varchar2)                                      
                                 };
            _param[0].Value = _tableName;

            OracleDataReader dr = OracleHelper.ExecuteReader(OracleHelper.ConnectionStringProfile, CommandType.Text, _sb.ToString(), _param);

            while (dr.Read())
            {
                SystemICS_SJJH_TableColumn _item = new SystemICS_SJJH_TableColumn(
                        dr.IsDBNull(0) ? "" : dr.GetString(0),
                        dr.IsDBNull(1) ? "" : dr.GetString(1),
                        dr.IsDBNull(2) ? "" : dr.GetString(2),
                        dr.IsDBNull(3) ? 1 : Convert.ToInt32(dr.GetDecimal(3)),
                        dr.IsDBNull(4) ? "" : dr.GetString(4)
                        );

                _ret.Add(_item);

            }
            dr.Close();
            return _ret;
        }




        public List<SystemICS_SJJH_DownloadLog> GetSJJHProcessList(string _yhm, DateTime _start, DateTime _end)
        {
            List<SystemICS_SJJH_DownloadLog> _ret = new List<SystemICS_SJJH_DownloadLog>();
            OraMetaDataQueryFactroy _odf = new OraMetaDataQueryFactroy();
            List<MDQuery_GuideLineParameter> _param = new List<MDQuery_GuideLineParameter>();
            _param.Add(new MDQuery_GuideLineParameter(new MD_GuideLineParameter("&strYHM", "", "字符型", 0, 0, "", true, ""), _yhm));
            _param.Add(new MDQuery_GuideLineParameter(new MD_GuideLineParameter("&dtBegin", "", "日期型", 0, 0, "", true, ""), _start.ToString("yyyy-MM-dd") + " 00:00:00"));
            _param.Add(new MDQuery_GuideLineParameter(new MD_GuideLineParameter("&dtEnd", "", "日期型", 0, 0, "", true, ""), _end.ToString("yyyy-MM-dd") + " 23:59:59"));

            DataTable _dt = _odf.QueryGuideLine("911000001682", _param);
            foreach (DataRow _dr in _dt.Rows)
            {
                SystemICS_SJJH_DownloadLog _item = new SystemICS_SJJH_DownloadLog(
                        _dr.IsNull("系统名称") ? "" : _dr["系统名称"].ToString(),
                        _dr.IsNull("下载对象名称") ? "" : _dr["下载对象名称"].ToString(),
                        (DateTime)_dr["下载时间"],
                        Convert.ToInt32(_dr["下载进度"]),
                        _dr.IsNull("更新对象分类") ? "" : _dr["更新对象分类"].ToString()
                        );

                _ret.Add(_item);

            }
            return _ret;
        }


        public List<OrgExtInfo> GetOrgExtRootData(List<OrgExtFieldDefine> PropertieDefines)
        {
            return GetOrgExtChildData(SinoUserCtx.CurUser.CurrentPost.PostDwID, PropertieDefines);
        }



        public List<OrgExtInfo> GetOrgExtChildData(string _fid, List<OrgExtFieldDefine> PropertieDefines)
        {
            List<OrgExtInfo> _ret = new List<OrgExtInfo>();
            StringBuilder _sb = new StringBuilder();
            _sb.Append(" SELECT  fj.ZZJGID, jg.jgqc, fj.JGXSMC, fj.ISDISPLAY, fj.DISPLAYORDER, jg.sjdwid");
            foreach (OrgExtFieldDefine _field in PropertieDefines)
            {
                _sb.Append(string.Format(",fj.{0}", _field.FieldName));
            }
            _sb.Append(" FROM qx2_zzjg jg ");
            _sb.Append(" join QX2_JGFJXX fj on jg.ZZJGID=fj.ZZJGID ");
            _sb.Append(" where level <= 2 ");
            _sb.Append(" START WITH (jg.ZZJGID = :nParent ) ");
            _sb.Append(" CONNECT BY prior   jg.zzjgid=jg.SJDWID ");

            OracleParameter[] _param = {
                                        new OracleParameter(":nParent", OracleDbType.Decimal)                                      
                                 };
            _param[0].Value = decimal.Parse(_fid);

            OracleDataReader dr = OracleHelper.ExecuteReader(OracleHelper.ConnectionStringProfile, CommandType.Text, _sb.ToString(), _param);

            while (dr.Read())
            {
                OrgExtInfo _item = new OrgExtInfo(
                        dr.IsDBNull(0) ? "" : dr.GetDecimal(0).ToString(),
                        dr.IsDBNull(1) ? "" : dr.GetString(1),
                        dr.IsDBNull(2) ? "" : dr.GetString(2),
                        dr.IsDBNull(3) ? (decimal)0 : dr.GetDecimal(3),
                        dr.IsDBNull(4) ? (decimal)0 : dr.GetDecimal(4),
                        dr.IsDBNull(5) ? "" : dr.GetDecimal(5).ToString()
                        );
                int _index = 6;
                foreach (OrgExtFieldDefine _field in PropertieDefines)
                {
                    _item.SetValue(_field.FieldName, dr[_index++]);
                }
                _ret.Add(_item);
            }
            dr.Close();
            return _ret;
        }




        public bool SaveOrgExtList(List<OrgExtInfo> BeSavedDataList, List<OrgExtFieldDefine> PropertieDefines)
        {
            StringBuilder _sb = new StringBuilder();
            _sb.Append(" update QX2_JGFJXX set JGXSMC=:JGXSMC,ISDISPLAY=:ISDISPLAY,DISPLAYORDER=:DISPLAYORDER");
            foreach (OrgExtFieldDefine _field in PropertieDefines)
            {
                _sb.Append(string.Format(",{0}=:{0}", _field.FieldName));
            }
            _sb.Append(" where ZZJGID=:ZZJGID ");

            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                OracleTransaction _txn = cn.BeginTransaction();
                foreach (OrgExtInfo _item in BeSavedDataList)
                {
                    try
                    {
                        List<OracleParameter> _plist = new List<OracleParameter>();
                        _plist.Add(new OracleParameter(":JGXSMC", _item.GetValue("JGXSMC")));
                        _plist.Add(new OracleParameter(":ISDISPLAY", _item.GetValue("ISDISPLAY")));
                        _plist.Add(new OracleParameter(":DISPLAYORDER", _item.GetValue("DISPLAYORDER")));
                        foreach (OrgExtFieldDefine _field in PropertieDefines)
                        {
                            _plist.Add(new OracleParameter(string.Format(":{0}", _field.FieldName), _item.GetValue(_field.FieldName)));
                        }
                        _plist.Add(new OracleParameter(":ZZJGID", Convert.ToDecimal(_item.GetValue("ZZJGID"))));
                        OracleParameter[] _ps = _plist.ToArray();
                        OracleHelper.ExecuteNonQuery(cn, CommandType.Text, _sb.ToString(), _ps);

                    }
                    catch (Exception e)
                    {
                        string _errmsg = string.Format("写入{1}的组织机构扩展信息时出错,错误信息为:{0}!",
                              e.Message, _item.GetValue("ZZJGID"));
                        OralceLogWriter.WriteSystemLog(_errmsg, "ERROR");
                        _txn.Rollback();
                        return false;
                    }

                }
                _txn.Commit();
                cn.Close();
            }
            return true;
        }




        private const string SQL_GetFsDataLoadAlertMailReceiver = "select * from YW_FS_SJJZTSJSR where LX=:LX";
        public DataTable GetFsDataLoadAlertMailReceiver(string _selectedStr)
        {
            OracleParameter[] _param = {
                                        new OracleParameter(":LX", OracleDbType.Varchar2)                                      
                                 };
            _param[0].Value = _selectedStr;

            return OracleHelper.FillDataTable(OracleHelper.ConnectionStringProfile, CommandType.Text, SQL_GetFsDataLoadAlertMailReceiver, _param);

        }


        private const string SQL_DelFsDataLoadAlertReceiver = "delete from YW_FS_SJJZTSJSR where id=:ID";
        public bool DelFsDataLoadAlertReceiver(string id)
        {
            OracleParameter[] _param = {
                                        new OracleParameter(":ID", OracleDbType.Decimal)                                      
                                 };
            _param[0].Value = Decimal.Parse(id);

            int _ret = OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionStringProfile, CommandType.Text, SQL_DelFsDataLoadAlertReceiver, _param);
            return true;
        }

        private const string SQL_ModifyFsDataLoadAlertReceiver = "update YW_FS_SJJZTSJSR set JSR=:JSR where id=:ID";
        public bool ModifyFsDataLoadAlertReceiver(string id, string EmailAddr)
        {
            OracleParameter[] _param = {
					new OracleParameter(":LX", OracleDbType.Varchar2) ,
                                        new OracleParameter(":ID", OracleDbType.Decimal)                                      
                                 };
            _param[0].Value = EmailAddr;
            _param[1].Value = Decimal.Parse(id);

            int _ret = OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionStringProfile, CommandType.Text, SQL_ModifyFsDataLoadAlertReceiver, _param);
            return true;
        }

        private const string SQL_AddFsDataLoadAlertReceiver = "insert into YW_FS_SJJZTSJSR (id,lx,jsr) values (SEQ_QX2.nextval,:LX,:JSR)";
        public bool AddFsDataLoadAlertReceiver(string lx, string EmailAddr)
        {
            OracleParameter[] _param = {
					new OracleParameter(":LX", OracleDbType.Varchar2) ,
                                        new OracleParameter(":JSR", OracleDbType.Varchar2)                                      
                                 };
            _param[0].Value = lx;
            _param[1].Value = EmailAddr;

            int _ret = OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionStringProfile, CommandType.Text, SQL_AddFsDataLoadAlertReceiver, _param);
            return true;
        }


        public Dictionary<string, SystemICS_SJJH_DownloadLog> GetSJJHState(string _yhm)
        {
            Dictionary<string, SystemICS_SJJH_DownloadLog> _ret = new Dictionary<string, SystemICS_SJJH_DownloadLog>();
            OraMetaDataQueryFactroy _odf = new OraMetaDataQueryFactroy();
            List<MDQuery_GuideLineParameter> _param = new List<MDQuery_GuideLineParameter>();
            _param.Add(new MDQuery_GuideLineParameter(new MD_GuideLineParameter("&strYHM", "", "字符型", 0, 0, "", true, ""), _yhm));
            DataTable _dt = _odf.QueryGuideLine("911000001681", _param);
            foreach (DataRow _dr in _dt.Rows)
            {
                string _s = _dr["更新对象分类"].ToString();
                if (!_ret.ContainsKey(_s))
                {
                    SystemICS_SJJH_DownloadLog _item = new SystemICS_SJJH_DownloadLog(
                    _dr.IsNull("系统名称") ? "" : _dr["系统名称"].ToString(),
                    "",
                    (DateTime)_dr["下载时间"],
                    Convert.ToInt32(_dr["下载进度"]),
                    _dr.IsNull("更新对象分类") ? "" : _dr["更新对象分类"].ToString()
                    );
                    _ret.Add(_s, _item);
                }
            }
            return _ret;
        }


        private const string SQL_GetTaskInfo = @"select RWID,RWMC,RWMS,RZLB,RWML,NEXTTIME,LASTTIME,RUNFLAG,RUNRESULT,RWZT from gzrw where RWID=:RWID";
        public SinoTaskInfo GetTaskInfo(string TaskID)
        {
            SinoTaskInfo _ret = null;
            OracleParameter[] _param = {
					new OracleParameter(":RWID", OracleDbType.Decimal)                               
                                 };
            _param[0].Value = decimal.Parse(TaskID);
            try
            {
                OracleDataReader _dr = OracleHelper.ExecuteReader(OracleHelper.ConnectionStringProfile, CommandType.Text, SQL_GetTaskInfo, _param);
                while (_dr.Read())
                {
                    _ret = new SinoTaskInfo();
                    _ret.RWID = _dr.IsDBNull(0) ? "" : _dr.GetDecimal(0).ToString();
                    _ret.RWMC = _dr.IsDBNull(1) ? "" : _dr.GetString(1);
                    _ret.RWMS = _dr.IsDBNull(2) ? "" : _dr.GetString(2);
                    _ret.RWLX = _dr.IsDBNull(3) ? "" : _dr.GetString(3);
                    _ret.RWML = _dr.IsDBNull(4) ? "" : _dr.GetString(4);
                    _ret.NextTime = _dr.IsDBNull(5) ? new DateTime(1900, 1, 1) : _dr.GetDateTime(5);
                    _ret.LastTime = _dr.IsDBNull(6) ? new DateTime(1900, 1, 1) : _dr.GetDateTime(6);
                    _ret.RunFlag = _dr.IsDBNull(7) ? "" : _dr.GetDecimal(7).ToString();
                    _ret.LastResult = _dr.IsDBNull(8) ? "" : _dr.GetString(8);
                    _ret.RWZT = _dr.IsDBNull(9) ? "" : _dr.GetDecimal(9).ToString();
                }
                return _ret;
            }
            catch (Exception ex)
            {
                string _errmsg = string.Format("取RWID={1}的工作任务信息时出错,错误信息为:{0}!",
                                    ex.Message, TaskID);
                OralceLogWriter.WriteSystemLog(_errmsg, "ERROR");
                return null;
            }
        }

        private const string SQL_GetTaskLog = @" select  t.* from (select r.* from GZRW_RZ r where r.rwid=:RWID and r.runtime>:LASTTIME  and runflag>:HAVEERROR order by runtime desc) t where rownum<:LINENUM";
        public DataTable GetTaskLog(string TaskID, DateTime LastTime, bool GetStartData, bool OnlyErrorData)
        {
            OracleParameter[] _param = {
					new OracleParameter(":RWID", OracleDbType.Decimal),
                                        new OracleParameter(":LASTTIME",OracleDbType.Date),
                                        new OracleParameter(":HAVEERROR",OracleDbType.Decimal),
                                        new OracleParameter(":LINENUM",OracleDbType.Decimal)
                                 };
            _param[0].Value = decimal.Parse(TaskID);
            _param[1].Value = LastTime;
            _param[2].Value = (OnlyErrorData ? (decimal)0 : (decimal)-1);
            _param[3].Value = (GetStartData ? (decimal)31 : (decimal)30000);
            return OracleHelper.FillDataTable(OracleHelper.ConnectionStringProfile, CommandType.Text, SQL_GetTaskLog, _param);

        }

        private const string SQL_SetTaskState = @"update GZRW set RWZT=:NEWZT where RWID=:RWID and RWZT=:LIMIT";
        public string SetTaskState(string TaskID, int NewState, int LimitState)
        {
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                OracleTransaction txn = cn.BeginTransaction();
                try
                {
                    OracleParameter[] _param = {
					                new OracleParameter(":NEWZT", OracleDbType.Decimal) ,
                                                        new OracleParameter(":RWID", OracleDbType.Decimal),
                                                        new OracleParameter(":LIMIT", OracleDbType.Decimal)           
                                                 };
                    _param[0].Value = Convert.ToDecimal(NewState);
                    _param[1].Value = decimal.Parse(TaskID);
                    _param[2].Value = Convert.ToDecimal(LimitState);

                    int _ret = OracleHelper.ExecuteNonQuery(cn, CommandType.Text, SQL_SetTaskState, _param);
                    txn.Commit();
                    return "";
                }
                catch (Exception ex)
                {
                    txn.Rollback();
                    return ex.Message;
                }
            }
        }
        private const string SQL_ResetTaskParam = @"update GZRW set NEXTTIME=:NEXT,RWML=:RWMC where RWID=:RWID and RWZT<>1";
        public string ResetTaskParam(string TaskID, DateTime NextTime, string NewParam)
        {
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                OracleTransaction txn = cn.BeginTransaction();
                try
                {
                    OracleParameter[] _param = {
					                new OracleParameter(":NEXT", OracleDbType.Date) ,
                                                        new OracleParameter(":RWMC",OracleDbType.Varchar2),
                                                        new OracleParameter(":RWID", OracleDbType.Decimal)        
                                                 };
                    _param[0].Value = NextTime;
                    _param[1].Value = NewParam;
                    _param[2].Value = decimal.Parse(TaskID);


                    int _ret = OracleHelper.ExecuteNonQuery(cn, CommandType.Text, SQL_ResetTaskParam, _param);
                    txn.Commit();
                    return "";
                }
                catch (Exception ex)
                {
                    txn.Rollback();
                    return ex.Message;
                }
            }
        }



        public List<QueryLogRecord> GetQueryLog(DateTime _startDate, DateTime _endDate, string _userName)
        {
            List<QueryLogRecord> _ret = new List<QueryLogRecord>();
            string _sql = "select ID,SJ,QUERY_STR,YHID,";
            _sql += "(select yhm from qx2_yhxx yh where yh.yhid=t.YHID) YHM, ";
            _sql += "ZHTJ_ZZJG2.Get_YHXM(YHID) YHXM from QUERY_LOG t ";
            _sql += " where (SJ between :KSRQ and :JSRQ ) ";

            if (_userName.Trim().Length > 0)
            {
                _sql += string.Format(" and yhid in (select yhid from qx2_yhxx t where yhm = '{0}' or xm = '{1}') ", _userName, _userName);
            }


            _sql += " order by SJ DESC ";
            OracleParameter[] _param = {
                                        new OracleParameter(":KSRQ", OracleDbType.Date),
                                        new OracleParameter(":JSRQ",OracleDbType.Date)
                                 };
            _param[0].Value = _startDate;
            _param[1].Value = _endDate;

            OracleDataReader dr = OracleHelper.ExecuteReader(OracleHelper.ConnectionStringProfile, CommandType.Text,
                                _sql, _param);

            while (dr.Read())
            {

                QueryLogRecord _mitem = new QueryLogRecord(
                        dr.IsDBNull(0) ? "" : dr.GetDecimal(0).ToString(),
                       dr.IsDBNull(1) ? DateTime.Now : dr.GetDateTime(1),
                        dr.IsDBNull(4) ? "" : dr.GetString(4),
                        dr.IsDBNull(2) ? "" : dr.GetString(2)
                );
                _ret.Add(_mitem);
            }
            dr.Close();
            return _ret;

        }

        private const string SQL_GetDataInfo = @"select GZ_DATE,GZ_META,GZ_YEAR,GZ_MONTH,GZ_DAY,GZ_LX,GZ_SFGZR,GZ_FXSB 
                                                from GZRL where GZ_DATE>:STARTDATE and GZ_DATE<:ENDDATE order by GZ_DATE";
        public List<WC_DataInfo> GetDataInfo(int Year)
        {
            List<WC_DataInfo> _ret = new List<WC_DataInfo>();
            OracleParameter[] _param = {
                                        new OracleParameter(":STARTDATE", OracleDbType.Varchar2,8),
                                        new OracleParameter(":ENDDATE",OracleDbType.Varchar2,8)
                                 };
            _param[0].Value = (new DateTime(Year - 1, 12, 1)).ToString("yyyyMMdd");
            _param[1].Value = (new DateTime(Year + 1, 1, 31)).ToString("yyyyMMdd");

            OracleDataReader dr = OracleHelper.ExecuteReader(OracleHelper.ConnectionStringProfile, CommandType.Text,
                                SQL_GetDataInfo, _param);
            while (dr.Read())
            {
                string _datestr = dr.IsDBNull(0) ? "" : dr.GetString(0);
                if (_datestr != "" && _datestr.Length == 8)
                {
                    WC_DataInfo _di = new WC_DataInfo();
                    _di.GZ_Date = new DateTime(int.Parse(_datestr.Substring(0, 4)), int.Parse(_datestr.Substring(4, 2)), int.Parse(_datestr.Substring(6, 2)));
                    _di.Meta = dr.IsDBNull(1) ? "" : dr.GetString(1);
                    _di.Year = int.Parse(dr.IsDBNull(2) ? "1" : dr.GetString(2));
                    _di.Month = int.Parse(dr.IsDBNull(3) ? "1" : dr.GetString(3));
                    _di.Day = int.Parse(dr.IsDBNull(4) ? "1" : dr.GetString(4));
                    _di.IsTJSBR = ((dr.IsDBNull(5) ? 0 : Convert.ToInt16(dr.GetDecimal(5))) > 0);
                    _di.IsWorkDay = ((dr.IsDBNull(6) ? 0 : Convert.ToInt16(dr.GetDecimal(6))) < 1);
                    _di.IsFXSBR = ((dr.IsDBNull(7) ? 0 : Convert.ToInt16(dr.GetDecimal(7))) > 0);
                    _ret.Add(_di);
                }
            }
            dr.Close();
            return _ret;
        }

        private const string SQL_DelDataInfo = @"delete from GZRL where GZ_DATE=:GZDATE";
        private const string SQL_InsDataInfo = @"insert into GZRL (GZ_DATE,GZ_META,GZ_YEAR,GZ_MONTH,GZ_DAY,GZ_LX,GZ_SFGZR,GZ_FXSB)
                                                    values (:GZ_DATE,:GZ_META,:GZ_YEAR,:GZ_MONTH,:GZ_DAY,:GZ_LX,:GZ_SFGZR,:GZ_FXSB)";
        public bool SaveDataInfo(WC_DataInfo DataInfo)
        {
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                OracleTransaction _txn = cn.BeginTransaction();
                try
                {
                    OracleCommand _cmd = new OracleCommand(SQL_DelDataInfo, cn);
                    _cmd.Parameters.Add(":GZDATE", DataInfo.GZ_Date.ToString("yyyyMMdd"));
                    _cmd.ExecuteNonQuery();

                    OracleCommand _cmd2 = new OracleCommand(SQL_InsDataInfo, cn);
                    _cmd2.Parameters.Add(":GZDATA", DataInfo.GZ_Date.ToString("yyyyMMdd"));
                    _cmd2.Parameters.Add(":GZ_META", DataInfo.Meta);
                    _cmd2.Parameters.Add(":GZ_YEAR", Convert.ToDecimal(DataInfo.GZ_Date.Year));
                    _cmd2.Parameters.Add(":GZ_MONTH", Convert.ToDecimal(DataInfo.GZ_Date.Month));
                    _cmd2.Parameters.Add(":GZ_DAY", Convert.ToDecimal(DataInfo.GZ_Date.Day));
                    _cmd2.Parameters.Add(":GZ_LX", DataInfo.IsTJSBR ? (decimal)1 : (decimal)0);
                    _cmd2.Parameters.Add(":GZ_SFGZR", DataInfo.IsWorkDay ? (decimal)0 : (decimal)1);
                    _cmd2.Parameters.Add(":GZ_FXSB", DataInfo.IsFXSBR ? (decimal)1 : (decimal)0);
                    _cmd2.ExecuteNonQuery();
                    _txn.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    string _err = string.Format("写入GZRL日期:{0}时发生错误:{1}", DataInfo.GZ_Date, ex.Message);
                    OralceLogWriter.WriteSystemLog(_err, "ERROR");
                    _txn.Rollback();
                    return false;
                }


            }
        }
        #endregion



        public WC_TJSB_Settings GetTJSBSettings()
        {
            WC_TJSB_Settings ret = new WC_TJSB_Settings();

            //取统计上报日
            string _sbr = Get_ZHTJ_CS("每月上报日");
            ret.SBDay = (_sbr == "") ? 1 : int.Parse(_sbr);
            ret.FTP_Addr = Get_ZHTJ_CS("统计司FTP地址");
            ret.FTP_Path = Get_ZHTJ_CS("统计司FTP目录");
            string _port = Get_ZHTJ_CS("统计司FTP端口");
            ret.FTP_Port = (_port == "") ? 21 : int.Parse(_port);
            ret.FTP_User = Get_ZHTJ_CS("统计司FTP用户名"); ;
            ret.FTP_Pass = Get_ZHTJ_CS("统计司FTP口令");
            ret.Backup_Path = Get_ZHTJ_CS("上报数据备份目录");

            return ret;
        }

        private const string SQL_GetZHTJ_CS = @"select CSDATA from ZHTJ_CSB where CSNAME = :CSNAME ";
        private string Get_ZHTJ_CS(string CSNAME)
        {

            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                OracleCommand _cmd = new OracleCommand(SQL_GetZHTJ_CS, cn);
                _cmd.Parameters.Add(":CSNAME", CSNAME);
                object csz = _cmd.ExecuteScalar();
                if (csz == null)
                {
                    return "";
                }
                else
                {
                    return csz.ToString();
                }
            }
        }



        public bool SaveTJSBSettings(WC_TJSB_Settings Settings)
        {
            Save_ZHTJ_CS("每月上报日", Settings.SBDay.ToString(), "每月上报日");
            Save_ZHTJ_CS("统计司FTP地址", Settings.FTP_Addr, "统计司FTP地址");
            Save_ZHTJ_CS("统计司FTP端口", Settings.FTP_Port.ToString(), "统计司FTP端口");
            Save_ZHTJ_CS("统计司FTP目录", Settings.FTP_Path, "统计司FTP目录");
            Save_ZHTJ_CS("统计司FTP用户名", Settings.FTP_User, "统计司FTP用户名");
            Save_ZHTJ_CS("统计司FTP口令", Settings.FTP_Pass, "统计司FTP口令");
            Save_ZHTJ_CS("上报数据备份目录", Settings.Backup_Path, "上报数据备份目录");
            return true;

        }

        private const string SQL_DelZHTJ_CS = @"Delete from ZHTJ_CSB where CSNAME = :CSNAME ";
        private const string SQL_InsZHTJ_CS = @"insert into ZHTJ_CSB (CSNAME,CSDATA,CSDESC) values (:CSNAME,:CSNAME,:CSDESC)";
        private bool Save_ZHTJ_CS(string CSNAME, string CSDATA, string Des)
        {

            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                OracleTransaction _txn = cn.BeginTransaction();
                try
                {
                    OracleCommand _cmd = new OracleCommand(SQL_DelZHTJ_CS, cn);
                    _cmd.Parameters.Add(":CSNAME", CSNAME);
                    _cmd.ExecuteNonQuery();

                    OracleCommand _cmd2 = new OracleCommand(SQL_InsZHTJ_CS, cn);
                    _cmd2.Parameters.Add(":CSNAME", CSNAME);
                    _cmd2.Parameters.Add(":CSDATA", CSDATA);
                    _cmd2.Parameters.Add(":CSDESC", Des);
                    _cmd2.ExecuteNonQuery();
                    _txn.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    string _err = string.Format("写入参数{0}时发生错误:{1}", CSNAME, ex.Message);
                    OralceLogWriter.WriteSystemLog(_err, "ERROR");
                    _txn.Rollback();
                    return false;
                }
            }
        }

        private const string SQL_GetGDSList = @"select ID,ICSNAME,DWDM,ICSDESCRIPT,ICSTYPE,ICSPARAM,ICSRETURN,ICSTOKENTYPE,ICSCONFIG,ICSSTATE from md_icsdefine";
        public List<GDSCommanderDefine> GetGDSList()
        {
            List<GDSCommanderDefine> _ret = new List<GDSCommanderDefine>();
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                OracleDataReader dr = OracleHelper.ExecuteReader(OracleHelper.ConnectionStringProfile, CommandType.Text, SQL_GetGDSList, null);
                while (dr.Read())
                {
                    GDSCommanderDefine _gd = new GDSCommanderDefine();
                    _gd.ID = dr.IsDBNull(0) ? "" : dr.GetString(0);
                    _gd.CommandName = dr.IsDBNull(1) ? "" : dr.GetString(1);
                    _gd.DWDM = dr.IsDBNull(2) ? "" : dr.GetString(2);
                    _gd.Descript = dr.IsDBNull(3) ? "" : dr.GetString(3);
                    _gd.IcsType = dr.IsDBNull(4) ? "" : dr.GetString(4);
                    _gd.CallParamDefine = dr.IsDBNull(5) ? "" : dr.GetString(5);
                    _gd.ReturnDefine = dr.IsDBNull(6) ? "" : dr.GetString(6);
                    _gd.TokenType = dr.IsDBNull(7) ? "" : dr.GetString(7);
                    _gd.IcsConfig = dr.IsDBNull(8) ? "" : dr.GetString(8);
                    _gd.State = dr.IsDBNull(9) ? "" : dr.GetString(9);
                    _ret.Add(_gd);
                }
                dr.Close();
                return _ret;
            }
        }

        //        private const string SQL_SaveGDSDefine = @"update md_icsdefine  set ICSNAME=:ICSNAME,DWDM=:DWDM,ICSDESCRIPT=:DES,ICSTYPE=:ICSTYPE,ICSPARAM=:ICSPARAM,
        //                                                                            ICSRETURN=:ICSRETURN,ICSTOKENTYPE=:TOKENTYPE,ICSCONFIG=:ICSCFG,ICSSTATE=:ICSSTATE
        //                                                    where id=:ID";

        private const string SQL_SaveGDSDefine = @"update md_icsdefine set ICSNAME=:ICSNAME,DWDM=:DWDM,ICSDESCRIPT=:DES,ICSTYPE=:ICSTYPE,ICSPARAM=:ICSPARAM,
                                                                            ICSRETURN=:ICSRETURN,ICSTOKENTYPE=:TOKENTYPE,ICSCONFIG=:ICSCONFIG,ICSSTATE=:ICSSTATE
                                                    where id=:ID";

        private const string SQL_InsertGDSDefine = @"insert into md_icsdefine (ID,ICSNAME,DWDM,ICSDESCRIPT,ICSTYPE,ICSPARAM,ICSRETURN,ICSTOKENTYPE,ICSCONFIG,ICSSTATE)
                                                                      values  (:ID,:ICSNAME,:DWDM,:DES,:ICSTYPE,:ICSPARAM,:ICSRETURN,:TOKENTYPE,:ICSCONFIG,:ICSSTATE)";
        private const string SQL_HaveGDSDefine = @"select count(id) from md_icsdefine where id=:ID";

        public bool SaveGDSDefine(GDSCommanderDefine GDSDefine)
        {
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                OracleTransaction _txn = cn.BeginTransaction();
                try
                {
                    OracleCommand _cmd = new OracleCommand(SQL_HaveGDSDefine, cn);
                    _cmd.Parameters.Add(":ID", GDSDefine.ID);
                    decimal _count = (decimal)_cmd.ExecuteScalar();

                    if (_count > 0)
                    {
                        OracleCommand _upCmd = new OracleCommand(SQL_SaveGDSDefine, cn);
                        _upCmd.Parameters.Add(":ICSNAME", GDSDefine.CommandName);
                        _upCmd.Parameters.Add(":DWDM", GDSDefine.DWDM);
                        _upCmd.Parameters.Add(":DES", GDSDefine.Descript);
                        _upCmd.Parameters.Add(":ICSTYPE", GDSDefine.IcsType);
                        _upCmd.Parameters.Add(":ICSPARAM", GDSDefine.CallParamDefine);
                        _upCmd.Parameters.Add(":ICSRETURN", GDSDefine.ReturnDefine);
                        _upCmd.Parameters.Add(":TOKENTYPE", GDSDefine.TokenType);
                        _upCmd.Parameters.Add(":ICSCONFIG", GDSDefine.IcsConfig);
                        _upCmd.Parameters.Add(":ICSSTATE", GDSDefine.State);
                        _upCmd.Parameters.Add(":ID", GDSDefine.ID);
                        _upCmd.ExecuteNonQuery();

                    }
                    else
                    {
                        OracleCommand _insCmd = new OracleCommand(SQL_InsertGDSDefine, cn);
                        _insCmd.Parameters.Add(":ID", GDSDefine.ID);
                        _insCmd.Parameters.Add(":ICSNAME", GDSDefine.CommandName);
                        _insCmd.Parameters.Add(":DWDM", GDSDefine.DWDM);
                        _insCmd.Parameters.Add(":DES", GDSDefine.Descript);
                        _insCmd.Parameters.Add(":ICSTYPE", GDSDefine.IcsType);
                        _insCmd.Parameters.Add(":ICSPARAM", GDSDefine.CallParamDefine);
                        _insCmd.Parameters.Add(":ICSRETURN", GDSDefine.ReturnDefine);
                        _insCmd.Parameters.Add(":TOKENTYPE", GDSDefine.TokenType);
                        _insCmd.Parameters.Add(":ICSCONFIG", GDSDefine.IcsConfig);
                        _insCmd.Parameters.Add(":ICSSTATE", GDSDefine.State);
                        _insCmd.ExecuteNonQuery();
                    }
                    _txn.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    string _err = string.Format("保存通用接口定义信息{0}时发生错误:{1}", GDSDefine.ID, ex.Message);
                    OralceLogWriter.WriteSystemLog(_err, "ERROR");
                    _txn.Rollback();
                    return false;
                }
            }
        }

        private const string SQL_DelGDSDefine = @"delete md_icsdefine where ID=:ID";
        public bool DelGDSDefine(string GDSDefineID)
        {
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                OracleTransaction _txn = cn.BeginTransaction();
                try
                {
                    OracleCommand _cmd = new OracleCommand(SQL_DelGDSDefine, cn);
                    _cmd.Parameters.Add(":ID", GDSDefineID);
                    _cmd.ExecuteNonQuery();
                    _txn.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    string _err = string.Format("删除通用接口定义信息{0}时发生错误:{1}", GDSDefineID, ex.Message);
                    OralceLogWriter.WriteSystemLog(_err, "ERROR");
                    _txn.Rollback();
                    return false;
                }
            }
        }

        private const string SQL_GetTokenRecord = @"select ID,COMMANDNAME,REMOTEIP,TOKENDATA from xt_icsqx where COMMANDNAME=:COMMANDNAME";
        public List<GDSTokenRecord> GetTokenRecord(string GDSCommandName)
        {
            List<GDSTokenRecord> _ret = new List<GDSTokenRecord>();
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                OracleCommand _cmd = new OracleCommand(SQL_GetTokenRecord, cn);
                _cmd.Parameters.Add(":COMMANDNAME", GDSCommandName);
                OracleDataReader dr = _cmd.ExecuteReader();
                while (dr.Read())
                {
                    GDSTokenRecord _gd = new GDSTokenRecord();
                    _gd.ID = dr.IsDBNull(0) ? "" : dr.GetString(0);
                    _gd.CommandName = dr.IsDBNull(1) ? "" : dr.GetString(1);
                    _gd.RemoteIP = dr.IsDBNull(2) ? "" : dr.GetString(2);
                    _gd.TokenData = dr.IsDBNull(3) ? "" : dr.GetString(3);
                    _ret.Add(_gd);
                }
                dr.Close();
                return _ret;
            }
        }

        private const string SQL_InsertTokenRecord = @"insert into xt_icsqx (ID,COMMANDNAME,REMOTEIP,TOKENDATA) values (:ID,:COMMANDNAME,:REMOTEIP,:TOKENDATA)";
        public bool InsertICSTokenRecord(GDSTokenRecord Record)
        {
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                OracleTransaction _txn = cn.BeginTransaction();
                try
                {
                    OracleCommand _cmd = new OracleCommand(SQL_InsertTokenRecord, cn);
                    _cmd.Parameters.Add(":ID", Record.ID);
                    _cmd.Parameters.Add(":COMMANDNAME", Record.CommandName);
                    _cmd.Parameters.Add(":REMOTEIP", Record.RemoteIP);
                    _cmd.Parameters.Add(":TOKENDATA", Record.TokenData);
                    _cmd.ExecuteNonQuery();
                    _txn.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    string _err = string.Format("添加通用接口令牌信息{0}时发生错误:{1}", Record.RemoteIP, ex.Message);
                    OralceLogWriter.WriteSystemLog(_err, "ERROR");
                    _txn.Rollback();
                    return false;
                }
            }
        }

        private const string SQL_UpdateICSTokenRecord = @"update  xt_icsqx set TOKENDATA = :TOKENDATA WHERE id=:ID";
        public bool UpdateICSTokenRecord(GDSTokenRecord Record)
        {
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                OracleTransaction _txn = cn.BeginTransaction();
                try
                {
                    OracleCommand _cmd = new OracleCommand(SQL_UpdateICSTokenRecord, cn);
                    _cmd.Parameters.Add(":TOKENDATA", Record.TokenData);
                    _cmd.Parameters.Add(":ID", Record.ID);
                    _cmd.ExecuteNonQuery();
                    _txn.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    string _err = string.Format("修改通用接口令牌信息{0}时发生错误:{1}", Record.RemoteIP, ex.Message);
                    throw new Exception(_err);
                }
            }
        }

        private const string SQL_DelICSTokenRecord = @"Delete from xt_icsqx where id=:ID";
        public bool DelICSTokenRecord(string RecordID)
        {
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                OracleTransaction _txn = cn.BeginTransaction();
                try
                {
                    OracleCommand _cmd = new OracleCommand(SQL_DelICSTokenRecord, cn);
                    _cmd.Parameters.Add(":ID", RecordID);
                    _cmd.ExecuteNonQuery();
                    _txn.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    string _err = string.Format("删除通用接口令牌信息{0}时发生错误:{1}", RecordID, ex.Message);
                    throw new Exception(_err);
                }
            }
        }

        private const string SQL_GetICSLogRecord = @" select * from (
                                                    select log.id,log.sj,log.icstype,log.srcip,log.logmsg,log.callresult,log.callparam,logex.callreturn from xt_icslog log,xt_icslog_ex logex
                                                    where log.id=logex.id and log.icstype=:TYPENAME order by sj desc
                                                    ) where rownum<=:ROWCOUNT";
        public DataTable GetICSLogRecord(string CommandName, decimal RowCount)
        {

            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                OracleTransaction _txn = cn.BeginTransaction();
                try
                {
                    OracleParameter[] _param = {  new OracleParameter(":TYPENAME",OracleDbType.Varchar2),
                                          new OracleParameter(":ROWCOUNT", OracleDbType.Decimal)   };
                    _param[0].Value = "JSGDS_" + CommandName;
                    _param[1].Value = RowCount;
                    DataTable _dt = OracleHelper.FillDataTable(cn, CommandType.Text, SQL_GetICSLogRecord, _param);
                    return _dt;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

        }
    }
}
