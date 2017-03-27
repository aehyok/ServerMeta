using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.V2.Flow
{
    /// </summary>
    [DataContract]
    public class Flow_Direction
    {
        [DataMember]
        public int RowIndex { get; set; }

        [DataMember]
        public List<Flow_DirectionUnit> Flow_DirectionList { get; set; }
    }
}
