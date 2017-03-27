using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.IO;

namespace SinoSZJS.Base.Authorize.CUPPA
{

    public class CUPPAPassportConfig
    {
        public static bool DebugMode = false;
        public static string CUPPA_Check_DebugDataPath = "";
        public static bool CUPPA_Check_WriteLog = false;
        public static string CheckObjTemp = "";
        public static string CheckViewName = "";
        public const string SQL_GetYHIDByGUID = "select ZHTJ_ZZJG2.GetYHID_From_GUID(:GUID) from dual";

        public static void WriteCUPPALog(string _logstring)
        {
            StreamWriter _fs;
            string logFileName = CUPPAPassportConfig.CUPPA_Check_DebugDataPath + "CUPPA_LOG.txt";

            if (File.Exists(logFileName))
            {
                _fs = File.AppendText(logFileName);
            }
            else
            {
                _fs = File.CreateText(logFileName);
            }
            _fs.WriteLine(string.Format("[{0}] {1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), _logstring));
            _fs.Close();
        }

        static CUPPAPassportConfig()
        {
            string _debugMode = ConfigurationManager.AppSettings["CUPPA_Check_Mode"];
            if (_debugMode != null && _debugMode.ToUpper() == "DEBUG")
            {
                DebugMode = true;
            }

            string _debugDataPath = ConfigurationManager.AppSettings["CUPPA_Check_DebugDataPath"];
            if (_debugDataPath == string.Empty || _debugDataPath == null)
            {
                CUPPA_Check_DebugDataPath = @"d:\temp\debugdata\";
            }
            else
            {
                CUPPA_Check_DebugDataPath = _debugDataPath;
            }

            string _writelog = ConfigurationManager.AppSettings["CUPPA_Check_WriteLog"];
            if (_writelog == null || _writelog == string.Empty)
            {
                CUPPA_Check_WriteLog = false;
            }
            else
            {
                _writelog = _writelog.ToUpper();
                CUPPA_Check_WriteLog = ((_writelog == "YES") || (_writelog == "Y"));
            }

            string _type = ConfigurationManager.AppSettings["CUPPA_ObjectTemp"];
            if (_type == string.Empty || _type == null)
            {
                CheckObjTemp = "windows";
            }
            else
            {
                CheckObjTemp = _type;
            }

            string _vn = ConfigurationManager.AppSettings["CUPPA_ViewName"];
            if (_vn == string.Empty || _vn == null)
            {
                CheckViewName = "JS_VIEW";
            }
            else
            {
                CheckViewName = _vn;
            }
        }
    }
}
