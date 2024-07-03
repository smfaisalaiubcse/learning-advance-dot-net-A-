using Microsoft.Ajax.Utilities;
using Simple_Blog_Site.Auth;
using Simple_Blog_Site.DTOs;
using Simple_Blog_Site.EF;
using Simple_Blog_Site.Models;
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
            var blogs = db.Blogs.Select(b => new BlogDTO
            {
                Id = b.Id,
                Title = b.Title,
                BlogData = b.BlogData,
                BlogTime = b.BlogTime,
                UId = b.UId,
                UserFullName = b.UserFullName,
                LikeCount = b.LikeCount,
                DislikeCount = b.DislikeCount,
                CommentCount = b.CommentCount
            }).ToList();

            var viewModel = new BlogViewModel
            {
                NewBlog = new BlogDTO(),
                AllBlogs = blogs ?? new List<BlogDTO>()
            };

            return View(viewModel);
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
                    UserFullName = (string)TempData["FullName"],
                    LikeCount = 0,
                    DislikeCount = 0,
                    CommentCount = 0,
                };
                db.Blogs.Add(newBlog);
                db.SaveChanges();
                TempData["Msg"] = "Post Successful";
                return RedirectToAction("Index", "User");
            }
            else
            {
                TempData["Msg"] = "Validation Error: " + string.Join(", ", ModelState.Values
                                                .SelectMany(v => v.Errors)
                                                .Select(e => e.ErrorMessage));
            }
            return View(blog);
        }


        [HttpPost]
        public ActionResult updateBlog()
        {
            return View();
        }
        [HttpGet]
        public ActionResult viewAllBlogsByMe() 
        {
            var data = db.Blogs.ToList();
            return View(Convert(data));
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
        public static BlogDTO Convert(Blog b)
        {
            return new BlogDTO()
            {
               Id=b.Id,
               Title=b.Title,
               BlogData = b.BlogData,
               BlogTime = b.BlogTime,
               UId = b.UId,
               LikeCount = b.LikeCount,
               DislikeCount = b.DislikeCount,
               CommentCount = b.CommentCount,
            };
        }
        public static List<BlogDTO> Convert(List<Blog> blogs)
        {
            var list = new List<BlogDTO>();
            foreach (var item in blogs)
            {
                list.Add(Convert(item));
            }
            return list;
        }

    }
}