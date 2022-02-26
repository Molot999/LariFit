using LariFit.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace LariFit.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> logger;


        public HomeController(ILogger<HomeController> logger)
        {
            this.logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }


    }
}