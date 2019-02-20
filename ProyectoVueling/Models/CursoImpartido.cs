using System;
using System.Collections.Generic;

namespace ProyectoVueling.Models
{
    public partial class CursoImpartido
    {
        public int Id { get; set; }
        public int? IdCurso { get; set; }
        public int? IdCliente { get; set; }
        public DateTime? Fecha { get; set; }
        public byte[] Audio { get; set; }
        public double? Nota { get; set; }

        public Cliente IdClienteNavigation { get; set; }
        public Curso IdCursoNavigation { get; set; }
    }
}
