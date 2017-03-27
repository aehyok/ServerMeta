using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace SinoSZPluginFramework.ClientPlugin
{
        public class MenuFunctions
        {
                public static IApplication Application = null;

                /// <summary>
                /// 采用泛型的加页
                /// </summary>
                /// <typeparam name="T"></typeparam>
                /// <param name="_frmName"></param>
                public static T AddPage<T>(string _frmName) where T : new()
                {
                        if (Application == null) return default(T);

                        if (Application.IsExistForm(_frmName))
                        {
                                Application.SetFormActive(_frmName);
                                return default(T);
                        }
                        else
                        {
                                T _frm = new T();
                                Application.AddForm(_frmName, _frm as Form);
                                return _frm;
                        }

                }

                /// <summary>
                /// 采用泛型的加页
                /// </summary>
                /// <typeparam name="T"></typeparam>
                /// <param name="_frmName"></param>
                public static T AddPage<T>(string _frmName, IApplication _application) where T : new()
                {
                        if (_application.IsExistForm(_frmName))
                        {
                                _application.SetFormActive(_frmName);
                                return default(T);
                        }
                        else
                        {
                                T _frm = new T();
                                _application.AddForm(_frmName, _frm as Form);
                                return _frm;
                        }

                }

                public static void AddPage(string _frmName, IApplication _application, Form _frm)
                {
                        if (_application.IsExistForm(_frmName))
                        {
                                _application.SetFormActive(_frmName);
                        }
                        else
                        {
                                _application.AddForm(_frmName, _frm);
                        }
                }
        }
}
