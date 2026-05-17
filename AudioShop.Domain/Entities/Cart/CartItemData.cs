using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AudioShop.Domains.Entities.Cart;
using AudioShop.Domains.Entities.Product;

namespace AudioShop.Domains.Entities.Cart
{
    public class CartItemData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int CartId { get; set; }
        [ForeignKey("CartId")]
        public CartData Cart { get; set; }
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public ProductData Product { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }

    }
}