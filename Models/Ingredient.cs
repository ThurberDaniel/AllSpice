using System.ComponentModel.DataAnnotations;

namespace AllSpice.Models
{
    public class Ingredient
    {
        [Required]
        public int Id { get; set; }
        [Required]

        public string RecipesId { get; set; }
        [Required]

        public string Name { get; set; }
        public int Quantity { get; set; }
    }
}