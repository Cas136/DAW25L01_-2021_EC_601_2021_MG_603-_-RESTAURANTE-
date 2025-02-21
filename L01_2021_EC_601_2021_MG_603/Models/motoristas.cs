using System.ComponentModel.DataAnnotations;

namespace L01_2021_EC_601_2021_MG_603.Models
{
    public class motoristas
    {
        [Key] 
        public int motoristaId { get; set; }
        public string nombreMotorista { get; set; }
    }
}
