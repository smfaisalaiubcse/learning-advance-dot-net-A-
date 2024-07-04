using PerfectLoginSystem.DTOs;
using PerfectLoginSystem.EFs;
using Simple_Blog_Site.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PerfectLoginSystem.Controllers
{
    [AdminAccess]
    public class AdminController : Controller
    {
        PerfectLoginSystemEntities2 db = new PerfectLoginSystemEntities2();
        public ActionResult Index()
        {
            var data = db.Users.ToList(); // Replace 'Users' with your actual DbSet for users
            var userDtos = data.Select(user => new UserDTO
            {
                Id = user.Id,
                Type = user.Type,
                FullName = user.FullName,
                Gender = user.Gender,
                DOB = user.DOB,
                Password = user.Password,
                Email = user.Email
            }).ToList();

            return View(userDtos);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var exobj = db.Users.Find(id);
            var data = Convert(exobj);
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(UserDTO obj)
        {
            var exobj = db.Users.Find(obj.Id);
            //var data = RegistrationController.Convert(exobj);
            exobj.DOB = obj.DOB;
            exobj.Gender = obj.Gender;
            exobj.Password = obj.Password;
            exobj.FullName = obj.FirstName + " "+ obj.LastName;
            exobj.Email = obj.Email;
            db.SaveChanges();
            var data = Convert(exobj);
            return RedirectToAction("Index");
        }
        public UserDTO Convert(User u)
        {
            return new UserDTO
            {
                Id = u.Id,
                Type = u.Type,
                FullName = u.FullName,
                Gender = u.Gender,
                DOB = u.DOB,
                Password = u.Password,
                Email = u.Email,
            };
        }
    }
}