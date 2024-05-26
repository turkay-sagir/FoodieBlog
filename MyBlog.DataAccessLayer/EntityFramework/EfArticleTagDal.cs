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
    public class EfArticleTagDal : GenericRepository<ArticleTag>, IArticleTagDal
    {
        BlogContext context = new BlogContext();
        public List<ArticleTag> GetTagListByArticle(int id)
        {
            return context.ArticleTags.Where(x=>x.ArticleId == id).ToList();
        }

        public ArticleTag GetArticleTagByTagIdAndArticleId(int tagId, int articleId)
        {
            return context.ArticleTags.Where(x=>x.TagId == tagId && x.ArticleId==articleId).FirstOrDefault();
        }
    }
}
