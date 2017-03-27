using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.V2.Authorize
{
    [DataContract]
    public class SinoOrganize
    {
        //是否可选
        [DataMember]
        public bool CanSeleceted { get; set; }

        /// <summary>
        /// 显示顺序
        /// </summary>
        [DataMember]
        public int DisplayOrder { get; set; }

        /// <summary>
        /// 单位ID码
        /// </summary>
        [DataMember]
        public decimal Code { get; set; }
        /// <summary>
        /// 父单位ID码
        /// </summary>
        [DataMember]
        public decimal FatherCode { get; set; }
        /// <summary>
        /// 单位名称
        /// </summary>
        [DataMember]
        public string Name { get; set; }
        /// <summary>
        /// 单位全称
        /// </summary>
        [DataMember]
        public string FullName { get; set; }
        /// <summary>
        /// 单位性质　(职能处室\隶属关处)
        /// </summary>
        [DataMember]
        public string Function { get; set; }

        /// <summary>
        /// 单位代码
        /// </summary>
        [DataMember]
        public string DWDM { get; set; }

        public SinoOrganize()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        public SinoOrganize(decimal code, decimal fatherCode, string dwdm, string name, string fullName, string function, int order)
        {
            this.Code = code;
            this.DWDM = dwdm;
            this.FatherCode = fatherCode;
            this.Name = name;
            this.FullName = fullName;
            this.Function = function;
            this.DisplayOrder = order;
        }

        public SinoOrganize(decimal code, decimal fatherCode, string dwdm, string name, string fullName, string function, int order, bool canSelected)
        {
            this.Code = code;
            this.DWDM = dwdm;
            this.FatherCode = fatherCode;
            this.Name = name;
            this.FullName = fullName;
            this.Function = function;
            this.DisplayOrder = order;
            this.CanSeleceted = canSelected;
        }
    }
}
