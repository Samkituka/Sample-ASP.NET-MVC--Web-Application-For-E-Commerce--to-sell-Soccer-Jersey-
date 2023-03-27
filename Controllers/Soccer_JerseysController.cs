using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoccerJerseyPass.Data;

namespace SoccerJerseyPass.Controllers
{
    public class Soccer_JerseysController : Controller
    {
        private readonly AppDbContext _context;

        public Soccer_JerseysController(AppDbContext context)
        {
            _context = context; 
        }

        public async Task<IActionResult> Index()
        {
            var allSoccer_Jerseys = await _context.Soccer_Jerseys.Include(n=> n.League).OrderBy(n=>n.Name).ToListAsync();
            return View(allSoccer_Jerseys);
        }
    }
}
