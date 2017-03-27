using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SinoSZJS.Base.V2.InputModel
{
    /// <summary>
    /// added by lqm 录入模型列字段定义
    /// </summary>
    [DataContract]
    public class MD_InputModel_Column
    {
        /// <summary>
        /// 列Id
        /// </summary>
        [DataMember]
        public string ColumnID { get; set; }
        
        /// <summary>
        /// 字段名称
        /// </summary>
        [DataMember]
        public string ColumnName { get; set; }

        /// <summary>
        /// 显示名称
        /// </summary>
        [DataMember]
        public string DisplayName { get; set; }

        /// <summary>
        /// 显示顺序
        /// </summary>
        [DataMember]
        public int DisplayOrder { get; set; }

        /// <summary>
        /// 录入字符的最大长度
        /// </summary>
        [DataMember]
        public int MaxInputLength { get; set; }
        
        /// <summary>
        /// 字段类型
        /// </summary>
        [DataMember]
        public string ColumnType { get; set; }
        
        /// <summary>
        /// 录入模型Id
        /// </summary>
        [DataMember]
        public string InputModelId { get; set; }
        [DataMember]
        public bool CanSave { get; set; }
        
        /// <summary>
        /// 是否显示此字段
        /// </summary>
        [DataMember]
        public bool CanDisplay { get; set; }

        /// <summary>
        /// 是否为计算字段
        /// </summary>
        [DataMember]
        public bool IsCompute { get; set; }

        /// <summary>
        /// 是否只读
        /// </summary>
        [DataMember]
        public bool ReadOnly { get; set; }

        /// <summary>
        /// 单位代码
        /// </summary>
        [DataMember]
        public string DWDM { get; set; }

        /// <summary>
        /// 默认值
        /// </summary>
        [DataMember]
        public string DefaultValue { get; set; }

        /// <summary>
        /// 录入规则
        /// </summary>
        [DataMember]
        public string InputRule { get; set; }

        /// <summary>
        /// 数据变更处理事件
        /// </summary>
        [DataMember]
        public string DataChangedEvent { get; set; }

        /// <summary>
        /// 可编辑规则
        /// </summary>
        [DataMember]
        public string CanEditRule { get; set; }
        
        /// <summary>
        /// 字段宽度
        /// </summary>
        [DataMember]
        public int Width { get; set; }
        
        /// <summary>
        /// 行高度
        /// </summary>
        [DataMember]
        public int LineHeight { get; set; }
        
        /// <summary>
        /// 文本对其方式
        /// </summary>
        [DataMember]
        public int TextAlign { get; set; }

        /// <summary>
        /// 编辑格式
        /// </summary>
        [DataMember]
        public string EditFormat { get; set; }

        /// <summary>
        /// 是否必填项
        /// </summary>
        [DataMember]
        public bool Required { get; set; }

        /// <summary>
        /// 工具提示文本
        /// </summary>
        [DataMember]
        public string ToolTipText { get; set; }
        
        /// <summary>
        /// 展示格式
        /// </summary>
        [DataMember]
        public string DisplayFormat { get; set; }

        /// <summary>
        /// 默认显示
        /// </summary>
        [DataMember]
        public bool DefaultShow { get; set; }

        public MD_InputModel_Column() { }
        public MD_InputModel_Column(string id, string columnName, string displayName, string columnType, int order, string inputModelId,
                                                                bool canSave, bool canDisplay, bool isCompute, bool readOnly, string dwdm, string defalutValue,
                                                                string inputRule, string editRule, int width, int height, int align, string editFormat, string displayFormat,
                                                                bool required, string toolTipText, int maxLength, string dataChangedEvent)
        {
            Required = required;
            MaxInputLength = maxLength;
            ToolTipText = toolTipText;
            TextAlign = align;
            EditFormat = editFormat;
            DisplayFormat = displayFormat;
            ColumnID = id;
            ColumnName = columnName;
            DisplayName = displayName;
            ColumnType = columnType;
            DisplayOrder = order;
            InputModelId = inputModelId;
            CanSave = canSave;
            CanDisplay = canDisplay;
            IsCompute = isCompute;
            ReadOnly = readOnly;
            DWDM = dwdm;
            DefaultValue = defalutValue;
            InputRule = inputRule;
            CanEditRule = editRule;
            Width = width;
            LineHeight = height;
            DataChangedEvent = dataChangedEvent;
        }
    }
}
