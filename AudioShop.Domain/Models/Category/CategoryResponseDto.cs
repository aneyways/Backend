using System.Collections.Generic;
using AudioShop.Domains.Models.Product;

namespace AudioShop.Domains.Models.Category
{
    public class CategoryResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
