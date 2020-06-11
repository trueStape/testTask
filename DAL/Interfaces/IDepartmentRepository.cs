using System;
using DAL.Entities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IDepartmentRepository : IGenericRepository<DepartmentEntity>
    {
        Task<List<DepartmentEntity>> GetAllDepartmentsAsync();
        Task<DepartmentEntity> GetDepartmentAsync(Guid departmentId);
    }
}