using System;
using System.ServiceModel.Dispatcher;
using System.ServiceModel;
using System.ServiceModel.Channels;
using SinoSZJS.Base.Authorize;

namespace SinoSZJS.Base.WCF.Service
{
    public class ServiceInterpector : IDispatchMessageInspector
    {
        #region IDispatchMessageInspector Members

        public object AfterReceiveRequest(ref System.ServiceModel.Channels.Message request, System.ServiceModel.IClientChannel channel, System.ServiceModel.InstanceContext instanceContext)
        {
            string ticket = GetCurrentTicket();
            string ipAddr = GetIPAddress();

            if (!TicketLib.Check(ticket)) throw new FaultException("Invalid User!");
            return null;
        }

        public static string GetCurrentTicket()
        {
            var ticket = GetHeaderValue("SinoBestTicket");
            return ticket.ToString();
        }

        private string GetIPAddress()
        {
            MessageProperties properties = OperationContext.Current.IncomingMessageProperties;
            //获取消息发送的远程终结点IP和端口
            RemoteEndpointMessageProperty endpoint = properties[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;
            return endpoint.Address;
        }

        public void BeforeSendReply(ref System.ServiceModel.Channels.Message reply, object correlationState)
        {
        }

        public static string GetCurrentPost()
        {
            return GetHeaderValue("CurrentPostID");
        }

        private static string GetHeaderValue(string name, string ns = "http://SinoBestSZ.com")
        {
            return GetRequestHearderValue(name, ns);
        }

        public static string GetRequestHearderValue(string name, string ns)
        {
            var headers = OperationContext.Current.IncomingMessageHeaders;
            var index = headers.FindHeader(name, ns);
            if (index > -1)
                return headers.GetHeader<string>(index);
            else
                return null;
        }
        #endregion

        
    }
}
