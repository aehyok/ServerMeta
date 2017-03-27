using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SinoSZServerBase;
using SinoSZJS.Base.Misc;
using SinoSZJS.Base.WorkCalendar;
using Oracle.DataAccess.Client;
using SinoSZJS.DataAccess;
using System.Data;
using System.IO;
using SinoSZJS.CS.Tasks.Common;
using System.Threading;

namespace SinoSZJS.CS.Tasks.Customs.TJS
{
    public class Task_TJS : Task_Base
    {
        private WC_TJSB_Settings TJSSettings = null;
        public Task_TJS(string _rwid, string _param)
        {
            this._Rwid = _rwid;
            string _stepstr = StrUtils.GetMetaByName("STEP", _param);	//STEP: 任务时间间隔

            try
            {
                this._TimeStep = int.Parse(_stepstr);
            }
            catch
            {
                this._TimeStep = 1;
            }

            TJSSettings = GetTJSBSettings();
        }

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

        private bool RunStoreProcess(string _clny)
        {
            //执行存贮过程
            OracleCommand cmd = new OracleCommand();
            using (OracleConnection cn = OracleHelper.OpenConnection())
            {
                try
                {
                    cmd.Connection = cn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "ZHTJ_BTJS.BTJS";
                    cmd.Parameters.Add(new OracleParameter("strNY", _clny));
                    cmd.ExecuteNonQuery();//执行存储过程
                    return true;
                }
                catch (Exception e)
                {
                    string _log = string.Format("设置统计司上报数据处理存贮过程(ZHTJ_BTJS.BTJS)时出现错误：", e.Message);
                    WriteTaskLog(9, _log);
                    return false;
                }
            }

        }

        private bool CheckResult(string clny)
        {
            //检查处理结果
            try
            {
                using (OracleConnection cn = OracleHelper.OpenConnection())
                {
                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = cn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = " Select  runok from TJ_TJSOK where NY=:NY";
                    cmd.Parameters.Add(new OracleParameter(":NY", clny));
                    using (OracleDataReader myReader = cmd.ExecuteReader())
                    {
                        while (myReader.Read())
                        {
                            string _cljg = myReader.GetString(0);
                            if (_cljg.ToUpper() == "Y")
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                    return false;
                }
            }
            catch (Exception e)
            {
                string _log = string.Format("查询统计司数据上报处理结果时出现错误：", e.Message);
                this.WriteTaskLog(9, _log);
                return false;
            }
        }

        private bool CreateFileV3(string clny, string _TJSDir)
        {
            //创建上报文件
            try
            {
                if (!Directory.Exists(_TJSDir))
                {
                    Directory.CreateDirectory(_TJSDir);                   
                }

                //查看有无本日处理目录，无则创建，有则清除
                string _MainDir = _TJSDir + string.Format("\\{0}", clny);
                if (Directory.Exists(_MainDir))
                {
                    Directory.Delete(_MainDir, true);
                    Thread.Sleep(1000);
                }
                Directory.CreateDirectory(_MainDir);

                DateTime _maxDate = new DateTime(int.Parse(clny.Substring(0, 4)), int.Parse(clny.Substring(4, 2)), 1);
                _maxDate = _maxDate.AddMonths(-1);
                DateTime beginDate = _maxDate.AddMonths(-23);

                while (beginDate <= _maxDate)
                {
                    DateTime endDate = new DateTime(beginDate.Year, 12, 1);
                    if (endDate > _maxDate)
                    {
                        endDate = _maxDate;
                    }
                    string _fname = _MainDir + string.Format("\\JR0000{0}.DAT", endDate.ToString("yyyyMM"));
                    WriteFileV3(_fname, beginDate, endDate);
                    beginDate = endDate.AddMonths(1);
                }


                return true;

            }
            catch (Exception e)
            {
                string _log = string.Format("创建统计司数据上报文件时出现错误：{0}", e.Message);
                this.WriteTaskLog(9, _log);
                return false;
            }
        }



       
        private const string SQL_WriteFile = @"select zbdm||','||ny||','|| gbdm||','|| trunc(NVL(sl1,0))||','|| trunc(NVL(sl2,0))||','|| tqsj||',' ||bmdm from tj_zbjlb
                                               WHERE NY between   to_char(:dtBegin,'YYYYMM') and to_char(:dtEnd,'YYYYMM')
                                                 and exists (select zbdm from  tj_zbdm_for_tjs tjs where tjs.zbdm=tj_zbjlb.zbdm)
                                               and NY>'200512' ORDER BY ZBDM,GBDM ";
        private void WriteFileV3(string _fname, DateTime beginDate, DateTime endDate)
        {
            //生成数据文件
            StreamWriter sr = null;
            try
            {
                using (OracleConnection cn = OracleHelper.OpenConnection())
                {
                    sr = File.CreateText(_fname);

                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = cn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = SQL_WriteFile;
                    cmd.Parameters.Add(new OracleParameter(":dtBegin", beginDate));
                    cmd.Parameters.Add(new OracleParameter(":dtEnd", endDate));
                    OracleDataReader myReader = cmd.ExecuteReader();
                    while (myReader.Read())
                    {
                        sr.WriteLine(myReader.GetString(0));
                    }
                    sr.Close();
                }
            }
            catch (Exception e)
            {
                string _log = string.Format("生成统计司{0}数据文件时出现错误：{1}", _fname, e.Message);
                this.WriteTaskLog(9, _log);
                if (sr != null)
                {
                    sr.Close();
                }
            }
        }


        /// <summary>
        /// 发送文件
        /// </summary>
        /// <param name="clny"></param>
        /// <param name="_TJSDir"></param>
        /// <returns></returns>
        private bool TransFile(string clny, string _TJSDir)
        {
            string _upfile = "";
            try
            {
                //上报文件目录
                string _MainDir = _TJSDir + Path.DirectorySeparatorChar.ToString() + clny;
                if (!Directory.Exists(_MainDir))
                {
                    string _emsg = string.Format("统计司数据上报文件目录[{0}]找不到！！", _MainDir);
                    this.WriteTaskLog(9, _emsg);
                    return false;
                }

                //连接FTP              
                FtpClient _ftp = new FtpClient(this.TJSSettings.FTP_Addr, this.TJSSettings.FTP_User, this.TJSSettings.FTP_Pass, this.TJSSettings.FTP_Port);

                _ftp.RemotePath = this.TJSSettings.FTP_Path;
                //一个个文件上传
                foreach (string _fileName in Directory.GetFiles(_MainDir))
                {
                    try
                    {
                        FileInfo _fi = new FileInfo(_fileName);
                        _upfile = _fi.Name;
                        if (_ftp.CheckFileExist(_upfile))
                        {
                            _ftp.DeleteFile(_upfile);
                        }

                        _ftp.Upload(_fi, _fi.Name);
                    }
                    catch (Exception ex2)
                    {
                        throw new Exception(string.Format("上传{0}文件到{2}时失败！{1}", _fileName, ex2.Message, _upfile));
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                string _log = string.Format("传输统计司数据上报文件时出现错误：{0}\r\n ", e.Message);
                this.WriteTaskLog(9, _log);
                return false;
            }
        }


        public override DateTime GetNextTime()
        {
            DateTime _nt = this._startTime;
            OracleCommand cmd = new OracleCommand();
            try
            {
                using (OracleConnection cn = OracleHelper.OpenConnection())
                {

                    //取工作日历记录
                    cmd.Connection = cn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select GZ_DAY from GZRL where GZ_YEAR=:YEAR and GZ_MONTH=:MONTH and GZ_LX=1";
                    int _year = this._startTime.Year;
                    int _month = this._startTime.Month + 1;
                    if (_month == 13)
                    {
                        _year++;
                        _month = 1;
                    }
                    cmd.Parameters.Add(new OracleParameter(":YEAR", _year.ToString()));
                    cmd.Parameters.Add(new OracleParameter(":MONTH", _month.ToString()));
                    using (OracleDataReader myReader = cmd.ExecuteReader())
                    {
                        int _day = -1;
                        while (myReader.Read())
                        {
                            _day = int.Parse(myReader.GetString(0));
                        }
                        if (_day < 1)
                        {
                            //若工作日历记录中没有，取使用每月默认上报日
                            _day = this.TJSSettings.SBDay;
                        }
                        _nt = new DateTime(_year, _month, _day, 1, 0, 0);
                    }
                }
            }
            catch (Exception e)
            {
                string _log = string.Format("计算下一个统计日时出现错误：", e.Message);
                this.WriteTaskLog(9, _log);
                _nt = DateTime.Now;
            }
            return _nt;

        }
        /// <summary>
        /// 写任务出错结果
        /// </summary>
        /// <param name="_errorMsg"></param>
        public override void WriteErrorResult(string _errorMsg)
        {
            DateTime _nextTime = this.GetNextTime();
            SQL_TaskCommon.WriteErrorResult(_Rwid, _startTime, _nextTime, _errorMsg);
        }

        public override void ThreadProc()
        {
            WriteRWState();

            //执行存贮过程
            string _Clny = DateTime.Today.ToString("yyyyMM");
            if (!RunStoreProcess(_Clny))
            {
                string _emsg = string.Format("执行统计司数据上报[{0}]的存贮过程时出现失败。", _Clny);
                WriteErrorResult(_emsg);
                return;
            }

            //判断执行结果
            if (!CheckResult(_Clny))
            {
                //失败
                string _emsg = string.Format("统计司数据上报[{0}]的存贮过程处理结果为失败。", _Clny);
                WriteErrorResult(_emsg);
                return;
            }


            //取文件目录
            string _TJSDir = this.TJSSettings.Backup_Path;

            //查看有无上报文件目录，无则创建
            if (_TJSDir == "") _TJSDir = Utils.ExeDir + Path.DirectorySeparatorChar.ToString() + "TJS_DATA";

            //生成文件
            if (!CreateFileV3(_Clny, _TJSDir))
            {
                //失败
                string _emsg = string.Format("生成统计司数据上报文件时失败。", _Clny);
                WriteErrorResult(_emsg);
                return;
            }

            //用ftp传输文件
            if (!TransFile(_Clny, _TJSDir))
            {
                //失败
                string _emsg = string.Format("传输统计司数据上报文件时失败。", _Clny);
                WriteErrorResult(_emsg);
                return;
            }

            //写任务结果
            WriteResult();

        }
    }
}
