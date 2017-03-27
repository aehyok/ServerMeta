using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZJS.Base.SystemInterface
{
        public class SystemICS_SJJH
        {
                private string id = "";
                private string displayName = "";
                private string logonName = "";
                private string dwid = "";
                private string dwmc = "";
                private string param = "";

                public SystemICS_SJJH(string _id, string _displayName, string _logonName, string _dwid, string _dwmc, string _param)
                {
                        id = _id;
                        displayName = _displayName;
                        logonName = _logonName;
                        dwid = _dwid;
                        dwmc = _dwmc;
                        param = _param;
                }

                public string Param
                {
                        get { return param; }
                        set { param = value; }
                }

                public string ID
                {
                        get { return id; }
                        set { id = value; }
                }

                public string DisplayName
                {
                        get { return displayName; }
                        set { displayName = value; }
                }

                public string LogonName
                {
                        get { return logonName; }
                        set { logonName = value; }
                }

                public string DWID
                {
                        get { return dwid; }
                        set { dwid = value; }
                }

                public string DWMC
                {
                        get { return dwmc; }
                        set { dwmc = value; }
                }


        }
}
