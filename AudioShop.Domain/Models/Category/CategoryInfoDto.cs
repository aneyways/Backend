using System.Collections.Generic;
using AudioShop.Domains.Models.Product;

namespace AudioShop.Domains.Models.Category
{
    internal class CategoryInfoDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
