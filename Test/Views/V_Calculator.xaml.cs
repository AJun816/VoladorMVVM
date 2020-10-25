using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using VoladorMVVM;

namespace Test.Views
{
    /// <summary>
    /// Calculator.xaml 的交互逻辑
    /// </summary>
    public partial class V_Caculator : Window
    {
        public V_Caculator()
        {
            InitializeComponent();
            ViewModelManager.Register<V_Caculator, VM_Calculator>();
            ViewModelManager.SetViewModel(this);
        }
    }
}
