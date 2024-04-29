﻿using MyBlog.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.BusinessLayer.Abstract
{
    public interface IMessageService:IGenericService<Message>
    {
        public List<Message> TGetListOfReceivedMessage(string p);
        public List<Message> TGetListOfSentMessage(string p);
    }
}
