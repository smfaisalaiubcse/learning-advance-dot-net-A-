using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using University_Management_System.DTOs;
using University_Management_System.EF;
using University_Management_System.Auth;


namespace University_Management_System.Controllers
{
    [Student]
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Courses()
        {
            return View();
        }
        public ActionResult Logout()
        {
            return View();
        }
        public ActionResult Profile()
        {
            return View();
        }
    }
}