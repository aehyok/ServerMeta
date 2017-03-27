using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Json;
using System.IO;


namespace SinoSystemWatch.Base.Define
{
    public class WatchSystemLib
    {
        public static Dictionary<string, SystemStateItem> SystemLib = new Dictionary<string, SystemStateItem>();

        public static void Clear()
        {
            SystemLib.Clear();
        }

        public static bool AddSystem(SystemStateItem _item)
        {
            if (SystemLib.ContainsKey(_item.SystemName))
            {
                return false;
            }
            else
            {
                SystemLib.Add(_item.SystemName, _item);
                return true;
            }
        }

        public static bool RemoveSystem(string SystemName)
        {
            if (SystemLib.ContainsKey(SystemName))
            {
                SystemLib.Remove(SystemName);
                return true;
            }
            else
            {
                return false;
            }
        }

        public static SystemStateItem GetSystem(string SystemName)
        {
            if (SystemLib.ContainsKey(SystemName))
            {
                return SystemLib[SystemName];
            }
            else
            {
                return null;
            }
        }



        public static string GetJsonData()
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Dictionary<string, SystemStateItem>));
            MemoryStream stream = new MemoryStream();
            serializer.WriteObject(stream, SystemLib);
            stream.Position = 0;

            StreamReader sr = new StreamReader(stream);
            string resultStr = sr.ReadToEnd();
            sr.Close();
            stream.Close();

            return resultStr;

        }
    }
}
