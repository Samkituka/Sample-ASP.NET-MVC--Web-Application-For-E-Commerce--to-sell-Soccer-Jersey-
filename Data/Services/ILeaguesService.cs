using SoccerJerseyPass.Models;
using System;
using System.Net;

namespace SoccerJerseyPass.Data.Services
{
    public interface ILeaguesService
    {
        Task <IEnumerable<League>> GetAllAsync();

        Task<League> GetByIdAsync(int Id);

        Task AddAsync(League league);

        Task<League> UpdateAsync(int id, League newLeague);

        Task DeleteAsync(int id); 

    }
}
