using System.ComponentModel.DataAnnotations;

namespace WebMaquina.Models
{
    public class CadMaquina
    {
        [Key]
        public int IDMaquina { get; set; }
        public string Modelo { get; set; }
        public string Produto { get; set;}
    }
}
