using AudioShop.BusinessLogic.Core.Products;
using AudioShop.BusinessLogic.Interface;
using AudioShop.Domains.Models.Base;
using AudioShop.Domains.Models.Product;

namespace AudioShop.BusinessLogic.Functions.Products
{
    public class ProductFlow : ProductAction, IProductAction
    {
        public List<ProductDto> GetAllProductsAction()
        {
            var products = ExecuteGetAllProductsAction();
            //product = GetOrientedProductsForAccount(products);

            return products;
        }

        public ProductDto GetProductByIdAction(int id)
        {
            return GetProductDataByIdAction(id);
        }

        public ResponceMsg ResponceProductUpdateAction(ProductDto product)
        {
            return ExecuteProductUpdateAction(product);
        }

        public ResponceMsg ResponceProductDeleteAction(int id)
        {
            return ExecuteProductDeleteAction(id);
        }

        public ResponceMsg ResponceProductCreateAction(ProductDto product)
        {
            return ExecuteProductCreateAction(product);
        }
    }
}
