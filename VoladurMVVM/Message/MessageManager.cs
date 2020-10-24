using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace VoladorMVVM.Message
{
    public class MessageManager : IMessageManager
    {
        //此静态实例用于全局消息
        private static MessageManager _default;
        public static MessageManager Default 
        {
            get 
            {
                if (_default == null) _default = new MessageManager();
                return _default;
            } 
        }

        /// <summary>
        /// 消息列表  保存已注册的消息操作
        /// </summary>
        private readonly List<MsgActionInfo> _messageList = new List<MsgActionInfo>();

        /// <summary>
        /// 注册消息到消息列表中
        /// </summary>
        /// <param name="regInstance">消息实例</param>
        /// <param name="msgName">消息名称</param>
        /// <param name="action">消息动作</param>
        /// <param name="group">消息组</param>
        public void Register(object regInstance, string msgName, Action action, string group = "")
        {
            _messageList.Add(new MsgActionInfo 
            { 
                RegInstance =regInstance,
                MsgName = msgName,
                Action = action,
                Group = group
            });
        }

        /// <summary>
        /// 注册消息到消息列表中
        /// </summary>
        /// <typeparam name="T">消息的参数类型</typeparam>
        /// <param name="regInstance">消息实例</param>
        /// <param name="msgName">消息名称</param>
        /// <param name="action">消息动作</param>
        /// <param name="group">消息组</param>
        public void Register<T>(object regInstance, string msgName, Action<T> action, string group = "")
        {
            _messageList.Add(new MsgActionInfo<T>
            {
                RegInstance = regInstance,
                MsgName =msgName,
                Action = action,
                Group = group
            }) ;
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="msgName">消息名称</param>
        /// <param name="targetType">接收消息的目标类型</param>
        /// <param name="group">消息组</param>
        public void SendMsg(string msgName, Type targetType = null, string group = "")
        {
            var actions = GetMsgActionInfo(msgName,targetType,group);
            foreach (var item in actions)
            {
                item.Execute();
            }
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <typeparam name="T">消息参数类型</typeparam>
        /// <param name="msgName">消息名称</param>
        /// <param name="msgArgs">消息参数</param>
        /// <param name="targetType">接收消息的目标类型</param>
        /// <param name="group">消息组</param>
        public void SendMsg<T>(string msgName, T msgArgs, Type targetType = null, string group = "")
        {
            var actions = GetMsgActionInfo(msgName, targetType, group);
            foreach (var item in actions)
            {
                var msgAction = item as MsgActionInfo<T>;
                if (msgAction != null)msgAction.Execute(msgArgs);
            }
        }

        /// <summary>
        /// 注销信息
        /// </summary>
        /// <param name="regInstance">消息实例</param>
        public void UnRegister(object regInstance)
        {
            var msgActions = _messageList.Where(m => m.RegInstance == regInstance).ToList();
            foreach (var item in msgActions)
            {
                _messageList.Remove(item);
            }
        }
        /// <summary>
        /// 清除消息列表
        /// </summary>
        public void Clear()
        {
            _messageList.Clear();
        }
        /// <summary>
        /// 当窗口关闭时，取消注册消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void WindowClose(object sender, EventArgs e)
        {
            //注销窗体的消息
            UnRegister(sender);
            //注销ViewModel的消息
            var win = sender as FrameworkElement;
            if (win != null)
                UnRegister(win.DataContext);
        }

        private IEnumerable<MsgActionInfo> GetMsgActionInfo(string msgName, Type targetType, string group)
        {
            if (targetType == null)
                return _messageList.Where(m =>
                    m.MsgName == msgName
                    && m.Group == group);
            else
            {
                return _messageList.Where(m =>
                    m.MsgName == msgName
                    && m.Group == group
                    && m.RegInstance.GetType() == targetType);
            }
        }
    }
}
