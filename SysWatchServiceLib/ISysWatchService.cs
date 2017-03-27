using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SysWatchServiceLib
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“ISysWatchService”。
    [ServiceContract(CallbackContract = typeof(ICallbackContract))]
    public interface ISysWatchService
    {
        /// <summary>
        /// 订阅服务
        /// </summary>
        [OperationContract(IsOneWay = true)]
        void Regist();

        /// <summary>
        /// 退订服务
        /// </summary>
        [OperationContract(IsOneWay = true)]
        void UnRegist();

 
    }
}
