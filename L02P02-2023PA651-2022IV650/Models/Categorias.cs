using System.ComponentModel.DataAnnotations;

namespace L02P02_2023PA651_2022IV650.Models
{
    public class Categorias
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
}
