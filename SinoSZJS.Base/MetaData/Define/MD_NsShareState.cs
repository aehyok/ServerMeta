using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZJS.Base.MetaData.Define
{
        /// <summary>
        /// 命名空间共享状态列表
        /// </summary>
        public class MD_NsShareState
        {
                private string nameSpace = "";
                private string description = "";
                private string state = "";

                public string NameSpace
                {
                        get { return nameSpace; }
                        set { nameSpace = value; }
                }

                public string Description
                {
                        get { return description; }
                        set { description = value; }
                }


                public string State
                {
                        get { return state; }
                        set { state = value; }
                }

                public MD_NsShareState() { }

                public MD_NsShareState(string _ns, string _des, string _state)
                {
                        NameSpace = _ns;
                        Description = _des;
                        State = _state;
                }
        }
}
