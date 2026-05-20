using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AudioShop.Domains.Entities.Order;
using AudioShop.Domains.Entities.Product;

namespace AudioShop.Domains.Entities.Order
{
    public class OrderItemData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ProductId { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public OrderData Order { get; set; }
        [ForeignKey("ProductId")]
        public ProductData Product { get; set; }
        public decimal UnitPrice { get; set; }
    }

}