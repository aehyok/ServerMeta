using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.XtraTreeList;
using System.ComponentModel;

namespace SinoSZClientUser.TreeObject
{
        public class TObj_RightItemList : BindingList<TObj_RightItem>, TreeList.IVirtualTreeListData
        {
                #region 实现　IVirtualTreeListData 接口

                public void VirtualTreeGetCellValue(VirtualTreeGetCellValueInfo info)
                {
                        TObj_RightItem obj = info.Node as TObj_RightItem;
                        switch (info.Column.FieldName)
                        {
                                case "ID":
                                        info.CellData = obj.ID;
                                        break;
                                case "FatherID":
                                        info.CellData = obj.FatherID;
                                        break;
                                case "Name":
                                        info.CellData = obj.Name;
                                        break;
                                case "HaveRight":
                                        info.CellData = obj.HaveRight;
                                        break;
                        }
                }

                public void VirtualTreeGetChildNodes(VirtualTreeGetChildNodesInfo info)
                {
                        TObj_RightItem obj = info.Node as TObj_RightItem;
                        info.Children = obj.Children;
                }

                public void VirtualTreeSetCellValue(VirtualTreeSetCellValueInfo info)
                {
                        TObj_RightItem obj = info.Node as TObj_RightItem;
                        switch (info.Column.FieldName)
                        {
                                case "ID":
                                        obj.ID = (string)info.NewCellData;
                                        break;
                                case "FatherID":
                                        obj.FatherID = (string)info.NewCellData;
                                        break;
                                case "Name":
                                        obj.Name = (string)info.NewCellData;
                                        break;
                                case "HaveRight":
                                        obj.HaveRight = (bool)info.NewCellData;
                                        break;
                        }
                }

                #endregion

                protected override void InsertItem(int index, TObj_RightItem item)
                {
                        item.Owner = this;
                        base.InsertItem(index, item);
                }
        }
}
