using Microsoft.AspNetCore.Mvc;
using SoccerJerseyPass.Data;
using SoccerJerseyPass.Data.Services;
using SoccerJerseyPass.Models;

namespace SoccerJerseyPass.Controllers
{
    public class PlayersController : Controller
    {

        private readonly IPlayersService _service;

        public PlayersController( IPlayersService service)
        {
            _service = service; 
        }
    
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();

            return View(data);
        }

        // GET:Player /Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task <IActionResult> Create([Bind("FullName, ProfilePictureURL,Bio")]Player player)
        {
            if (!ModelState.IsValid)
            {
             await _service.AddAsync(player);
             return RedirectToAction(nameof(Index));
            }
           return View(player);
        }


        // GET : Player/ Details/1
        public async Task<IActionResult> Details(int id)
        {
            var playerDetails = await _service.GetByIdAsync(id);

            if (playerDetails == null) return View("NotFound");
            return View(playerDetails);
        }

        // GET: Player/Edit/1
        public async Task <IActionResult> Edit(int id)
        {
            var playerDetails = await _service.GetByIdAsync(id);

            if (playerDetails == null) return View("NotFound");
            return View(playerDetails);
            
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id, FullName, ProfilePictureURL,Bio")] Player player)
        {
            if (!ModelState.IsValid)
            {
            await _service.UpdateAsync(id, player);
            return RedirectToAction(nameof(Index));
            }
                return View(player);
        }

        // Get:Player/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var playerDetails = await _service.GetByIdAsync(id);

            if (playerDetails == null) return View("NotFound");
            return View(playerDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> IsDeleted(int id)
        {
            var playerDetails = await _service.GetByIdAsync(id);
            if (playerDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
