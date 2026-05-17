using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AudioShop.Domains.Entities.Order;
using AudioShop.Domains.Entities.User;
using AudioShop.Domains.Enums.Order;

namespace AudioShop.Domains.Entities.Order
{
    public class OrderData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public UserData User { get; set; }
        [InverseProperty("Order")]
        public List<OrderItemData> Items { get; set; } = new List<OrderItemData>();
        public decimal TotalPrice { get; set; }
        public OrderStatus Status { get; set; }
    }
}