using ShoeStore.Data;
using ShoeStore.Data.Entities;
using ShoeStore.Services.Users.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoeStore.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> userRepository;

        public UserService(IRepository<User> userRepository)
        {
            this.userRepository = userRepository;
        }
        public UserDto Get(int id)
        {
            if (id < 0) throw new ArgumentException(nameof(id));
            var user = userRepository.Get(id);
            if (user == null) throw new ArgumentNullException($"User with Id : {id} was not found");

            var userDto = new UserDto
            {
                Id = user.Id,
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Password = user.Password
            };
            return userDto;
        }

        public IList<UserDto> GetAll()
        {
            return userRepository.Query().Select(u => new UserDto
            {
                Id = u.Id,
                UserName = u.UserName,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Email = u.Email,
                Password = u.Password
            }).ToList();
        }
    }
}
