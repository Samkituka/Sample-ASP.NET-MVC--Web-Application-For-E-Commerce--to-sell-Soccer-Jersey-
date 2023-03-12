﻿using SoccerJerseyPass.Data.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoccerJerseyPass.Models
{
    public class Soccer_Jersey
    {
        [Key]

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public string ImageURL { get; set; }

        public string Size { get; set; }

        public string Sleeve { get; set; }

        public Club Club { get; set; }

        // Relationships

        public List <Player_Jersey> PlayerJersey { get; set; }

        // League

        public int LeagueId { get; set; }

        [ForeignKey("LeagueId")]

        public List <League> leagues { get; set; }

        // Coach

        public int CoachId { get; set; }

        [ForeignKey("CoachId")]

        public List<Coach> coaches { get; set; }
    }
}
