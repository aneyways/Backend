
using AudioShop.BusinessLogic.Interface;


namespace AudioShop.BusinessLogic
{
    public class BusinessLogic
    {
        public IUser GetUserBL()
        {
            return new UserBL();
        }
    }
}