﻿using System;
using System.Collections.Generic;

namespace WebCursos.Models
{
    public partial class Modulo
    {
        public Modulo()
        {
            Amedida = new HashSet<Amedida>();
            Lección = new HashSet<Lección>();
        }

        public int Id { get; set; }
        public string Modulo1 { get; set; }
        public string ComentarioHtml { get; set; }
        public int? Curso { get; set; }
        public int? DuracionEnMinutos { get; set; }
        public bool? HayEjercicios { get; set; }
        public int? Pos { get; set; }

        public Curso CursoNavigation { get; set; }
        public ICollection<Amedida> Amedida { get; set; }
        public ICollection<Lección> Lección { get; set; }
    }
}
