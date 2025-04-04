using System.ComponentModel.DataAnnotations;

namespace L02P02_2023PA651_2022IV650.Models
{
    public class Categorias
    {
        [Key]
        public int id { get; set; }
        public string categoria { get; set; }
    }
}
