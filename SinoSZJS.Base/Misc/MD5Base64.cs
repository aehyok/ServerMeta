using System;
using System.Security.Cryptography;

namespace SinoSZJS.Base.Misc
{
    /// <summary>
    /// MD5Base64 的摘要说明。
    /// </summary>
    public class MD5Base64
    {

        public static string Encode(string sourceString)
        {
            char[] chars = sourceString.ToCharArray();
            int count = chars.Length;
            byte[] bytes = new byte[count];
            for (int i = 0; i < count; i++)
            {
                bytes[i] = (byte)chars[i];
            }
            SHA256 sha256 = new SHA256Managed();
            byte[] tmpByte = sha256.ComputeHash(bytes);
            sha256.Clear();
            return Convert.ToBase64String(tmpByte);
        }

    }
}
