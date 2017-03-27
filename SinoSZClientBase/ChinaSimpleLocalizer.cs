using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.XtraEditors.Controls;

namespace SinoSZClientBase
{
        public class ChinaSimpleLocalizer : Localizer
        {
                public override string GetLocalizedString(StringId id)
                {
                        switch (id)
                        {
                                // ...
                                case StringId.DateEditToday: return "今天";
                                case StringId.DateEditClear: return "清空";
                                case StringId.Cancel: return "取消";
                                case StringId.OK: return "确定";
                                case StringId.DataEmpty: return "空";
                                case StringId.InvalidValueText: return "录入值不正确";
                                case StringId.PictureEditMenuCopy: return "复制";
                                case StringId.PictureEditMenuCut: return "剪切";
                                case StringId.PictureEditMenuDelete: return "删除";
                                case StringId.PictureEditMenuLoad: return "读取";
                                case StringId.PictureEditMenuPaste: return "粘贴";
                                case StringId.PictureEditMenuSave: return "保存";
                                case StringId.TextEditMenuCopy: return "复制";
                                case StringId.TextEditMenuCut: return "剪切";
                                case StringId.TextEditMenuDelete: return "删除";
                                case StringId.TextEditMenuPaste: return "粘贴";
                                case StringId.TextEditMenuSelectAll: return "全选";
                                case StringId.TextEditMenuUndo: return "取消";

                                case StringId.CheckChecked: return "已选";
                                case StringId.CheckUnchecked: return "未选";
                               
                                case StringId.FilterClauseEquals: return "等于";
                                case StringId.FilterClauseGreater: return "大于";
                                case StringId.FilterClauseGreaterOrEqual: return "大于等于";
                                case StringId.FilterClauseIsNotNull: return "非空值";
                                case StringId.FilterClauseIsNull: return "空值";
                                case StringId.FilterClauseLess: return "小于";
                                case StringId.FilterClauseLessOrEqual: return "小于等于";
                                case StringId.FilterClauseLike: return "近似";
                                case StringId.FilterClauseNoneOf: return "非集合内";
                                case StringId.FilterClauseNotBetween: return "不在范围";
                                case StringId.FilterClauseNotLike: return "不近似"; 
                                case StringId.FilterClauseAnyOf: return "集合";
                                case StringId.FilterClauseBeginsWith: return "起始值为";
                                case StringId.FilterClauseBetween: return "在范围内";
                                case StringId.FilterClauseBetweenAnd: return base.GetLocalizedString(id);
                                case StringId.FilterClauseContains: return "包含";
                                case StringId.FilterClauseDoesNotContain: return "不包含";
                                case StringId.FilterClauseDoesNotEqual: return "不等于";
                                case StringId.FilterClauseEndsWith: return "结束值为";
                                       

                             
                                
                                // ...
                        }
                        return base.GetLocalizedString(id);
                }

        }
}
