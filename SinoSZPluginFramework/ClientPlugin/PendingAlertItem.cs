using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZPluginFramework.ClientPlugin
{
        [Serializable]
        public class PendingAlertItem
        {
                private string id = "";
                private string yjnr = "";
                private string yjlx = "";
                private string yjzt = "";
                private DateTime yjsj = DateTime.Now;

                public string ID { get { return id; } set { id = value; } }
                public string YJNR { get { return yjnr; } set { yjnr = value; } }
                public string YJLX { get { return yjlx; } set { yjlx = value; } }
                public string YJZT { get { return yjzt; } set { yjzt = value; } }
                public DateTime YJSJ { get { return yjsj; } set { yjsj = value; } }

                public PendingAlertItem() { }
                public PendingAlertItem(string _id, string _nr, string _lx, string _zt, DateTime _sj)
                {
                        ID = _id;
                        YJNR = _nr;
                        YJLX = _lx;
                        YJZT = _zt;
                        YJSJ = _sj;
                }
        }
}
