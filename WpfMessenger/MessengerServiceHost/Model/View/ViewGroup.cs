using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerServiceHost.Model.View
{
    public class ViewGroup
    {
        public int GroupId { get; set; }
        public string Name { get; set; }
        public int Participants { get; set; }
        public byte[] Image { get; set; }

        public ICollection<ViewUser> Users { get; set; }
        public ICollection<ViewMessage> Messages { get; set; }
    }
}
