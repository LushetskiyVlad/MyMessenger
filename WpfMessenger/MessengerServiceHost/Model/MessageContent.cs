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
    [DataContract]
    public class MessageContent
    {
        [ForeignKey("Message")]
        [DataMember]
        public int MessageContentId { get; set; }
        [DataMember]
        public string Text { get; set; }
        [DataMember]
        public Message Message { get; set; }

        public static explicit operator ViewMessageContent(MessageContent m)
        {
            return new ViewMessageContent
            {
                MessageContentId = m.MessageContentId,
                Text = m.Text
            };
        }
        public static explicit operator MessageContent(ViewMessageContent m)
        {
            return new MessageContent
            {
                MessageContentId = m.MessageContentId,
                Text = m.Text
            };
        }
    }
}