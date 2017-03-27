using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceProcess;
using SinoSZJS.Base.Misc;

namespace SinoSZServerBase
{
        public class OracleService
        {
                public static bool IsStart()
                {
                        string _OracleServiceName = ConfigFile.OracleServiceName;
                        if (_OracleServiceName == "") return true;
                        ServiceController _oracleService =null;
                        foreach (ServiceController _sc in ServiceController.GetDevices())
                        {
                                if (_sc.DisplayName == _OracleServiceName)
                                {
                                        _oracleService = _sc;
                                }
                        }

                        if (_oracleService != null)
                        {
                                _oracleService.WaitForStatus(ServiceControllerStatus.Running,new TimeSpan(0,20,0));
                        }

                        return true;
                }
        }
}
