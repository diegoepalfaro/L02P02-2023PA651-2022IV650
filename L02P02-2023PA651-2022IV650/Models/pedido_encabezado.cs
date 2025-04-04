using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace L02P02_2023PA651_2022IV650.Models
{
    public class pedido_encabezado
    {
        [Key]
        public int id { get; set; }
        public int id_cliente { get; set; }
        [ForeignKey("idcliente")]
        public Clientes cliente { get; set; }
        public int cantidad_libros { get; set; }
        public decimal total { get; set; }
    }
}
