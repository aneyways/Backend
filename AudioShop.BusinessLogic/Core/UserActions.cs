using AudioShop.DataAccess.Context;
using AudioShop.Domains.Entities.Cart;
using AudioShop.Domains.Entities.User;
using AudioShop.Domains.Enums.Cart;
using AudioShop.Domains.Models.User;

namespace AudioShop.BusinessLogic.Core
{
    public class UserActions
    {
        protected AppDbContext _db = new AppDbContext();

        public List<UserData> ExecuteGetAllUsersAction()
        {
            return _db.UserDatas.ToList();
        }

        public UserData ExecuteCreateNewUsersAction(UserCreateDto _user)
        {
            UserData newUser = new UserData()
            {
                UserName = _user.UserName,
                Email = _user.Email,
                Password = _user.Password,
                DefaultPaymentMethod = _user.DefaultPaymentMethod,
                DOB = _user.DOB,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                IsActive = true,
            };

            _db.UserDatas.Add(newUser);
            _db.SaveChanges();

            CartData newCart = new CartData()
            {
                UserId = newUser.Id,
                TotalPrice = 0,
                Status = CartStatus.Active,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };

            _db.CartDatas.Add(newCart);
            _db.SaveChanges();

            return newUser;
        }

        public UserData ExecuteUpdateUserAction(int id, UserCreateDto _user)
        {
            var user = _db.UserDatas.FirstOrDefault(u => u.Id == id);

            if (user == null) return null;

            user.UserName = _user.UserName;
            user.Email = _user.Email;
            user.Password = _user.Password;
            user.DefaultPaymentMethod = _user.DefaultPaymentMethod;
            user.DOB = _user.DOB;

            _db.SaveChanges();
            return user;
        }

        public bool ExecuteDeleteUserAction(int id)
        {
            var user = _db.UserDatas.FirstOrDefault(u => u.Id == id);

            if (user == null) return false;

            _db.UserDatas.Remove(user);
            _db.SaveChanges();
            return true;
        }
        public UserData ExecuteGetUserByIdAction(int id)
        {
            return _db.UserDatas.FirstOrDefault(u => u.Id == id);
        }


    }
}