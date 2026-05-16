using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AudioShop.Domains.Entities.Product;


namespace AudioShop.Domains.Models.Product
{
    public class ProductDto
    {

        public int Id { get; set; }
        public string Name { get; set; }

        public ProductDescriptionData? Description { get; set; }
        public CategoryData Category { get; set; }
        public List<ProductImgData> Images { get; set; }
        public decimal Price { get; set; }
    }
}
