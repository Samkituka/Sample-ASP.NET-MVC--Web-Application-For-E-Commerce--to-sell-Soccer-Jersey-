using System;
using System.ComponentModel.DataAnnotations;

namespace SoccerJerseyPass.Models
{
    public class League
    {
        [Key]

        public int Id { get; set; }

        [Display(Name= "League Logo")]
        public string Logo { get; set; }

        [Display(Name ="League Name")]
        public string Name { get; set; }

        [Display(Name= "League Description")]
        public string Description { get; set; }

        // Relationships
        
        public List<Soccer_Jersey> soccer_Jerseys { get; set; }


    }
}
