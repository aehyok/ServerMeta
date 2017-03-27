using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace SinoSZJS.Base.SinoBestMTS
{
    public class SinoBestMTSMessage
    {
        public string Header { get; set; }
        public string Body { get; set; }
        public string Processor { get; set; }
        public SinoBestMTSMessage(string xml)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);

            Header=GetInnerXML(doc,"Header");
            Body = GetInnerXML(doc, "Body");
            Processor = GetInnerXML(doc, "Processor");
        }

        public string GetInnerXML(XmlDocument Doc, string TagName)
        {
            XmlNodeList elemList = Doc.GetElementsByTagName(TagName);
            if (elemList.Count > 0)
            {
                return elemList[0].InnerXml;
            }
            else
            {
                return "";
            }
        }



    }
}
 