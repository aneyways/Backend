using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AudioShop.Domains.Entitiies.Product;
using AudioShop.Domains.Entitiies.Refs;
using AudioShop.Domains.Enums;

namespace AudioShop.Domains.Entitiies.Product
{
    public class ProductData : SharedFields
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public ProductDescriptionData? Description { get; set; }
        public CategoryData Category { get; set; }
        public List<ProductImgData> Images { get; set; }
        public decimal Price { get; set; }
        public ProductStatus Status { get; set; }
    }
}
