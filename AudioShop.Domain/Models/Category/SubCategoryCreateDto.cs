using System.ComponentModel.DataAnnotations;

namespace AudioShop.Domains.Models.Category
{
    public class SubCategoryCreateDto
    {
        [Required]
        public int CategoryId { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Name { get; set; } = null!;
    }
}