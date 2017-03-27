using System;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Configuration;
using System.ServiceModel.Channels;
using System.ServiceModel;
using SinoSZJS.Base.Authorize;

namespace SinoSZJS.Base.WCF.Client
{
    public class ClientInterpector : IClientMessageInspector
    {
        public void AfterReceiveReply(ref Message reply, object correlationState)
        {
        }

        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            var ticketHeader = MessageHeader.CreateHeader("SinoBestTicket", "http://SinoBestSZ.com", SinoBestTicketCache.CurrentTicket, false, "");
            request.Headers.Add(ticketHeader);
            var PostHeader = MessageHeader.CreateHeader("CurrentPostID", "http://SinoBestSZ.com", SessionClass.CurrentSinoUser.CurrentPost.PostID, false, "");
            request.Headers.Add(PostHeader);
            return null;
        }
    }
}
