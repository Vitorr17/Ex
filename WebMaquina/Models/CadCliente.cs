using System.ComponentModel.DataAnnotations;

namespace WebMaquina.Models
{
    public class CadCliente
    {
        [Key]
        public int IDCliente { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
    }
}
