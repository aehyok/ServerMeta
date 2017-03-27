using System;
using System.Collections.Generic;
using System.Text;
using SinoSZJS.Base.RefCode;
using System.Configuration;
using SinoSZPluginFramework.ServerPlugin;
using SinoSZJS.Base.Misc;
using SinoSZJS.Base.MenuType;
using SinoSZJS.Base.Authorize;

namespace SinoSZClientBase
{
        public class RefTableConfig
        {
                public static ICS_RefCode GetRefTableInterface()
                {
                        string className, profilePath;

                        string dataBaseType = ConfigurationManager.AppSettings["DataBaseType"] as string;
                        switch (dataBaseType)
                        {
                                case "ORACLE":
                                        return null;

                                case "SQLSERVER":
                                        return null;

                                //case "REMOTING":
                                //        IServiceFactory _serviceFactory = (IServiceFactory)RemotingClientSvc.GetAppSvrObj(typeof(IServiceFactory));
                                //        RemotingClientSvc.BindTicketToCallContext(SessionClass.CurrentTicket);
                                //        ICS_RefCode _ret = _serviceFactory.GetInterFace("RefTableServerPlugin") as ICS_RefCode;
                                //        return _ret;

                        }

                        return null;
                }
        }
}
