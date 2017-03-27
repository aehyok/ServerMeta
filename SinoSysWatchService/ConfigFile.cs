using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace SinoSysWatchService
{
    public class ConfigFile
    {
        private static int listenPort = 9999;
        public static int ListenPort
        {
            get
            {
                try
                {
                    string _ics_Channel_str = ConfigurationManager.AppSettings["ListenPort"].ToUpper();
                    listenPort = int.Parse(_ics_Channel_str);
                }
                catch (Exception ex)
                {
                    listenPort = 9999;
                }
                return listenPort;
            }

        }

    }
}
