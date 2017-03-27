using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.Design;
using System.Windows.Forms;
using DevExpress.XtraBars.Docking;

using DevExpress.XtraBars.Ribbon;
using SinoSZPluginFramework.ClientPlugin;

namespace SinoSZPluginFramework
{
        public interface IApplication : IServiceContainer
        {
                DockPanel LeftToolPanel { get;}
                DockPanel RightToolPanel { get;}

                DockPanel BottomToolPanel { get;}

                RibbonControl MainRibbon { get;}
                RibbonStatusBar MainStatusBar { get;}               
               
                Form MainForm { get;}

                IChildForm ActiveChildForm { get;}
                
                bool IsExistForm(string _frmName);
                bool AddForm(string _frmName,Form _frm);
                bool RemoveForm(string _frmName);
                bool SetFormActive(string _frmName);
               
                void WriteMessage(string _msg);

                /// <summary>
                /// 注册待办事项接口
                /// </summary>
                /// <param name="iPendingAlert"></param>
                /// <returns></returns>
                bool RegisterIPendingAlert(IPendingAlert iPendingAlert);
        }
}
