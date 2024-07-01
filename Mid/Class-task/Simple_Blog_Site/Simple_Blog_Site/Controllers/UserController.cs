using Microsoft.Ajax.Utilities;
using Simple_Blog_Site.Auth;
using Simple_Blog_Site.DTOs;
using Simple_Blog_Site.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Simple_Blog_Site.Controllers
{
    [UserAccess]
    public class UserController : Controller
    {
        Simple_Blog_SiteEntities2 db = new Simple_Blog_SiteEntities2();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult createBlog() 
        { 
            return View(); 
        }
        [HttpPost]
        public ActionResult createBlog(BlogDTO blog)
        {
            if (ModelState.IsValid)
            {
                Blog newBlog = new Blog
                {
                    Id = blog.Id,
                    Title = blog.Title,
                    BlogData = blog.BlogData,
                    BlogTime = DateTime.Now,
                    UId = (int)TempData["UserId"], 
                    LikeCount = 0,
                    DislikeCount = 0,
                    CommentCount = 0,
                };
                db.Blogs.Add(newBlog);
                db.SaveChanges();
                TempData["Msg"] = "Post Successfull";
                return RedirectToAction("Index", "User");
            }
            else 
                TempData["Msg"] = "Problem";
            return View(blog); 
        }

        [HttpPost]
        public ActionResult updateBlog()
        {
            return View();
        }
        public ActionResult Logout()
        {
            Session["user"] = null;
            return RedirectToAction("Index", "Home");
        }
        //int userID = ((UserDTO)controller.Session["user"]).Id;
        //public static Blog Convert(UserDTO ud)
        //{
        //    ud.Id = ((UserDTO)Session["user"]).Id;
        //    return new Blog
        //    {
        //        Id = u.Id,
        //        Title = u.Title,
        //        BlogData = u.BlogData,
        //        BlogTime = DateTime.Now,
        //        UId = userID,
        //        LikeCount = 0,
        //        DislikeCount = 0,
        //        CommentCount = 0,
        //    };
        //}

    }
}