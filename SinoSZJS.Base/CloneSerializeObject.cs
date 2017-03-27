using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace SinoSZJS.Base
{
    public class CloneSerializeObject
    {
        static public object Clone(object _obj)
        {
            object _ret;
            IFormatter formatter = new BinaryFormatter();
            using (Stream stream = new MemoryStream())
            {
                formatter.Serialize(stream, _obj);

                stream.Position = 0;
                _ret = formatter.Deserialize(stream);
            }
            return _ret;
        }
    }
}
