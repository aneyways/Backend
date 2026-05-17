using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AudioShop.Domains.Entities.Cart;
using AudioShop.Domains.Entities.Refs;
using AudioShop.Domains.Entities.User;
using AudioShop.Domains.Enums.Cart;

namespace AudioShop.Domains.Entities.Cart
{
    public class CartData : SharedFields
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public UserData User { get; set; }
        [InverseProperty("Cart")]
        public List<CartItemData> Items { get; set; } = new List<CartItemData>();

        public decimal TotalPrice { get; set; }
        public CartStatus Status { get; set; }

    }
}