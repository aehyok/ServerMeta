using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace SinoSZJS.Base.V2.Misc
{
    public static class DataConverter
    {
        /// <summary>
        /// XML转为Dictionary<string,object>
        /// </summary>
        /// <param name="pstr"></param>
        /// <returns></returns>
        public static Dictionary<string, string> ChangeXMLToDictionary(string pstr)
        {
            int index, start, end, em_start;
            string mark, endmark;
            Dictionary<string, string> _ret = new Dictionary<string, string>();
            index = 0;
            if (pstr != null)
            {
                while (index < pstr.Length)
                {
                    start = pstr.IndexOf('<', index);
                    if (start >= 0)
                    {
                        end = pstr.IndexOf('>', start);
                        if (end >= 0)
                        {
                            mark = pstr.Substring(start + 1, end - start - 1);
                            endmark = string.Format("</{0}>", mark);
                            em_start = pstr.IndexOf(endmark, end + 1);
                            if (em_start >= 0)
                            {
                                string value = pstr.Substring(end + 1, em_start - end - 1);
                                _ret.Add(mark, value);
                                index = end + endmark.Length + 1;
                            }
                            else
                            {
                                index = end + 1;
                            }
                        }
                        else
                        {
                            index = start + 1;
                        }
                    }
                    else
                    {
                        index = pstr.Length + 1;
                    }
                }
            }
            return _ret;
        }

        /// <summary>
        /// DataTable转换为XML
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string DataTableToXml(this DataTable dt)
        {
            StringBuilder sb = new StringBuilder();
            XmlWriter writer = XmlWriter.Create(sb);
            XmlSerializer serializer = new XmlSerializer(typeof(DataTable));
            serializer.Serialize(writer, dt);
            writer.Close();
            return sb.ToString();
        }

        /// <summary>
        /// DataSet转换为XML
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        public static string DataSetToXml(this DataSet ds)
        {
            StringBuilder sb = new StringBuilder();
            XmlWriter writer = XmlWriter.Create(sb);
            XmlSerializer serializer = new XmlSerializer(typeof(DataSet));
            serializer.Serialize(writer, ds);
            writer.Close();
            return sb.ToString();
        }
        /// <summary>
        /// 将XML字符串转换为StreamReader
        /// </summary>
        /// <param name="xmlStr"></param>
        /// <returns></returns>
        public static StreamReader GetStream(this string xmlStr)
        {
            byte[] tempByte = Encoding.UTF8.GetBytes(xmlStr);
            MemoryStream stream = new MemoryStream(tempByte);
            //stream.Position = 0;
            StreamReader streamReader = new StreamReader(stream);
            return streamReader;
        }

        /// <summary>
        /// 将XML字符串转换为DataTable并将XML中的数据填充到DataTable
        /// </summary>
        /// <param name="StrData"></param>
        /// <returns></returns>
        public static DataSet XMLToDataSet(this string StrData)
        {
            if (!string.IsNullOrEmpty(StrData))
            {
                XmlDocument xmlDoc = new XmlDocument();
                DataSet ds = new DataSet();
                try
                {
                    xmlDoc.LoadXml(StrData);
                    ds.ReadXml(GetStream(xmlDoc.OuterXml));
                    return ds;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 将XML转换为DataTable
        /// </summary>
        /// <param name="StrData"></param>
        /// <returns></returns>
        public static DataTable XMLToDataTable(this string StrData)
        {
            if (!string.IsNullOrEmpty(StrData))
            {
                XmlDocument xmlDoc = new XmlDocument();
                DataTable ds = new DataTable("ResultTable");
                try
                {
                    xmlDoc.LoadXml(StrData);
                    XmlSerializer serializer = new XmlSerializer(typeof(DataTable));
                    ds = (DataTable)serializer.Deserialize(GetStream(xmlDoc.InnerXml));

                    return ds;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            else
            {
                return null;
            }
        }
    }
}
