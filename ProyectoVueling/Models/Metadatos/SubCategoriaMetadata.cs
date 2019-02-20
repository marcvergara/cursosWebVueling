using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace ProyectoVueling.Models
{
    [ModelMetadataType(typeof(SubCategoriaMetadata))]
    public partial class SubCategoria
    {

    }

    public class SubCategoriaMetadata
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "La nombre de la subcategoría es obligatorio")]
        [MinLength(2, ErrorMessage = "La longitud mínima es de 2")]
        [DisplayName("Nombre de la subcategoría")]
        public string SubCategoria1 { get; set; }

        [Required(ErrorMessage = "La categoría es obligatoria")]
        [DisplayName("Id de la categoría")]
        public int? Categoria { get; set; }

        [DisplayName("Comentario en HTML")]
        [UIHint("tinymce_jquery_full")]
        public string ComentarioHtml { get; set; }

        [DisplayName("Thumbnail")]
        public byte[] ImagenMiniatura { get; set; }
        [DisplayName("Imagen")]
        public byte[] ImagenGrande { get; set; }

        public Categoria CategoriaNavigation { get; set; }
        public ICollection<Curso> Curso { get; set; }
    }
 
}
