using System.Security.Cryptography.X509Certificates;
using AudioShop.BusinessLogic.Functions;
using AudioShop.BusinessLogic.Interface;


namespace AudioShop.BusinessLogic
{
    public class BusinessLogic
    {
        public BusinessLogic()
        {
        }

        public IProductAction GetProductAction()
        {
            return new ProductFlow();
        }

        public IUserAction GetUserAction()
        {
            return new UserFlow();
        }

        public ICartAction GetCartActions()
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


    }
}