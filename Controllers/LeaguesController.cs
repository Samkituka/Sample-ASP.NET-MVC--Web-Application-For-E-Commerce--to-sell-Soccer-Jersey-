using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoccerJerseyPass.Data;
using SoccerJerseyPass.Data.Services;
using SoccerJerseyPass.Models;

namespace SoccerJerseyPass.Controllers
{
    public class LeaguesController : Controller
    {
        private readonly ILeaguesService _service;

        public LeaguesController(ILeaguesService service)
        {
            _service = service; 
        }


        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();

            return View(data);
        }

        // GET: League /Create
        public async Task <IActionResult> Create ()
        {
            return View();
        }

        [HttpPost]
        public async Task <IActionResult> Create([Bind("Logo, Name, Description")] League league)
        {
            if (!ModelState.IsValid)
            {
                await _service.AddAsync(league);
                return RedirectToAction(nameof(Index));
            }
            return View(league);
        }

        //// GET: League /Details/1
        public async Task<IActionResult> Details(int id)
        {
            var leagueDetails = await _service.GetByIdAsync(id);

            if (leagueDetails == null) return View("NotFound");
            return View(leagueDetails);
        }

        // GET: League /Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var leagueDetails = await _service.GetByIdAsync(id);

            if (leagueDetails == null) return View("NotFound");
            return View(leagueDetails);

        }


        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id, Logo, Name,Description")] League league)
        {
            if (!ModelState.IsValid)
            {
                await _service.UpdateAsync(id, league);
                return RedirectToAction(nameof(Index));
            }
            return View(league);
        }

        // GET: League /Create
        public async Task<IActionResult> Delete(int id)
        {
            var leagueDetails = await _service.GetByIdAsync(id);

            if (leagueDetails == null) return View("NotFound");
            return View(leagueDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> IsDeleted(int id)
        {
            var leagueDetails = await _service.GetByIdAsync(id);
            if (leagueDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
