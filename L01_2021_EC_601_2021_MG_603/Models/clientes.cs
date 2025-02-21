using System.ComponentModel.DataAnnotations;

namespace L01_2021_EC_601_2021_MG_603.Models
{
    public class clientes
    {
        [Key]
        public int clienteId { get; set; }

        public string nombreCliente { get; set; }

        public string direccion { get; set; }
    }
}
