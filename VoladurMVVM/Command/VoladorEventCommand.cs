using System.Windows;
using System.Windows.Input;
using System.Windows.Interactivity;

namespace SimpleMVVM.Command
{
    public class VoladorEventCommand : TriggerAction<DependencyObject>
    {
        //绑定命令
        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        //使用DependencyProperty作为Command的后备存储。这样可以启用动画，样式，绑定等。
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register("Command", typeof(ICommand), typeof(VoladorEventCommand), new PropertyMetadata(null));

        //命令参数
        public object CommandParateter
        {
            get { return (object)GetValue(CommandParateterProperty); }
            set { SetValue(CommandParateterProperty, value); }
        }

        //使用DependencyProperty作为Command的后备存储。这样可以启用动画，样式，绑定等。
        public static readonly DependencyProperty CommandParateterProperty =
            DependencyProperty.Register("CommandParateter", typeof(object), typeof(VoladorEventCommand), new PropertyMetadata(null));

        private ICommand GetCommand()
        {
            return Command;
        }

        //重写Invoke
        protected override void Invoke(object parameter)
        {
            if (CommandParateter != null) parameter = CommandParateter;
            var cmd = GetCommand();
            if (cmd != null) cmd.Execute(parameter);
        }
    }
}
