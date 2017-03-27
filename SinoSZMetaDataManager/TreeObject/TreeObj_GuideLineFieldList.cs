using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.XtraTreeList;
using System.ComponentModel;

namespace SinoSZMetaDataManager.TreeObject
{
        public class TreeObj_GuideLineFieldList : BindingList<TreeObj_GuidelLineFieldItem>, TreeList.IVirtualTreeListData
        {
                #region 实现　IVirtualTreeListData　接口

                public void VirtualTreeGetCellValue(VirtualTreeGetCellValueInfo info)
                {
                        TreeObj_GuidelLineFieldItem obj = info.Node as TreeObj_GuidelLineFieldItem;
                        switch (info.Column.FieldName)
                        {
                                case "Name":
                                        info.CellData = obj.Name;
                                        break;
                                case "DisplayTitle":
                                        info.CellData = obj.DisplayTitle;
                                        break;
                                case "Type":
                                        info.CellData = obj.Type;
                                        break;
                                case "DisplayOrder":
                                        info.CellData = obj.DisplayOrder;
                                        break;
                                case "DisplayWidth":
                                        info.CellData = obj.DisplayWidth;
                                        break;
                                case "DisplayFormat":
                                        info.CellData = obj.DisplayFormat;
                                        break;
                                case "TextAlign":
                                        info.CellData = obj.TextAlign;
                                        break;        
                                case "CanHide":
                                        info.CellData = obj.CanHide;
                                        break;        

                        }
                }

                public void VirtualTreeGetChildNodes(VirtualTreeGetChildNodesInfo info)
                {
                        TreeObj_GuidelLineFieldItem obj = info.Node as TreeObj_GuidelLineFieldItem;
                        info.Children = obj.Children;
                }

                public void VirtualTreeSetCellValue(VirtualTreeSetCellValueInfo info)
                {
                        TreeObj_GuidelLineFieldItem obj = info.Node as TreeObj_GuidelLineFieldItem;
                        switch (info.Column.FieldName)
                        {
                                case "Name":
                                        obj.Name = (string)info.NewCellData;
                                        break;
                                case "DisplayTitle":
                                        obj.DisplayTitle = (string)info.NewCellData;
                                        break;
                                case "Type":
                                        obj.Type = (string)info.NewCellData;
                                        break;
                                case "DisplayOrder":
                                        obj.DisplayOrder = int.Parse(info.NewCellData.ToString());
                                        break;
                                case "DisplayWidth":
                                        obj.DisplayWidth = int.Parse(info.NewCellData.ToString());
                                        break;
                                case "DisplayFormat":
                                        obj.DisplayFormat = (string)info.NewCellData;
                                        break;
                                case "TextAlign":
                                        obj.TextAlign = (string)info.NewCellData;
                                        break;
                                case "CanHide":
                                        obj.CanHide = (bool)info.NewCellData;
                                        break;   
                        }
                }

                #endregion

                protected override void InsertItem(int index, TreeObj_GuidelLineFieldItem item)
                {
                        item.Owner = this;
                        base.InsertItem(index, item);
                }
        }
}
