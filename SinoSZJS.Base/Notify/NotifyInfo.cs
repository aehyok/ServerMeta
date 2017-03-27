using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZJS.Base.Notify
{
        public class NotifyInfo
        {
                private string id = "";
                private string title = "";
                private string context = "";
                private string fbdwid = "";
                private string fbdwmc = "";
                private string fbyhid = "";
                private string fbyhmc = "";
                private string telNum = "";
                private string email = "";
                private DateTime sendTime = DateTime.MinValue;

                public NotifyInfo() { }
                public NotifyInfo(string _id, string _title, string _context, string _fbdwid, string _fbdwmc, string _fbyhid, string _fbyhmc, string _telnum, string _email,DateTime _sendTime)
                {
                        id = _id;
                        title = _title;
                        context = _context;
                        fbdwid = _fbdwid;
                        fbdwmc = _fbdwmc;
                        fbyhid = _fbyhid;
                        fbyhmc = _fbyhmc;
                        telNum = _telnum;
                        email = _email;
                        sendTime = _sendTime;
                }

                public string ID
                {
                        get { return id; }
                        set { id = value; }
                }

                public string TelNum
                {
                        get { return telNum; }
                        set { telNum = value; }
                }

                public string Email
                {
                        get { return email; }
                        set { email = value; }
                }

                public DateTime SendTime
                {
                        get { return sendTime; }
                        set { sendTime = value; }
                }


                public string Title
                {
                        get { return title; }
                        set { title = value; }
                }

                public string Context
                {
                        get { return context; }
                        set { context = value; }
                }

                public string FBdwid
                {
                        get { return fbdwid; }
                        set { fbdwid = value; }
                }

                public string FBdwmc
                {
                        get { return fbdwmc; }
                        set { fbdwmc = value; }
                }

                public string FByhid
                {
                        get { return fbyhid; }
                        set { fbyhid = value; }
                }

                public string FByhmc
                {
                        get { return fbyhmc; }
                        set { fbyhmc = value; }
                }
        }
}
