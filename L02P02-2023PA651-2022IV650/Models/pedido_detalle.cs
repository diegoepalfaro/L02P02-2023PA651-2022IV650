using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace L02P02_2023PA651_2022IV650.Models
{
    public class pedido_detalle
    {
        [Key]
        public int Id { get; set; }

        public int IdPedido { get; set; }
        [ForeignKey("IdPedido")]
        public pedido_encabezado Pedido { get; set; }

        public int IdLibro { get; set; }
        [ForeignKey("IdLibro")]
        public Libros Libro { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}

