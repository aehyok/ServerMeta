using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SinoSystemWatch.Base.WatchNode;
using SinoSystemWatch.Base.SystemCheck;
using SinoSystemWatch.Base.WinServiceCheck;
using System.Configuration;
using System.ServiceProcess;
using System.Web.Script.Serialization;

namespace SinoSysWatchService.System.WinService
{
    public class WinServiceCheck : ICheckProject
    {
        public int Check(ref string json)
        {
            List<WinServiceStatus> WinServicesInfo = CheckWinService();
            int _ret = CheckError(WinServicesInfo);
            var jser = new JavaScriptSerializer();
            //序列化
            json = jser.Serialize(WinServicesInfo);

            //反序列化
            //EntryHeadExtend = jser.Deserialize<ICS_ENTRY_HEAD_EXTEND>(json);

            //判断处于错误状态还是警告状态

            return _ret;
        }

        private int CheckError(List<WinServiceStatus> WinServicesInfo)
        {
            int _ret = 0;
            foreach (WinServiceStatus _wss in WinServicesInfo)
            {
                _ret = Math.Max(_ret, _wss.Flag);
            }
            return _ret;
        }

        private List<WinServiceStatus> CheckWinService()
        {
            List<WinServiceStatus> _list = new List<WinServiceStatus>();
            CheckWinServiceConfigSection WinServiceList = (CheckWinServiceConfigSection)ConfigurationManager.GetSection("CheckWinServiceList");
            foreach (CheckWinServiceConfigurationElement _el in WinServiceList.PluginCollection)
            {
                WinServiceStatus _wss = new WinServiceStatus();
                _wss.ServiceName = _el.Name;
                _wss.Description = _el.Description;
                CheckWinServiceStatus(_wss);
                _list.Add(_wss);
            }
            return _list;

        }

        /// <summary>
        ///  取Win服务的状态,其中Flag: 0:未知 1:正常运行 3：停止或错误或其它或未安装此服务
        /// </summary>
        /// <param name="_wss"></param>
        private void CheckWinServiceStatus(WinServiceStatus _wss)
        {
            ServiceController _sc = new ServiceController(_wss.ServiceName);
            try
            {
                ServiceControllerStatus st = _sc.Status;
                _wss.Status = st.ToString();
                switch (st)
                {
                    case ServiceControllerStatus.Running:
                        _wss.Flag = 1;
                        break;
                    case ServiceControllerStatus.Stopped:
                        _wss.Flag = 3;
                        break;
                    default:
                        _wss.Flag = 3;
                        break;
                }
            }
            catch (Exception ex)
            {
                _wss.Status = ex.Message;
                _wss.Flag = 3;
            }
        }
    }
}
