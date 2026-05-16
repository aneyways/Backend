using System.ComponentModel;
using AudioShop.BusinessLogic.Functions.Auth;
using AudioShop.BusinessLogic.Functions.Order;
using AudioShop.BusinessLogic.Functions.Products;
using AudioShop.BusinessLogic.Functions.SiteReview;
using AudioShop.BusinessLogic.Functions.SubCategory;
using AudioShop.BusinessLogic.Interface;
using AudioShop.BusinessLogic.Functions.Auth;
using AudioShop.BusinessLogic.Functions.Cart;
using AudioShop.BusinessLogic.Functions.Category;
using AudioShop.BusinessLogic.Functions.Order;
using AudioShop.BusinessLogic.Functions.ProductReview;
using AudioShop.BusinessLogic.Functions.Products;
using AudioShop.BusinessLogic.Functions.SiteReview;
using AudioShop.BusinessLogic.Functions.SubCategory;
using AudioShop.BusinessLogic.Functions.User;
using AudioShop.BusinessLogic.Interface;

namespace AudioShop.BusinessLogic
{
    public class BusinessLogic
    {
        public BusinessLogic() { }
        public IAuthActions GetAuthActions()
        {
            return new AuthFlow();
        }

        public IProductActions GetProductActions()
        {
            return new ProductFlow();
        }

        public IUserActions GetUserActions()
        {
            return new UserFlow();
        }

        public IOrderActions GetOrderActions()
        {
            return new OrderFlow();
        }

        public ISiteReviewActions GetSiteReviewActions()
        {
            return new SiteReviewFlow();
        }

        public ICartActions GetCartActions()
        {
            return new CartFlow();
        }

        public IProductReviewActions GetProductReviewActions()
        {
            return new ProductReviewFlow();
        }

        public ICategoryActions GetCategoryActions()
        {
            return new CategoryFlow();
        }
        public ISubCategoryActions GetSubCategoryActions()
        {
            return new SubCategoryFlow();
        }
    }
}