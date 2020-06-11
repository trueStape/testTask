using DAL.Entities.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class UserRepository : GenericRepository<UserEntity>, IUserRepository
    {
        private readonly DatabaseContext _context;

        public UserRepository(DatabaseContext context)
            : base(context)
        {
            _context = context;
        }
        
        public Task<UserEntity> GetUserAsync(Guid id)
        {
            return Query()
                .Include(x => x.UserInformation)
                    .ThenInclude(x => x.Department)
                .Where(x => x.Id == id && x.IsDeleted == false)
                .SingleOrDefaultAsync();
        }

        public Task<List<UserEntity>> GetAllUsersAsync()
        {
            return Query()
                .Include(x => x.UserInformation)
                    .ThenInclude(x=>x.Department)
                .Where(x => x.IsDeleted == false)
                .OrderBy(x => x.LastName)
                .ToListAsync();
        }
    }
}