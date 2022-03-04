using System.Threading.Tasks;
using StatesTest.Data.Models;

namespace StatesTest.Data.Repositories
{
    public interface IStateRepository : IBaseRepository<StateEntity>
    {
        Task<StateEntity> GetById(int id);
    }
}