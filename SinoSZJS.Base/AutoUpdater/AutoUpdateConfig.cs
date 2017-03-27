using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Net;
using System.IO;
using System.Diagnostics;
using System.Configuration;

namespace SinoSZJS.Base.AutoUpdater
{
        public class AutoUpdateConfig
        {
                private IList<UpdateFileInfo> _CurrentVersionFiles = null;
                private List<ClientPluginInfo> _PluginLists = null;

                public List<ClientPluginInfo> PluginList
                {
                        get { return _PluginLists; }
                        set { _PluginLists = value; }
                }


                public IList<UpdateFileInfo> CurrentVersionfiles
                {
                        get { return _CurrentVersionFiles; }
                        set { _CurrentVersionFiles = value; }
                }


                /// <summary>
                /// LoadConfig: Invoke this method when you are ready to populate this object
                /// </summary>
                public bool LoadConfig(string url, string user, string pass)
                {
                        try
                        {
                                //Load the xml config file
                                XmlDocument XmlDoc = new XmlDocument();
                                HttpWebResponse Response;
                                HttpWebRequest Request;
                                //Retrieve the File

                                Request = (HttpWebRequest)WebRequest.Create(url);
                                //Request.Headers.Add("Translate: f");
                                Request.Method = "GET";
                                Request.AllowAutoRedirect = true;

                                if (user != null && user != "")
                                        Request.Credentials = new NetworkCredential(user, pass);
                                else
                                        Request.Credentials = CredentialCache.DefaultCredentials;

                                Response = (HttpWebResponse)Request.GetResponse();

                                Stream respStream = null;
                                respStream = Response.GetResponseStream();

                                //Load the XML from the stream
                                XmlDoc.Load(respStream);

                                //Parse out the AvailableVersion
                                XmlNode AvailableVersionNode = XmlDoc.SelectSingleNode(@"//VersionConfig");

                                CheckFileList(AvailableVersionNode);
                                
                                respStream.Close();
                                Response.Close();

                        }
                        catch (Exception e)
                        {
                                Debug.WriteLine("Failed to read the config file at: " + url);
                                Debug.WriteLine("Make sure that the config file is present and has a valid format");
                                Debug.WriteLine("Error Message: " + e.Message);
                                //XtraMessageBox.Show("Make sure that the config file is present and has a valid format");
                                return false;
                        }
                        return true;
                }

            


                private void CheckFileList(XmlNode AvailableVersionNode)
                {
                        this._CurrentVersionFiles = new List<UpdateFileInfo>();
                        foreach (XmlNode _fileNode in AvailableVersionNode.ChildNodes)
                        {
                                string _fname = _fileNode.Attributes["Name"].Value;
                                string _version = _fileNode.Attributes["Version"].Value;
                                string _url = _fileNode.Attributes["AppFileURL"].Value;
                                UpdateFileInfo _finfo = new UpdateFileInfo(_fname, _version, _url);
                                this._CurrentVersionFiles.Add(_finfo);
                        }
                }
        }
}
