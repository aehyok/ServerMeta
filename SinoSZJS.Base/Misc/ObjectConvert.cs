using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace SinoSZJS.Base.Misc
{
    public class ObjectConvert
    {
        public static byte[] ConvertToByte(object _obj)
        {
            byte[] theBytes;
            IFormatter formatter = new BinaryFormatter();
            using (Stream stream = new MemoryStream())
            {
                formatter.Serialize(stream, _obj);
                stream.Seek(0, SeekOrigin.Begin);
                theBytes = new byte[stream.Length];
                stream.Read(theBytes, 0, theBytes.Length);
                stream.Close();
            }
            return theBytes;
        }

        public static T ConvertToObject<T>(byte[] _bytes)
        {
            IFormatter formatter = new BinaryFormatter();
            MemoryStream stream = new MemoryStream(_bytes);
            T t = (T)formatter.Deserialize(stream);
            stream.Close();
            return t;
        }
    }
}
