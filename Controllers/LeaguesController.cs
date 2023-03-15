using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoccerJerseyPass.Data;

namespace SoccerJerseyPass.Controllers
{
    public class LeaguesController : Controller
    {
        private readonly AppDbContext _context;

        public LeaguesController(AppDbContext context)
        {
            _context = context; 
        }

        public async Task <IActionResult> Index()
        {

            var allLeagues = await _context.Leagues.ToListAsync();
            return View();
        }
    }
}
