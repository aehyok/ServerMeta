using System;
using System.ServiceModel;
using SinoSZJS.Base.SystemLog;

namespace SinoSZJS.Base.WCF.Client
{
	public static class WcfExtensions
	{
		public static void Using<T>(this T client, Action<T> work)
			where T : ICommunicationObject
		{
			try
			{
				work(client);
				if (client.State != System.ServiceModel.CommunicationState.Faulted)
				{
					client.Close();
				}
			}
			catch (CommunicationException e)
			{
				client.Abort();
			}
			catch (TimeoutException e)
			{
				client.Abort();
			}
			catch (Exception e)
			{
				client.Abort();
			}
		}
	}
}
