using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMVVM.Message
{
    public class ConfirmBoxMsg:MessageBase
    {
        public bool Result { get; set; }
        public string Title { get; private set; }
        public string Content { get; private set; }

        public ConfirmBoxMsg(string title, string content, object sender = null)
            : base(sender)
        {
            Title = title;
            Content = content;
        }
    }
}
