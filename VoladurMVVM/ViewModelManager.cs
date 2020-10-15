using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using SimpleMVVM.Message;
using SimpleMVVM.ViewModel;

namespace SimpleMVVM
{
    public class ViewModelManager
    {
        private static List<ViewModelInfo> _viewModelInfoList = new List<ViewModelInfo>();

        /// <summary>
        /// 注册视图，视图模型和消息注册器
        /// </summary>
        /// <typeparam name="TView">视图的类型</typeparam>
        /// <typeparam name="TViewModel">视图模型的类型</typeparam>
        /// <typeparam name="TMsgRegister">MessageRegister的类型</typeparam>
        /// <param name="token">ViewModel的标识</param>
        public static void Register<TView, TViewModel, TMsgRegister>(string token = "")
        {
            var vmInfo = new ViewModelInfo(
                typeof(TView),
                typeof(TViewModel),
                typeof(TMsgRegister),
                token);
            _viewModelInfoList.Add(vmInfo);
        }

        /// <summary>
        /// 注册视图和视图模型但是不使用MessageRegister
        /// </summary>
        /// <typeparam name="TView">视图的类型</typeparam>
        /// <typeparam name="TViewModel">视图模型的类型</typeparam>
        /// <param name="token">ViewModel的标识</param>
        public static void Register<TView, TViewModel>(string token = "")
        {
            var vmInfo = new ViewModelInfo(
                typeof(TView),
                typeof(TViewModel),
                token: token);
            _viewModelInfoList.Add(vmInfo);
        }

        /// <summary>
        /// 获取视图的视图模型
        /// </summary>
        /// <typeparam name="TView">视图的类型</typeparam>
        /// <param name="token">ViewModel的标识</param>
        /// <returns>ViewModel</returns>
        public static object GetViewModel<TView>(string token = "")
        {
            try
            {
                var vmType = GetViewModelInfo(typeof(TView), token).ViewModelType;
                return vmType.Assembly.CreateInstance(vmType.FullName);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 将视图的视图模型设置为DataContext，并使用视图的MessageRegister来注册消息
        /// </summary>
        /// <param name="view">设置View的DataContext</param>
        /// <param name="isGlobalMsg">消息注册为全局或非全局</param>
        /// <param name="token">ViewModel的标识</param>
        public static void SetViewModel(FrameworkElement view, bool isGlobalMsg = false, string token = "")
        {
            var vmInfo = GetViewModelInfo(view.GetType(), token);
            if (vmInfo == null) return;
            var vm = vmInfo.GetViewModelInstance();
            //设置ViewModel的UIDispatcher
            vm.UIDispatcher = view.Dispatcher;
            //设置View的DataContext
            view.DataContext = vm;
            //注册View的消息
            var msgRegister = vmInfo.GetMsgRegisterInstance();
            if (msgRegister == null) return;

            msgRegister.RegInstance = view;
            if (isGlobalMsg)
            {
                var win = view as Window;
                if (win == null)
                {
                    throw new Exception("only can set a Window's message as global!");
                }
                vm.MsgManager = MessageManager.Default;
                win.Closed += MessageManager.Default.WindowClose;
            }
            else
            {
                vm.MsgManager = new MessageManager();
            }
            msgRegister.MsgManager = vm.MsgManager;
            msgRegister.Register();
        }
        /// <summary>
        /// 获取该View对应的ViewModelInfo
        /// </summary>
        /// <param name="viewType">视图类型</param>
        /// <param name="token">视图标识</param>
        /// <returns>ViewModelInfo</returns>
        private static ViewModelInfo GetViewModelInfo(Type viewType, string token = "")
        {
            try
            {
                return _viewModelInfoList
                    .Where(p => p.ViewType == viewType && p.Token == token)
                    .First();
            }
            catch
            {
                return null;
            }
        }
    }
}
