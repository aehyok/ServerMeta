using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SinoSystemWatch.Base.WCF;
using SinoSystemWatch.Base.Define;
using SinoSysMonitorCenter.SystemNode;

namespace SinoSysMonitorCenter
{
    public class CommandParse
    {
        public byte[] DoCommand(string CommandName, string DesServer, byte[] ParameterData)
        {
            byte[] _retbytes;
            string _retstr;
            string[] CmdStrs = CommandName.Split('.');
            switch (CmdStrs[0])
            {
                case "GetSystemList":
                    _retstr = WatchSystemLib.GetJsonData();
                    _retbytes = WcfDataCompressControl.Compress(_retstr);
                    break;
                case "AddWatchNode":
                    _retstr = SystemNodeAccessor.AddSystem(ParameterData);
                    _retbytes = WcfDataCompressControl.Compress(_retstr);
                    break;
                case "DelWatchNode":
                    _retstr = SystemNodeAccessor.DelSystem(ParameterData);
                    _retbytes = WcfDataCompressControl.Compress(_retstr);
                    break;
                case "ModifyWatchNode":
                    _retstr = SystemNodeAccessor.ModifySystem(ParameterData);
                    _retbytes = WcfDataCompressControl.Compress(_retstr);
                    break;
                case "GetNodeCheckMsg":
                    _retstr = DoGetNodeCheckMsg(DesServer, ParameterData);
                    _retbytes = WcfDataCompressControl.Compress(_retstr);
                    break;
                case "GetNodePluginVersion":
                    _retstr = DoGetNodePluginVersion(DesServer, ParameterData);
                    _retbytes = WcfDataCompressControl.Compress(_retstr);
                    break;
                case "RemoveAppPlugin":
                    _retstr = DoRemoveAppPlugin(DesServer, ParameterData);
                    _retbytes = WcfDataCompressControl.Compress(_retstr);
                    break;
                case "UpLoadFilePlugin":
                    _retstr = DoUpLoadFilePlugin(DesServer, ParameterData);
                    _retbytes = WcfDataCompressControl.Compress(_retstr);
                    break;
                case "LoadAppPlugin":
                    _retstr = DoLoadAppPlugin(DesServer, ParameterData);
                    _retbytes = WcfDataCompressControl.Compress(_retstr);
                    break;
                case "GetAppPluginList":
                    _retstr = DoGetAppPluginList(DesServer, ParameterData);
                    _retbytes = WcfDataCompressControl.Compress(_retstr);
                    break;
                case "ExcuteNodeCommand":
                    _retstr = DoExcuteNodeCommand(CommandName,DesServer, ParameterData);
                    _retbytes = WcfDataCompressControl.Compress(_retstr);
                    break;
                case "ExcuteNodeCommandWithByte":
                    _retbytes = DoExcuteNodeCommandWithByte(CommandName, DesServer, ParameterData);                   
                    break;
                    
                default:
                    _retstr = string.Format("命令[{0}]无法识别!", CommandName);
                    _retbytes = WcfDataCompressControl.Compress(_retstr);
                    break;
            }
            return _retbytes;
        }

        private byte[] DoExcuteNodeCommandWithByte(string CommandName, string DesServer, byte[] ParameterData)
        {
            return SendCommandToNodeWithByte(DesServer, CommandName, ParameterData);
        }

      

        private string DoExcuteNodeCommand(string CommandName, string DesServer, byte[] ParameterData)
        {
            return SendCommandToNode(DesServer, CommandName, ParameterData);
        }

        private string DoGetAppPluginList(string DesServer, byte[] ParameterData)
        {
            return SendCommandToNode(DesServer, "GetAppPluginList", ParameterData);
        }

        private string DoLoadAppPlugin(string DesServer, byte[] ParameterData)
        {
            return SendCommandToNode(DesServer, "LoadAppPlugin", ParameterData);
        }

        private string DoUpLoadFilePlugin(string DesServer, byte[] ParameterData)
        {
            return SendCommandToNode(DesServer, "UpLoadFilePlugin", ParameterData);
        }

        private string DoRemoveAppPlugin(string DesServer, byte[] ParameterData)
        {
            return SendCommandToNode(DesServer, "RemoveAppPlugin", ParameterData);
        }

        private string DoGetNodePluginVersion(string DesServer, byte[] ParameterData)
        {
            return SendCommandToNode(DesServer, "GetNodePluginVersion", null);
        }

        private byte[] SendCommandToNodeWithByte(string DesServer, string CommandName, byte[] ParamData)
        {
            SystemStateItem _el = WatchSystemLib.GetSystem(DesServer);
            if (_el.Connected)
            {
                object[] _plist = new object[3]{
                "OK",CommandName,ParamData};
                try
                {
                    object _ret = ExecuteWCF.ExecuteMethod<SysWatchService.ISWCommandService>(_el.SystemURL, "DoCommand", _plist);
                    byte[] _byteret = _ret as byte[];
                    return _byteret;

                }
                catch (Exception ex)
                {
                    string _error = string.Format("从{0}中取当前状态出错！{1}", DesServer, ex.Message);
                    throw new Exception(_error);
                }
            }
            else
            {
                string _error = string.Format("服务器[{0}]暂时尚未连接！", DesServer);
                throw new Exception(_error);
            }
        }

        private string SendCommandToNode(string DesServer, string CommandName, byte[] ParamData)
        {
            SystemStateItem _el = WatchSystemLib.GetSystem(DesServer);
            if (_el.Connected)
            {
                object[] _plist = new object[3]{
                "OK",CommandName,ParamData};
                try
                {
                    object _ret = ExecuteWCF.ExecuteMethod<SysWatchService.ISWCommandService>(_el.SystemURL, "DoCommand", _plist);
                    byte[] _byteret = _ret as byte[];
                    string _msg = Encoding.Unicode.GetString(_byteret);
                    return _msg;

                }
                catch (Exception ex)
                {
                    string _error = string.Format("从{0}中取当前状态出错！{1}", DesServer, ex.Message);
                    throw new Exception(_error);
                }
            }
            else
            {
                string _error = string.Format("服务器[{0}]暂时尚未连接！", DesServer);
                throw new Exception(_error);
            }
        }

        private string DoGetNodeCheckMsg(string DesServer, byte[] ParameterData)
        {
            SystemStateItem _el = WatchSystemLib.GetSystem(DesServer);
            object[] _plist = new object[3]{
                "OK","GetNodeCheckMsg",null};
            try
            {
                object _ret = ExecuteWCF.ExecuteMethod<SysWatchService.ISWCommandService>(_el.SystemURL, "DoCommand", _plist);
                byte[] _byteret = _ret as byte[];
                string _msg = Encoding.Unicode.GetString(_byteret);
                return _msg;

            }
            catch (Exception ex)
            {
                string _error = string.Format("从{0}中取当前状态出错！{1}", DesServer, ex.Message);
                throw new Exception(_error);
            }
        }




    }
}
