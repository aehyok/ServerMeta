using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.IO;
using System.Xml;
using System.Text;
using SinoSZJS.Base.InputModel;
using System.Xml.Serialization;

namespace SinoSZJS.Base.Misc
{
    public static class DataConvert
    {
        public static string DataTableToXml(this DataTable dt)
        {
            //System.IO.TextWriter tw = new System.IO.StringWriter();
            //dt.WriteXml(tw);

            //MemoryStream ms = null;
            //XmlTextWriter XmlWt = null;
            //ms = new MemoryStream();
            ////根据ms实例化XmlWt
            //XmlWt = new XmlTextWriter(ms, Encoding.Unicode);
            ////获取ds中的数据
            //dt.WriteXml(XmlWt);
            //int count = (int)ms.Length;
            //byte[] temp = new byte[count];
            //ms.Seek(0, SeekOrigin.Begin);
            //ms.Read(temp, 0, count);
            ////返回Unicode编码的文本
            //UnicodeEncoding ucode = new UnicodeEncoding();
            //string returnValue = ucode.GetString(temp).Trim();

            StringBuilder sb = new StringBuilder();
            XmlWriter writer = XmlWriter.Create(sb);
            XmlSerializer serializer = new XmlSerializer(typeof(DataTable));
            serializer.Serialize(writer, dt);
            writer.Close();
            return sb.ToString();


        }
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

        /// <summary>
        /// 根据子模型名称获取DataTable
        /// </summary>
        /// <param name="StrData"></param>
        /// <param name="ModelName"></param>
        /// <returns></returns>
        public static string GetDataTableByModelName(string StrData, string ModelName)
        {
            if (!string.IsNullOrEmpty(StrData))
            {
                XmlDocument XmlData = new XmlDocument();
                XmlData.LoadXml(StrData);
                DataTable dt = new DataTable();
                XmlNode doc = XmlData.SelectSingleNode("//DocumentElement");
                XmlNodeList xnList = XmlData.SelectNodes("//DocumentElement/ResultTable[@option='-1']");
                foreach (XmlNode xn in xnList)
                {
                    doc.RemoveChild(xn);
                }
                return XmlData.OuterXml;
                //return XMLToDataTable("<TempRoot>" + XmlTemp.InnerXml + "</TempRoot>").Tables["ResultTable"];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 将录入模型Add的实体数据转换为XML
        /// </summary>
        /// <param name="Entity"></param>
        /// <param name="?"></param>
        /// <returns></returns>
        public static string GetXMLDataByEntity(MD_InputEntity Entity)
        {
            DataTable dt = new DataTable("ResultTable");
            DataRow dr = dt.NewRow();
            foreach (KeyValuePair<string, string> obj in Entity.InputData)
            {
                if (!string.IsNullOrEmpty(obj.Value.ToString()))
                {
                    dt.Columns.Add(obj.Key);
                    dr[obj.Key] = obj.Value;
                }
            }
            dt.Rows.Add(dr);
            System.IO.TextWriter tw = new System.IO.StringWriter();
            dt.WriteXml(tw);
            return tw.ToString();
        }

        /// <summary>
        /// 将指定XML节点导入到另一XMl文档当中
        /// </summary>
        /// <param name="ChildModelRow"></param>
        /// <param name="Content"></param>
        /// <param name="ModelName"></param>
        /// <returns></returns>
        public static string GetChildModelContent(string ChildModelRow, string Content, string ModelName)
        {
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.LoadXml(ChildModelRow);
            XmlNode ChildRowNode = xmldoc.SelectSingleNode("/DocumentElement/ResultTable");
            (ChildRowNode as XmlElement).SetAttribute("option", "1");
            XmlDocument XmlContent = new XmlDocument();
            XmlContent.LoadXml(Content);
            XmlNode ImNode = XmlContent.ImportNode(ChildRowNode, true);
            XmlNode XmlTemp = XmlContent.SelectSingleNode("//DataTable[@ModelName='" + ModelName + "']");
            XmlDocument xmlDocTemp = new XmlDocument();
            xmlDocTemp.LoadXml(XmlTemp.OuterXml);
            if (xmlDocTemp.SelectSingleNode("//DocumentElement") != null)
            {
                if (XmlContent.SelectSingleNode("//DataTable[@ModelName='" + ModelName + "']").ChildNodes[2] != null) { XmlContent.SelectSingleNode("//DataTable[@ModelName='" + ModelName + "']").ChildNodes[2].AppendChild(ImNode); }
                else
                {
                    XmlContent.SelectSingleNode("//DataTable[@ModelName='" + ModelName + "']").ChildNodes[1].ChildNodes[0].AppendChild(ImNode);
                }

                ///XmlContent.SelectSingleNode("//DataTable[@ModelName='" + ModelName + "']").SelectSingleNode("//DocumentElement").AppendChild(ImNode);
            }
            else
            {
                XmlNode ImNode1 = XmlContent.ImportNode(xmldoc.DocumentElement, true);
                XmlContent.SelectSingleNode("//DataTable[@ModelName='" + ModelName + "']").AppendChild(ImNode1);
            }
            return XmlContent.InnerXml;
        }


        #region 序列化
        /// <summary>
        /// 序列化
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="obj">对象</param>
        /// <returns></returns>
        public static string Serializer(Type type, object obj)
        {
            MemoryStream Stream = new MemoryStream();
            XmlSerializer xml = new XmlSerializer(type);
            try
            {
                //序列化对象
                xml.Serialize(Stream, obj);
            }
            catch
            {
                throw;
            }
            Stream.Position = 0;
            StreamReader sr = new StreamReader(Stream);
            string str = sr.ReadToEnd();

            sr.Dispose();
            Stream.Dispose();

            return str;
        }
        #endregion

        #region 反序列化
        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="xml">XML字符串</param>
        /// <returns></returns>
        public static object Deserialize(Type type, string xml)
        {
            try
            {
                using (StringReader sr = new StringReader(xml))
                {
                    XmlSerializer xmldes = new XmlSerializer(type);
                    return xmldes.Deserialize(sr);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion

    }
}
