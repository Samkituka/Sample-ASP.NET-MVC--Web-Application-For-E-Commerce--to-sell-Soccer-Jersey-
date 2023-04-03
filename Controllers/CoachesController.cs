using Microsoft.AspNetCore.Mvc;
using SoccerJerseyPass.Data;
using SoccerJerseyPass.Data.Services;
using SoccerJerseyPass.Models;

namespace SoccerJerseyPass.Controllers
{
    public class CoachesController : Controller
    {

        private readonly ICoachesService _service;

        public CoachesController(ICoachesService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();

            return View(data);
        }

        //GET: Coaches/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName, ProfilePictureURL,Bio")] Coach coach)
        {
            if (!ModelState.IsValid)
            {
                await _service.AddAsync(coach);
                return RedirectToAction(nameof(Index));
            }
            return View(coach);
        }

        //GET: Coaches/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var coachDetails = await _service.GetByIdAsync(id);

            if (coachDetails == null) return View("NotFound");
            return View(coachDetails);
        }

        //GET: Coaches/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var coachDetails = await _service.GetByIdAsync(id);

            if (coachDetails == null) return View("NotFound");
            return View(coachDetails);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id, FullName, ProfilePictureURL,Bio")] Coach coach)
        {
            if (!ModelState.IsValid)
            {
                await _service.UpdateAsync(id, coach);
                return RedirectToAction(nameof(Index));
            }
            return View(coach);
        }

        //GET: Coaches/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var coachDetails = await _service.GetByIdAsync(id);

            if (coachDetails == null) return View("NotFound");
            return View(coachDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> IsDeleted(int id)
        {
            var coachDetails = await _service.GetByIdAsync(id);
            if (coachDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
