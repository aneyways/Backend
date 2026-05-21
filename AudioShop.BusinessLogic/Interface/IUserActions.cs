using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AudioShop.Domains.Models.User;

namespace AudioShop.BusinessLogic.Interface
{
    public interface IUserActions
    {
        public List<UserResponseDto> GetAllUsersAction();
        public UserResponseDto CreateNewUserAction(UserCreateDto _user);
        public UserResponseDto UpdateUserAction(int id, UserCreateDto _user);
        public bool DeleteUserAction(int id);
        public UserResponseDto GetUserByIdAction(int id);

    }
}