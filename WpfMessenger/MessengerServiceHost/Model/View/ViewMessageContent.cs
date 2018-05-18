using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerServiceHost.Model.View
{
    public class ViewMessageContent
    {
        public int MessageContentId { get; set; }
        public string Text { get; set; }
        public ViewMessage Message { get; set; }
    }
}