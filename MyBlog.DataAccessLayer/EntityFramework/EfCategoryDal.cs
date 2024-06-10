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
    public class EfCategoryDal : GenericRepository<Category>, ICategoryDal
    {
        BlogContext context = new BlogContext();
        public List<KeyValuePair<string, int>> GetCategoriesWithArticleCount()
        {
            return context.Categories.Select(x => new KeyValuePair<string, int>(x.CategoryName, x.Articles.Count)).ToList();
        }
    }
}
