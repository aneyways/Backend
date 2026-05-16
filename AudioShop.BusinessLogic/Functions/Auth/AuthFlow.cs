using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AudioShop.BusinessLogic.Core.Auth;
using AudioShop.BusinessLogic.Interface;
using AudioShop.Domains.Models.Auth;
using AudioShop.Domains.Models.Base;
using AudioShop.Domains.Models.User;
namespace AudioShop.BusinessLogic.Functions.Auth
{
    public class AuthFlow : AuthActions, IAuthActions
    {
        public ResponseAction UserRegisterAction(UserRegisterData data)
        {
            var user = ExecuteUserRegisterAction(data);

            if (user == null)
            {
                return new ResponseAction
                {
                    IsSuccess = false,
                    Message = "User with this Username or Email already exists"
                };
            }

            return new ResponseAction
            {
                IsSuccess = true,
                Message = "Successly registered",
                Id = user.Id
            };
        }

        public ResponseAction UserLoginAction(UserLoginData auth)
        {
            var user = ExecuteUserLoginAction(auth);

            if (user == null)
            {
                return new ResponseAction
                {
                    IsSuccess = false,
                    Message = "Invalid username or password"
                };
            }

            var token = GenerateUserToken(user);

            return new ResponseAction
            {
                IsSuccess = true,
                Message = token,
                Id = user.Id
            };
        }
    }
}