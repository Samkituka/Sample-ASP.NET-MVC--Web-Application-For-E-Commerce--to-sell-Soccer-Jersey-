using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Identity.Client;
using SoccerJerseyPass.Data.Base;
using SoccerJerseyPass.Data.Base.ViewModels;
using SoccerJerseyPass.Models;

namespace SoccerJerseyPass.Data.Services
{
    public class SoccerJerseysService : EntityBaseRepository<Soccer_Jersey>, ISoccerJerseysService
    {
        private readonly AppDbContext _context;

        public SoccerJerseysService(AppDbContext context) : base(context) 
        { 
            _context = context; 
        }

        public async Task AddNewSoccer_JerseyAsync(NewSoccer_JerseyVM data)
        {
            var newSoccer_Jersey = new Soccer_Jersey()
            {
                Name = data.Name,
                Description = data.Description,
                Price = data.Price,
                ImageURL = data.ImageURL,
                LeagueId = data.LeagueId,
                Size = data.Size,
                Sleeve = data.Sleeve,
                Club = data.Club,
                CoachId = data.CoachId
            };
            await _context.Soccer_Jerseys.AddAsync(newSoccer_Jersey);
            await _context.SaveChangesAsync();

            // Add Player Jersey 
            foreach (var playerId in data.PlayerIds)
            {
                var newPlayer_Jersey = new Player_Jersey()
                {
                    Soccer_JerseyId = newSoccer_Jersey.Id,
                    PlayerId = playerId
                };
                await _context.Player_Jerseys.AddAsync(newPlayer_Jersey);
            }
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSoccer_JerseyAsync(int id)
        {
            var soccer_jerseyDetails = await _context.Soccer_Jerseys
              .Include(l => l.League)
              .Include(c => c.Coach)
              .Include(pj => pj.Player_Jerseys).ThenInclude(a => a.Player)
              .FirstOrDefaultAsync(n => n.Id == id);

            var entity = await _context.Set<Soccer_Jersey>().FirstOrDefaultAsync(n => n.Id == id);
            EntityEntry entityEntry = _context.Entry<Soccer_Jersey>(entity);
            entityEntry.State = EntityState.Deleted;

            await _context.SaveChangesAsync();
        }

        public async Task<NewSoccer_JerseyDropdownsVM> GetNewSoccer_JerseyDropdownsValues()
        {
            var response = new NewSoccer_JerseyDropdownsVM()
            {
                Players = await _context.Players.OrderBy(n => n.FullName).ToListAsync(),
                Leagues = await _context.Leagues.OrderBy(n => n.Name).ToListAsync(),
                Coaches = await _context.Coaches.OrderBy(n => n.FullName).ToListAsync()
            };

            return response;
        }

        public async Task<Soccer_Jersey> GetSoccer_JerseyByIdAsync(int id)
        {
            var soccer_jerseyDetails = await _context.Soccer_Jerseys
              .Include(l =>l.League)
              .Include(c =>c.Coach)
              .Include(pj => pj.Player_Jerseys).ThenInclude(a => a.Player)
              .FirstOrDefaultAsync(n => n.Id == id);

            return soccer_jerseyDetails;
        }

        public async Task UpdateSoccer_JerseyAsync(NewSoccer_JerseyVM data)
        {
            var soccer = await _context.Soccer_Jerseys.FirstOrDefaultAsync(n => n.Id == data.Id);

            if (soccer != null)
            {
                soccer.Name = data.Name;
                soccer.Description = data.Description;
                soccer.Price = data.Price;
                soccer.ImageURL = data.ImageURL;
                soccer.LeagueId = data.LeagueId;
                soccer.Size = data.Size;
                soccer.Sleeve = data.Sleeve;
                soccer.Club = data.Club;
                soccer.CoachId = data.CoachId;
                await _context.SaveChangesAsync();
            }


            var existingPlayer = _context.Player_Jerseys.Where(n => n.Soccer_JerseyId == data.Id).ToList();
            _context.Player_Jerseys.RemoveRange(existingPlayer);
            await _context.SaveChangesAsync();


            foreach (var playerId in data.PlayerIds)
            {
                var newPlayerJersey = new Player_Jersey()
                {
                    Soccer_JerseyId = data.Id,
                    PlayerId = playerId
                };
                await _context.Player_Jerseys.AddAsync(newPlayerJersey);
            }
            await _context.SaveChangesAsync();
        }
    }
}
