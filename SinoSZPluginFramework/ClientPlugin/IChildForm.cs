using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.Design;

namespace SinoSZPluginFramework
{
        public interface IChildForm 
        {
                IApplication Application { get;set;}
                event EventHandler<EventArgs> MenuChanged;
                
                IList<FrmMenuPage> GetMenuPages();

                /// <summary>
                /// 执行命令
                /// </summary>
                /// <param name="_cmdName"></param>
                /// <returns></returns>
                bool DoCommand(string _cmdName);
        }
}
