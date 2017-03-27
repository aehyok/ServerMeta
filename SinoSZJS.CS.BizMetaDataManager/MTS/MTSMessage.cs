using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace SinoSZJS.CS.BizMetaDataManager.MTS
{
    public class MTSMessage
    {
        /// <summary>
        /// 消息GUID 唯一编码
        /// </summary>
        public string PKGuid { get; set; }
        /// <summary>
        /// 发送方部署代码
        /// </summary>
        public string DEPLOYID_TX { get; set; }
        /// <summary>
        /// 接收方部署代码
        /// </summary>
        public string DEPLOYID_RX { get; set; }

        /// <summary>
        /// 数据包
        /// </summary>
        public string DataPKG { get; set; }

        /// <summary>
        /// 数据包处理方法
        /// </summary>
        public string PROCMETHOD { get; set; }

        public MTSMessage()
        {
        }

        public MTSMessage(string _msg)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(_msg);
                DEPLOYID_TX = GetData(doc, "DEPLOYID_TX");
                DEPLOYID_RX = GetData(doc, "DEPLOYID_RX");
                PKGuid = GetData(doc, "GUID");
                PROCMETHOD = GetData(doc, "METHOD");
                DataPKG = GetData(doc, "BODY");
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
                XmlElement MtsData = doc.CreateElement("MTSDATA");
                doc.AppendChild(MtsData);
                XmlElement Header = doc.CreateElement("HEADER");
                MtsData.AppendChild(Header);
                XmlElement pkguid = doc.CreateElement("GUID");
                pkguid.InnerText = PKGuid;
                Header.AppendChild(pkguid);
                XmlElement Deploy_tx = doc.CreateElement("DEPLOYID_TX");
                Deploy_tx.InnerText = this.DEPLOYID_TX;
                Header.AppendChild(Deploy_tx);
                XmlElement Deploy_rx = doc.CreateElement("DEPLOYID_RX");
                Deploy_rx.InnerText = this.DEPLOYID_RX;
                Header.AppendChild(Deploy_rx);
                XmlElement PKMethod = doc.CreateElement("METHOD");
                PKMethod.InnerText = this.PROCMETHOD;
                Header.AppendChild(PKMethod);

                XmlElement MsgBody = doc.CreateElement("BODY");
                MtsData.AppendChild(MsgBody);

                XmlDocument doc2 = new XmlDocument();
                doc2.LoadXml(this.DataPKG);
                if (doc.ChildNodes.Count > 1)
                {
                    MsgBody.InnerXml = doc2.ChildNodes[1].OuterXml;
                }
                else
                {
                    MsgBody.InnerXml = doc2.InnerXml;
                }



                return doc.InnerXml;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("转换为ESB数据格式发送错误：{0}!", ex));
            }

        }
    }
}
