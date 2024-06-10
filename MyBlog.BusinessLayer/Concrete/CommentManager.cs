using MyBlog.BusinessLayer.Abstract;
using MyBlog.DataAccessLayer.Abstract;
using MyBlog.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.BusinessLayer.Concrete
{
    public class CommentManager : ICommentService
    {
        private readonly ICommentDal _commentDal;

        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public Comment TGetCommentWithUserAndBlog(int id)
        {
            return _commentDal.GetCommentWithUserAndBlog(id);
        }

        public void TDelete(int id)
        {
            _commentDal.Delete(id);
        }

        public Comment TGetById(int id)
        {
            return _commentDal.GetById(id);
        }

        public List<Comment> TGetCommentsByBlog(int id)
        {
            return _commentDal.GetCommentsByBlog(id);
        }

        public List<Comment> TGetCommentsOfBlogsByWriter(int id)
        {
            return _commentDal.GetCommentsOfBlogsByWriter(id);
        }

        public List<Comment> TGetCommentsWithUserByBlog(int id)
        {
            return _commentDal.GetCommentsWithUserByBlog(id);
        }

        public List<Comment> TGetListAll()
        {
            return _commentDal.GetListAll();
        }

        public void TInsert(Comment entity)
        {
            _commentDal.Insert(entity);
        }

        public void TUpdate(Comment entity)
        {
            _commentDal.Update(entity);
        }

        public List<Comment> TGetAllCommentsOfAllBlogs()
        {
            return _commentDal.GetAllCommentsOfAllBlogs();
        }
    }
}
