using System.Security.Cryptography.X509Certificates;
using AudioShop.BusinessLogic.Functions;
using AudioShop.BusinessLogic.Interface;


namespace AudioShop.BusinessLogic
{
    public class BusinessLogic
    {
        public BusinessLogic()
        {}
        public IProductActions GetProductAction()
        {
            return new ProductFlow();
        }

        public IUserActions GetUserAction()
        {
            return new UserFlow();
        }

        public ICartActions GetCartActions()
        {
            return new CartFlow();
        }

        public IOrderActions GetOrderActions()
        {
            return new OrderFlow();
        }
        public IAuthActions GetAuthActions()
        {
            return new AuthFlow();
        }

        public ICategoryActions GetCategoryActions()
        {
            return new CategoryFlow();
        }
        public ISubCategoryAction GetSubCategoryActions()
        {
            return new SubCategoryFlow();
        }

    }
}