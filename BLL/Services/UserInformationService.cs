using BLL.Interfaces;
using BLL.Models.User;
using DAL.Entities.Entities;
using DAL.Interfaces;
using System;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserInformationService : IUserInformationService
    {
        private readonly IUserInformationRepository _userInformationRepository;

        public UserInformationService(IUserInformationRepository userInformationRepository)
        {
            _userInformationRepository = userInformationRepository;
        }

        public async Task<UserInformationEntity> CreateUserInformationAsync(Guid userId, UserInformationModel userInformationModel)
        {

            var userInformationEntity = new UserInformationEntity
            {
                UserId = userId,
                Addres = userInformationModel.Addres,
                DateOfBirth = userInformationModel.DateOfBirth,
                About = userInformationModel.About,
                DepartmentId = userInformationModel.Department.Id
            };

            await _userInformationRepository.CreateAsync(userInformationEntity);
            await _userInformationRepository.SaveAsync();

            return userInformationEntity;
        }

        public async Task UpdateUserInformationAsync(UserInformationEntity userInformationEntity, UserInformationModel userInformationModel)
        {
            userInformationEntity.Department.Id = userInformationModel.Department.Id;
            userInformationEntity.Addres = userInformationModel.Addres;
            userInformationEntity.DateOfBirth = userInformationModel.DateOfBirth;
            userInformationEntity.About = userInformationModel.About;

            await _userInformationRepository.SaveAsync();
        }
    }
}