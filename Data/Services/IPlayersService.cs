using SoccerJerseyPass.Models;
using System;
using System.Net;

namespace SoccerJerseyPass.Data.Services
{
    public interface IPlayersService
    {
        Task <IEnumerable<Player>> GetAllAsync();

        Task<Player> GetByIdAsync(int Id);

        Task AddAsync(Player player);

        Task<Player> UpdateAsync(int id, Player newPlayer);

        void Delete(int id); 

    }
}
