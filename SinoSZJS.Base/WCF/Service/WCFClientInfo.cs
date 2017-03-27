using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace SinoSZJS.Base.WCF.Service
{
    public class WCFClientInfo
    {
        public static string IPAddr
        {
            get
            {
                //提供方法执行的上下文环境
                OperationContext context = OperationContext.Current;
                //获取传进的消息属性
                MessageProperties properties = context.IncomingMessageProperties;
                //获取消息发送的远程终结点IP和端口
                RemoteEndpointMessageProperty endpoint = properties[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;
                return endpoint.Address;
            }
        }
    }
}
