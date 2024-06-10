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
    public class EfAppUserDal:GenericRepository<AppUser>,IAppUserDal
    {
        BlogContext context = new BlogContext();

        public AppUser GetUserByArticle(int id)
        {
            return context.Articles.Where(x=>x.ArticleId == id).Select(x=>x.AppUser).FirstOrDefault();

        }
    }
}
