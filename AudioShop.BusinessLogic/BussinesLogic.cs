using AudioShop.BusinessLogic.Functions.Auth;
using AudioShop.BusinessLogic.Functions.Order;
using AudioShop.BusinessLogic.Functions.Products;
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

        public IProduct GetProductActions()
        {
            return new ProductFlow();
        }


        public IOrderAction GetOrderActions()
        {
            return new OrderFlow();
        }

    }
}
