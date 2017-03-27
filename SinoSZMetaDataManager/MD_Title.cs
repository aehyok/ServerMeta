using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZMetaDataManager
{
        public class MD_Title
        {
                private string _displayTitle = "";
                private string _titleType = "";
                private object _fatherObj = null;

                public object FatherObj
                {
                        get { return _fatherObj; }
                        set { _fatherObj = value; }
                }

                public string DisplayTitle
                {
                        get { return _displayTitle; }
                        set { _displayTitle = value; }
                }

                public string TitleType
                {
                        get { return _titleType; }
                        set { _titleType = value; }
                }

                public MD_Title()
                {
                }

                public MD_Title(string _text, string _type)
                {
                        _displayTitle = _text;
                        _titleType = _type;
                }

                public MD_Title(string _text, string _type,object _father)
                {
                        _displayTitle = _text;
                        _titleType = _type;
                        _fatherObj = _father;
                }

                public override string ToString()
                {
                        return _displayTitle;
                }
        }
}
