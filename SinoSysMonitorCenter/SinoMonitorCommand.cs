using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.IO.Compression;
using System.IO;
using System.ServiceModel.Channels;
using SinoSystemWatch.Base.WCF;
using SinoSZJS.DataAccess;

namespace SinoSysMonitorCenter
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的类名“ISinoMonitorCommand”。
    public class SinoMonitorCommand : ISinoMonitorCommand
    {
        public byte[] DoCommand(string UserPass, string CommandName, string DesServer, byte[] ParameterData)
        {
            byte[] _retbytes;
            string _retstr = "";
            if (!ServerCommon.DataBaseConnection)
            {
                _retstr = "错误：服务端连接数据库失败！不可访问!";
                _retbytes = WcfDataCompressControl.Compress(_retstr);
                return _retbytes;
            }
            else
            {
                try
                {
                    bool _tokenIsOK = CheckUserPass(UserPass);
                    if (_tokenIsOK)
                    {
                        CommandParse _cp = new CommandParse();
                        _retbytes = _cp.DoCommand(CommandName, DesServer, ParameterData);
                    }
                    else
                    {
                        _retstr = "身份认证失败！不可访问!";
                        _retbytes = WcfDataCompressControl.Compress(_retstr);
                    }
                    return _retbytes;
                }
                catch (Exception ex)
                {
                    _retstr = "发生错误:" + ex.Message;
                    _retbytes = WcfDataCompressControl.Compress(_retstr);
                    return _retbytes;
                }
            }



        }


        private bool CheckUserPass(string tokenString)
        {
            //获取消息发送的远程终结点IP和端口
            RemoteEndpointMessageProperty endpoint = WcfUtils.GetCurrentWCFClientEndpoint();

            string csname = string.Format("SystemWatchPass_{0}", endpoint.Address);
            string data = SystemParameterHelper.GetSystemParms(csname);
            bool ret = (data == "") ? false : (data == tokenString);
            return ret;

        }
    }
}
