using DAL.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUserRepository : IGenericRepository<UserEntity>
    {
        Task<UserEntity> GetUserAsync(Guid id);
        Task<List<UserEntity>> GetAllUsersAsync();
    }
}