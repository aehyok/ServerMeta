using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Diagnostics;

namespace SinoSZJS.CS.AutoUpdater
{
        public class AutoUpdateStarterConfig
        {
                private string _ApplicationFolderName;
                public string ApplicationFolderName
                { get { return _ApplicationFolderName; } set { _ApplicationFolderName = value; } }

                private string _ApplicationExeName;
                public string ApplicationExeName
                { get { return _ApplicationExeName; } set { _ApplicationExeName = value; } }

                private bool _deleteTemp = true;
                public bool DeleteTemp
                {
                        get { return _deleteTemp; }
                        set { _deleteTemp = value; }
                }

                private string configFilePath;

                //calculated/readonly property
                public string ApplicationExePath
                {
                        get
                        {
                                return (Path.Combine(Path.GetDirectoryName(this.configFilePath), this.ApplicationFolderName) + @"\" + this.ApplicationExeName);
                        }
                        set { }
                }

                //calculated/readonly property
                public string ApplicationPath
                {
                        get
                        {
                                return (Path.Combine(Path.GetDirectoryName(this.configFilePath), this.ApplicationFolderName) + @"\");
                        }
                        set { }
                }

                /// <summary>
                /// Load: Returns a AutoUpdateStarterConfig object based on the xml file specified by filepath parameter
                /// </summary>
                /// <param name="filePath"></param>
                /// <returns></returns>
                public static AutoUpdateStarterConfig Load(string filePath)
                {
                        AutoUpdateStarterConfig config = new AutoUpdateStarterConfig();
                        config.configFilePath = filePath;

                        try
                        {
                                //Load the xml config file
                                XmlDocument XmlDoc = new XmlDocument();
                                try
                                {
                                        XmlDoc.Load(filePath);
                                }
                                catch (Exception e)
                                {
                                        Debug.WriteLine("Unable to load the AutoUpdateStarter config file at: " + filePath);
                                        Debug.WriteLine("Error Message: " + e.Message);
                                }

                                //Parse out the XML Nodes
                                XmlNode pathNode = XmlDoc.SelectSingleNode(@"//ApplicationFolderName");
                                config.ApplicationFolderName = pathNode.InnerText;

                                XmlNode exeNode = XmlDoc.SelectSingleNode(@"//ApplicationExeName");
                                config.ApplicationExeName = exeNode.InnerText;

                                XmlNode tempNode = XmlDoc.SelectSingleNode(@"//DeleteTemp");
                                config.DeleteTemp = (tempNode.InnerText.ToUpper() == "NO") ? false : true;

                                return config;

                        }
                        catch (Exception e)
                        {
                                Debug.WriteLine("Failed to read the AutoUpdateStarter config file at: " + filePath);
                                Debug.WriteLine("Make sure that the config file is present and has a valid format");
                                throw e;
                        }
                }//Load(string filePath)
        }//class AutoUpdateStarterConfig
}//namespace Conversive.AutoUpdateStarter