using Microsoft.AspNetCore.Mvc;

namespace SoccerJerseyPass.Controllers
{
    public class Soccer_JerseysController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
