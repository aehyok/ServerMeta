using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SinoSystemWatch.Base.WatchNode;
using SinoSystemWatch.Base.WebApp;
using System.Web.Script.Serialization;
using System.Configuration;
using System.IO;
using SinoSZJS.Base.Misc;
using System.IO.Compression;
using SinoSystemWatch.Base.WCF;

namespace SinoSysWatchService.Application.IISLog
{
    public class IISLogCheck : ICheckProject
    {
        private int UrlIndex = -1;
        private int ReturnIndex = -1;
        private int TimeTakenIndex = -1;
        private int WebExcuteWarningTime = 600000; //web响应用时超长警告
        private List<string> BlockedList = new List<string>();
        public int Check(ref string json)
        {
            BlockedList = LoadIISBlockedList();

            List<IISLogRecordItem> WcfInfo = GetIISErrors();
            int _ret = CheckError(WcfInfo);
            var jser = new JavaScriptSerializer();
            //序列化
            json = jser.Serialize(WcfInfo);

            return _ret;

        }

        //加载屏蔽表
        private List<string> LoadIISBlockedList()
        {
            string nextLine;
            List<string> _ret = new List<string>();
            string blockedListfn = Utils.ExeDir + "IISBlockedList.dat";
            if (File.Exists(blockedListfn))
            {
                using (FileStream fs = new FileStream(blockedListfn, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    using (StreamReader sr = new StreamReader(fs, System.Text.Encoding.Default))
                    {
                        while ((nextLine = sr.ReadLine()) != null)
                        {
                            if (!_ret.Contains(nextLine)) _ret.Add(nextLine);
                        }
                        sr.Close();
                    }
                    fs.Close();
                }
            }
            return _ret;
        }

        private int CheckError(List<IISLogRecordItem> IISList)
        {

            var returnerror = from _item in IISList
                              where _item.ReturnType >= 400 && _item.ReturnType <= 600
                              select _item;

            if (returnerror.Count() > 0) return 3;

            var returnwarning = from _item in IISList
                                where (_item.ReturnType >= 300 && _item.ReturnType < 400) || _item.ReturnType >= 900
                                select _item;

            if (returnwarning.Count() > 0) return 2;
            return 1;
        }

        private const long BUFFER_SIZE = 20480;
        public byte[] GetLogData(string GetLogType)
        {
            byte[] _retbytes;
            string nextLine;
            if (BlockedList.Count() < 1) BlockedList = LoadIISBlockedList();

            string _tempfile = Utils.ExeDir + "GetIISLogTemp.temp";
            FileInfo _tfile = new FileInfo(_tempfile);
            StreamWriter _sb = _tfile.CreateText();

            try
            {
                DateTime _dt = DateTime.Now.Date;
                string _path = ConfigurationManager.AppSettings["IISLogPath"];

                #region 获取文件列表信息
                List<FileInfo> files = new List<FileInfo>();

                foreach (var file in Directory.GetFiles(_path, "*.log", SearchOption.AllDirectories))
                {
                    files.Add(new FileInfo(file));
                }

                ///查询两日内文件列表信息
                var filevalues = from file in files
                                 where file.Extension.ToLower() == ".log" && file.LastWriteTime > _dt.AddDays(-1)
                                 orderby file.Name
                                 select file;
                #endregion

                if (filevalues.Count() < 1)
                {
                    //两日内无日志
                    throw new Exception("两日内无IIS日志文件！");
                }
                else
                {

                    foreach (var f in filevalues)
                    {
                        using (FileStream fs = new FileStream(f.FullName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                        {
                            using (StreamReader sr = new StreamReader(fs, System.Text.Encoding.Default))
                            {
                                while ((nextLine = sr.ReadLine()) != null)
                                {
                                    int _timetaken = 0;
                                    string _urlstring = "";
                                    int _type = PharseIISLine(nextLine, ref _timetaken, ref _urlstring);
                                    if (!BlockedList.Contains(_urlstring))
                                    {
                                        #region 判别行类型，按要求写入文件
                                        if (_type < 0)
                                        {
                                            //标识行                                            
                                            _sb.WriteLine(nextLine);

                                        }
                                        else if (_type > 0 && _type < 300 && GetLogType == "ALL")
                                        {
                                            _sb.WriteLine(nextLine);
                                        }
                                        else if (_type >= 300 && _type < 400 && GetLogType != "ERROR")
                                        {
                                            _sb.WriteLine(nextLine);
                                        }
                                        else
                                        {
                                            _sb.WriteLine(nextLine);
                                        }
                                        #endregion
                                    }

                                }
                                sr.Close();
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                //写本地临时文件
                _sb.WriteLine(ex.Message);
            }
            _sb.Close();

            //压缩字节并返回
            FileStream sourceFile = File.OpenRead(_tempfile);
            using (MemoryStream _ms = new MemoryStream())
            {
                GZipStream compStream = new GZipStream(_ms, CompressionMode.Compress);

                try
                {
                    int theByte = sourceFile.ReadByte();
                    while (theByte != -1)
                    {
                        compStream.WriteByte((byte)theByte);
                        theByte = sourceFile.ReadByte();
                    }
                }
                finally
                {
                    compStream.Dispose();
                }
                sourceFile.Close();
                compStream.Close();
                _retbytes = _ms.ToArray();


            }
            if (File.Exists(_tempfile)) File.Delete(_tempfile);

            return _retbytes;
        }


        private List<IISLogRecordItem> GetIISErrors()
        {
            string nextLine;
            List<IISLogRecordItem> _ret = new List<IISLogRecordItem>();
            DateTime _dt = DateTime.Now.Date;
            string _path = ConfigurationManager.AppSettings["IISLogPath"];
            try
            {
                WebExcuteWarningTime = int.Parse(ConfigurationManager.AppSettings["WebExcuteWarningTime"]);
            }
            catch
            {
                WebExcuteWarningTime = 600000;
            }
            if (_path != null && _path != string.Empty)
            {
                List<FileInfo> files = new List<FileInfo>();
                ///获取文件列表信息
                foreach (var file in Directory.GetFiles(_path, "*.log", SearchOption.AllDirectories))
                {
                    files.Add(new FileInfo(file));
                }

                ///查询两日内文件列表信息
                var filevalues = from file in files
                                 where file.Extension.ToLower() == ".log" && file.LastWriteTime > _dt.AddDays(-1)
                                 orderby file.Name
                                 select file;
                if (filevalues.Count() < 1)
                {
                    //两日内无日志
                    IISLogRecordItem _i1 = new IISLogRecordItem();
                    _i1.RecordNum = 1; //1表示2日内无访问
                    _i1.ReturnType = 0;

                    _ret.Add(_i1);
                }
                else
                {
                    ///统计执行情况
                    Dictionary<int, int> _dict = new Dictionary<int, int>();
                    foreach (var f in filevalues)
                    {
                        using (FileStream fs = new FileStream(f.FullName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                        {
                            using (StreamReader sr = new StreamReader(fs, System.Text.Encoding.Default))
                            {
                                while ((nextLine = sr.ReadLine()) != null)
                                {
                                    int _timetaken = 0;
                                    string _urlstring = "";
                                    int _type = PharseIISLine(nextLine, ref _timetaken, ref _urlstring);
                                    if (!BlockedList.Contains(_urlstring))
                                    {
                                        if (_type > 0)
                                        {
                                            #region 返回码记录
                                            if (_dict.ContainsKey(_type))
                                            {
                                                _dict[_type] += 1;
                                            }
                                            else
                                            {
                                                _dict.Add(_type, 1);
                                            }
                                            #endregion

                                            #region Web响应超长记录
                                            if (_timetaken > WebExcuteWarningTime)
                                            {
                                                if (_dict.ContainsKey(902))
                                                {
                                                    _dict[902] += 1;
                                                }
                                                else
                                                {
                                                    _dict.Add(902, 1);
                                                }
                                            }
                                            #endregion
                                        }
                                    }
                                }

                                sr.Close();
                            }
                        }
                    }

                    //生成检查结果项
                    foreach (int _t in _dict.Keys)
                    {
                        IISLogRecordItem _item = new IISLogRecordItem();
                        _item.RecordNum = _dict[_t]; //1表示2日内无访问
                        _item.ReturnType = _t;
                        _ret.Add(_item);
                    }
                }
            }
            return _ret;
        }

        /// <summary>
        /// 分析日志记录 主要分析返回码 和响应时长 
        /// 扩展返回码
        ///   1：2日内无访问
        ///   901：日志行解析错误或格式不对
        /// </summary>
        /// <param name="nextLine"></param>
        /// <returns></returns>
        private int PharseIISLine(string nextLine, ref int timeTaken, ref string UrlString)
        {
            timeTaken = 0;
            UrlString = "";
            if (nextLine.Length < 1) return -1;

            #region 处理日志标头
            if (nextLine.StartsWith("#"))
            {
                PharseHeader(nextLine);
                return -1;
            }
            #endregion


            string[] _strs = nextLine.Split(' ');
            if (_strs.Length < 4) return -1;

            int _len = _strs.Length;

            #region 处理日志中的响应时长
            if (_len > TimeTakenIndex)
            {
                try
                {
                    timeTaken = int.Parse(_strs[TimeTakenIndex]);
                }
                catch
                {
                    //格式错
                    timeTaken = 0;
                    return 901;
                }
            }
            else
            {
                //格式错
                timeTaken = 0;
                return 901;
            }
            #endregion

            #region 处理返回码
            if (_len > ReturnIndex)
            {
                try
                {
                    int _returncode = int.Parse(_strs[ReturnIndex]);
                    UrlString = _strs[UrlIndex];
                    return _returncode;
                }
                catch
                {
                    //格式错
                    return 901;
                }

            }
            else
            {
                //格式错
                return 901;
            }

            #endregion
        }

        private void PharseHeader(string nextLine)
        {
            if (nextLine.StartsWith("#Fields:"))
            {
                string[] _strs = nextLine.Split(' ');
                int _len = _strs.Length;
                for (int i = 0; i < _len; i++)
                {
                    switch (_strs[i])
                    {
                        case "sc-status":
                            ReturnIndex = i - 1;
                            break;
                        case "time-taken":
                            TimeTakenIndex = i - 1;
                            break;
                        case "cs-uri-stem":
                            UrlIndex = i - 1;
                            break;
                    }
                }
            }
        }
    }
}
