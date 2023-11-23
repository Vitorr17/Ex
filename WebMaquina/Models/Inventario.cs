using System.ComponentModel.DataAnnotations;

namespace WebMaquina.Models
{
    public class Inventario
    {
        [Key]
        public int IDInventario { get; set; }
        public int IDCliente { get; set; }
        public int IDMaquina { get; set;}
        public string Nome { get; set; }
        public string Modelo { get; set; }
        public string Produto { get; set; }
        public string Valor { get; set;}
        public string Data_ { get; set;} 
    }
}
