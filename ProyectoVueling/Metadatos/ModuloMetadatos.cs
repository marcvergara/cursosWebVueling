using Microsoft.AspNetCore.Mvc;
using ProyectoVueling.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoVueling.Metadatos
{
    public class ModuloMetadatos
    {
        public int Id { get; set; }
        [Display(Name = "Titulo del módulo")]
        [Required]
        public string Modulo1 { get; set; }

        [Display(Name = "Comentarios")]
        public string ComentarioHtml { get; set; }
        public int? Curso { get; set; }
        [Display(Name = "Duración en Minutos")]
        public int? DuracionEnMinutos { get; set; }
        [DisplayName("Ejercicios")]
        public bool? HayEjercicios { get; set; }
        [Display(Name = "Posición en el Curso")]
        public int? Pos { get; set; }
        [Display(Name = "Profesor")]
        public int? IdProfesor { get; set; }
        [Display(Name = "Nombre del Curso")]
        public Curso CursoNavigation { get; set; }
        [Display(Name = "Profesor")]
        public Profesor IdProfesorNavigation { get; set; }
        public ICollection<Lección> Lección { get; set; }
        public ICollection<ModulosCursoAmedida> ModulosCursoAmedida { get; set; }
        public ICollection<ModulosCursoCerrado> ModulosCursoCerrado { get; set; }
    }
    [ModelMetadataType(typeof(ModuloMetadatos))]
    public partial class Modulo { }
}
