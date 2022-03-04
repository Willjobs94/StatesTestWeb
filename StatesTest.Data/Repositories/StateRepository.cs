using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StatesTest.Data.Models;

namespace StatesTest.Data.Repositories
{
    public class StateRepository : BaseRepository<StateEntity>,  IStateRepository
    {
        
        private readonly StatesTestDbContext _dbContext;
        public StateRepository(StatesTestDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<StateEntity> GetById(int id)
        {
            return await _dbContext.Set<StateEntity>().FirstOrDefaultAsync(x => x.StateId == id);
        }
    }
}