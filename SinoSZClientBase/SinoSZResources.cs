using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Resources;
using System.Collections;
using System.Reflection;
using SinoSZClientBase.Properties;
using System.IO;
using SinoSZJS.Base.Authorize;

namespace SinoSZClientBase
{
        public class SinoSZResources
        {
                private static Dictionary<string, Image> ImageDict = new Dictionary<string, Image>();

                public static Dictionary<string, Image> Images
                {
                        get { return ImageDict; }
                }

                public static void InitResourceDict(Assembly assem)
                {
                        ImageDict = new Dictionary<string, Image>();
                        string _fname = string.Format("{0}.Properties.Resources.resources", assem.GetName().Name);
                        using (Stream stream = assem.GetManifestResourceStream(_fname))
                        {
                                // 2. Find resource in .resources file
                                using (ResourceReader reader = new ResourceReader(stream))
                                {
                                        foreach (DictionaryEntry en in reader)
                                        {
                                                if (en.Value is Image)
                                                {
                                                        ImageDict.Add(en.Key.ToString(), (Image)en.Value);
                                                }
                                        }
                                }
                        }

                }


                public static Image GetIcon(string iconName)
                {
                        if (ImageDict.ContainsKey(iconName))
                        {
                                return ImageDict[iconName];
                        }
                        else
                        {
                                return null;
                        }
                }
        }
}
