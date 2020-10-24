using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Test.Message;
using Test.Views;
using VoladorMVVM.Message;

namespace Test
{
    public class MainWindowMsg : MessageRegisterBase
    {
        public override void Register()
        {
            RegisterMsg("ShowBox", new Action<string>(s=>MessageBox.Show(s)));

            RegisterMsg<ConfirmBoxMsg>("ShowConfirmBox", a=> 
            {
                if (MessageBox.Show(a.Content,a.Title,MessageBoxButton.YesNo)==MessageBoxResult.Yes)
                {
                    a.Result = true;
                }
                else
                {
                    a.Result = false;
                }
            });

            RegisterMsg<ComputeMsgArgs>("ShowComputeWindow",a => 
            {
                V_Caculator calculator = new V_Caculator();
                calculator.Owner = RegInstance as Window;
                calculator.Show();
            });
        }
    }
}
