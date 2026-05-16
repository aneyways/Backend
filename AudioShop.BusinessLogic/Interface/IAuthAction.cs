using AudioShop.Domains.Models.Auth;
using AudioShop.Domains.Models.Base;
using AudioShop.Domains.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioShop.BusinessLogic.Interface
{
    public interface IAuthActions
    {

        public ResponseAction UserRegisterAction(UserRegisterData data);

        public ResponseAction UserLoginAction(UserLoginData auth);
    }
}