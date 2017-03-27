using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using DevExpress.XtraTreeList;

namespace SinoSZClientUser.TreeObject
{
        public class TObj_ModelRightList : BindingList<TObj_ModelRightItem>, TreeList.IVirtualTreeListData
        {
                #region 实现　IVirtualTreeListData 接口

                public void VirtualTreeGetCellValue(VirtualTreeGetCellValueInfo info)
                {
                        TObj_ModelRightItem obj = info.Node as TObj_ModelRightItem;
                        switch (info.Column.FieldName)
                        {
                                case "ID":
                                        info.CellData = obj.ID;
                                        break;
                                case "Name":
                                        info.CellData = obj.Name;
                                        break;
                                case "Title":
                                        info.CellData = obj.Title;
                                        break;
                                case "HaveRight":
                                        info.CellData = obj.HaveRight;
                                        break;
                        }
                }

                public void VirtualTreeGetChildNodes(VirtualTreeGetChildNodesInfo info)
                {
                        TObj_ModelRightItem obj = info.Node as TObj_ModelRightItem;
                        info.Children = obj.Children;
                }

                public void VirtualTreeSetCellValue(VirtualTreeSetCellValueInfo info)
                {
                        TObj_ModelRightItem obj = info.Node as TObj_ModelRightItem;
                        switch (info.Column.FieldName)
                        {
                                case "ID":
                                        obj.ID = (string)info.NewCellData;
                                        break;
                                case "Title":
                                        obj.Title= (string)info.NewCellData;
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

                protected override void InsertItem(int index, TObj_ModelRightItem item)
                {
                        item.Owner = this;
                        base.InsertItem(index, item);
                }


        }
}
