using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Localization;

namespace SinoSZClientBase
{
        public class ChinaSimpleTreeListLocalizer : DevExpress.XtraTreeList.Localization.TreeListLocalizer
        {

                public override string GetLocalizedString(DevExpress.XtraTreeList.Localization.TreeListStringId id)
                {
                        switch (id)
                        {
                                case TreeListStringId.MenuColumnBestFit: return "自动调整宽度";
                                case TreeListStringId.MenuColumnBestFitAllColumns: return "全部列自动调整宽度";
                                case TreeListStringId.MenuColumnColumnCustomization: return "自定义字段";
                                case TreeListStringId.MenuColumnSortAscending: return "升序";
                                case TreeListStringId.MenuColumnSortDescending: return "降序";
                                        
                        }
                        
                        return base.GetLocalizedString(id);
                }
               
        }
}
