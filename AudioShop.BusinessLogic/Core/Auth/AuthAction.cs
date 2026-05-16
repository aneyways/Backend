using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AudioShop.BusinessLogic.Interface;
using AudioShop.BusinessLogic.Core.User;
using AudioShop.BusinessLogic.Structure;
using AudioShop.DataAccess.Context;
using AudioShop.Domains.Entities.User;
using AudioShop.Domains.Models.Auth;
using AudioShop.Domains.Models.User;

namespace AudioShop.BusinessLogic.Core.Auth
{
    public class AuthActions
    {
        private readonly UserActions _userActions = new();

        public UserData? ExecuteUserRegisterAction(UserRegisterData registerData)
        {
            var _newUser = new UserCreateDto
            {
                UserName = registerData.UserName,
                Email = registerData.Email,
                Password = registerData.Password
            };

            var _user = _userActions.ExecuteCreateUserAction(_newUser);

            return _user;
        }

        public UserData? ExecuteUserLoginAction(UserLoginData data)
        {
            if (string.IsNullOrEmpty(data.Login) || string.IsNullOrEmpty(data.Password))
            {
                return null;
            }

            var passwordHash = PasswordHasher.Hash(data.Password);

            using (var db = new AppDbContext())
            {
                return db.Users.FirstOrDefault(u => (u.UserName == data.Login || u.Email == data.Login) && u.Password == passwordHash);
            }
        }

        public string? GenerateUserToken(UserData user)
        {
            var token = new TokenService();
            return token.GenerateToken(user.Id, user.UserName, user.Role.ToString());
        }
    }
}