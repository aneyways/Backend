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
using AudioShop.Domains.Enums.User;
using AudioShop.BusinessLogic;

namespace AudioShop.BusinessLogic.Core
{
    public class AuthActions
    {
        protected AppDbContext _db = new AppDbContext();

        public UserData ExecuteLoginAction(LoginDto _login)
        {
            var user = _db.UserDatas
                .FirstOrDefault(u => u.UserName == _login.UserName);

            if (user == null) return null;

            if (!PasswordHasher.Verify(_login.Password, user.Password))
                return null;

            return user;
        }

        public UserData ExecuteRegisterAction(RegisterDto _register)
        {
            var exists = _db.UserDatas.Any(u => u.UserName == _register.UserName);
            if (exists) return null;

            UserData newUser = new UserData()
            {
                UserName = _register.UserName,
                Email = _register.Email,
                Password = PasswordHasher.Hash(_register.Password),
                Role = UserRole.User,
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
        public string? GenerateUserToken(UserData user)
        {
            var token = new TokenService();
            return token.GenerateToken(user);
        }
    }
}