using DAL.Entities.Entities;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class UserInformationRepository : GenericRepository<UserInformationEntity>, IUserInformationRepository
    {
        private readonly DatabaseContext _context;
        public UserInformationRepository(DatabaseContext context) 
            : base(context)
        {
            _context = context;
        }
    }
}