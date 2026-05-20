using System.ComponentModel.DataAnnotations;

namespace AudioShop.Domains.Models.Category
{
    public class CategoryCreateDto
    {
        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Name { get; set; } = null!;
    }
}
    