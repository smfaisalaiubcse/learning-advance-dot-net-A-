﻿using PerfectLoginSystem.DTOs;
using PerfectLoginSystem.EFs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PerfectLoginSystem.Controllers
{
    public class RegistrationController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        PerfectLoginSystemEntities2 db = new PerfectLoginSystemEntities2();
        [HttpPost]
        public ActionResult Index(UserDTO user)
        {
            try
            {
                db.Users.Add(Convert(user));
                db.SaveChanges();
                return RedirectToAction("Index", "Login");
            }
            catch (Exception ex)
            {
                TempData["msg"] = "Something went wrong!!" + ex.Message;
            }
            return View(user);
        }
        public static User Convert(UserDTO u)
        {
            return new User
            {
                Id = u.Id,
                FullName = u.FirstName + u.LastName,
                Gender = u.Gender,
                DOB = u.DOB,
                Password = u.Password,
                Email = u.Email,
            };
        }
    }
}