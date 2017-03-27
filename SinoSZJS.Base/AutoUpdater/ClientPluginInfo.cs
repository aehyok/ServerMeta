using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZJS.Base.AutoUpdater
{
        /// <summary>
        /// 插件信息
        /// </summary>
        public class ClientPluginInfo
        {
                private string _name = "";
                private string _type = "";
                private string _assembly = "";
                private string _description = "";


                public String Name
                {
                        get
                        {
                                return _name;
                        }
                        set
                        {
                                _name = value;
                        }
                }


                public String Type
                {
                        get
                        {
                                return _type;
                        }
                        set
                        {
                                _type = value;
                        }
                }


                public String Assembly
                {
                        get
                        {
                                return _assembly;
                        }
                        set
                        {
                                _assembly = value;
                        }
                }


                public String Description
                {
                        get
                        {
                                return _description;
                        }
                        set
                        {
                                _description = value;
                        }
                }
        }
}
