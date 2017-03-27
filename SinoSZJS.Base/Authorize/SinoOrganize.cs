using System;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.Authorize
{
    /// <summary>
    /// SinoOrganize 的摘要说明。
    /// 单位组织机构
    /// 2006-11-4
    /// </summary>        
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

        public SinoOrganize(decimal _code, decimal _fatherCode, string _dwdm, string _name, string _fullName, string _function, int _order)
        {
            this.Code = _code;
            this.DWDM = _dwdm;
            this.FatherCode = _fatherCode;
            this.Name = _name;
            this.FullName = _fullName;
            this.Function = _function;
            this.DisplayOrder = _order;
        }

        public SinoOrganize(decimal _code, decimal _fatherCode, string _dwdm, string _name, string _fullName, string _function, int _order, bool _canSelected)
        {
            this.Code = _code;
            this.DWDM = _dwdm;
            this.FatherCode = _fatherCode;
            this.Name = _name;
            this.FullName = _fullName;
            this.Function = _function;
            this.DisplayOrder = _order;
            this.CanSeleceted = _canSelected;
        }
    }
}
