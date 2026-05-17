using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AudioShop.Domains.Models.Cart;
using AudioShop.Domains.Entities.Order;
using AudioShop.Domains.Models.Cart;

namespace AudioShop.Domains.Models.Order
{
    public class OrderCreateDto
    {
        public int UserId { get; set; }
        public List<OrderItemCreateDto> Items { get; set; } = new List<OrderItemCreateDto>();
    }
}