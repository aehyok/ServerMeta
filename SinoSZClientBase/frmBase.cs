using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SinoSZPluginFramework;

namespace SinoSZClientBase
{
        public partial class frmBase : DevExpress.XtraEditors.XtraForm, IChildForm
        {
                protected IApplication _application = null;
                protected bool _initFinished = false;
                protected string _menuPageName = "辅助功能";
                public frmBase()
                {
                        InitializeComponent();
                }


                #region 实现IChildForm接口

                public IApplication Application
                {
                        get { return _application; }
                        set { _application = value; }
                }

                public event EventHandler<EventArgs> MenuChanged;
                virtual public void RaiseMenuChanged()
                {
                        if (this._initFinished && MenuChanged != null)
                        {
                                MenuChanged(this, new EventArgs());
                        }
                }


                public IList<FrmMenuPage> GetMenuPages()
                {
                        IList<FrmMenuPage> _ret = new List<FrmMenuPage>();
                        FrmMenuPage _page = new FrmMenuPage(_menuPageName);
                        _page.MenuGroups = GetMenuGroups(_page.PageTitle);
                        _ret.Add(_page);

                        return _ret;
                }



                virtual protected IList<FrmMenuGroup> GetMenuGroups(string _pagename)
                {
                        IList<FrmMenuGroup> _ret = new List<FrmMenuGroup>();

                        return _ret;
                }


                public bool DoCommand(string _cmdName)
                {
                        return ExcuteCommand(_cmdName);
                }

                virtual protected bool ExcuteCommand(string _cmdName)
                {

                        return true;
                }

                virtual public void Init(string _title, string _menuName, object _param)
                {
                        this._menuPageName = _menuName;
                }
                #endregion

        }
}