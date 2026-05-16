
using AudioShop.Domains.Entities.Order;

namespace AudioShop.Domains.Models.Order
{
    public class OrderDto
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public List<OrderItemDto> Items { get; set; }

        public decimal Total { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime Created { get; set; }
    }
}
