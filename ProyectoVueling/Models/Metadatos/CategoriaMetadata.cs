using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProyectoVueling.Models
{
    [ModelMetadataType(typeof(CategoriaMetadata))]
    public partial class Categoria
    {

    }

    public class CategoriaMetadata
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Categoría")]
        public string Categoria1 { get; set; }
        [DisplayName("Comentario en HTML")]
        [UIHint("tinymce_jquery_full")]
        public string ComentarioHtml { get; set; }
        [DisplayName("Thumbnail")]
        public byte[] ImagenMiniatura { get; set; }
        [DisplayName("Imagen")]
        public byte[] ImagenGrande { get; set; }
        public string Color { get; set; }

        public ICollection<SubCategoria> SubCategoria { get; set; }
    }
}
