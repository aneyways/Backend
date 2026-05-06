using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AudioShop.Domains.Models.Base;
using AudioShop.Domains.Models.Product;

namespace AudioShop.BusinessLogic.Interface
{ 
   
    public interface IProduct
    {
        List<ProductDto> GetAllProductsAction();
        ProductDto GetProductByIdAction(int id);
        ResponceMsg ResponceProductUpdateAction(ProductDto product);
        ResponceMsg ResponceProductDeleteAction(int id);
        ResponceMsg ResponceProductCreateAction(ProductDto product);
    }
}
