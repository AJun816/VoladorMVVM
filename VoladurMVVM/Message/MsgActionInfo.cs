using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMVVM.Message
{
    class MsgActionInfo
    {
        /// <summary>
        /// 接收消息的实例
        /// </summary>
        public object RegInstance { get; internal set; }
        /// <summary>
        /// 消息名
        /// </summary>
        public string MsgName { get; internal set; }
        /// <summary>
        /// 消息群组
        /// </summary>
        public string Group { get; internal set; }
        /// <summary>
        /// 当收到此消息时，执行此操作
        /// </summary>
        public Action Action { get; internal set; }
        public void Execute()
        {
            if (Action != null) Action();
            //Action?.Invoke();
        }
    }
}
