using PerfectLoginSystem.DTOs;
using PerfectLoginSystem.EFs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PerfectLoginSystem.Controllers
{
    public class LoginController : Controller
    {
        PerfectLoginSystemEntities2 db = new PerfectLoginSystemEntities2();
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
                            where u.Email.Equals(l.Email) &&
                            u.Password.Equals(l.Password)
                            select u).SingleOrDefault();
                if (user == null)
                {
                    TempData["Msg"] = "User not found / Uname pass mismatch";
                    return RedirectToAction("Index");
                }
                Session["user"] = user;
                TempData["userId"] = user.Id;
                return RedirectToAction("Index", "Admin");
            }
            return View(l);
        }
    }
}