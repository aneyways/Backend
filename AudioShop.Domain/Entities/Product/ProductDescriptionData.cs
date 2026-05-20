using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AudioShop.Domains.Entities.Product
{
    public class ProductDescriptionData
    {
        public int id { get; set; }

        [Required]
        [StringLength(300)]
        public string Description { get; set; }
        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public ProductData Product { get; set; }
    }
}
