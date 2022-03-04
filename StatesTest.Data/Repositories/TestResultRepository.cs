using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StatesTest.Data.Models;

namespace StatesTest.Data.Repositories
{
    public class TestResultRepository : BaseRepository<TestResult>, ITestResultRepository
    {
        private readonly StatesTestDbContext _dbContext;
        public TestResultRepository(StatesTestDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TestResult> GetById(int id)
        {
            return await _dbContext.Set<TestResult>().FirstOrDefaultAsync(x => x.TestResultId == id);
        }
    }
}