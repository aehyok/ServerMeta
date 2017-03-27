using System;
using System.Collections.Generic;
using System.Text;

using SinoSZJS.Base.MetaData.QueryModel;

namespace SinoSZMetaDataManager.TreeObject
{
        public class TreeObj_GuideLineFieldGroup : TreeObj_GuidelLineFieldItem
        {
                private MD_GuideLineFieldGroup _groupData = null;
                public TreeObj_GuideLineFieldGroup()
                {
                        _type = "GROUP";
                }


                public TreeObj_GuideLineFieldGroup(MD_GuideLineFieldGroup data)
                {
                        _groupData = data;
                        _type = "GROUP";
                        this.children = new TreeObj_GuideLineFieldList();
                }

                public MD_GuideLineFieldGroup GroupData
                {
                        get { return _groupData; }
                }

                override public string Name
                {
                        get { return _groupData.GroupName; }
                        set
                        {
                                if (_groupData.GroupName == value) return;
                                _groupData.GroupName = value;
                                OnChanged();
                        }
                }

                override public string DisplayTitle
                {
                        get { return _groupData.DisplayTitle; }
                        set
                        {
                                if (_groupData.DisplayTitle == value) return;
                                _groupData.DisplayTitle = value;
                                OnChanged();
                        }
                }

                override public int DisplayOrder
                {
                        get { return _groupData.DisplayOrder; }
                        set
                        {
                                if (_groupData.DisplayOrder == value) return;
                                _groupData.DisplayOrder = value;
                                OnChanged();
                        }
                }
                public override bool CanHide
                {
                        get
                        {
                                return _groupData.CanHide;
                        }
                        set
                        {
                                if (_groupData.CanHide == value) return;
                                _groupData.CanHide = value;
                                OnChanged();
                        }
                }

                public override int DisplayWidth
                {
                        get
                        {
                                return 0;
                        }
                        set
                        {
                                int i = value;
                        }
                }

                override public string TextAlign
                {
                        get { return _groupData.TextAlign; }
                        set
                        {
                                if (_groupData.TextAlign == value) return;
                                _groupData.TextAlign = value;
                                OnChanged();
                        }
                }

                override public string DisplayFormat
                {
                        get { return _groupData.DefaultStatus; }
                        set
                        {
                                if (_groupData.DefaultStatus == value) return;
                                _groupData.DefaultStatus = value;
                                OnChanged();
                        }
                }
        }
}
