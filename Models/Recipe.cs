using System.ComponentModel.DataAnnotations;

namespace AllSpice.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        [Required]
        public string CreatorId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; } = "No Description";

    }
}