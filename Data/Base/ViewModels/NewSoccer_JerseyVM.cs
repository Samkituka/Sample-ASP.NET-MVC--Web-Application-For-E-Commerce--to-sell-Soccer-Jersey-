using SoccerJerseyPass.Data.Enums;
using SoccerJerseyPass.Models;
using System.ComponentModel.DataAnnotations;

namespace SoccerJerseyPass.Data.Base.ViewModels
{
    public class NewSoccer_JerseyVM
    {
        public int Id { get; set; }

        [Display(Name = "Jersey name")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Display(Name = "Jersey description")]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Display(Name = "Price in $")]
        [Required(ErrorMessage = "Price is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a positive value.")]
        public double Price { get; set; }

        [Display(Name = "Jersey poster URL")]
        [Required(ErrorMessage = "Jersey poster URL is required")]
        public string ImageURL { get; set; }

        [Display(Name = "Jersey size")]
        [Required(ErrorMessage = "size is required")]
        public string Size { get; set; }

        [Display(Name = "Jersey sleeve")]
        [Required(ErrorMessage = "Sleeve is required")]
        public string Sleeve { get; set; }

        [Display(Name = "Select a category")]
        [Required(ErrorMessage = "Club is required")]
        public Club Club { get; set; }

        //Relationships
        [Display(Name = "Select player(s)")]
        [Required(ErrorMessage = "Player jersey(s) is required")]
        public List<int> PlayerIds { get; set; }

        [Display(Name = "Select a league")]
        [Required(ErrorMessage = "League Jersey  is required")]
        public int LeagueId { get; set; }

        [Display(Name = "Select a coach")]
        [Required(ErrorMessage = "coach is required")]
        public int CoachId { get; set; }
    }
}
