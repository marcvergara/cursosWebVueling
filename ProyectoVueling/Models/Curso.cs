using System;
using System.Collections.Generic;

namespace ProyectoVueling.Models
{
    public partial class Curso
    {
        public Curso()
        {
            CursoImpartido = new HashSet<CursoImpartido>();
            Modulo = new HashSet<Modulo>();
            ModulosCursoCerrado = new HashSet<ModulosCursoCerrado>();
        }

        public int Id { get; set; }
        public string Curso1 { get; set; }
        public string ComentarioHtml { get; set; }
        public byte[] ImagenMiniatura { get; set; }
        public byte[] ImagenGrande { get; set; }
        public int? SubCategoria { get; set; }

        public SubCategoria SubCategoriaNavigation { get; set; }
        public ICollection<CursoImpartido> CursoImpartido { get; set; }
        public ICollection<Modulo> Modulo { get; set; }
        public ICollection<ModulosCursoCerrado> ModulosCursoCerrado { get; set; }
    }
}
