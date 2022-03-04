using System.Threading.Tasks;
using StatesTest.Data.Models;

namespace StatesTest.Data.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetById(int id);
    }
}