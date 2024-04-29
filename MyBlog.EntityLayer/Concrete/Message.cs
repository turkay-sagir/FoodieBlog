using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.EntityLayer.Concrete
{
    public class Message
    {
        public int MessageId { get; set; }
        public string Subject { get; set; }
        public string Sender { get; set; }
        public string SenderName { get; set; }
        public string Receiver { get; set; }
        public string ReceiverName { get; set; }
        public string MessageContent { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Status { get; set; }

    }
}
