using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AudioShop.Domains.Entitiies.Product;

namespace AudioShop.Domains.Entitiies.Product
{
    public class ProductDescriptionData
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string? Description { get; set; }
        public DescriptionAdvanced DescriptionAdvanced { get; set; }
    }
}
