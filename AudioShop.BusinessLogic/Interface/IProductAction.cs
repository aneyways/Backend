using AudioShop.Domains.Models.Product;
using AudioShop.Domains.Models.Product;

namespace AudioShop.BusinessLogic.Interface
{
    public interface IProductAction
    {
        List<ProductInfoDto> GetAllProductsAction();

        ProductInfoDto? GetProductByIdAction(int id);

        List<ProductInfoDto> GetProductsByCategoryAction(int categoryId);

        List<ProductInfoDto> GetProductsBySubCategoryAction(int subCategoryId);

        ProductInfoDto? CreateProductAction(ProductCreateDto product);

        ProductInfoDto? UpdateProductAction(int id, ProductCreateDto product);

        bool DeleteProductAction(int id);
    }
}