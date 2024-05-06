﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.EntityLayer.Concrete
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Status { get; set; }
        public int ArticleId { get; set; }
        public Article Article { get; set; }
        public int? AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
