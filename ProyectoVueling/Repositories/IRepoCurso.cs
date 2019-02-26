using ProyectoVueling.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoVueling.Repositories
{
    public interface IRepoCurso:IRepository<Curso>
    {
        DateTime CalcularFecha();
    }
}
