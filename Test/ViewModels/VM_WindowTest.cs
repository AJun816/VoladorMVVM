using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using VoladorMVVM;
using VoladorMVVM.Command;
using VoladorMVVM.Message;
using Test.Message;

namespace Test
{
    public class VM_WindowTest:ViewModelBase
    {
        #region 数据属性测试
        private string _title = "VoladorMVVM测试";
        public string Title
        {
            get { return _title; }
            set {
                _title = value;
                this.RaisePropertyChanged("Title");
            }
        }
        #endregion
        #region 基础命令测试：Execute,CanExecute,ParamCommand测试
        private bool _canExecute;

        public bool CanExecute
        {
            get { return _canExecute; }
            set {
                _canExecute = value;
                this.RaisePropertyChanged("CanExecute");
            }
        }


        public VoladorCommand NormalCommand => new VoladorCommand(obj =>
        {
            MessageBox.Show("普通按钮被点击");
        });


        public VoladorCommand CanExecuteCommand => new VoladorCommand(
            new Action<object>(
                obj => MessageBox.Show("命令可以执行！")),
            new Func<object, bool>(
                obj => CanExecute));


        public VoladorCommand ParamCommand => new VoladorCommand(
            new Action<object>(
                obj => MessageBox.Show(obj.ToString())),
            new Func<object, bool>(
                obj => !string.IsNullOrEmpty(obj.ToString())));

        #endregion
        #region 事件、事件参数与命令进行绑定测试
        private bool _isReceiveMouseMove;
        public bool IsReceiveMouseMove
        {
            get { return _isReceiveMouseMove; }
            set {
                _isReceiveMouseMove = value;
                this.RaisePropertyChanged("IsReceiveMouseMove");
            }
        }

        private string _tipText;
        public string TipText
        {
            get { return _tipText; }
            set {
                _tipText = value;
                RaisePropertyChanged("TipText");
            }
        }


        public VoladorCommand LoadedCommand => new VoladorCommand(obj =>
        {
            MessageBox.Show("程序加载完毕");
        });


        public VoladorCommand<MouseEventArgs> MouseMoveCommand => new VoladorCommand<MouseEventArgs>(
            new Action<MouseEventArgs>(e =>
            {
                var point = e.GetPosition(e.Device.Target);
                var left = "左键放开";
                var mid = "中键放开";
                var right = "右键放开";

                if (e.LeftButton == MouseButtonState.Pressed)
                    left = "左键按下";
                if (e.MiddleButton == MouseButtonState.Pressed)
                    mid = "中键按下";
                if (e.RightButton == MouseButtonState.Pressed)
                    right = "右键按下";
                TipText = $"当前鼠标位置  X:{point.X}  Y:{point.Y}  当前鼠标状态:{left} {mid}  {right}";
            }),
            new Func<object, bool>(obj => IsReceiveMouseMove)
            );

        #endregion
        #region View与ViewModel通信测试

        private Brush _BgBrush;
        public Brush BgBrush
        {
            get { return _BgBrush; }
            set {
                _BgBrush = value;
                this.RaisePropertyChanged("BgBrush");
            }
        }

        private int _x;

        public int X
        {
            get { return _x; }
            set {
                _x = value;
                this.RaisePropertyChanged("X");
            }
        }

        private int _y;

        public int Y
        {
            get { return _y; }
            set {
                _y = value;
                this.RaisePropertyChanged("Y");
            }
        }

        private int _result;

        public int Result
        {
            get { return _result; }
            set {
                _result = value;
                this.RaisePropertyChanged("Result");
            }
        }


        public VoladorCommand GeneralCommand => new VoladorCommand(obj =>
        {
            MsgManager.SendMsg("ShowBox", "这是一个普通的消息框");
        });

        public VoladorCommand ConfirmCommand => new VoladorCommand(obj =>
        {
            var msg = new ConfirmBoxMsg(
                            "请确认!",
                            "是否关闭当前弹窗！");
            MsgManager.SendMsg("ShowConfirmBox", msg);
            if (msg.Result)
                MsgManager.SendMsg("ShowBox", "成功关闭！");
            else
                BgBrush = null;
        });


        public VoladorCommand ComputeCommand => new VoladorCommand(obj =>
        {
            var msg = new ComputeMsgArgs();
            MsgManager.SendMsg("ShowComputeWindow", msg);
            X = msg.X;
            Y = msg.Y;
            Result = msg.Result;
        });
        #endregion
    }
}
