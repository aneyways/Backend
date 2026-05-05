using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AudioShop.BusinessLogic.Core.Auth;
using AudioShop.BusinessLogic.Interface;
using AudioShop.Domains.Models.User;

namespace AudioShop.BusinessLogic.Functions.Auth
{
    public class AuthFlow : AuthActions, IAuthActions
    {
        public object? LoginActionFlow(UserAuthAction auth)
        {
            var isValid = ValidateLogin(auth);
            return isValid ? GenToken(auth) : null;
        }
    }
}
