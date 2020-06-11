using BLL.Interfaces;
using BLL.Models.User;
using DAL.Entities.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }


        public async Task CreateDepartmentAsync(DepartmentModel departmentModel)
        {
            var departmentEntity = new DepartmentEntity
            {
                Id = Guid.NewGuid(),
                Name = departmentModel.Name
            };

            await _departmentRepository.CreateAsync(departmentEntity);
            await _departmentRepository.SaveAsync();
        }

        public async Task<DepartmentEntity> GetDepartmentAsync(Guid departmentId)
        {
            return await _departmentRepository.GetDepartmentAsync(departmentId);
        }

        public async Task<List<DepartmentEntity>> GetAllDepartmentsAsync()
        {
            return await _departmentRepository.GetAllDepartmentsAsync();
        }

        public async Task<string> DeleteDepartmentAsync(Guid departmentId)
        {
            var department = _departmentRepository.Get(departmentId);
            if (department == null) return "Department is not found";

            _departmentRepository.Delete(department);
            await _departmentRepository.SaveAsync();
            return "Department deleted";
        }

        public async Task<string> UpdateDepartmentAsync(Guid departmentId, DepartmentModel departmentModel)
        {
            var department = await _departmentRepository.GetAsync(departmentId);
            if (department == null) return "Department is not found";

            department.Name = departmentModel.Name;
            await _departmentRepository.SaveAsync();

            return $"Department {department.Name} Updated";
        }
    }
}