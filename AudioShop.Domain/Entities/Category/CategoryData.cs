using AudioShop.Domains.Entities.Product;
using AudioShop.Domains.Entities.Refs;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AudioShop.Domains.Entities.Category
{
    public class CategoryData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;
        public List<SubCategoryData>? SubCategories { get; set; }
        public List<ProductData>? Products { get; set; }
    }
}
