using MessengerServiceHost.Model.View;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MessengerServiceHost.Model
{
    public class Message
    {
        public int MessageId { get; set; }
        [Required]
        [ForeignKey("User")]
        public int FromId { get; set; }
        public int GroupId { get; set; }
        [Required]
        public DateTime DispatchTime { get; set; }
        public User User { get; set; }
        public Group Group { get; set; }
        public MessageContent Content { get; set; }

        public static explicit operator ViewMessage(Message m)
        {
            return new ViewMessage
            {
                MessageId = m.MessageId,
                FromId = m.FromId,
                GroupId = m.GroupId,
                DispatchTime = m.DispatchTime,
                Content = (ViewMessageContent)m.Content,
                //Group = (ViewGroup)m.Group,
                User = (ViewUser)m.User
            };
        }
        public static explicit operator Message(ViewMessage m)
        {
            return new Message
            {
                MessageId = m.MessageId,
                FromId = m.FromId,
                GroupId = m.GroupId,
                DispatchTime = m.DispatchTime,
                Content = (MessageContent)m.Content,
                //Group = (Group)m.Group,
                //User = (User)m.User
            };
        }
    }
}