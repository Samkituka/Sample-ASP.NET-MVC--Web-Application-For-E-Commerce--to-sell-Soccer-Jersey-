using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SoccerJerseyPass.Data;
using SoccerJerseyPass.Data.Base.ViewModels;
using SoccerJerseyPass.Data.Services;
using SoccerJerseyPass.Models;

namespace SoccerJerseyPass.Controllers
{
    public class Soccer_JerseysController : Controller
    {
        private readonly ISoccerJerseysService _service;

        public Soccer_JerseysController( ISoccerJerseysService service)
        {
            _service= service;
        }

        public async Task<IActionResult> Index()
        {
          var data = await _service.GetAllAsync(n=>n.League);  
            return View(data);
        }

        // Get: Soccer_Jersey / Create
        public async Task<IActionResult> Create()
        {
            var jerseyDropdownsData = await _service.GetNewSoccer_JerseyDropdownsValues();

            ViewBag.Leagues = new SelectList(jerseyDropdownsData.Leagues, "Id", "Name");
            ViewBag.Coaches = new SelectList(jerseyDropdownsData.Coaches, "Id", "FullName");
            ViewBag.Players = new SelectList(jerseyDropdownsData.Players, "Id", "FullName");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewSoccer_JerseyVM jersey)
        {
            if (!ModelState.IsValid)
            {
                var jerseyDropdownsData = await _service.GetNewSoccer_JerseyDropdownsValues();

                ViewBag.Leagues = new SelectList(jerseyDropdownsData.Leagues, "Id", "Name");
                ViewBag.Coaches = new SelectList(jerseyDropdownsData.Coaches, "Id", "FullName");
                ViewBag.Players = new SelectList(jerseyDropdownsData.Players, "Id", "FullName");

                return View(jersey);
            }

            await _service.AddNewSoccer_JerseyAsync(jersey);
            return RedirectToAction(nameof(Index));
        }

        //Get:Soccer_Jersey /Details/1
        public async Task<IActionResult> Details(int id)
        {
            var jerseyDetails = await _service.GetSoccer_JerseyByIdAsync(id);
            return View(jerseyDetails);
        }

        //Get : Soccer_Jersey/ Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var jerseyDetails = await _service.GetSoccer_JerseyByIdAsync(id);
            if (jerseyDetails == null) return View("NotFound");

            var response = new NewSoccer_JerseyVM()
            {
                Id = jerseyDetails.Id,
                Name = jerseyDetails.Name,
                Description = jerseyDetails.Description,
                Price = jerseyDetails.Price,
                Size = jerseyDetails.Size,
                Sleeve = jerseyDetails.Sleeve,
                ImageURL = jerseyDetails.ImageURL,
                Club = jerseyDetails.Club,
                LeagueId = jerseyDetails.LeagueId,
                CoachId = jerseyDetails.CoachId,
                PlayerIds = jerseyDetails.Player_Jerseys.Select(n => n.PlayerId).ToList(),
            };

            var jerseyDropdownsData = await _service.GetNewSoccer_JerseyDropdownsValues();
            ViewBag.Leagues = new SelectList(jerseyDropdownsData.Leagues, "Id", "Name");
            ViewBag.Coaches = new SelectList(jerseyDropdownsData.Coaches, "Id", "FullName");
            ViewBag.Players = new SelectList(jerseyDropdownsData.Players, "Id", "FullName");

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id,NewSoccer_JerseyVM soccer)
        {
            if (id != soccer.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var jerseyDropdownsData = await _service.GetNewSoccer_JerseyDropdownsValues();

                ViewBag.Leagues = new SelectList(jerseyDropdownsData.Leagues, "Id", "Name");
                ViewBag.Coaches = new SelectList(jerseyDropdownsData.Coaches, "Id", "FullName");
                ViewBag.Players = new SelectList(jerseyDropdownsData.Players, "Id", "FullName");

                return View(soccer);
            }

            await _service.UpdateSoccer_JerseyAsync(soccer);
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Filter(string searchString)
        {
            var jersey = await _service.GetAllAsync(n => n.League);

            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResultNew = jersey.Where(n => string.Equals(n.Name, searchString, StringComparison.CurrentCultureIgnoreCase) || string.Equals(n.Description, searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();

                return View("Index", filteredResultNew);
            }

            return View("Index", jersey);
        }

 
    }
}


