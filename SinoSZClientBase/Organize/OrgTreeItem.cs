using System;
using System.Collections.Generic;
using System.Text;
using SinoSZJS.Base.Authorize;
using System.ComponentModel;

namespace SinoSZClientBase.Organize
{
        [Serializable]
        public class OrgTreeItem
        {
                protected SinoOrganize data = null;
                protected OrgTreeList owner;
                protected OrgTreeList children;

                public OrgTreeItem()
                {
                        this.children = null;
                        this.owner = null;
                        data = new SinoOrganize();
                }

                public OrgTreeItem(SinoOrganize _data)
                {
                        this.children = null;
                        this.owner = null;
                        data = _data;
                }

              

                /// <summary>
                /// 单位ID码
                /// </summary>
                public decimal ID
                {
                        get { return data.Code; }
                        set
                        {
                                if (ID == value) return;
                                ID = value;
                                OnChanged();
                        }
                }

                /// <summary>
                /// 父单位ID码
                /// </summary>
                public decimal FatherID
                {
                        get { return data.FatherCode;}
                        set
                        {
                                if (FatherID == value) return;
                                FatherID = value;
                                OnChanged();
                        }
                }

                /// <summary>
                /// 单位名称
                /// </summary>
                public string Name
                {
                        get { return data.Name; }
                        set
                        {
                                if (Name == value) return;
                                Name = value;
                                OnChanged();
                        }
                }

                /// <summary>
                /// 单位全称
                /// </summary>
                public string FullName
                {
                        get { return data.FullName; }
                        set
                        {
                                if (FullName == value) return;
                                FullName = value;
                                OnChanged();
                        }
                }

                /// <summary>
                /// 单位代码
                /// </summary>
                public string DWDM
                {
                        get { return data.DWDM; }
                       set
                        {
                                if (DWDM == value) return;
                                DWDM = value;
                                OnChanged();
                        }
                }

                [Browsable(false)]
                public OrgTreeList Owner
                {
                        get { return owner; }
                        set { owner = value; }
                }

                [Browsable(false)]
                public OrgTreeList Children { get { return children; } }

                virtual protected void OnChanged()
                {
                        if (owner == null) return;
                        int index = owner.IndexOf(this);
                        owner.ResetItem(index);
                }


        }
}
