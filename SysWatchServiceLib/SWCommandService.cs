using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using SinoSystemWatch.Base.WatchNode;
using SinoSystemWatch.Base.Task;
using SinoSystemWatch.Base.PluginFramework;
using SinoSystemWatch.Base.Common;

namespace SysWatchServiceLib
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的类名“SWCommandService”。
    public class SWCommandService : ISWCommandService
    {
        public byte[] DoCommand(string Token, string CommandName, byte[] ParameterData)
        {
            string[] CommandStr = CommandName.Split('.');
            string MainCommandName = CommandStr[0];
            switch (MainCommandName)
            {
                case "Connect":
                    return ConnectService();

                case "GetCurrentState":
                    return GetCurrentState();

                case "GetNodeCheckMsg":
                    return GetNodeCheckMsg();
                case "GetNodePluginVersion":
                    return GetPluginVersion();

                case "RemoveAppPlugin":
                    return RemoveAppPlugin(ParameterData);
                case "UpLoadFilePlugin":
                    return UpLoadFilePlugin(ParameterData);
                case "LoadAppPlugin":
                    return LoadAppPlugin(ParameterData);

                case "GetAppPluginList":
                    return GetAppPluginList(ParameterData);

                case "ExcuteNodeCommand":
                    if (CommandStr.Length > 2)
                    {
                        return DoCommandInPlugin(CommandStr[1], CommandStr[2], ParameterData);
                    }
                    else
                    {
                        return CommandCanNotUse();
                    }
                    break;
                case "ExcuteNodeCommandWithByte":
                    if (CommandStr.Length > 2)
                    {
                        return DoCommandInPlugin(CommandStr[1], CommandStr[2], ParameterData);
                    }
                    else
                    {
                        return CommandCanNotUse();
                    }
                    break;
                default:
                    return CommandCanNotUse();
                    break;
            }
        }

        private byte[] DoCommandInPlugin(string PluginName, string CommandName, byte[] ParameterData)
        {
            IServerPlugin _plugin = ServerPluginService.CurrentService.GetPluginInstance(PluginName);
            if (_plugin != null)
            {
                byte[] _ret = _plugin.DoCommand(CommandName, ParameterData);
                if (_ret == null)
                {
                    return CommandCanNotUse();
                }
                else
                {
                    return _ret;
                }
            }
            else
            {
                return CommandCanNotUse();
            }
        }

        private byte[] GetAppPluginList(byte[] ParameterData)
        {
            string _ret = "";
            //加载插件
            _ret = ServerFileCommon.GetAppPluginList();
            byte[] _data = Encoding.Unicode.GetBytes(_ret);
            return _data;
        }

        private byte[] LoadAppPlugin(byte[] ParameterData)
        {
            string _ret = "";
            AppPluginInfo _api = CommandCommon.GetParamDataObj<AppPluginInfo>(ParameterData);
            //将正确版本插件DLL复制到运行目录

            //加载插件
            _ret = ServerPluginService.LoadAppPlugin(_api);


            byte[] _data = Encoding.Unicode.GetBytes(_ret);
            return _data;
        }

        private byte[] UpLoadFilePlugin(byte[] ParameterData)
        {
            UpLoadFileInfo _ufi = CommandCommon.GetParamDataObj<UpLoadFileInfo>(ParameterData);
            string _ret = ServerFileCommon.UpLoad(_ufi);

            byte[] _data = Encoding.Unicode.GetBytes(_ret);
            return _data;
        }

        private byte[] RemoveAppPlugin(byte[] ParameterData)
        {
            AppPluginInfo _api = CommandCommon.GetParamDataObj<AppPluginInfo>(ParameterData);
            string _ret = ServerPluginService.RemovePlugin(_api);
            byte[] _data = Encoding.Unicode.GetBytes(_ret);
            return _data;
        }

        private byte[] GetPluginVersion()
        {
            string _ret = ServerPluginService.GetPluginInfoString();
            byte[] _data = Encoding.Unicode.GetBytes(_ret);
            return _data;
        }

        private byte[] GetNodeCheckMsg()
        {
            string _ret = TaskList.GetCheckMsg();
            byte[] _data = Encoding.Unicode.GetBytes(_ret);
            return _data;
        }

        private byte[] GetCurrentState()
        {
            TaskList.ComputeState();
            string _ret = WatchNodeCache.Output();
            byte[] _data = Encoding.Unicode.GetBytes(_ret);
            return _data;
        }

        private byte[] CommandCanNotUse()
        {
            string _ret = "False!命令不可用!";
            byte[] _data = Encoding.Unicode.GetBytes(_ret);
            return _data;
        }

        private byte[] ConnectService()
        {
            string _ret = string.Format("Success!{0}", WatchNodeCache.Output());
            byte[] _data = Encoding.Unicode.GetBytes(_ret);
            return _data;
        }
    }
}
