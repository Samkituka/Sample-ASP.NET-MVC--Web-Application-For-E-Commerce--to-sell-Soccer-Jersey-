using SoccerJerseyPass.Models;
using System;
using System.Net;

namespace SoccerJerseyPass.Data.Services
{
    public interface ICoachesService
    {
        Task <IEnumerable<Coach>> GetAllAsync();

        Task<Coach> GetByIdAsync(int Id);

        Task AddAsync(Coach coach);

        Task<Coach> UpdateAsync(int id, Coach newCoach);

        Task DeleteAsync(int id); 

    }
}
