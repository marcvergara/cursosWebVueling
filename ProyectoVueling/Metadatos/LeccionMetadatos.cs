using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoVueling.Metadatos
{
    public class LeccionMetadatos
    {
        [Display(Name = "Leccion")]
        [Required]
        public int Id { get; set; }
        [Display(Name = "Titulo de la Lección")]
        public string Lección1 { get; set; }
        [Display(Name = "Comentarios")]
        public string ComentarioHtml { get; set; }

        [Display(Name = "Modulo")]
        public int? Modulo { get; set; }
        [DisplayName("Se incluyen ejercicios en esta lección")]
        public bool? HayEjercicios { get; set; }
        [Display(Name = "Posición en el Curso")]
        public int? Pos { get; set; }

        public Modulo ModuloNavigation { get; set; }
        [ModelMetadataType(typeof(LeccionMetadatos))]
        public partial class Lección { }
    }
}
