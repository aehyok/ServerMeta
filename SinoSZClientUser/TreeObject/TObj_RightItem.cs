using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using SinoSZJS.Base.User;

namespace SinoSZClientUser.TreeObject
{
        public class TObj_RightItem
        {
                protected UserRightInfo RightInfo = null;
                protected TObj_RightItemList owner;
                protected TObj_RightItemList children;


                public TObj_RightItem()
                {
                        this.children = new TObj_RightItemList();
                        this.owner = null;
                        RightInfo = new UserRightInfo();
                }

                public TObj_RightItem(UserRightInfo _data)
                {
                        this.children = new TObj_RightItemList();
                        this.owner = null;
                        RightInfo = _data;
                }

                public UserRightInfo Data
                {
                        get { return RightInfo; }
                        set { RightInfo = value; }
                }

                [Browsable(false)]
                public TObj_RightItemList Owner
                {
                        get { return owner; }
                        set { owner = value; }
                }

                [Browsable(false)]
                public TObj_RightItemList Children { get { return children; } }

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
                        get { return RightInfo.RightID; }
                        set
                        {
                                if (RightInfo.RightID == value) return;
                                RightInfo.RightID = value;
                                OnChanged();
                        }
                }
                /// <summary>
                /// 权限名称
                /// </summary>
                public string Name
                {
                        get { return RightInfo.RightName; }
                        set
                        {
                                if (RightInfo.RightName == value) return;
                                RightInfo.RightName = value;
                                OnChanged();
                        }
                }
                /// <summary>
                /// 父权限ID
                /// </summary>
                public string FatherID
                {
                        get { return RightInfo.FatherRightID; }
                        set
                        {
                                if (RightInfo.FatherRightID == value) return;
                                RightInfo.FatherRightID = value;
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
