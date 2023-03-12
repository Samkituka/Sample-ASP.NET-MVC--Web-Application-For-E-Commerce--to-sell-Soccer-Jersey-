using System;
using System.ComponentModel.DataAnnotations;

namespace SoccerJerseyPass.Models
{
    public class League
    {
        [Key]

        public int Id { get; set; }

        public string Logo { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        // Relationships
        
        public List<Soccer_Jersey> soccer_Jerseys { get; set; }


    }
}
