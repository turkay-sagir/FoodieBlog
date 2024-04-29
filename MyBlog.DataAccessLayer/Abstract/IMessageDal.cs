using MyBlog.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.DataAccessLayer.Abstract
{
    public interface IMessageDal:IGenericDal<Message>
    {
        public List<Message> GetListOfReceivedMessage(string p);
        public List<Message> GetListOfSentMessage(string p);
    }
}
