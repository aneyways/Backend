using AudioShop.Domains.Models.ProductReview;

namespace AudioShop.BusinessLogic.Interface
{
    public interface IProductReviewActions
    {
        public ProductReviewDto CreateProductReviewAction(ProductReviewDto review);
        public List<ProductReviewDto> GetAllProductReviewsAction();
        public List<ProductReviewDto> GetProductReviewsByProductIdAction(int productId);
        public bool DeleteProductReviewAction(int id);
    }
}