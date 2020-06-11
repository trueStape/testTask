using BLL.Models.User;
using System;
using System.Threading.Tasks;
using DAL.Entities.Entities;

namespace BLL.Interfaces
{
    public interface IUserInformationService
    {
        Task<UserInformationEntity> CreateUserInformationAsync(Guid userId, UserInformationModel userInformationModel);
        Task UpdateUserInformationAsync(UserInformationEntity userInformationEntity, UserInformationModel userInformationModel);
    }
}