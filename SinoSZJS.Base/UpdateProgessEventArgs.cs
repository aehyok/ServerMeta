using System;
using System.Collections.Generic;
using System.Text;


namespace SinoSZJS.Base
{
        public class UpdateProgessEventArgs : EventArgs
        {
                private string _msg = "";
                public string Message
                {
                        get { return _msg; }
                        set { _msg = value; }
                }

                public UpdateProgessEventArgs()
                {
                }

                public UpdateProgessEventArgs(string _message)
                {
                        _msg = _message;
                        
                }
        }
}
