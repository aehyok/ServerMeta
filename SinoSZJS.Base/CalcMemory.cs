using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace SinoSZJS.Base
{
        public class CalcMemory
        {
                /// <summary>
                /// 计划实例占用的内存大小
                /// </summary>
                /// <param name="_c"></param>
                /// <returns></returns>
                public static long CalcInstanceMemory(object _c)
                {
                        IFormatter formatter = new BinaryFormatter();
                        Stream stream = new MemoryStream();
                        formatter.Serialize(stream, _c);
                        long _ret = stream.Length;
                        stream.Close();
                        return _ret;
                }
        }
}
