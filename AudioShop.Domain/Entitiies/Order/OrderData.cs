using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AudioShop.Domains.Entitiies.Order;

namespace AudioShop.Domains.Entitiies.Order
{
    public class OrderData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int UserId { get; set; }


        [InverseProperty("Order")]
        public List<OrderItemData> Items { get; set; }

        public decimal Total { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime Created { get; set; }

        public bool IsDeleted { get; set; }
    }
}
