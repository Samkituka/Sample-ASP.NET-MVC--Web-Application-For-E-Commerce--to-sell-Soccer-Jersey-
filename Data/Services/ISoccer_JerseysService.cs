using SoccerJerseyPass.Data.Base;
using SoccerJerseyPass.Data.Base.ViewModels;
using SoccerJerseyPass.Models;
using System;
using System.Net;

namespace SoccerJerseyPass.Data.Services
{
    public interface ISoccerJerseysService:IEntityBaseRepository <Soccer_Jersey>
    {
        Task<IEnumerable<Soccer_Jersey>> GetAllAsync();
        Task<Soccer_Jersey> GetSoccer_JerseyByIdAsync(int id);
        Task<NewSoccer_JerseyDropdownsVM> GetNewSoccer_JerseyDropdownsValues();
        Task AddNewSoccer_JerseyAsync(NewSoccer_JerseyVM data);
        Task UpdateSoccer_JerseyAsync(NewSoccer_JerseyVM data);
        Task DeleteSoccer_JerseyAsync(int id);

    }
}
