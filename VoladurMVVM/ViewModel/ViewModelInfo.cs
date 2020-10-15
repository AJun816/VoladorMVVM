using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using SimpleMVVM.Message;

namespace SimpleMVVM.ViewModel
{
    public class ViewModelInfo
    {
        /// <summary>
        /// 视图的类型
        /// </summary>
        public Type ViewType { get; private set; }
        /// <summary>
        /// 视图模型的类型
        /// </summary>
        public Type ViewModelType { get; private set; }
        /// <summary>
        /// MessageRegister的类型
        /// </summary>
        public Type MsgRegisterType { get; private set; }
        /// <summary>
        /// 视图的标识
        /// </summary>
        public string Token { get; private set; }
        public ViewModelInfo(Type view, Type viewModel, Type msgRegister = null, string token = "")
        {
            ViewType = view;
            ViewModelType = viewModel;
            MsgRegisterType = msgRegister;
            Token = token;
        }
        /// <summary>
        /// 获取ViewModel的一个新实例
        /// </summary>
        /// <returns></returns>
        public ViewModelBase GetViewModelInstance()
        {
            if (ViewModelType == null) return null;
            return ViewModelType
                .Assembly
                .CreateInstance(ViewModelType.FullName)
                as ViewModelBase;
        }
        /// <summary>
        /// 获取一个MessageRegister的新实例
        /// </summary>
        /// <returns></returns>
        public IMessageRegister GetMsgRegisterInstance()
        {
            if (MsgRegisterType == null) return null;
            return MsgRegisterType
                .Assembly
                .CreateInstance(MsgRegisterType.FullName)
                as IMessageRegister;
        }
    }
}
