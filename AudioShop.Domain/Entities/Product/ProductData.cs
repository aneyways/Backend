using AudioShop.Domains.Entities.Cart;
using AudioShop.Domains.Entities.Category;
using AudioShop.Domains.Entities.Order;
using AudioShop.Domains.Entities.Refs;
using AudioShop.Domains.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AudioShop.Domains.Entities.Product
{
    public class ProductData : SharedFields
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string Name { get; set; }
        [Required]
        [StringLength(500, MinimumLength = 1)]
        public string Description { get; set; }
        public decimal Price { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 1)   ]

        [InverseProperty("Product")]
        public List<CartItemData> CartItems { get; set; } = new List<CartItemData>();

        [InverseProperty("Product")]
        public List<OrderItemData> OrderItems { get; set; } = new List<OrderItemData>();
        public int? SubCategoryId { get; set; }

        [ForeignKey("SubCategoryId")]
        public SubCategoryData? SubCategory { get; set; }
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public CategoryData? Category { get; set; }

        [InverseProperty("Product")]
        public List<ProductImgData> Images { get; set; } = new();

    }
}