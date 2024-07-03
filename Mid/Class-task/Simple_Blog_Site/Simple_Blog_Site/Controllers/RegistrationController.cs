using Simple_Blog_Site.DTOs;
using Simple_Blog_Site.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Simple_Blog_Site.Controllers
{
    public class RegistrationController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        Simple_Blog_SiteEntities2 db = new Simple_Blog_SiteEntities2();
        [HttpPost]
        public ActionResult Index(UserDTO user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(Convert(user));
                db.SaveChanges();
                return RedirectToAction("Success");
            }
            return View(user);
        }
        public static User Convert(UserDTO u)
        {
            return new User
            {
                Id = u.Id,
                UName = u.UName,
                Type = "User",
                Email = u.Email,
                Password = u.Password,
                FullName = u.FullName,
            };
        }
        public ActionResult Success()
        {
            return View();
        }

    }
}