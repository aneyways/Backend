using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AudioShop.Domains.Entities.Cart;
using AudioShop.Domains.Entities.Order;
using AudioShop.Domains.Entities.Refs;
using AudioShop.Domains.Entities.Cart;
using AudioShop.Domains.Entities.Order;
using AudioShop.Domains.Entities.Refs;

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
        [StringLength(100, MinimumLength = 1)]
        public string Category { get; set; }
        [InverseProperty("Product")]
        public List<CartItemData> CartItems { get; set; } = new List<CartItemData>();

        [InverseProperty("Product")]
        public List<OrderItemData> OrderItems { get; set; } = new List<OrderItemData>();
    }
}