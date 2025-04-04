using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace L02P02_2023PA651_2022IV650.Models
{
    public class pedido_detalle
    {
        [Key]
        public int id { get; set; }
        public int id_pedido { get; set; }
        [ForeignKey("id_pedido")]
        public pedido_encabezado pedido { get; set; }
        public int id_libro { get; set; }
        [ForeignKey("id_Libro")]
        public Libros libro { get; set; }
        public DateTime created_at { get; set; }
    }
}

