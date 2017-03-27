using System;
using System.Collections.Generic;
using System.Text;
using SinoSZJS.Base.MetaData.QueryModel;


namespace SinoSZMetaDataQuery.DataSearch
{
        [Serializable]
        public class SearhProgressState
        {
                private string _msg = "";
                private List<MDSearch_ResultDataIndex> _resultData = new List<MDSearch_ResultDataIndex>();

                public string Message
                {
                        get { return _msg; }
                        set { _msg = value; }
                }

                public List<MDSearch_ResultDataIndex> ResultData
                {
                        get { return _resultData; }
                        set { _resultData = value; }
                }

                public SearhProgressState() { }

                public SearhProgressState(string message, List<MDSearch_ResultDataIndex> _data)
                {
                        this._msg = message;
                        this._resultData = _data;
                }
        }
}
