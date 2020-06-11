using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Models.User;
using DAL.Entities.Entities;

namespace BLL.Interfaces
{
    public interface IDepartmentService
    {
        Task CreateDepartmentAsync(DepartmentModel departmentModel);
        Task<DepartmentEntity> GetDepartmentAsync(Guid departmentId);
        Task<List<DepartmentEntity>> GetAllDepartmentsAsync();
        Task<string> DeleteDepartmentAsync(Guid departmentId);
        Task<string> UpdateDepartmentAsync(Guid departmentId, DepartmentModel departmentModel);
    }
}