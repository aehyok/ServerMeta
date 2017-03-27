using System;
using System.Collections.Generic;
using System.Text;
using SinoSZPluginFramework.ServerPlugin;
using SinoSZJS.Base.Misc;
using SinoSZJS.Base.Authorize;
using System.Configuration;
using System.Reflection;
using System.Linq;
using SinoSZClientBase.CommonService;

namespace SinoSZJS.Base.RefCode
{
    public static class RefCodeManager
    {
        //public static SinoSZClientBase.CommonService.CommonServiceClient IRefCode
        //{
        //    get
        //    {
        //        return new SinoSZClientBase.CommonService.CommonServiceClient();
        //    }


        //}

        private static RefCodeTableSet _refTableCache = new RefCodeTableSet();

        public static RefCodeTable GetRefTable(string _tanme)
        {
            if (_tanme == "") return null;
            if (!_refTableCache.RefTables.ContainsKey(_tanme))
            {
                //加载代码表
                RefCodeTable _rtable = new RefCodeTable();
                using (CommonServiceClient _csc = new CommonServiceClient())
                {
                    _rtable.Properties = _csc.GetRefCodePropertie(_tanme);
                }

                _refTableCache.RefTables.Add(_tanme, _rtable);
            }
            return _refTableCache.RefTables[_tanme];

        }

        private static void LoadCode(ref RefCodeTable _rtable)
        {
            if (_rtable.Properties.LevelDownloadMode == 1)
            {
                //一次性下载全部代码
                using (CommonServiceClient _csc = new CommonServiceClient())
                {
                    _rtable.CodeData = _csc.GetFullRefCodeData(_rtable.Name).ToList<RefCodeData>();
                }
            }
            else
            {
                //分级下载代码
            }
        }



        public static List<RefCodeData> GetChildLevelRecords(RefCodeTable _rct, string _fatherCode)
        {
            List<RefCodeData> _ret = new List<RefCodeData>();
            foreach (RefCodeData _data in _rct.CodeData)
            {
                if (_data.FatherCode == _fatherCode)
                {
                    _ret.Add(_data);
                }
            }

            return _ret;
        }

        public static bool GetAllRecords(RefCodeTable _rct)
        {
            LoadCode(ref _rct);
            return true;
        }

        public static List<RefCodeData> GetLevelDownChildRecords(RefCodeTable _rct, string _fatherCode)
        {
            if (_rct.LevelCodeData.ContainsKey(_fatherCode))
            {
                return _rct.LevelCodeData[_fatherCode];
            }
            else
            {
                using (CommonServiceClient _csc = new CommonServiceClient())
                {
                    List<RefCodeData> _getChildData = _csc.GetChildRefCodeData(_rct.Name, _fatherCode).ToList<RefCodeData>();
                    _rct.LevelCodeData.Add(_fatherCode, _getChildData);
                    return _getChildData;
                }
            }
        }

        public static object GetFullDisplay(RefCodeData _codeItem)
        {
            return string.Format("[{0}] {1}", _codeItem.Code, _codeItem.DisplayTitle);
        }
    }
}
