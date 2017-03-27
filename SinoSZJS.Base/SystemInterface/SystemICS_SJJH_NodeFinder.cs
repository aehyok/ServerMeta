using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZJS.Base.SystemInterface
{
        public class SystemICS_SJJH_NodeFinder
        {
                private string FindStr = "";
                public SystemICS_SJJH_NodeFinder(string _findStr)
                {
                        this.FindStr = _findStr;
                }

                public bool FindByID(SystemICS_SJJH_Node _node)
                {
                        return _node.ID.ToString() == FindStr;
                }

                public bool FindByFatherID(SystemICS_SJJH_Node _node)
                {
                        return _node.FatherID.ToString() == FindStr;
                }
        }
}
