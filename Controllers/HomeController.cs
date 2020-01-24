using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ManagementSystem1.Models;

namespace ManagementSystem1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IStudentRepository _studentRepository;

        
        public HomeController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        //public IActionResult Index()
        //{
        //    ViewBag.Title = "Student-OverView";
        //    var student = _studentRepository.GetAllStudent().OrderBy(p => p.Id);
        //    return View(student);
        //}
        public IActionResult Index()
        {
            var model = _studentRepository.GetAllStudent();
            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Student student)
        {
            if(ModelState.IsValid)
            {
                Student newstudent = _studentRepository.Add(student);
            }
            return RedirectToAction("index"); 
        }
        public IActionResult Privacy()
        {
           var model = _studentRepository.GetAllStudent();
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
