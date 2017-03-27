using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars;

namespace SinoSZPluginFramework
{
        public class MenuService : IMenuService
        {
                public static int PicWidth = -1;
                public static FrmMenuItem LastClickMenu = null;
                protected IApplication application = null;
                protected Dictionary<String, FrmMenuPage> MainMenuPages = new Dictionary<string, FrmMenuPage>();

                public MenuService(IApplication application)
                {
                        this.application = application;
                }



                #region 私有属性
                protected RibbonPageCollection CurrentPageCategorys
                {
                        get
                        {
                                if (this.application == null) return null;
                                if (this.application.MainRibbon == null) return null;
                                if (this.application.MainRibbon.PageCategories[0] == null) return null;
                                return this.application.MainRibbon.Pages;

                        }
                }


                #endregion

                #region 私有方法

                protected void _menuitem_ItemClick(object sender, ItemClickEventArgs e)
                {
                        BarItem _bi = e.Item;
                        if (_bi.Tag is FrmMenuItem)
                        {
                                FrmMenuItem _mi = _bi.Tag as FrmMenuItem;
                                if (_mi.MenuCommand != null)
                                {
                                        MenuCommandDefine _cd = _mi.MenuCommand;
                                        LastClickMenu = _mi;
                                        _cd.RunCommand(_mi.MenuID);
                                }
                        }

                }

                #endregion

                #region IMenuService Members

                public void AddMainMenuPage(FrmMenuPage menuPage)
                {
                        string pageName = menuPage.PageName;
                        if (MainMenuPages.ContainsKey(pageName))
                        {
                                MessageBox.Show(string.Format("菜单页{0}已经存在!", pageName));
                        }
                        else
                        {

                                RibbonPage _rp = new RibbonPage();
                                _rp.Name = menuPage.PageName;
                                _rp.Text = menuPage.PageTitle;

                                MainMenuPages[pageName] = menuPage;
                                RibbonControl mainMenu = application.MainRibbon;
                                if (mainMenu != null)
                                {
                                        if (!mainMenu.Pages.Contains(_rp))
                                        {
                                                mainMenu.Pages.Add(_rp);
                                                menuPage.Tag = _rp;
                                        }
                                }
                        }
                }

                public void AddMenuGroup(FrmMenuPage menuPage, FrmMenuGroup menuGroup)
                {
                        RibbonControl mainMenu = application.MainRibbon;
                        if (MainMenuPages[menuPage.PageName] == null) return;

                        if (mainMenu != null)
                        {
                                if (menuPage.Tag is RibbonPage)
                                {
                                        RibbonPage _rPage = menuPage.Tag as RibbonPage;
                                        RibbonPageGroup _menuGroup = new RibbonPageGroup();
                                        _menuGroup.Name = menuGroup.GroupName;
                                        _menuGroup.Text = menuGroup.DisplayTitle;
                                        _rPage.Groups.Add(_menuGroup);
                                        menuGroup.Tag = _menuGroup;
                                }
                                else
                                {
                                        MessageBox.Show(string.Format("菜单页{0}不存在!", menuPage.PageName));
                                }
                        }

                }

                public void AddMenuItem(FrmMenuPage menuPage, FrmMenuGroup menuGroup, FrmMenuItem menuItem)
                {
                        RibbonControl mainMenu = application.MainRibbon;
                        if (MainMenuPages[menuPage.PageName] == null) return;

                        if (mainMenu != null)
                        {
                                if (menuGroup.Tag is RibbonPageGroup)
                                {
                                        RibbonPageGroup _mGroup = menuGroup.Tag as RibbonPageGroup;

                                        BarItem _menuitem = new BarButtonItem();
                                        _menuitem.Caption = menuItem.MenuTitle;
                                        _menuitem.Tag = menuItem;
                                        _menuitem.LargeGlyph = menuItem.MenuIcon;
                                        _menuitem.Glyph = menuItem.MenuIcon;
                                        _menuitem.ItemClick += new ItemClickEventHandler(_menuitem_ItemClick);
                                        _menuitem.LargeWidth = (PicWidth == -1) ? menuItem.MenuPicWidth : PicWidth;
                                        _mGroup.ItemLinks.Add(_menuitem);

                                }
                                else
                                {
                                        MessageBox.Show(string.Format("菜单页{0}不存在!", menuPage.PageName));
                                }
                        }

                }

                public void AddMenuItem(FrmMenuGroup menuGroup, FrmMenuItem menuItem)
                {
                        RibbonControl mainMenu = application.MainRibbon;

                        if (mainMenu != null)
                        {
                                if (menuGroup.Tag is RibbonPageGroup)
                                {
                                        RibbonPageGroup _mGroup = menuGroup.Tag as RibbonPageGroup;

                                        BarItem _menuitem = new BarButtonItem();
                                        _menuitem.Caption = menuItem.MenuTitle;
                                        _menuitem.Tag = menuItem;
                                        _menuitem.LargeGlyph = menuItem.MenuIcon;
                                        _menuitem.Glyph = menuItem.MenuIcon;
                                        _menuitem.ItemClick += new ItemClickEventHandler(_menuitem_ItemClick);
                                        _menuitem.LargeWidth = (PicWidth == -1) ? menuItem.MenuPicWidth : PicWidth;
                                        _mGroup.ItemLinks.Add(_menuitem);
                                       
                                }
                                else
                                {
                                        MessageBox.Show(string.Format("菜单组{0}不存在!", menuGroup.GroupName));
                                }
                        }
                }



                public void RemoveMenuItem(FrmMenuPage menuPage, FrmMenuGroup menuGroup, FrmMenuItem menuItem)
                {
                        RibbonControl mainMenu = application.MainRibbon;
                        if (MainMenuPages[menuPage.PageName] == null) return;

                        if (mainMenu != null)
                        {
                                if (menuGroup.Tag is RibbonPageGroup)
                                {
                                        RibbonPageGroup _mGroup = menuGroup.Tag as RibbonPageGroup;
                                        {
                                                foreach (BarItemLink _mi in _mGroup.ItemLinks)
                                                {
                                                        if (_mi.Caption == menuItem.MenuTitle)
                                                        {
                                                                _mGroup.ItemLinks.Remove(_mi);
                                                                break;
                                                        }
                                                }

                                        }
                                }
                                else
                                {
                                        MessageBox.Show(string.Format("菜单页{0}不存在!", menuPage.PageName));
                                }
                        }

                }

                public void RemoveMenuGroup(FrmMenuPage menuPage, FrmMenuGroup menuGroup)
                {
                        RibbonControl mainMenu = application.MainRibbon;
                        if (MainMenuPages[menuPage.PageName] == null) return;

                        if (mainMenu != null)
                        {
                                if (menuPage.Tag is RibbonPage)
                                {
                                        RibbonPage _rPage = menuPage.Tag as RibbonPage;
                                        RibbonPageGroup _mGroup = null;
                                        foreach (RibbonPageGroup _rg in _rPage.Groups)
                                        {
                                                if (_rg.Name == menuGroup.GroupName)
                                                {
                                                        _mGroup = _rg;
                                                        break;
                                                }
                                        }

                                        if (_mGroup != null)
                                        {
                                                _rPage.Groups.Remove(_mGroup);
                                        }
                                }
                                else
                                {
                                        MessageBox.Show(string.Format("菜单页{0}不存在!", menuPage.PageName));
                                }
                        }
                }

                public void RemoveMainMenuPage(string pageName)
                {
                        if (!MainMenuPages.ContainsKey(pageName))
                        {
                                MessageBox.Show(string.Format("菜单页{0}不存在!", pageName));
                        }
                        else
                        {
                                FrmMenuPage _menuPage = MainMenuPages[pageName];
                                if (_menuPage.Tag is RibbonPage)
                                {
                                        RibbonPage _rp = _menuPage.Tag as RibbonPage;
                                        RibbonControl mainMenu = application.MainRibbon;
                                        if (mainMenu != null)
                                        {
                                                mainMenu.Pages.Remove(_rp);
                                                MainMenuPages.Remove(pageName);
                                        }
                                }
                        }

                }

                #endregion





                #region IMenuService Members



                #endregion
        }
}
