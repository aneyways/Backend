
namespace AudioShop.Domains.Models.Category
{
    public class SubCategoryResponseDto
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; } = null!;
    }
}