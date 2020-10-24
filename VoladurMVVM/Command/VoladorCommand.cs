using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace VoladorMVVM.Command
{
    public class VoladorCommand : ICommand
    {
        //当这个命令能不能执行状态发生改变时，通知命令的调用者，告诉他状态
        public event EventHandler CanExecuteChanged
        {
            add {
                if (_canExecuteAction != null)
                {
                    CommandManager.RequerySuggested += value;
                }
            }
            remove {
                if (_canExecuteAction != null)
                {
                    CommandManager.RequerySuggested -= value;
                }
            }
        }
        //检查命令是否可以执行
        private readonly Func<object, bool> _canExecuteAction;
        //命令执行的动作
        private readonly Action<object> _executeAction;

        public VoladorCommand(Action<object> executeAction) : this(executeAction,null) { }       
        public VoladorCommand(Action<object> executeAction, Func<object, bool> canExecuteAction)
        {
            _executeAction = executeAction;
            _canExecuteAction = canExecuteAction;
        }

        //用来帮助命令的呼叫者，判断这个命令能不能执行
        public bool CanExecute(object parameter) => _canExecuteAction?.Invoke(parameter) ?? true;

        //最为重要的是这个命令，当命令执行的时候，做什么事情
        public void Execute(object parameter)
        {
            if (_executeAction != null && CanExecute(parameter))
            {
                _executeAction(parameter);
            }
        }

    }

}
