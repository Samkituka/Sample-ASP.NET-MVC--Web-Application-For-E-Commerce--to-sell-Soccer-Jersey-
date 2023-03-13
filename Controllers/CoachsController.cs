using Microsoft.AspNetCore.Mvc;

namespace SoccerJerseyPass.Controllers
{
    public class CoachsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
