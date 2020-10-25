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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Test.ViewModels;
using VoladorMVVM;

namespace Test.Views
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class V_MainWindow : Window
    {
        public V_MainWindow()
        {
            InitializeComponent();
            ViewModelManager.Register<V_MainWindow, VM_WindowTest,MainWindowMsg>();
            ViewModelManager.SetViewModel(this);

        }

        private void btnValidatetionHelper_Click(object sender, RoutedEventArgs e)
        {
            V_ValidatetionHelper validatetionHelper = new V_ValidatetionHelper();
            validatetionHelper.Show();
            validatetionHelper.DataContext = new VM_ValidatetionHelper();
        }

        private void btnPropertyValidateModel_Click(object sender, RoutedEventArgs e)
        {
            V_PropertyValidateModel propertyValidateModel = new V_PropertyValidateModel();
            propertyValidateModel.Show();
            propertyValidateModel.DataContext = new VM_PropertyValidateModel();
        }
    }
}
