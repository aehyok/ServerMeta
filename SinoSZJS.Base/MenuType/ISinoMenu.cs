using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZJS.Base.MenuType
{
        public interface ISinoMenu
        {
                List<SinoMenuItem> GetAllMenus(string _postID);

                List<firstPageItem> GetfirstPage();

          
        }
}
