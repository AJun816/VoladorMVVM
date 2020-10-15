using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleMVVM.Message;

namespace Test.Message
{
    class ComputeMsgArgs:MessageBase
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Result { get; set; }
        public ComputeMsgArgs()
        {
            X = 1;
            Y = 2;
            Result = 3;
        }
    }
}
