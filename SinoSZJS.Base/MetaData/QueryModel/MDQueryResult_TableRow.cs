using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.MetaData.QueryModel
{
    [DataContract]
    public class MDQueryResult_TableRow
    {
        /// <summary>
        /// 表名称
        /// </summary>
        [DataMember]
        private Dictionary<string, object> _data = new Dictionary<string, object>();


        /// <summary>
        /// 记录列值
        /// </summary>
        [DataMember]
        public Dictionary<string, object> Values
        {
            get { return _data; }
            set { _data = value; }
        }

    }


}
