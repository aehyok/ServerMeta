using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SysWatchServiceLib
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的类名“SysWatchService”。
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class SysWatchService : ISysWatchService
    {
        public void Regist()
        {
            ICallbackContract callbackChannel = OperationContext.Current.GetCallbackChannel<ICallbackContract>();
            //添加到管理列表中
            ChannelManager.Instance.Add(callbackChannel);

        }

        public void UnRegist()
        {
            ICallbackContract callbackChannel = OperationContext.Current.GetCallbackChannel<ICallbackContract>();
            //从管理列表中移除
            ChannelManager.Instance.Remove(callbackChannel);
        }

    }
}
