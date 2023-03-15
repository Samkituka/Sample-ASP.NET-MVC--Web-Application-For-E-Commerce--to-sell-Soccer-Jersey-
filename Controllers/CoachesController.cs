using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoccerJerseyPass.Data;

namespace SoccerJerseyPass.Controllers
{
    public class CoachesController : Controller
    {
        private readonly AppDbContext _context;

        public CoachesController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var allCoaches = await _context.Coaches.ToListAsync();
            return View();
        }
    }
}
