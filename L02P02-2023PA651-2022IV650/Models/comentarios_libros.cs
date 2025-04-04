using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace L02P02_2023PA651_2022IV650.Models
{
    public class comentarios_libros
    {
        [Key]
        public int id { get; set; }
        public int id_libro { get; set; }
        [ForeignKey("id_libro")]
        public Libros libro { get; set; }
        public string comentarios { get; set; }
        public string usuario { get; set; }
       public DateTime created_at { get; set; }
    }
}
