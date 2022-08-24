using System.ComponentModel.DataAnnotations;

namespace BlendersDC_API.DTOs
{
    public class OilDTO
    {
        [Required]
        public int ID { get; set; }     // PK
        [Required]
        public double OilTank1 { get; set; }        // Not Null
        [Required]
        public double OilTank2 { get; set; }        // Not Null
        [Required]
        public double OilTankInter { get; set; }    // Not Null
        [Required]
        public DateTime CreatedAt { get; set; }     // Not Null
    }
}
