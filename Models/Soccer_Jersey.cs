using SoccerJerseyPass.Data;
using System;
using System.ComponentModel.DataAnnotations;

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
    }
}
