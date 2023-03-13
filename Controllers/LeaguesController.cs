using Microsoft.AspNetCore.Mvc;

namespace SoccerJerseyPass.Controllers
{
    public class LeaguesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
