using System;
using System.ComponentModel.DataAnnotations;

namespace SoccerJerseyPass.Models
{
    public class Coach
    {
        [Key]

        public int Id { get; set; }

        [Display(Name = "Profile Picture")]
        public string ProfilePictureURL { get; set; }

        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Display(Name = "Biography")]
        public string Bio { get; set; }

        // Relationships

        public List <Soccer_Jersey> Soccer_Jerseys { get; set; }
    }
}
