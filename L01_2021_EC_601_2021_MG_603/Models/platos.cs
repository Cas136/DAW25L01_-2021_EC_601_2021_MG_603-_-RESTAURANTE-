using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace L01_2021_EC_601_2021_MG_603.Models
{
    public class platos
    {
        [Key]
        public int platoId { get; set; }

        public string nombrePlato { get; set; }

  
        public decimal precio { get; set; }
    }
}
