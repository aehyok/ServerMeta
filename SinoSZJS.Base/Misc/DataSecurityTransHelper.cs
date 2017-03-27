using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;

namespace SinoSZJS.Base.Misc
{
    public class DataSecurityTransHelper
    {
        //默认密钥向量 
        private static byte[] IVkey1 = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF, 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };

        public static byte[] Encode<T>(T obj, string key)
        {
            MemoryStream stream = new MemoryStream();
            IFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, obj);
            stream.Flush();
            byte[] theBytes = stream.ToArray();
            stream.Close();
            if (key == null || key == "")
            {
                return theBytes;
            }
            else
            {
                SymmetricAlgorithm des = Rijndael.Create();
                des.Key = Encoding.UTF8.GetBytes(key);
                des.IV = IVkey1;
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
                cs.Write(theBytes, 0, theBytes.Length);
                cs.FlushFinalBlock();
                byte[] cipherBytes = ms.ToArray();//得到加密后的字节数组
                cs.Close();
                ms.Close();
                return cipherBytes;
            }

        }

        public static T Decode<T>(byte[] data, string key)
        {
            if (key == null || key == "")
            {
                IFormatter formatter = new BinaryFormatter();
                MemoryStream stream = new MemoryStream(data);
                T t = (T)formatter.Deserialize(stream);
                stream.Close();
                return t;
            }
            else
            {
                SymmetricAlgorithm des = Rijndael.Create();
                des.Key = Encoding.UTF8.GetBytes(key);
                des.IV = IVkey1;
                byte[] decryptBytes = new byte[data.Length];
                MemoryStream ms = new MemoryStream(data);
                CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Read);
                cs.Read(decryptBytes, 0, decryptBytes.Length);
                cs.Close();
                ms.Close();

                IFormatter formatter = new BinaryFormatter();
                MemoryStream stream = new MemoryStream(decryptBytes);
                T t = (T)formatter.Deserialize(stream);
                stream.Close();
                return t;
            }
        }
    }
}
