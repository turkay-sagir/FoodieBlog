﻿using MyBlog.BusinessLayer.Abstract;
using MyBlog.DataAccessLayer.Abstract;
using MyBlog.DataAccessLayer.Context;
using MyBlog.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.BusinessLayer.Concrete
{
    public class AppUserManager : IAppUserService
    {
        private readonly IAppUserDal _appUserDal;

        public AppUserManager(IAppUserDal appUserDal)
        {
            _appUserDal = appUserDal;
        }

        public void TDelete(int id)
        {
            _appUserDal.Delete(id);
        }

        public AppUser TGetById(int id)
        {
            return _appUserDal.GetById(id);
        }

        public List<AppUser> TGetListAll()
        {
            return _appUserDal.GetListAll();
        }

        public AppUser TGetUserByArticle(int id)
        {
            return _appUserDal.GetUserByArticle(id);
        }

        public void TInsert(AppUser entity)
        {
            _appUserDal.Insert(entity);
        }

        public void TUpdate(AppUser entity)
        {
            _appUserDal.Update(entity);
        }
    }
}
