using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZJS.Base.MenuType
{
        public class MenuTypeCollection : System.Collections.CollectionBase
        {

                public MenuTypeCollection()
                {
                        //
                        // TODO: 在此处添加构造函数逻辑
                        //
                }
                public MenuTypeBase this[int index]
                {
                        get
                        {
                                return (MenuTypeBase)List[index];
                        }
                }

                public int Add(MenuTypeBase _cmd)
                {
                        return List.Add(_cmd);
                }

                public MenuTypeBase FindByName(string _s)
                {
                        foreach (MenuTypeBase _mt in this)
                        {
                                if (_mt.MenuTypeName == _s) return _mt;
                        }
                        return null;
                }
        }
}
