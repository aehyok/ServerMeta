using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Reflection;

namespace SinoSZClientSysManager.GDSManager
{
    public class ExcuteWCF
    {
        public static object ExecuteMethod<T>(string pUrl, string BindingType, string pMethodName, params object[] pParams)
        {
            EndpointAddress address = new EndpointAddress(pUrl);
            Binding bindinginstance = null;
            switch (BindingType)
            {
                case "TcpBinding":
                    NetTcpBinding ws = new NetTcpBinding();
                    ws.MaxReceivedMessageSize = 20971520;
                    ws.Security.Mode = SecurityMode.None;
                    bindinginstance = ws;
                    break;
                case "HttpBinding":
                    BasicHttpBinding bhb = new BasicHttpBinding();
                    bhb.MaxReceivedMessageSize = 20971520;
                    bhb.Security.Mode = BasicHttpSecurityMode.None;
                    bindinginstance = bhb;
                    break;
                case "wsHttpBinding":
                    WSHttpBinding wshb = new WSHttpBinding();
                    wshb.MaxReceivedMessageSize = 20971520;
                    wshb.Security.Mode = SecurityMode.None;
                    bindinginstance = wshb;
                    break;

            }

            using (ChannelFactory<T> channel = new ChannelFactory<T>(bindinginstance, address))
            {
                T instance = channel.CreateChannel();
                using (instance as IDisposable)
                {
                    try
                    {
                        Type type = typeof(T);
                        MethodInfo mi = type.GetMethod(pMethodName);
                        return mi.Invoke(instance, pParams);
                    }
                    catch (TimeoutException)
                    {
                        (instance as ICommunicationObject).Abort();
                        throw;
                    }
                    catch (CommunicationException)
                    {
                        (instance as ICommunicationObject).Abort();
                        throw;
                    }
                    catch (Exception vErr)
                    {
                        (instance as ICommunicationObject).Abort();
                        throw;
                    }
                }
            }
        }
    }
}
