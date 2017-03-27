using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Json;
using SinoSystemWatch.Base.WCF;
using System.IO;

namespace SinoSystemWatch.Base.Common
{
    public class CommandCommon
    {
        public static T GetParamDataObj<T>(byte[] ParameterData)
        {
            string _decodeItem = WcfDataCompressControl.UnCompress(ParameterData);
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
            MemoryStream ms = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(_decodeItem.ToCharArray()));
            T _item = (T)serializer.ReadObject(ms);
            ms.Close();
            return _item;
        }


    }
}
