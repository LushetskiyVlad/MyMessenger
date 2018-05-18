using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerServiceHost.Model.View
{
    public class ViewMessage
    {
        public int MessageId { get; set; }
        public int FromId { get; set; }
        public int GroupId { get; set; }
        public DateTime DispatchTime { get; set; }
        public ViewUser User { get; set; }
        public ViewGroup Group { get; set; }
        public ViewMessageContent Content { get; set; }
    }
}
