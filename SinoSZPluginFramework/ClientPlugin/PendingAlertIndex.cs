using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZPluginFramework.ClientPlugin
{
        public class PendingAlertIndex
        {
                private string gname = "";
                private int itemCount = 0;
                private IPendingAlert icsAlert = null;

                public IPendingAlert ICS_Alert { get { return icsAlert; } set { icsAlert = value; } }

                public string GroupName
                {
                        get { return gname; }
                        set { gname = value; }
                }
                public int Count { get { return itemCount; } set { itemCount = value; } }

                public PendingAlertIndex(string groupName, int count, IPendingAlert ics)
                {
                        GroupName = groupName;
                        Count = count;
                        ICS_Alert = ics;
                }

        }
}
