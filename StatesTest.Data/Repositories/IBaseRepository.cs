using System.Linq;
using System.Threading.Tasks;

namespace StatesTest.Data.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();

        Task<TEntity> Create(TEntity entity);

        Task<TEntity> Update(TEntity entity);
        
    }
}