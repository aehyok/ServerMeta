using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SinoSystemWatch.Base.WatchNode;

namespace SinoSystemWatch.InfoShow
{
    public class InfoShowLib
    {
        public static IInfoShow CreateInterface(CheckInfoResult InfoResult)
        {
            switch (InfoResult.CheckProjectName)
            {
                case "WinServiceCheck":
                    return new InfoShow_WinServiceCheck();

                case "HardDiskSpaceCheck":
                    return new InfoShow_HDSpaceCheck();

                case "OracleConnectCheck":
                    return new InfoShow_DatabaseCheck();

                case "WCFStatusCheck":
                    return new InfoShow_WCFServiceCheck();

                case "IISLogCheck":
                    return new InfoShow_IISLogCheck();

                case "SystemLogCheck":
                    return new InfoShow_SystemLogCheck();

                case "UserLogCheck":
                    return new InfoShow_SystemLogCheck();

                case "QueryLogCheck":
                    return new InfoShow_SystemLogCheck();

                case "SystemTaskCheck":
                    return new InfoShow_TaskCheck();

                default:
                    return new InfoShowBase();
            }

        }
    }
}
