using Microsoft.AspNetCore.Mvc;
using SoccerJerseyPass.Data;

namespace SoccerJerseyPass.Controllers
{
    public class PlayersController : Controller
    {

        private readonly AppDbContext _context;

        public PlayersController(AppDbContext context)
        {
            _context = context;
        }
    
        public IActionResult Index()
        {
            var data = _context.Players.ToList();

            return View();
        }
    }
}
