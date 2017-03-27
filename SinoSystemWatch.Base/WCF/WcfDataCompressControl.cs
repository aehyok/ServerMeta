using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Compression;

namespace SinoSystemWatch.Base.WCF
{
    public class WcfDataCompressControl
    {
        public static byte[] Compress(string DataStr)
        {
            byte[] _retbytes;
            #region 压缩返回结果
            byte[] byteArray = System.Text.Encoding.Unicode.GetBytes(DataStr);

            using (MemoryStream ms = new MemoryStream())
            {
                GZipStream zip = new GZipStream(ms, CompressionMode.Compress);
                zip.Write(byteArray, 0, byteArray.Length);
                zip.Close(); //Gzip流必须先关闭，才可以读取压缩数据，否则读出来的数据不正确。
                _retbytes = ms.ToArray();
            }
            #endregion

            return _retbytes;
        }

        public static string UnCompress(byte[] DataByte)
        {
            using (MemoryStream tempMs = new MemoryStream())
            {
                using (MemoryStream ms = new MemoryStream(DataByte))
                {
                    GZipStream Decompress = new GZipStream(ms, CompressionMode.Decompress);
                    Decompress.CopyTo(tempMs);
                    Decompress.Close();

                    string _decodeDate = Encoding.Unicode.GetString(tempMs.ToArray());
                    return _decodeDate;
                }
            }
        }

        public static byte[] Compress(byte[] byteArray)
        {
            byte[] _retbytes;
            #region 压缩返回结果

            using (MemoryStream ms = new MemoryStream())
            {
                GZipStream zip = new GZipStream(ms, CompressionMode.Compress);
                zip.Write(byteArray, 0, byteArray.Length);
                zip.Close(); //Gzip流必须先关闭，才可以读取压缩数据，否则读出来的数据不正确。
                _retbytes = ms.ToArray();
            }
            #endregion

            return _retbytes;
        }

        public static byte[] UnCompressByts(byte[] DataByte)
        {
            using (MemoryStream tempMs = new MemoryStream())
            {
                using (MemoryStream ms = new MemoryStream(DataByte))
                {
                    GZipStream Decompress = new GZipStream(ms, CompressionMode.Decompress);
                    Decompress.CopyTo(tempMs);
                    Decompress.Close();
                    return tempMs.ToArray();

                }
            }
        }
    }
}
