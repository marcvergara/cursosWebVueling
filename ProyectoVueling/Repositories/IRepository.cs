using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoVueling.Repositories
{
    public interface IRepository<T>
    {
        Task<T> Get(int id);
        IEnumerable<T> Get();
    }
}
