using BLL.Models.User;
using DAL.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IUserService
    {
        Task CreateUserAsync(UserModel user);
        Task<UserEntity> GetUserAsync(Guid userId);
        Task<List<UserEntity>> GetAllUsersAsync();
        Task<string> DeleteUserAsync(Guid userId);
        Task<string> UpdateUserAsync(Guid userId, UserModel userModel);
    }
}