using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AudioShop.Domains.Entities.Order;
using AudioShop.Domains.Enums.Order;

namespace AudioShop.Domains.Models.Order
{
    public class OrderResponseDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public List<OrderItemData> Items { get; set; } = new List<OrderItemData>();
        public decimal TotalPrice { get; set; }
        public OrderStatus Status { get; set; }
    }
}