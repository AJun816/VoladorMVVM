using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoladorMVVM;
using VoladorMVVM.Command;
using VoladorMVVM.Message;

namespace Test
{
    public class VM_Calculator:ViewModelBase
    {
        private int _result;

        public int Result
        {
            get { return _result; }
            set {
                _result = value;
                this.RaisePropertyChanged("Result");
            }
        }

        private int _numOne;

        public int NumOne
        {
            get { return _numOne; }
            set {
                _numOne = value;
                this.RaisePropertyChanged("NumOne");
            }
        }

        private int _numTwo;

        public int NumTwo
        {
            get { return _numTwo; }
            set {
                _numTwo = value;
                this.RaisePropertyChanged("NumTwo");
            }
        }


    }
}
