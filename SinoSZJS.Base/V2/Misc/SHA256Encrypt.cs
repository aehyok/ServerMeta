using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace SinoSZJS.Base.V2.Misc
{
	/// <summary>
	/// SHA256加密算法
	/// </summary>
	public class SHA256Base64
	{
		/// <summary>
		/// SHA256加密
		/// </summary>
		/// <param name="sourceString">源字符串</param>
		/// <returns></returns>
		public static string Encrypt(string sourceString)
		{
			//char[] chars = sourceString.ToCharArray();
			//int count = chars.Length;
			//byte[] bytes = new byte[count];
			//for (int i = 0; i < count; i++)
			//{
			//    bytes[i] = (byte)chars[i];
			//}
			byte[] bytes = Encoding.UTF8.GetBytes(sourceString);
			SHA256 sha256 = new SHA256Managed();
			byte[] tmpByte = sha256.ComputeHash(bytes);
			sha256.Clear();
			return Convert.ToBase64String(tmpByte);
		}
	}
}
