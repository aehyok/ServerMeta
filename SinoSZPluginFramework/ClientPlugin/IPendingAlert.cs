using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZPluginFramework.ClientPlugin
{
        public interface IPendingAlert
        {
                IApplication Application { get;set;}
                void ShowDetail();
                List<PendingAlertIndex> GetAlertIndex();
                List<PendingAlertItem> GetUserPendingAlertList(string zt, string cl,DateTime kssj, DateTime jssj);
        }
}
