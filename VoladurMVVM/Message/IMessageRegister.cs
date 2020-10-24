using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoladorMVVM.Message
{
    public interface IMessageRegister
    {
        object RegInstance { get; set; }
        IMessageManager MsgManager { get; set; }
        void Register();
    }
}
