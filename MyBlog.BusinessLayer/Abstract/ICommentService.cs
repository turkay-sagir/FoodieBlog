﻿using MyBlog.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.BusinessLayer.Abstract
{
    public interface ICommentService:IGenericService<Comment>
    {
        List<Comment> TGetCommentsByBlog(int id);
        List<Comment> TGetCommentsWithUserByBlog(int id);
        List<Comment> TGetCommentsOfBlogsByWriter(int id);
        Comment TGetCommentWithUserAndBlog(int id);
        List<Comment> TGetAllCommentsOfAllBlogs();
    }
}
