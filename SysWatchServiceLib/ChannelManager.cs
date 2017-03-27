using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SysWatchServiceLib
{
    public class ChannelManager
    {
        #region Fields

        /// <summary>
        /// 回调通道列表
        /// </summary>
        private List<ICallbackContract> callbackChannelList = new List<ICallbackContract>();

        /// <summary>
        /// 用于互斥锁的对象
        /// </summary>
        public static readonly object SyncObj = new object();

        #endregion

        #region Single

        private static readonly Lazy<ChannelManager> instance = new Lazy<ChannelManager>(() => new ChannelManager());

        public static ChannelManager Instance
        {
            get { return instance.Value; }
        }

        protected ChannelManager() { }

        #endregion

        #region Methods
        /// <summary>
        /// 将回调通道加入到通道列表中进行管理
        /// </summary>
        /// <param name="callbackChannel"></param>
        public void Add(ICallbackContract callbackChannel)
        {
            if (callbackChannelList.Contains(callbackChannel))
            {
                Console.WriteLine("已存在重复通道");
            }
            else
            {
                lock (SyncObj)
                {
                    callbackChannelList.Add(callbackChannel);
                    Console.WriteLine("添加了新的通道");
                }
            }
        }

        /// <summary>
        /// 从通道列表中移除对一个通道的管理
        /// </summary>
        /// <param name="callbackChannel"></param>
        public void Remove(ICallbackContract callbackChannel)
        {
            if (!callbackChannelList.Contains(callbackChannel))
            {
                Console.WriteLine("不存在待移除通道");
            }
            else
            {
                lock (SyncObj)
                {
                    callbackChannelList.Remove(callbackChannel);
                    Console.WriteLine("移除了一个通道");
                }
            }
        }

        /// <summary>
        /// 广播消息
        /// </summary>
        /// <param name="message"></param>
        public void NotifyMessage(string message)
        {
            if (callbackChannelList.Count > 0)
            {
                //避免对callbackChannelList的更改对广播造成的影响
                ICallbackContract[] callbackChannels = callbackChannelList.ToArray();

                foreach (var channel in callbackChannels)
                {
                    try
                    {
                        //广播消息
                        channel.ServerReply(message);
                    }
                    catch
                    {
                        //对异常的通道进行处理
                        callbackChannelList.Remove(channel);
                    }
                }
            }
        }
        #endregion
    }
}
