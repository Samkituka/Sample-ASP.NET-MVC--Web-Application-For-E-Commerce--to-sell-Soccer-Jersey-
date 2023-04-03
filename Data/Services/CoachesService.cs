using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using SoccerJerseyPass.Models;

namespace SoccerJerseyPass.Data.Services
{
    public class CoachesService : ICoachesService
    {
        private readonly AppDbContext _context;

        public CoachesService(AppDbContext context)
        {
            _context = context;
        }
        
        public async Task AddAsync(Coach coach)
        {
            await _context.AddAsync(coach);
           await  _context.SaveChangesAsync();
     
        }

        public async Task DeleteAsync(int Id)
        {
            var result = await _context.Coaches.FirstOrDefaultAsync(n => n.Id == Id);
             _context.Coaches.Remove(result);
            await _context.SaveChangesAsync();
        }

        public async Task <IEnumerable<Coach>> GetAllAsync()
        {
            var result = await _context.Coaches.ToListAsync();
            return result; 
        }

        public async Task<Coach> GetByIdAsync (int Id)
        {
           var result = await _context.Coaches.FirstOrDefaultAsync(n => n.Id== Id);
            return result;
        }

        public async Task <Coach> UpdateAsync(int id, Coach newCoach)
        {
            _context.Update(newCoach);
            await _context.SaveChangesAsync();
            return newCoach;
            
        }
    }
}
