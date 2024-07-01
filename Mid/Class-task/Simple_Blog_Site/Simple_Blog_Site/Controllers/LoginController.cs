using Simple_Blog_Site.DTOs;
using Simple_Blog_Site.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Simple_Blog_Site.Controllers
{
    public class LoginController : Controller
    {
        Simple_Blog_SiteEntities2 db = new Simple_Blog_SiteEntities2();
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(LoginDTO l)
        {
            if (ModelState.IsValid)
            {
                var user = (from u in db.Users
                            where u.UName.Equals(l.UName) &&
                            u.Password.Equals(l.Password)
                            select u).SingleOrDefault();
                if (user == null)
                {
                    TempData["Msg"] = "User not found / Uname pass mismatch";
                    return RedirectToAction("Index");
                }
                Session["user"] = user;
                //Session["id"] = ((UserDTO)Session["user"]).Id;
                TempData["userId"] = user.Id;
                TempData["Msg"] = "Login Successfull as "+user.Type;
                if (user.Type.Equals("User"))
                {
                    return RedirectToAction("Index", "User");
                }
                if (user.Type.Equals("Admin"))
                {
                    return RedirectToAction("Index", "Admin");
                }
                return RedirectToAction("Index", "Login");
            }
            return View(l);
        }
    }
}