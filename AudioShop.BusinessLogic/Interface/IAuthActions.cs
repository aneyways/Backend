using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AudioShop.Domains.Models.Auth;

namespace AudioShop.BusinessLogic.Interface
{
    public interface IAuthActions
    {
        public string LoginAction(LoginDto _login);
        public string RegisterAction(RegisterDto _register);
    }
}