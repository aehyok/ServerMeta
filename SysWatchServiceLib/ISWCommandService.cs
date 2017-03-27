using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SysWatchServiceLib
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“ISWCommandService”。
    [ServiceContract]
    public interface ISWCommandService
    {
        [OperationContract]
        byte[] DoCommand(string Token,string CommandName, byte[] ParameterData);
    }
}
