using Microsoft.EntityFrameworkCore;
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
    public class EfCommentDal : GenericRepository<Comment>, ICommentDal
    {
        BlogContext context = new BlogContext();

        private readonly IArticleDal _articleDal;

        public EfCommentDal(IArticleDal articleDal)
        {
            _articleDal = articleDal;
        }

        public Comment GetCommentWithUserAndBlog(int id)
        {
            return context.Comments.Where(x=>x.CommentId==id).Include(x => x.AppUser).Include(x => x.Article).FirstOrDefault();
        }

        public List<Comment> GetCommentsByBlog(int id)
        {
            return context.Comments.Where(x=>x.ArticleId == id).ToList();
        }

        public List<Comment> GetCommentsWithUserByBlog(int id)
        {
            return context.Comments.Where(x => x.ArticleId == id).Include(x => x.AppUser).ToList();
        }

        public List<Comment> GetCommentsOfBlogsByWriter(int id)
        {
            var values = _articleDal.GetArticlesByWriter(id).Select(x=>x.ArticleId).ToList();

            return context.Comments.Where(x=>values.Contains(x.ArticleId)).OrderByDescending(x=>x.Article.Title).Include(x=>x.Article).Include(x=>x.AppUser).ToList();
        }

    }
}
