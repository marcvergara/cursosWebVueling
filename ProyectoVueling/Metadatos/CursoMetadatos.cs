using Microsoft.AspNetCore.Mvc;
using ProyectoVueling.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProyectoVueling.Metadatos
{
    public class CursoMetadatos
    {

        public int Id { get; set; }
        [Display(Name = "Titulo del Curso")]
        [Required]
        public string Curso1 { get; set; }
        [Display(Name = "Comentarios")]
        public string ComentarioHtml { get; set; }
        [Display(Name = "Imagen en Miniatura")]
        public byte[] ImagenMiniatura { get; set; }
        [Display(Name = "Imagen")]
        public byte[] ImagenGrande { get; set; }
        [Display(Name = "SubCategoria")]
        public int? SubCategoria { get; set; }
        [Display(Name = "Sub Categoria ID")]
        public SubCategoria SubCategoriaNavigation { get; set; }
        public ICollection<CursoImpartido> CursoImpartido { get; set; }
        public ICollection<Modulo> Modulo { get; set; }
        public ICollection<ModulosCursoCerrado> ModulosCursoCerrado { get; set; }
    }
    [ModelMetadataType(typeof(CursoMetadatos))]
    public partial class Curso { }
}
