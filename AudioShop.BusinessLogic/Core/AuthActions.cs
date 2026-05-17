using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AudioShop.DataAccess.Context;
using AudioShop.Domains.Entities.Cart;
using AudioShop.Domains.Entities.User;
using AudioShop.Domains.Enums.Cart;
using AudioShop.Domains.Models.Auth;
using AudioShop.DataAccess.Context;
using AudioShop.Domains.Entities.Cart;
using AudioShop.Domains.Entities.User;
using AudioShop.Domains.Enums.Cart;
using AudioShop.Domains.Models.Auth;
namespace AudioShop.BusinessLogic.Core
{
    public class AuthActions
    {
        protected AppDbContext _db = new AppDbContext();

        public UserData ExecuteLoginAction(LoginDto _login)
        {
            return _db.UserDatas.FirstOrDefault(u =>
                u.UserName == _login.UserName &&
                u.Password == _login.Password);
        }

        public UserData ExecuteRegisterAction(RegisterDto _register)
        {
            var exists = _db.UserDatas.Any(u => u.UserName == _register.UserName);
            if (exists) return null;

            UserData newUser = new UserData()
            {
                UserName = _register.UserName,
                Email = _register.Email,
                Password = _register.Password,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                IsActive = true,
            };
            _db.UserDatas.Add(newUser);
            _db.SaveChanges();

            CartData newCart = new CartData()
            {
                UserId = newUser.Id,
                Status = CartStatus.Active,
                TotalPrice = 0,
            };
            _db.CartDatas.Add(newCart);
            _db.SaveChanges();

            return newUser;
        }
    }
}