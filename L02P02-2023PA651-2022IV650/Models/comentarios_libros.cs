using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace L02P02_2023PA651_2022IV650.Models
{
    public class comentarios_libros
    {
        [Key]
        public int Id { get; set; }
        public int IdLibro { get; set; } 

        [ForeignKey("IdLibro")]
        public Libros Libro { get; set; }

        public string Comentarios { get; set; }
        public string Usuario { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
