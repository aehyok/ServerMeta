using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace SinoSZPluginFramework
{
        public class FrmMenuItem
        {
                private string _menuTitle;
                private string _commandName;
                private Image _menuIcon;
                private int _menuPicWidth = 70;
                private bool _buttonEnable = true;
                private MenuCommandDefine _commandDefine = null;
                private List<FrmMenuItem> _childMenus = new List<FrmMenuItem>();
                private string _menuID;

                public string MenuID
                {
                        get { return _menuID; }
                        set { _menuID = value; }
                }

                public List<FrmMenuItem> ChildMenus
                {
                        get { return _childMenus; }
                        set { _childMenus = value; }
                }

                public int MenuPicWidth
                {
                        get { return this._menuPicWidth; }
                        set { this._menuPicWidth = value; }
                }

                public bool ButtonEnable
                {
                        get { return this._buttonEnable; }
                        set { this._buttonEnable = value; }
                }

                public string MenuTitle
                {
                        get { return this._menuTitle; }
                        set { this._menuTitle = value; }
                }

                public string CommandName
                {
                        get { return this._commandName; }
                        set { this._commandName = value; }
                }


                public Image MenuIcon
                {
                        get { return this._menuIcon; }
                        set { this._menuIcon = value; }
                }

                public MenuCommandDefine MenuCommand
                {
                        get
                        {
                                return this._commandDefine;
                        }
                        set
                        {
                                _commandDefine = value;
                        }
                }

                public FrmMenuItem(string _id, string _title, string _command, Image _icon)
                {
                        InitItem(_id, _title, _command, _icon, 70, true, null);
                }

                public FrmMenuItem(string _id, string _title, string _command, Image _icon, MenuCommandDefine _cdefine)
                {
                        InitItem(_id, _title, _command, _icon, 70, true, _cdefine);
                }

                public FrmMenuItem(string _title, string _command, Image _icon, bool _enabled)
                {
                        InitItem("0", _title, _command, _icon, 70, _enabled, null);
                }

                public FrmMenuItem(string _id, string _title, string _command, Image _icon, bool _enabled)
                {
                        InitItem(_id, _title, _command, _icon, 70, _enabled, null);
                }

                public FrmMenuItem(string _id, string _title, string _command, Image _icon, bool _enabled, MenuCommandDefine _cdefine)
                {
                        InitItem(_id, _title, _command, _icon, 70, _enabled, _cdefine);
                }

                public FrmMenuItem(string _title, string _command, Image _icon, int _width)
                {
                        InitItem("0", _title, _command, _icon, _width, true, null);
                }

                public FrmMenuItem(string _title, string _command, Image _icon, int _width,bool _enabled)
                {
                        InitItem("0", _title, _command, _icon, _width, _enabled, null);
                }


                public FrmMenuItem(string _id, string _title, string _command, Image _icon, int _width)
                {
                        InitItem(_id, _title, _command, _icon, _width, true, null);
                }

                public FrmMenuItem(string _title, string _command, Image _icon, int _width, MenuCommandDefine _cdefine)
                {
                        InitItem("0", _title, _command, _icon, _width, true, _cdefine);
                }

                public FrmMenuItem(string _id, string _title, string _command, Image _icon, int _width, MenuCommandDefine _cdefine)
                {
                        InitItem(_id, _title, _command, _icon, _width, true, _cdefine);
                }

                public FrmMenuItem(string _id, string _title, string _command, Image _icon, int _width, bool _enable, MenuCommandDefine _cdefine)
                {
                        InitItem(_id, _title, _command, _icon, _width, _enable, _cdefine);
                }

                private void InitItem(string _id, string _title, string _command, Image _icon, int _width, bool _enabled, MenuCommandDefine _cdefine)
                {
                        this._menuID = _id;
                        this._menuIcon = _icon;
                        this._commandName = _command;
                        this._menuTitle = _title;
                        this._menuPicWidth = _width;
                        this._buttonEnable = _enabled;
                        this._commandDefine = _cdefine;
                }
        }
}
