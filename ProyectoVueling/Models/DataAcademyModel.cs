using System.Collections.Generic;

namespace ProyectoVueling.Models
{
    public class DataAcademyModel
    {
        private IEnumerable<Curso> Cursos { get; }
        private IEnumerable<Profesor> Profesores { get; }
        private IEnumerable<CursoImpartido> CursosImpartidos { get; }
        private IEnumerable<Modulo> Modulos { get; }

        public DataAcademyModel(IEnumerable<Curso> cursos, IEnumerable<Profesor> profesores, IEnumerable<CursoImpartido> cursosImpartidos, IEnumerable<Modulo> modulos)
        {
            Cursos = cursos;
            Profesores = profesores;
            CursosImpartidos = cursosImpartidos;
            Modulos = modulos;
        }
    }
}
