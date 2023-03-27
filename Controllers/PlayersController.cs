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
    
        public async Task <IActionResult> Index()
        {
            var data =await  _service.GetAllAsync();

            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task <IActionResult> Create([Bind("FullName, ProfilePictureURL,Bio")]Player player)
        {
            if (!ModelState.IsValid)
            {
                return View(player);
            }
           await _service.AddAsync(player);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var playerDetails = await _service.GetByIdAsync(id);

            if (playerDetails == null) return View("NotFound");
            return View(playerDetails);
        }

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
                return View(player);
            }
            await _service.UpdateAsync(id, player);
            return RedirectToAction(nameof(Index));
        }
    }
}
