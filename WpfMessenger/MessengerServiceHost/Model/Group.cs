using MessengerServiceHost.Model.View;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MessengerServiceHost.Model
{
    [DataContract]
    public class Group
    {
        [DataMember]
        public int GroupId { get; set; }
        [MaxLength(50)]
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int Participants { get; set; }
        [DataMember]
        public byte[] Image { get; set; }
        [DataMember]
        public ICollection<User> Users { get; set; }
        [DataMember]
        public ICollection<Message> Messages { get; set; }

        public static explicit operator ViewGroup(Group group)
        {
            return new ViewGroup
            {
                GroupId = group.GroupId,
                Image = group.Image,
                Name = group.Name,
                Participants = group.Participants
            };
        }
        public static explicit operator Group(ViewGroup viewGroup)
        {
            return new Group
            {
                GroupId = viewGroup.GroupId,
                Image = viewGroup.Image,
                Name = viewGroup.Name,
                Participants = viewGroup.Participants
            };
        }
    }
}