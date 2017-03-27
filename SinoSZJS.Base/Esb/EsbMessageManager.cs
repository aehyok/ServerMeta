using System.Text;
using System;

namespace SinoSZJS.Base.Esb
{
    public enum EsbNodes
    {
        EsbHeader,
        HeaderControl,
        Name,
        Version,
        From,
        To,
        Operation,
        SendTime,
        GUID,
        EsbBody,
        BodyControl,
        SourceGUID,
        SourceBizID,
        DestBizID,
        OperationType,
        Business
    };

    public class EsbMessageBase
    {
        public virtual string H_Name { get; set; }
        public virtual string H_Version { get; set; }
        public virtual string H_From { get; set; }
        public virtual string H_To { get; set; }
        public virtual string H_Operation { get; set; }
        public virtual string H_SendTime { get; set; }
        public virtual string H_GUID { get; set; }

        public virtual string B_SourceGUID { get; set; }
        public virtual string B_SourceBizID { get; set; }
        public virtual string B_DestBizID { get; set; }
        public virtual string B_OperationType { get; set; }
        public virtual string B_Business { get; set; }


        #region ESB报文：用于发送至HZ2011系统

        public virtual string CreateMessage(bool inIsFileFormat = false)
        {
            //消息格式的ESB数据
            string _ret = "<?xml version=\"1.0\"?>";
            _ret += Environment.NewLine;
            _ret += "<EsbEnvelope xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns=\"http://hh2010.customs.gov.cn/common/schemas/ESBSchemas/\">";
            _ret += Create_ESB_Header() + Create_ESB_Body();
            _ret += "</EsbEnvelope>";

            if (inIsFileFormat == true)
            {//文件格式的ESB数据
                byte[] buffer = Encoding.GetEncoding("utf-8").GetBytes(_ret);
                _ret = "";
                foreach (byte b in buffer) _ret += string.Format("%{0:X}", b);
            }

            return _ret;
        }

        //Esb报文：头部
        private string Create_ESB_Header()
        {
            //1-节点：<HeaderControl>各子节点
            string _name = Create_XML_Node(EsbNodes.Name, H_Name);
            string _version = Create_XML_Node(EsbNodes.Version, H_Version);
            string _from = Create_XML_Node(EsbNodes.From, H_From);
            string _to = Create_XML_Node(EsbNodes.To, H_To);
            string _operation = Create_XML_Node(EsbNodes.Operation, H_Operation);
            string _sendTime = Create_XML_Node(EsbNodes.SendTime, H_SendTime);
            string _GUID = Create_XML_Node(EsbNodes.GUID, H_GUID);
            //2-节点：<HeaderControl>
            string _headerControlValue = _name + _version + _from + _to + _operation + _sendTime + _GUID;
            string _headerControl = Create_XML_Node(EsbNodes.HeaderControl, _headerControlValue);
            //3-节点：<EsbHeader>
            string _esbHeader = Create_XML_Node(EsbNodes.EsbHeader, _headerControl);

            return _esbHeader;
        }

        //Esb报文：实体
        private string Create_ESB_Body()
        {
            //1-节点：<BodyControl>各子节点
            string _sourceGUID = Create_XML_Node(EsbNodes.SourceGUID, B_SourceGUID);
            string _sourceBizID = Create_XML_Node(EsbNodes.SourceBizID, B_SourceBizID);
            string _destBizID = Create_XML_Node(EsbNodes.DestBizID, B_DestBizID);
            string _operationType = Create_XML_Node(EsbNodes.OperationType, B_OperationType);
            //2-节点：<BodyControl>
            string _bodyControlValue = _sourceGUID + _sourceBizID + _destBizID + _operationType;
            string _bodyControl = Create_XML_Node(EsbNodes.BodyControl, _bodyControlValue);
            //2-节点：<Business>
            string _business = Create_XML_Node(EsbNodes.Business, B_Business);
            //3-节点：<EsbBody>
            string _esbBodyValue = _bodyControl + _business;
            string _esbBody = Create_XML_Node(EsbNodes.EsbBody, _esbBodyValue);

            return _esbBody;
        }

        //创建XML节点
        private string Create_XML_Node(EsbNodes inNodeType, string inNodeValue)
        {
            string _nodeType = inNodeType.ToString();
            string _ret = "<" + _nodeType + ">" + inNodeValue + "</" + _nodeType + ">";
            return _ret;
        }

        #endregion


        #region ESB报文：用于本地的Winform预览

        public virtual string Preview_CreateMessage(bool inIsFileFormat = false)
        {
            //消息格式的ESB数据
            string _ret = "<?xml version=\"1.0\"?>";
            _ret+= Environment.NewLine;
            _ret += "<EsbEnvelope xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns=\"http://hh2010.customs.gov.cn/common/schemas/ESBSchemas/\">";
            _ret += Environment.NewLine;
            _ret += Preview_Create_ESB_Header() + Preview_Create_ESB_Body();
            _ret += "</EsbEnvelope>";

            if (inIsFileFormat == true)
            {//文件格式的ESB数据
                byte[] buffer = Encoding.GetEncoding("utf-8").GetBytes(_ret);
                _ret = "";
                foreach (byte b in buffer) _ret += string.Format("%{0:X}", b);
            }

            return _ret;
        }

        //Esb报文：头部
        private string Preview_Create_ESB_Header()
        {
            //1-节点：<HeaderControl>各子节点
            string _name = Preview_Create_XML_Node(EsbNodes.Name, H_Name, 2);
            string _version = Preview_Create_XML_Node(EsbNodes.Version, H_Version, 2);
            string _from = Preview_Create_XML_Node(EsbNodes.From, H_From, 2);
            string _to = Preview_Create_XML_Node(EsbNodes.To, H_To, 2);
            string _operation = Preview_Create_XML_Node(EsbNodes.Operation, H_Operation, 2);
            string _sendTime = Preview_Create_XML_Node(EsbNodes.SendTime, H_SendTime, 2);
            string _GUID = Preview_Create_XML_Node(EsbNodes.GUID, H_GUID, 2);
            //2-节点：<HeaderControl>
            string _headerControlValue = _name + _version + _from + _to + _operation + _sendTime + _GUID;
            string _headerControl = Preview_Create_XML_Node(EsbNodes.HeaderControl, _headerControlValue, 1, true);
            //3-节点：<EsbHeader>
            string _esbHeader = Preview_Create_XML_Node(EsbNodes.EsbHeader, _headerControl, 0, true);

            return _esbHeader;
        }

        //Esb报文：实体
        private string Preview_Create_ESB_Body()
        {
            //1-节点：<BodyControl>各子节点
            string _sourceGUID = Preview_Create_XML_Node(EsbNodes.SourceGUID, B_SourceGUID, 2);
            string _sourceBizID = Preview_Create_XML_Node(EsbNodes.SourceBizID, B_SourceBizID, 2);
            string _destBizID = Preview_Create_XML_Node(EsbNodes.DestBizID, B_DestBizID, 2);
            string _operationType = Preview_Create_XML_Node(EsbNodes.OperationType, B_OperationType, 2);
            //2-节点：<BodyControl>
            string _bodyControlValue = _sourceGUID + _sourceBizID + _destBizID + _operationType;
            string _bodyControl = Preview_Create_XML_Node(EsbNodes.BodyControl, _bodyControlValue, 1, true);
            //2-节点：<Business>
            string _business = Preview_Create_XML_Node(EsbNodes.Business, B_Business, 1);
            //3-节点：<EsbBody>
            string _esbBodyValue = _bodyControl + _business;
            string _esbBody = Preview_Create_XML_Node(EsbNodes.EsbBody, _esbBodyValue, 0, true);

            return _esbBody;
        }

        //创建XML节点
        private string Preview_Create_XML_Node(EsbNodes inNodeType, string inNodeValue, int tabCount, bool isContain = false)
        {
            string oneTab = "   ";
            string _tab = "";
            for (int i = 1; i <= tabCount; i++)
            {
                _tab += oneTab;
            }

            string _nodeType = inNodeType.ToString();

            string _ret = _tab + "<" + _nodeType + ">";
            if (isContain) _ret += Environment.NewLine;
            _ret += inNodeValue;
            if (isContain) _ret += _tab;
            _ret += "</" + _nodeType + ">" + Environment.NewLine;

            return _ret;
        }

        #endregion

    }
}
