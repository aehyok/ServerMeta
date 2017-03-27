using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZJS.Base.SystemLog
{
        public class QueryLogRecord
        {
                private string id = "";
                private DateTime czsj = DateTime.Now;
                private string userName = "";
                private string queryString = "";

                public QueryLogRecord() { }
                public QueryLogRecord(string _id, DateTime _czsj, string _czr, string _querystring)
                {
                        id = _id;
                        czsj = _czsj;
                        userName = _czr;
                        queryString = _querystring;
                }

                public string ID
                {
                        get { return id; }
                        set { id = value; }
                }
                public DateTime SJ
                {
                        get { return czsj; }
                        set { czsj = value; }
                }
                public string UserName
                {
                        get { return userName; }
                        set { userName = value; }
                }
                public string QueryString
                {
                        get { return queryString; }
                        set { queryString = value; }
                }



        }
}
