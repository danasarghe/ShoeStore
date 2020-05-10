using ShoeStore.Services.Users.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoeStore.Services.Users
{
   public  interface IUserService
    {
        UserDto Get(int id);
        IList<UserDto> GetAll();
    }
}
