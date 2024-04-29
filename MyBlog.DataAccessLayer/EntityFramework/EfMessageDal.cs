using MyBlog.DataAccessLayer.Abstract;
using MyBlog.DataAccessLayer.Context;
using MyBlog.DataAccessLayer.Repositories;
using MyBlog.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.DataAccessLayer.EntityFramework
{
    public class EfMessageDal:GenericRepository<Message>,IMessageDal
    {
        BlogContext context = new BlogContext();

        public List<Message> GetListOfReceivedMessage(string p)
        {
            return context.Messages.Where(x=>x.Receiver==p).ToList();
        }

        public List<Message> GetListOfSentMessage(string p)
        {
            return context.Messages.Where(x=>x.Sender==p).ToList();
        }
    }
}
