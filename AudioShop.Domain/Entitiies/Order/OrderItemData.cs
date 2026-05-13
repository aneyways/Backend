using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AudioShop.Domains.Entitiies.Order;

namespace AudioShop.Domains.Entitiies.Order
{
    public class OrderItemData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int OrderId { get; set; }

        [ForeignKey("OrderId")]
        public OrderData Order { get; set; }

        public string ProductInfo { get; set; }
        public int Qua { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
    }
}
