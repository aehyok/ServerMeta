using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Data;

namespace SinoSZJS.Base.InputModel
{

    [DataContract(IsReference = true)]
    public class MD_InputEntity
    {
        [DataMember]
        public string InputModelName { get; set; }
        [DataMember]
        public Dictionary<string, string> InputData { get; set; }
        [DataMember]
        public bool IsNewData { get; set; }   ///有修改   IsNew改为IsNewData
        [DataMember]                                     ///
        public bool IsNewFlow { get; set; } //是否写流程 （FJY）添加
        #region  lqm 合并添加  2012/9/20
        [DataMember]
        public Dictionary<string, string> ChildInputData { get; set; }
        //public bool HaveChildData(string _index)
        //{
        //    if (ChildInputData.ContainsKey(_index))
        //    {
        //        DataTable _dt = ChildInputData[_index] as DataTable;
        //        DataView _dv = new DataView(_dt, "", "", DataViewRowState.CurrentRows);
        //        return (_dv.Count > 0);
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
        public MD_InputEntity() { }
        public MD_InputEntity(string _inputModelName)
        {
            InputModelName = _inputModelName;
        }
        #endregion

        #region 2013.09.25 added by lqm
        [DataMember]
        public string BeforeWrite { get; set; }
        [DataMember]
        public string AfterWrite { get; set; }
        #endregion
    }
}
