using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Reflection;
using System.Drawing;
using DevExpress.Skins;
using SinoSZPluginFramework;
using SinoSZJS.CS.ClientBAPT.Properties;
using SinoSZClientBase;
using SinoSZJS.Base.Authorize;
using SinoSZJS.Base.Misc;


namespace JSCASys
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Cursor.Current = Cursors.WaitCursor;

#if !DEBUG
                        //如果不是在调试状态，则进行自动更新
                        AutoUpdateDlg _updatedlg = new AutoUpdateDlg("海关缉私办案平台客户端升级", ConfigFile.LiveUpdate_SvrInfoUrl);
                        _updatedlg.ShowDialog();
#endif



            DevLocalizerCHS.Init();


            DevExpress.UserSkins.BonusSkins.Register();
            DevExpress.Skins.SkinManager.EnableFormSkins();
            /*
            Caramel
            Money Twins
            Lilian
            The Asphalt World
            iMaginary
            Black
            Blue
            Coffee
            Liquid Sky
            London Liquid Sky
            Glass Oceans
            Stardust
             * */
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("iMaginary");

            //取版本信息
            Assembly SysAssembly = Assembly.GetEntryAssembly();
            SessionClass.SysAssemblyName = SysAssembly.GetName();
            SessionClass.SysResourcesAssembly = typeof(Resources).Assembly;
            SinoSZResources.InitResourceDict(SessionClass.SysResourcesAssembly);



            //TrackingServices.RegisterTrackingHandler(new SinoSZRemoteObjectTracker());

            MenuService.PicWidth = 70;
            LoginForm _login = new LoginForm("登录系统", Resources.login_PT1);
            Cursor.Current = Cursors.Default;

            if (_login.ShowDialog() == DialogResult.OK)
            {
                frmMainForm _mainForm = new frmMainForm(ConfigFile.SystemDisplayName);
                _mainForm.ChangePassword += new EventHandler<EventArgs>(_mainForm_ChangePassword);
                _mainForm.ReLoginForm = _login;
                Application.Run(_mainForm);
            }
        }

        static void _mainForm_ChangePassword(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://10.99.6.214/accreditadmin/dialogs/changeUserPwd.aspx");
        }
    }
}