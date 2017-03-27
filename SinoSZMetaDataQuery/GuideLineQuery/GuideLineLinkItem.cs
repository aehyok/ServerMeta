using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZMetaDataQuery.GuideLineQuery
{
        public class GuideLineLinkItem
        {
                //<指标>指标ID:指标标题:组名:图标名:参数</指标>    
                public string GuideLineID = "";
                public string Title = "";
                public string GroupName = "";
                public string IconName = "";
                public string Params = "";
                public string ExtendParams = "";

                public GuideLineLinkItem(string _p)
                {
                        string[] _glStrs = _p.Split(':');
                        GuideLineID = _glStrs[0];
                        Title = (_glStrs.Length > 1) ? _glStrs[1] : GuideLineID;
                        GroupName = (_glStrs.Length > 2) ? _glStrs[2] : "";
                        IconName = (_glStrs.Length > 3) ? _glStrs[3] : "";
                        Params = (_glStrs.Length > 4) ? _glStrs[4] : "";
                        ExtendParams = (_glStrs.Length > 5) ? _glStrs[5] : "";
                }
        }
}
