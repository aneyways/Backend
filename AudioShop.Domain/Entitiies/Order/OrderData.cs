using AudioShop.Domains.Entitiies.Order;
using AudioShop.Domains.Entitiies.User;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AudioShop.Domains.Entitiies.Order
{
    public class OrderData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public UserData? User { get; set; }

        [InverseProperty("Order")]
        public List<OrderItemData> Items { get; set; } = new();

        public decimal Total { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime Created { get; set; }
        public bool IsDeleted { get; set; }
    }
}
