using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZPluginFramework
{
        public class MenuClickedEventArgs :EventArgs
        {
                private string _menuCommand = "";
                public string MenuCommand
                {
                        get { return _menuCommand; }
                }

                public MenuClickedEventArgs(string _command)
                {
                        _menuCommand = _command;
                }
        }
}
