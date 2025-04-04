using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace L02P02_2023PA651_2022IV650.Models
{
    public class Libros
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string UrlImagen { get; set; }

        public int IdAutor { get; set; }
        [ForeignKey("IdAutor")]
        public Autores Autor { get; set; }

        public int IdCategoria { get; set; }
        [ForeignKey("IdCategoria")]
        public Categorias Categoria { get; set; }

        public decimal Precio { get; set; }
        public char Estado { get; set; }
    }
}
