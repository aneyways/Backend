namespace AudioShop.Domains.Models.Order
{
    public class OrderItemDto
    {
        public int Id { get; set; }
        public string ProductInfo { get; set; }
        public int Qua { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
    }
}
