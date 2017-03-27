using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.XtraGrid.Localization;


namespace SinoSZClientBase
{
    public class ChinaSimpleGridLocalizer : DevExpress.XtraGrid.Localization.GridLocalizer
    {
        public override string GetLocalizedString(DevExpress.XtraGrid.Localization.GridStringId id)
        {

            switch (id)
            {
                // 汉化
                case GridStringId.CustomFilterDialogCancelButton: return "取消";
                case GridStringId.CustomFilterDialogCaption: return "字段名称";
                //case GridStringId.CustomFilterDialogConditionBlanks: return "空";
                //case GridStringId.CustomFilterDialogConditionEQU: return "等于";
                //case GridStringId.CustomFilterDialogConditionLike: return "包含";
                //case GridStringId.CustomFilterDialogConditionGT: return "大于";
                //case GridStringId.CustomFilterDialogConditionGTE: return "大于等于";
                //case GridStringId.CustomFilterDialogConditionLT: return "小于";
                //case GridStringId.CustomFilterDialogConditionLTE: return "小于等于";
                //case GridStringId.CustomFilterDialogConditionNEQ: return "不等于";
                //case GridStringId.CustomFilterDialogConditionNonBlanks: return "非空值";
                //case GridStringId.CustomFilterDialogConditionNotLike: return "不包含";
                case GridStringId.CustomFilterDialogFormCaption: return "筛选条件";
                case GridStringId.CustomFilterDialogRadioAnd: return "并且";
                case GridStringId.CustomFilterDialogRadioOr: return "或者";
                case GridStringId.MenuColumnBestFit: return "自动适应大小";
                case GridStringId.MenuColumnBestFitAllColumns: return "全部自动适应大小";
                case GridStringId.MenuColumnClearFilter: return "清除筛选条件";
                case GridStringId.MenuColumnSortAscending: return "升序";
                case GridStringId.MenuColumnSortDescending: return "降序";
                case GridStringId.MenuFooterAverage: return "求平均值";
                case GridStringId.MenuFooterAverageFormat: return "平均值={0}";
                case GridStringId.MenuFooterCount: return "求记录数";
                case GridStringId.MenuFooterCountFormat: return "记录数={0}";
                case GridStringId.PopupFilterAll: return "[全部]";
                case GridStringId.PopupFilterBlanks: return "[空]";
                case GridStringId.PopupFilterCustom: return "[自定义]";
                case GridStringId.PopupFilterNonBlanks: return "[非空值]";
                case GridStringId.MenuFooterNone: return "清除";
                case GridStringId.MenuFooterMax: return "最大值";
                case GridStringId.MenuFooterMaxFormat: return "最大值={0}";
                case GridStringId.MenuFooterMin: return "最小值";
                case GridStringId.MenuFooterMinFormat: return "最小值={0}";
                case GridStringId.MenuFooterSum: return "求总和";
                case GridStringId.MenuFooterSumFormat: return "总和={0}";
                case GridStringId.MenuGroupPanelClearGrouping: return "清除分组";
                case GridStringId.MenuGroupPanelFullCollapse: return "全部收缩";
                case GridStringId.MenuGroupPanelFullExpand: return "全部展开";

                case GridStringId.CustomizationColumns: return "CustomizationColumns";
                case GridStringId.CustomizationCaption: return "字段收藏夹";
                case GridStringId.MenuColumnColumnCustomization: return "字段收藏功能";
                case GridStringId.MenuColumnGroup: return "以此字段分组";
                case GridStringId.GridGroupPanelText: return "[ 分组栏 ]";
                case GridStringId.MenuColumnClearSorting: return "清除排序";
                case GridStringId.MenuColumnFilterEditor: return "筛选编辑器";
                case GridStringId.MenuColumnGroupBox: return @"显示/隐藏分组栏";
                case GridStringId.FilterBuilderApplyButton: return "应用查询条件";
                case GridStringId.FilterBuilderCancelButton: return "取消";
                case GridStringId.FilterBuilderCaption: return "筛选条件编辑器";
                case GridStringId.FilterBuilderOkButton: return "确定";
                case GridStringId.MenuColumnUnGroup: return "取消分组";

                // ...
            }
            return base.GetLocalizedString(id);
        }
    }
}
