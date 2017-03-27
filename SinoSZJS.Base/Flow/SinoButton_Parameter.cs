using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.Flow
{
  
    [DataContract]
    public class SinoButton_Parameter
    {
        [DataMember]
        public string ActionID { get; set; }
        [DataMember]
        public string DisplayName { get; set; }
        [DataMember]
        public string ActionName { get; set; }
        [DataMember]
        public string LinkUrl { get; set; }
        [DataMember]
        public int ButWidth { get; set; }
        [DataMember]
        public int ButHeight { get; set; }

        public SinoButton_Parameter()
        { }

        public SinoButton_Parameter(string _actionID,string disName, string _actionName, string urllink, int width, int height)
        {
            ActionID = _actionID;
            DisplayName = disName;
            LinkUrl = urllink;
            ButWidth = width;
            ButHeight = height;
            ActionName = _actionName;
        }

    }
}
