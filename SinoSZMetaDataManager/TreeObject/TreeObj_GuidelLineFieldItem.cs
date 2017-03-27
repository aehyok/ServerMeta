using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel;
using SinoSZJS.Base.MetaData.QueryModel;

namespace SinoSZMetaDataManager.TreeObject
{
        public class TreeObj_GuidelLineFieldItem
        {
                protected string _type = "FIELD";
                private MD_GuideLineFieldName _data = null;
                protected TreeObj_GuideLineFieldList owner;
                protected TreeObj_GuideLineFieldList children;

                public TreeObj_GuidelLineFieldItem() { }

                public TreeObj_GuidelLineFieldItem(MD_GuideLineFieldName data)
                {
                        _data = data;
                        _type = "FIELD";
                }
                public MD_GuideLineFieldName FieldData
                {
                        get { return _data; }
                }

                [Browsable(false)]
                public TreeObj_GuideLineFieldList Children { get { return children; } }

                [Browsable(false)]
                public TreeObj_GuideLineFieldList Owner
                {
                        get { return owner; }
                        set { owner = value; }
                }

                public string Type
                {
                        get { return _type; }
                        set { _type = value; }
                }

           
                virtual public string Name
                {
                        get { return _data.FieldName; }
                        set
                        {
                                if (_data.FieldName == value) return;
                                _data.FieldName = value;
                                OnChanged();
                        }
                }

                virtual public string DisplayTitle
                {
                        get { return _data.DisplayTitle; }
                        set
                        {
                                if (_data.DisplayTitle == value) return;
                                _data.DisplayTitle = value;
                                OnChanged();
                        }
                }

                virtual public int DisplayOrder
                {
                        get { return _data.DisplayOrder; }
                        set
                        {
                                if (_data.DisplayOrder == value) return;
                                _data.DisplayOrder = value;
                                OnChanged();
                        }
                }

                virtual public int DisplayWidth
                {
                        get { return _data.DisplayWidth; }
                        set
                        {
                                if (_data.DisplayWidth == value) return;
                                _data.DisplayWidth = value;
                                OnChanged();
                        }
                }

                virtual public string TextAlign
                {
                        get { return _data.TextAlign; }
                        set
                        {
                                if (_data.TextAlign == value) return;
                                _data.TextAlign = value;
                                OnChanged();
                        }
                }

                virtual public string DisplayFormat
                {
                        get { return _data.DisplayFormat; }
                        set
                        {
                                if (_data.DisplayFormat == value) return;
                                _data.DisplayFormat = value;
                                OnChanged();
                        }
                }

                virtual public bool CanHide
                {
                        get { return _data.CanHide; }
                        set
                        {
                                if (_data.CanHide == value) return;
                                _data.CanHide = value;
                                OnChanged();
                        }
                }

                virtual protected void OnChanged()
                {
                        if (owner == null) return;
                        int index = owner.IndexOf(this);
                        owner.ResetItem(index);
                }
        }
}
