using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMVVM.Message
{
    public class DialogMsg:MessageBase
    {
        public object Data { get; set; }
        public object Result { get; set; }

        public DialogMsg(object sender = null)
            : base(sender)
        { }
    }
}
