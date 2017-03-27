using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZPluginFramework
{
        public class MenuCommandDefine
        {
                private IMenuCommand _commander = null;

                public IMenuCommand Commander
                {
                        get
                        {
                                return _commander;
                        }
                        set
                        {
                                _commander = value;
                        }
                }

                private string _commandName = "";                
                public string CommandName
                {
                        get
                        {
                                return _commandName;
                        }
                        set
                        {
                                _commandName = value;
                        }
                }

                private object _commandParam = null;
                public object CommandParam
                {
                        get
                        {
                                return _commandParam;
                        }
                        set
                        {
                                _commandParam = value;
                        }
                }

                private string _title = "";
                public string Title
                {
                        get { return _title; }
                        set { _title = value; }
                }

                public bool RunCommand(string _MenuID)
                {
			return _commander.DoCommand(_MenuID,_commandName, _title, _commandParam);
                }

                public MenuCommandDefine(string _commandName, string _commandTitle,IMenuCommand _cmder, object _param)
                {
                        this._commandName = _commandName;
                        this._commander = _cmder;
                        this._commandParam = _param;
                        this._title = _commandTitle;
                }
        }
}
