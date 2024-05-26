﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.EntityLayer.Concrete
{
    //Article ve Tag arasında köprü tablosu oluşturuldu.
    public class ArticleTag
    {
        public int ArticleTagId { get; set; }
        public int TagId { get; set; }
        public int ArticleId { get; set; }
        public Tag Tag { get; set; }
        public Article Article { get; set; }
    }
}
