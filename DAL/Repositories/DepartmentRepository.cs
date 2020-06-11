using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Entities.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class DepartmentRepository : GenericRepository<DepartmentEntity>, IDepartmentRepository
    {
        private readonly DatabaseContext _context;
        public DepartmentRepository(DatabaseContext context) 
            : base(context)
        {
            _context = context;
        }

        public Task<List<DepartmentEntity>> GetAllDepartmentsAsync()
        {
            return Query()
                .Include(x => x.Users)
                .OrderBy(x => x.Name)
                .ToListAsync();
        }

        public Task<DepartmentEntity> GetDepartmentAsync(Guid departmentId)
        {
            return Query()
                .Include(x => x.Users)
                    .ThenInclude(x => x.User)
                .Where(x => x.Id == departmentId)
                .FirstOrDefaultAsync();
        }
    }
}