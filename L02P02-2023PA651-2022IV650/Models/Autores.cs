using System.ComponentModel.DataAnnotations;

namespace L02P02_2023PA651_2022IV650.Models
{
    public class Autores
    {
        [Key]
        public int id { get; set; }
        public string autor { get; set; }
    }
}
