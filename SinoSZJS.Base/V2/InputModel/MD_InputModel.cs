using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.V2.InputModel
{
    /// <summary>
    /// added by lqm 2014.03.25
    /// </summary>
    [DataContract]
    public class MD_InputModel
    {
        /// <summary>
        /// 录入模型Id
        /// </summary>
        [DataMember]
        public string Id { get; set; }

        /// <summary>
        /// 录入模型命名空间
        /// </summary>
        [DataMember]
        public string NameSpace { get; set; }
        
        /// <summary>
        /// 录入模型名称
        /// </summary>
        [DataMember]
        public string ModelName { get; set; }

        /// <summary>
        /// 录入模型类型
        /// </summary>
        [DataMember]
        public string ModelType { get; set; }
        
        /// <summary>
        /// 录入模型描述
        /// </summary>
        [DataMember]
        public string Descript { get; set; }
        
        /// <summary>
        /// 录入模型名称
        /// </summary>
        [DataMember]
        public string DisplayName { get; set; }

        /// <summary>
        /// 录入模型显示顺序
        /// </summary>
        [DataMember]
        public int DisplayOrder { get; set; }

        /// <summary>
        /// 录入模型记录删除规则（暂时用不到此字段）
        /// </summary>
        [DataMember]
        public string DeleteRule { get; set; }

        /// <summary>
        /// 单位代码
        /// </summary>
        [DataMember]
        public string DWDM { get; set; }
        
        /// <summary>
        /// 初始化算法指标
        /// </summary>
        [DataMember]
        public string InitGuideLine { get; set; }

        /// <summary>
        /// 取数据算法指标
        /// </summary>
        [DataMember]
        public string GetDataGuideLine { get; set; }     //下面文件无此字段
        
        /// <summary>
        /// 取新记录算法指标
        /// </summary>
        [DataMember]
        public string GetNewRecordGuideLine { get; set; }

        /// <summary>
        /// 参数
        /// </summary>
        [DataMember]
        public string Param { get; set; }

        /// <summary>
        /// 参数类型
        /// </summary>
        [DataMember]
        public string ParamterType { get; set; }
        
        /// <summary>
        /// 是否为混合模型
        /// </summary>
        [DataMember]
        public bool IsMixModel { get; set; }

        /// <summary>
        /// 资源类型
        /// </summary>
        [DataMember]
        public string ResourceType { get; set; }

        /// <summary>
        /// 集成应用
        /// </summary>
        [DataMember]
        public string IntegretedApplication { get; set; }

        /// <summary>
        /// 写入前操作
        /// </summary>
        [DataMember]
        public string BeforeWrite { get; set; }
        
        /// <summary>
        /// 写入后操作
        /// </summary>
        [DataMember]
        public string AfterWrite { get; set; }

        /// <summary>
        /// 录入模型全名称(命名空间+录入模型名称)
        /// </summary>
        public string ModelFullName
        {
            get
            {
                return string.Format("{0}.{1}", NameSpace, ModelName);
            }
        }

        /// <summary>
        /// 显示名称
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return DisplayName;
        }

        /// <summary>
        /// 录入模型字段列表
        /// </summary>
        [DataMember]
        public List<MD_InputModel_Column> Columns { get; set; }

        /// <summary>
        /// 录入模型字段分组
        /// </summary>
        [DataMember]
        public List<MD_InputModel_ColumnGroup> Groups { get; set; }

        /// <summary>
        /// 子模型列表
        /// </summary>
        [DataMember]
        public List<MD_InputModel_Child> ChildInputModel { get; set; }

        /// <summary>
        /// 写入表列表
        /// </summary>
        [DataMember]
        public List<MD_InputModel_SaveTable> WriteTableNames { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string OrderField { get; set; }
        
        /// <summary>
        /// 表名称
        /// </summary>
        [DataMember]
        public string TableName { get; set; }

        /// <summary>
        /// 空构造函数
        /// </summary>
        public MD_InputModel() { }

        /// <summary>
        /// 带参数的构造函数
        /// </summary>
        public MD_InputModel(string id, string nameSpace, string modelName, string descript, string displayName, int displayOrder, string param, string deleteRule, string dwdm, string inputegretedApplication, string resourecType)
        {
            Id = id;
            NameSpace = nameSpace;
            ModelName = modelName;
            Descript = descript;
            DisplayName = displayName;
            DisplayOrder = displayOrder;
            Param = param;
            DeleteRule = deleteRule;
            DWDM = dwdm;
            IntegretedApplication = inputegretedApplication;
            ResourceType = resourecType;

        }
    }
}
