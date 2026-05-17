using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AudioShop.Domains.Entities.Cart;
using AudioShop.Domains.Enums.Cart;

namespace AudioShop.Domains.Models.Cart
{
    public class CartCreateDto
    {
        public int UserId { get; set; }
        //public List<CartItemData> Items { get; set; } = new List<CartItemData>();
        //public decimal TotalPrice { get; set; }
        public CartStatus Status { get; set; }
    }
}