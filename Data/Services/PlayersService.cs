using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using SoccerJerseyPass.Data.Base;
using SoccerJerseyPass.Models;

namespace SoccerJerseyPass.Data.Services
{
    public class PlayersService : EntityBaseRepository<Player>, IPlayersService
    {
        public PlayersService (AppDbContext context): base (context) { }
    }
}
