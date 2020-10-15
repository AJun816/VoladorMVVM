using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMVVM.Message
{
    public interface IMessageManager
    {
        /// <summary>
        /// 注册消息
        /// </summary>
        /// <param name="regInstance">实例收到消息</param>
        /// <param name="msgName">消息名</param>
        /// <param name="action">消息动作</param>
        /// <param name="group">消息群组</param>
        void Register(object regInstance,string msgName, Action action,string group = "");
        void Register<T>(object regInstance,string msgName,Action<T> action,string group="");
        void SendMsg(string msgName, Type targetType = null, string group = "");
        void SendMsg<T>(string msgName, T msgArgs, Type targetType = null, string group = "");
        void UnRegister(object regInstance);
        void Clear();
        void WindowClose(object sender, EventArgs e);
    }
}
