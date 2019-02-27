using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoVueling.Repositories
{
    public interface IRepository<T>
    {
        Task<T> GetAsync(int id);
        Task<IEnumerable<T>> GetAsync();
    }
}
