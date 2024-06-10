using MyBlog.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.DataAccessLayer.Abstract
{
    public interface ICommentDal : IGenericDal<Comment>
    {
        List<Comment> GetCommentsByBlog(int id);
        List<Comment> GetCommentsWithUserByBlog(int id);
        List<Comment> GetCommentsOfBlogsByWriter(int id);
        Comment GetCommentWithUserAndBlog(int id);
        List<Comment> GetAllCommentsOfAllBlogs();
    }
}
