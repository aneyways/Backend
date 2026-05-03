
using AudioShop.BusinessLogic.Interface;


namespace AudioShop.BusinessLogic
{
    public class BusinessLogic
    {
        public UserBL GetUserBL()
        {
            return new UserBL();
        }
    }
}
