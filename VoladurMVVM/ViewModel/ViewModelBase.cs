using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using VoladorMVVM.Message;
using VoladorMVVM.Threading;

namespace VoladorMVVM
{
    public class ViewModelBase:NotifyPropertyObject
    {
        private IMessageManager _msgManager;
        private Dispatcher _UIDispatcher;

        /// <summary>
        /// 用于发送消息查看
        /// </summary>
        public IMessageManager MsgManager
        {
            get {
                if (_msgManager == null)
                    _msgManager = MessageManager.Default;
                return _msgManager;
            }
            set { _msgManager = value; }
        }

        /// <summary>
        /// 用于交叉到视图的线程
        /// </summary>
        public Dispatcher UIDispatcher
        {
            get {
                if (_UIDispatcher == null)
                    _UIDispatcher = DispatcherHelper.UIDispatcher;
                return _UIDispatcher;
            }
            set { _UIDispatcher = value; }
        }

    }
}
