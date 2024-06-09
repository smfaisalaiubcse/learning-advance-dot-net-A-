using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task_1.Models;

namespace Task_1.Controllers
{
    public class HomeController : Controller
    {
        Student s1 = new Student()
        {
            Id = 1,
            Name = "S M Faisal",
            Email = "itssmfaisal@gmail.com",
            Phone = "+8801305619071",
            Expertise = "Programming",
            Degrees = new List<Degree>
            {
                new Degree
                {
                    DegreeName = "BSc CSE",
                    Result = "First Class",
                    PassingYear = 2015,
                    Group = "CS",
                    Institution = "XYZ University"
                },
                new Degree
                {
                    DegreeName = "HSC",
                    Result = "GPA-5",
                    PassingYear = 2019,
                    Group = "Science",
                    Institution = "XYZ College"
                }
            },
            Projects = new List<Project>
            {
                new Project
                {
                    ProjectTitle = "Trip_Nest",
                    Description = "A nest JS project",
                    Course = "Adv. Programming with web technology"
                },
                new Project
                {
                    ProjectTitle = "University Management System",
                    Description = "A Normal PHP, JS project",
                    Course = "Web technology"
                }
            }
        };
        public ActionResult Index()
        {
            ViewBag.Name = "Adv .Net";
            ViewBag.CTeacher = "Tanvir";

            ViewBag.Students = new Student[] { s1 };
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
        public ActionResult EducationDetails(int id)
        {
            ViewBag.Students = new Student[] { s1 };
            return View();
        }
        public ActionResult ProjectDetails(int id)
        {
            ViewBag.Students = new Student[] { s1 };
            return View();
        }

    }
}