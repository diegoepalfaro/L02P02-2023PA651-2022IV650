using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace L02P02_2023PA651_2022IV650.Models
{
    public class pedido_encabezado
    {
        [Key]
        public int Id { get; set; }

        public int IdCliente { get; set; }
        [ForeignKey("IdCliente")]
        public Clientes Cliente { get; set; }

        public int CantidadLibros { get; set; }
        public decimal Total { get; set; }
    }
}
