using System;
using System.ComponentModel.DataAnnotations;

namespace SoccerJerseyPass.Models
{
    public class League
    {
        [Key]

        public int Id { get; set; }

        [Display(Name= "League Logo")]
        [Required(ErrorMessage = "League logo is required")]
        public string Logo { get; set; }

        [Display(Name ="League Name")]
        [Required(ErrorMessage = "League name is required")]
        public string Name { get; set; }

        [Display(Name= "League Description")]
        [Required(ErrorMessage = "League description is required")]
        public string Description { get; set; }

        // Relationships
        
        public List<Soccer_Jersey> Soccer_Jerseys { get; set; }


    }
}
