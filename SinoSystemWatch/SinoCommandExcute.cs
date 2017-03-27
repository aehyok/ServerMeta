using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Compression;
using SinoSystemWatch.Base.WCF;
using System.Runtime.Serialization.Json;

namespace SinoSystemWatch
{
    public class SinoCommandExcute
    {
        public static string Do(string Token, string CommandName, string DesServer, byte[] ParamData)
        {
            using (SinoMoniterCommand.SinoMonitorCommandClient _sc = new SinoMoniterCommand.SinoMonitorCommandClient())
            {
                byte[] _ret = _sc.DoCommand(Token, CommandName, DesServer, ParamData);

                string _decodeDate = WcfDataCompressControl.UnCompress(_ret);
                return _decodeDate;
            }
        }

        public static byte[] DoNoCompressed<T>(string Token, string CommandName, string DesServer, T ParamData)
        {
            try
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
                MemoryStream stream = new MemoryStream();
                serializer.WriteObject(stream, ParamData);
                stream.Position = 0;

                StreamReader sr = new StreamReader(stream);
                string resultStr = sr.ReadToEnd();
                sr.Close();
                stream.Close();

                byte[] _callbytes = WcfDataCompressControl.Compress(resultStr);

                using (SinoMoniterCommand.SinoMonitorCommandClient _sc = new SinoMoniterCommand.SinoMonitorCommandClient())
                {
                    byte[] _ret = _sc.DoCommand(Token, CommandName, DesServer, _callbytes);
                    return _ret;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string Do<T>(string Token, string CommandName, string DesServer, T ParamData)
        {
            try
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
                MemoryStream stream = new MemoryStream();
                serializer.WriteObject(stream, ParamData);
                stream.Position = 0;

                StreamReader sr = new StreamReader(stream);
                string resultStr = sr.ReadToEnd();
                sr.Close();
                stream.Close();

                byte[] _callbytes = WcfDataCompressControl.Compress(resultStr);
                using (SinoMoniterCommand.SinoMonitorCommandClient _sc = new SinoMoniterCommand.SinoMonitorCommandClient())
                {
                    byte[] _ret = _sc.DoCommand(Token, CommandName, DesServer, _callbytes);

                    string _decodeDate = WcfDataCompressControl.UnCompress(_ret);
                    return _decodeDate;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
