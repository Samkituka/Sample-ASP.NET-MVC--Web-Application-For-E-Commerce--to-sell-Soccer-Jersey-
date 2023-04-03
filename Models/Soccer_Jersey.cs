using Azure.Core;
using SoccerJerseyPass.Data.Base;
using SoccerJerseyPass.Data.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoccerJerseyPass.Models
{
    public class Soccer_Jersey:IEntityBase
    {
        [Key]

        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a positive value.")]
        public double Price { get; set; }
        public string ImageURL { get; set; }
        public string Size { get; set; }
        public string Sleeve { get; set; }
        public Club Club { get; set; }

        // Relationships

        public List <Player_Jersey> Player_Jerseys { get; set; }

        // League

        public int LeagueId { get; set; }
        [ForeignKey("LeagueId")]    
        public League League { get; set; }

        // Coach

        public int CoachId { get; set; }
        [ForeignKey("CoachId")]
        public Coach Coach { get; set; }
    }
}
