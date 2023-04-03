using SoccerJerseyPass.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerJerseyPass.Data.Base.ViewModels
{
    public class NewSoccer_JerseyDropdownsVM
    {
        public NewSoccer_JerseyDropdownsVM()
        {
            Coaches = new List<Coach>();
            Leagues = new List<League>();
            Players = new List<Player>();
        }

        public List<Coach> Coaches { get; set; }
        public List<League> Leagues { get; set; }
        public List<Player> Players { get; set; }

    }
}
