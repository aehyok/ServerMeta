using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZJS.Base.MenuType
{
        public class MenuTypeCreator
        {
                public static MenuTypeCollection CreateNewMenuTypeCollection()
                {
                        MenuTypeCollection _mtc = new MenuTypeCollection();
                        _mtc.Add(MenuTypeCreator.CreateMenuType(""));

                        //新系统菜单类型定义
                        _mtc.Add(MenuTypeCreator.CreateMenuType("综合系统_元数据管理类型"));

                        ///旧系统菜单类型定义        
                        _mtc.Add(MenuTypeCreator.CreateMenuType("系统首页类型"));
                        _mtc.Add(MenuTypeCreator.CreateMenuType("首页类型"));
                        _mtc.Add(MenuTypeCreator.CreateMenuType("缉私综合_案件浏览类型"));
                        _mtc.Add(MenuTypeCreator.CreateMenuType("缉私综合_办案监督类型"));
                        _mtc.Add(MenuTypeCreator.CreateMenuType("缉私综合_案件预警类型"));
                        _mtc.Add(MenuTypeCreator.CreateMenuType("缉私综合_违法违规档案类型"));
                        _mtc.Add(MenuTypeCreator.CreateMenuType("命名空间综合类型"));
                        _mtc.Add(MenuTypeCreator.CreateMenuType("缉私综合_统计报表类型"));
                        _mtc.Add(MenuTypeCreator.CreateMenuType("缉私综合_信息补录类型"));
                        _mtc.Add(MenuTypeCreator.CreateMenuType("缉私综合_系统管理类型"));
                        _mtc.Add(MenuTypeCreator.CreateMenuType("缉私综合_执法评估类型"));
                        _mtc.Add(MenuTypeCreator.CreateMenuType("青岛_数据维护类型"));
                        _mtc.Add(MenuTypeCreator.CreateMenuType("青岛_数据比对类型"));
                        _mtc.Add(MenuTypeCreator.CreateMenuType("青岛_数据校验类型"));
                        _mtc.Add(MenuTypeCreator.CreateMenuType("青岛_统计报表类型"));
                        _mtc.Add(MenuTypeCreator.CreateMenuType("青岛_企业信息类型"));

                   


                        return _mtc;
                }

                public static MenuTypeBase CreateMenuType(string _typename)
                {
                        switch (_typename)
                        {
                                case "":
                                        return new MenuTypeBase("", "");
                                case "首页类型":
                                        return new MTC_WebFirstPage();
                                case "系统首页类型":
                                        return new MTC_StartPage();
                                case "缉私综合_案件浏览类型":
                                        return new MTC_AJLL();
                                case "缉私综合_办案监督类型":
                                        return new MTC_BAJD();
                                case "缉私综合_案件预警类型":
                                        return new MTC_AJYJ();
                                case "缉私综合_违法违规档案类型":
                                        return new MTC_WFWGDA();
                                case "命名空间综合类型":
                                        return new MTC_NAMESPACE();
                                case "缉私综合_统计报表类型":
                                        return new MTC_REPORT();
                                case "缉私综合_信息补录类型":
                                        return new MTC_XXBL();
                                case "缉私综合_系统管理类型":
                                        return new MTC_XTGL();
                                case "缉私综合_执法评估类型":
                                        return new MTC_ZFPG();
                                case "青岛_数据维护类型":
                                        return new MTC_QD_SJWH();
                                case "青岛_数据比对类型":
                                        return new MTC_QD_SJBD();
                                case "青岛_数据校验类型":
                                        return new MTC_QD_SJJY();
                                case "青岛_统计报表类型":
                                        return new MTC_QD_TJBB();
                                case "青岛_企业信息类型":
                                        return new MTC_QD_QYXX();
                                case "综合系统_元数据管理类型":
                                        return new SinoMTC_MetaDataManager();

                        }

                        return new MenuTypeBase("", "");

                }
        }
}
