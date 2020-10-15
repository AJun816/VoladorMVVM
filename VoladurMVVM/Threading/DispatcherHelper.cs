using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace SimpleMVVM.Threading
{
    public class DispatcherHelper
    {
        /// <summary>
        /// 主窗口的调度器
        /// </summary>
        public static Dispatcher UIDispatcher { get; set; }
    }
}
