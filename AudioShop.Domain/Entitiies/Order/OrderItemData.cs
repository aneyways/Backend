using AudioShop.Domains.Entitiies.Order;
using AudioShop.Domains.Entitiies.Product;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AudioShop.Domains.Entitiies.Order
{
    public class OrderItemData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int OrderId { get; set; }

        [ForeignKey("OrderId")]
        public OrderData? Order { get; set; }

        [Required]
        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public ProductData? Product { get; set; }

        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
