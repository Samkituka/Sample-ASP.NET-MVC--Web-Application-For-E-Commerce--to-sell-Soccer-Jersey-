using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using SoccerJerseyPass.Models;

namespace SoccerJerseyPass.Data.Services
{
    public class LeaguesService : ILeaguesService
    {
        private readonly AppDbContext _context;

        public LeaguesService(AppDbContext context)
        {
            _context = context;
        }
        
        public async Task AddAsync(League league)
        {
            await _context.AddAsync(league);
           await  _context.SaveChangesAsync();
     
        }

        public async Task DeleteAsync(int Id)
        {
            var result = await _context.Leagues.FirstOrDefaultAsync(n => n.Id == Id);
             _context.Leagues.Remove(result);
            await _context.SaveChangesAsync();
        }

        public async Task <IEnumerable<League>> GetAllAsync()
        {
            var result = await _context.Leagues.ToListAsync();
            return result; 
        }

        public async Task<League> GetByIdAsync (int Id)
        {
           var result = await _context.Leagues.FirstOrDefaultAsync(n => n.Id== Id);
            return result;
        }

        public async Task <League> UpdateAsync(int id, League newLeague)
        {
            _context.Update(newLeague);
            await _context.SaveChangesAsync();
            return newLeague;
            
        }
    }
}
