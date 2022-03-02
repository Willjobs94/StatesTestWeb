using System.Threading.Tasks;
using StatesTest.Data.Models;

namespace StatesTest.Data.Repositories
{
    public interface ITestResultRepository : IBaseRepository<TestResult>
    {
        Task<TestResult> GetById(int id);
    }
}