using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.XtraTreeList;
using System.ComponentModel;

namespace SinoSZClientBase.Organize
{
        [Serializable]
        public class OrgTreeList : BindingList<OrgTreeItem>, TreeList.IVirtualTreeListData
        {
                #region 实现　IVirtualTreeListData 接口

                public void VirtualTreeGetCellValue(VirtualTreeGetCellValueInfo info)
                {
                        OrgTreeItem obj = info.Node as OrgTreeItem;
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
                                case "FullName":
                                        info.CellData = obj.FullName;
                                        break;
                                case "DWDM":
                                        info.CellData = obj.DWDM;
                                        break;
                        }
                }

                public void VirtualTreeGetChildNodes(VirtualTreeGetChildNodesInfo info)
                {
                        OrgTreeItem obj = info.Node as OrgTreeItem;
                        info.Children = obj.Children;
                }

                public void VirtualTreeSetCellValue(VirtualTreeSetCellValueInfo info)
                {
                        OrgTreeItem obj = info.Node as OrgTreeItem;
                        switch (info.Column.FieldName)
                        {
                                case "ID":
                                        obj.ID = (decimal)info.NewCellData;
                                        break;
                                case "FatherID":
                                        obj.FatherID = (decimal)info.NewCellData;
                                        break;
                                case "Name":
                                        obj.Name = (string)info.NewCellData;
                                        break;
                                case "FullName":
                                        obj.FullName = (string)info.NewCellData;
                                        break;
                                case "DWDM":
                                        obj.DWDM = (string)info.NewCellData;
                                        break;
                        }
                }

                #endregion
        }
}
