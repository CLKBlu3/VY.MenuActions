using System.Threading.Tasks;

namespace VY.MenuActions.Infraestructure.Contracts.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetAllAsync();
        Task SaveAsync(T entity);
    }
}
