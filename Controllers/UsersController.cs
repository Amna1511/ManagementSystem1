using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ManagementSystem1.Models;

namespace ManagementSystem1.Controllers
{
    public class UsersController : Controller
    {
        private readonly AppDbContext _context;
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Authorise(User user)
        {
            using AppDbContext _context = new AppDbContext();
            if (user.Id == null)
            {
                user.LoginErrorMsg = "Invalid User name or password";
                return View("Index", "Users");
            }
            else
            {
                User UserDetail = _context.User.Where(x => x.Name == user.Name && x.Password == user.Password).FirstOrDefault();
                var temp = user.Id;
                HttpContext.Session.SetString("user.Id", "temp");
                ViewBag.Id = HttpContext.Session.GetString("user.Id");
                return RedirectToAction("Index", "Session");
            }
            //return View();

        }   
    }
}