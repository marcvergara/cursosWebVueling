using System;
using System.Collections.Generic;

namespace WebCursos.Models
{
    public partial class Amedida
    {
        public int Curso { get; set; }
        public int Modulo { get; set; }
        public string Observaciones { get; set; }

        public Curso CursoNavigation { get; set; }
        public Modulo ModuloNavigation { get; set; }
    }
}
