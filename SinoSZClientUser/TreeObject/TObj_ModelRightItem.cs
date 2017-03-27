using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using SinoSZJS.Base.User;

namespace SinoSZClientUser.TreeObject
{
        public class TObj_ModelRightItem
        {
                protected UserQueryModelInfo RightInfo = null;
                protected TObj_ModelRightList owner;
                protected TObj_ModelRightList children;

                public TObj_ModelRightItem()
                {
                        this.children = new TObj_ModelRightList();
                        this.owner = null;
                        RightInfo = new UserQueryModelInfo();
                }

                public TObj_ModelRightItem(UserQueryModelInfo _data)
                {
                        this.children = new TObj_ModelRightList();
                        this.owner = null;
                        RightInfo = _data;
                }

                public UserQueryModelInfo Data
                {
                        get { return RightInfo; }
                        set { RightInfo = value; }
                }

                [Browsable(false)]
                public TObj_ModelRightList Owner
                {
                        get { return owner; }
                        set { owner = value; }
                }

                [Browsable(false)]
                public TObj_ModelRightList Children { get { return children; } }

                virtual protected void OnChanged()
                {
                        if (owner == null) return;
                        int index = owner.IndexOf(this);
                        owner.ResetItem(index);
                }

                /// <summary>
                /// 权限ID
                /// </summary>
                public string ID
                {
                        get { return RightInfo.QueryModelID; }
                        set
                        {
                                if (RightInfo.QueryModelID == value) return;
                                RightInfo.QueryModelID = value;
                                OnChanged();
                        }
                }
                /// <summary>
                /// 权限名称
                /// </summary>
                public string Name
                {
                        get { return string.Format("{0}.{1}", RightInfo.QueryModelNamespace, RightInfo.QueryModelName); }
                        set
                        {
                                if (RightInfo.QueryModelName == value) return;
                                RightInfo.QueryModelName = value;
                                OnChanged();
                        }
                }

                /// <summary>
                /// 显示名称
                /// </summary>
                public string Title
                {
                        get { return string.Format("{0}.{1}", RightInfo.QueryModelNamespace, RightInfo.QueryModelTitle); }
                        set
                        {
                                if (RightInfo.QueryModelTitle == value) return;
                                RightInfo.QueryModelTitle = value;
                                OnChanged();
                        }
                }
                /// <summary>
                /// 是否具有权限
                /// </summary>
                public bool HaveRight
                {
                        get { return RightInfo.HaveRight; }
                        set
                        {
                                if (RightInfo.HaveRight == value) return;
                                RightInfo.HaveRight = value;
                                OnChanged();
                        }
                }
        }
}
