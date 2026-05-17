using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AudioShop.BusinessLogic;
using AudioShop.BusinessLogic.Core;
using AudioShop.Domains.Models.Auth;
using AudioShop.BusinessLogic.Interface;
using AudioShop.Domains.Models.Auth;

namespace AudioShop.BusinessLogic.Functions
{
    public class AuthFlow : AuthActions, IAuthActions
    {
        private TokenService _tokenService = new TokenService();

        public string LoginAction(LoginDto _login)
        {
            var user = ExecuteLoginAction(_login);
            if (user == null) return null;
            return _tokenService.GenerateToken(user);
        }

        public string RegisterAction(RegisterDto _register)
        {
            var user = ExecuteRegisterAction(_register);
            if (user == null) return null;
            return _tokenService.GenerateToken(user);
        }
    }
}