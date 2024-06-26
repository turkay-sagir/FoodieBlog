﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;
using MyBlog.EntityLayer.Concrete;
using Newtonsoft.Json;

namespace MyBlogPresentationLayer.Controllers
{
    [AllowAnonymous]
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly UserManager<AppUser> _userManager;

        public CommentController(ICommentService commentService, UserManager<AppUser> userManager)
        {
            _commentService = commentService;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<JsonResult> CreateComment(Comment p)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            p.CreatedDate = DateTime.Now;
            p.Status = "Bekliyor";
            p.AppUserId = user.Id;

            _commentService.TInsert(p);

            return Json("Success");
        }
    }
}
