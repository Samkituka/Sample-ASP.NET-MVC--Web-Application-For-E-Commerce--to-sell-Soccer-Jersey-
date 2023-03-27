using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using SoccerJerseyPass.Models;

namespace SoccerJerseyPass.Data.Services
{
    public class PlayersService : IPlayersService
    {
        private readonly AppDbContext _context;

        public PlayersService(AppDbContext context)
        {
            _context = context;
        }
        
        public async Task AddAsync(Player player)
        {
            await _context.AddAsync(player);
           await  _context.SaveChangesAsync();
     
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task <IEnumerable<Player>> GetAllAsync()
        {
            var result = await _context.Players.ToListAsync();
            return result; 
        }

        public async Task<Player> GetByIdAsync (int Id)
        {
           var result = await _context.Players.FirstOrDefaultAsync(n => n.Id== Id);
            return result;
        }

        public async Task <Player> UpdateAsync(int id, Player newPlayer)
        {
            _context.Update(newPlayer);
            await _context.SaveChangesAsync();
            return newPlayer;
            
        }
    }
}
