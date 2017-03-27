using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.User
{
    public class ConCheckListModel
    {
        /// <summary>
        /// 复选框名称
        /// </summary>
        [DataMember]
        public string CheckListName { get; set; }
        /// <summary>
        /// 岗位用户列表数据
        /// </summary>
        [DataMember]
        public List<PostUserList> DataList { get; set; }

        public ConCheckListModel() { }

        public ConCheckListModel(List<PostUserList> _dataList, string _checkListName)
        {
            DataList = _dataList;
            CheckListName = _checkListName;
        }


    }
}
