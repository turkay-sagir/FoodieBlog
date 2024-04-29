using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.EntityLayer.Concrete
{
    public class Notification
    {
        public int NotificationId { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Status { get; set; }
    }
}
