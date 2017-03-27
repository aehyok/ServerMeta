using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZJS.Base.SystemInterface
{
        public class SystemICS_SJJH_Node
        {
                private string id = "";
                private string displayName = "";
                private string lx = "";
                private string fatherId = "";
                private string userName = "";
                private int xh = 0;
                public SystemICS_SJJH_Node(string _id, string _fid, string _displayName, string _userName, string _lx,int _xh)
                {
                        id = _id;
                        fatherId = _fid;
                        displayName = _displayName;
                        lx = _lx;
                        userName = _userName;
                        xh = _xh;
                }

                /// <summary>
                /// 序号
                /// </summary>
                public int XH
                {
                        get { return xh; }
                        set { xh = value; }
                }

                /// <summary>
                /// 用户名
                /// </summary>
                public string UserName
                {
                        get { return userName; }
                        set { userName = value; }
                }



                /// <summary>
                /// ID
                /// </summary>
                public string ID
                {
                        get { return id; }
                        set { id = value; }
                }
                /// <summary>
                /// 父ID
                /// </summary>
                public string FatherID
                {
                        get { return fatherId; }
                        set { fatherId = value; }
                }
                /// <summary>
                /// 显示名称
                /// </summary>
                public string DisplayName
                {
                        get { return displayName; }
                        set { displayName = value; }
                }

                /// <summary>
                /// 类型： 机构、用户
                /// </summary>
                public string LX
                {
                        get { return lx; }
                        set { lx = value; }
                }

        }
}
