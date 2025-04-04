using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace L02P02_2023PA651_2022IV650.Models
{
    public class Libros
    {
        [Key]
        public int Id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string url_imagen { get; set; }
        public int id_autor { get; set; }
        [ForeignKey("id_autor")]
        public Autores autor { get; set; }
        public int id_categoria { get; set; }
        [ForeignKey("id_categoria")]
        public Categorias categoria { get; set; }
        public decimal precio { get; set; }
        public string? estado { get; set; }
    }
}
