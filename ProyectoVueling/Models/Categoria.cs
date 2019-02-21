using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoVueling.Models
{
    public partial class Categoria
    {
        public Categoria()
        {
            SubCategoria = new HashSet<SubCategoria>();
        }

        public int Id { get; set; }
        [Display(Name = "Categoría")]
        public string Categoria1 { get; set; }
        [Display(Name = "Comentario")]
        public string ComentarioHtml { get; set; }
        [Display(Name = "ImagenM")]
        [DataType(DataType.ImageUrl)]
        public byte[] ImagenMiniatura { get; set; }
        [Display(Name = "ImagenG")]
        public byte[] ImagenGrande { get; set; }
        public string Color { get; set; }

        public ICollection<SubCategoria> SubCategoria { get; set; }
    }
}
