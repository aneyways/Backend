using AudioShop.Domains.Entities.User;
using AudioShop.Domains.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioShop.BusinessLogic.Interface
{
    public interface IUserActions
    {
        List<UserInfoDto> GetAllUsersAction();

        UserInfoDto? GetUserByIdAction(int id);

        UserInfoDto? CreateUserAction(UserCreateDto user);

        bool DeleteUserAction(int id);

        UserInfoDto? UpdateUserAction(int id, UserCreateDto user);
    }
}