using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;


namespace SinoSZPluginFramework
{
        public interface IMenuService
        {

                void AddMainMenuPage(FrmMenuPage menuPage);
                void AddMenuGroup(FrmMenuPage menuPage, FrmMenuGroup menuGroup);
                void AddMenuItem(FrmMenuGroup menuGroup ,FrmMenuItem menuItem);
                void AddMenuItem(FrmMenuPage menuPage, FrmMenuGroup menuGroup, FrmMenuItem menuItem);

                void RemoveMenuItem(FrmMenuPage menuPage, FrmMenuGroup menuGroup, FrmMenuItem menuItem);
                void RemoveMenuGroup(FrmMenuPage menuPage, FrmMenuGroup menuGroup);
                void RemoveMainMenuPage(String pageName);

        }
}
