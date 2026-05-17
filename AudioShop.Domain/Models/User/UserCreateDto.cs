using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AudioShop.Domains.Enums.User;
using AudioShop.Domains.Entities.User;
using AudioShop.Domains.Enums.User;


namespace AudioShop.Domains.Models.User
{
    public class UserCreateDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        //public AddressData? DefaultAddress { get; set; }
        public PaymentMethods? DefaultPaymentMethod { get; set; }
        public DateTime DOB { get; set; }
        public GenderTypes Gender { get; set; }

    }
}