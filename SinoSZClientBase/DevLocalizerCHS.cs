using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Localization;
using DevExpress.XtraTreeList.Localization;

namespace SinoSZClientBase
{
        /// <summary>
        /// 中文化界面
        /// </summary>
        public class DevLocalizerCHS
        {
                /// <summary>
                /// 初始化
                /// </summary>
                public static void Init()
                {
                        DevExpress.Skins.SkinManager.EnableFormSkins();
                        ChinaSimpleLocalizer chinaSimpleLocalizer = new ChinaSimpleLocalizer();
                        Localizer.Active = chinaSimpleLocalizer;
                        ChinaSimpleGridLocalizer chinaSimpleGridLocalizer = new ChinaSimpleGridLocalizer();
                        GridLocalizer.Active = chinaSimpleGridLocalizer;
                        ChinaSimpleTreeListLocalizer chinaSimpleTreeListLocalizer = new ChinaSimpleTreeListLocalizer();
                        TreeListLocalizer.Active = chinaSimpleTreeListLocalizer;
                }
        }
}
