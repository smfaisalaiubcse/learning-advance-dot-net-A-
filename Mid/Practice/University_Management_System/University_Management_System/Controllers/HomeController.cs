using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using University_Management_System.DTOs;
using University_Management_System.EF;

namespace University_Management_System.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        University_Management_SystemEntities db = new University_Management_SystemEntities();
        [HttpPost]
        public ActionResult Login(LoginDTO l)
        {
            if (ModelState.IsValid)
            {
                var user = (from u in db.Users
                            where u.Id.Equals(l.Id) &&
                            u.Password.Equals(l.Password)
                            select u).SingleOrDefault();
                if (user == null)
                {
                    TempData["Msg"] = "User not found / Uname pass mismatch";
                    return RedirectToAction("Index");
                }
                Session["user"] = user;
                TempData["Msg"] = "Login Successfull "+ user.Type + user.Id;

                if (user.Type.Equals("Student"))
                {
                    return RedirectToAction("Index", "Student");
                }
                return RedirectToAction("Index");
            }
            return View(l);
        }
    }
}