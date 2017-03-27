using System;

namespace SinoSZJS.Base.Esb
{
    public class EsbMessageHZ2011 : EsbMessageBase
    {
        private string m_DefName = "JSBAPT";
        public override string H_Name
        {
            get { return m_DefName; }
            set { m_DefName = value; }
        }

        private string m_DefVersion = "1.0.0.0";
        public override string H_Version
        {
            get { return m_DefVersion; }
            set { m_DefVersion = value; }
        }

        public override string H_From
        {
            get { return "uddi:chinacustoms:xinxizhongxin:js2008esbprocesswcf"; }
        }

        public override string H_To
        {
            get { return "uddi:chinacustoms:4200:hztranswcfservice"; }
        }

        private string m_DefOperation = "ServiceHandler_JS4HZ";
        public override string H_Operation
        {
            get { return m_DefOperation; }
            set { m_DefOperation = value; }
        }

        public override string H_SendTime
        {
            get { return DateTime.Now.ToString("yyyy-MM-dd HH:mm"); }
        }

        public override string H_GUID
        {
            get { return Guid.NewGuid().ToString(); }
        }

        private string m_B_SourceGUID = "";
        public override string B_SourceGUID
        {
            get
            {
                if (m_B_SourceGUID == "")
                {
                    m_B_SourceGUID = Guid.NewGuid().ToString();
                }
                return m_B_SourceGUID;
            }

            set { m_B_SourceGUID = value; }
        }

        private string m_DefSourceBizID = "[发送方海关]_[发送应用代码]";
        public override string B_SourceBizID
        {
            get { return m_DefSourceBizID; }
            set { m_DefSourceBizID = value; }
        }

        private string m_DefDestBizID = "[接收方海关]_[接收应用代码]";
        public override string B_DestBizID
        {
            get { return m_DefDestBizID; }
            set { m_DefDestBizID = value; }
        }

        private string m_DefOperationType = "[接收方服务Code]";
        public override string B_OperationType
        {
            get { return m_DefOperationType; }
            set { m_DefOperationType = value; }
        }

        private string m_DefBusiness = "";
        public override string B_Business
        {
            get { return m_DefBusiness; }
            set { m_DefBusiness = value; }
        }


    }
}
