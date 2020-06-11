using BLL.Interfaces;
using BLL.Models.User;
using DAL.Entities.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserInformationService _informationService;
        
        public UserService(IUserRepository userRepository,
            IUserInformationService informationService)
        {
            _userRepository = userRepository;
            _informationService = informationService;
        }

        public async Task CreateUserAsync(UserModel user)
        {
            var userEntity = new UserEntity
            {
                Id = Guid.NewGuid(),
                Name = user.Name,
                LastName = user.LastName,
                Patronymic = user.Patronymic,
                IsDeleted = false
            };

            var userInformation = await _informationService.CreateUserInformationAsync(userEntity.Id, user.UserInformation);
            userEntity.UserInformation = userInformation;

            await _userRepository.CreateAsync(userEntity);
            await _userRepository.SaveAsync();
        }

        public async Task<UserEntity> GetUserAsync(Guid userId)
        {
            return await _userRepository.GetUserAsync(userId);
        }

        public async Task<List<UserEntity>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllUsersAsync();
        }

        public async Task<string> DeleteUserAsync(Guid userId)
        {
            var user = await _userRepository.GetUserAsync(userId);
            if (user == null) return "User is not found";

            user.IsDeleted = true;
            await _userRepository.SaveAsync();

            return $"User: {user.LastName} {user.Name} deleted";
        }

        public async Task<string> UpdateUserAsync(Guid userId, UserModel userModel)
        {
            var user = await _userRepository.GetUserAsync(userId);
            if (user == null) return "User is not found";
            
            user.LastName = userModel.LastName;
            user.Name = userModel.Name;
            user.Patronymic = userModel.Patronymic;
            await _userRepository.SaveAsync();

            await _informationService.UpdateUserInformationAsync(user.UserInformation, userModel.UserInformation);

            return "User Information Updated";
        }
    }
}