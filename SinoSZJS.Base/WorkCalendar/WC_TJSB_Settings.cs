using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.WorkCalendar
{
    [DataContract]
    public class WC_TJSB_Settings
    {
        [DataMember]
        public int SBDay { get; set; }
        [DataMember]
        public string FTP_Addr { get; set; }
        [DataMember]
        public string FTP_Path { get; set; }
        [DataMember]
        public string FTP_User { get; set; }
        [DataMember]
        public string FTP_Pass { get; set; }
        [DataMember]
        public int FTP_Port { get; set; }
        [DataMember]
        public string Backup_Path { get; set; }
    }
}
