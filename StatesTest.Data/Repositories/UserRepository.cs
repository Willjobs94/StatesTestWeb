using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StatesTest.Data.Models;

namespace StatesTest.Data.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly StatesTestDbContext _dbContext;
        public UserRepository(StatesTestDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> GetById(int id)
        {
            return await _dbContext.Set<User>().FirstOrDefaultAsync(x => x.UserId == id);
        }
    }
}