using Microsoft.AspNetCore.Mvc;
using SoccerJerseyPass.Models;
using System.Diagnostics;

namespace SoccerJerseyPass.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

      
    }
}