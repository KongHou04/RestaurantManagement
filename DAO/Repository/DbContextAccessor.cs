using System.Threading;
using DAO.Context;

namespace DAO.Repository
{
    public class DbContextAccessor
    {
        protected RMDbContext _context;
        public DbContextAccessor(RMDbContext context)
        {
            _context = context;
        }

    }
}