using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace SinoSZJS.CS.BizMetaDataManager.MTS
{
    public class MTSResultMessage
    {
        /// <summary>
        /// 消息GUID 唯一编码
        /// </summary>
        public string PKGuid { get; set; }

        /// <summary>
        /// 返回结果类型  0 成功 1失败
        /// </summary>
        public string ResultType { get; set; }

        /// <summary>
        /// 返回结果数据包
        /// </summary>
        public string ResultBody { get; set; }

        /// <summary>
        /// 对返回数据包的处理方法
        /// </summary>
        public string ResultMethod { get; set; }

        public MTSResultMessage()
        {
        }

        public MTSResultMessage(string _msg)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(_msg);
                PKGuid = GetData(doc, "GUID");
                ResultType = GetData(doc, "RESULT");
                ResultBody = GetData(doc, "BODY");
                ResultMethod = GetData(doc, "METHOD");

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private string GetData(XmlDocument doc, string TagName)
        {
            XmlNodeList elemList = doc.GetElementsByTagName(TagName);
            if (elemList.Count < 1)
            {
                return "";
            }
            else
            {
                return elemList[0].InnerXml;
            }
        }


        public string CreateMsg()
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                XmlDeclaration declare = doc.CreateXmlDeclaration("1.0", "utf-8", "yes");
                doc.AppendChild(declare);
                XmlElement MtsData = doc.CreateElement("RESULTDATA");
                doc.AppendChild(MtsData);
                XmlElement Header = doc.CreateElement("HEADER");
                MtsData.AppendChild(Header);
                XmlElement pkguid = doc.CreateElement("GUID");
                pkguid.InnerText = PKGuid;
                Header.AppendChild(pkguid);
                XmlElement Deploy_tx = doc.CreateElement("RESULT");
                Deploy_tx.InnerText = this.ResultType;
                Header.AppendChild(Deploy_tx);
                XmlElement PKMethod = doc.CreateElement("METHOD");
                PKMethod.InnerText = this.ResultMethod;
                Header.AppendChild(PKMethod);

                XmlElement MsgBody = doc.CreateElement("BODY");
                MsgBody.InnerXml = ResultBody;
                MtsData.AppendChild(MsgBody);

                return doc.InnerXml;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
