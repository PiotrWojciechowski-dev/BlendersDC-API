using System.ComponentModel.DataAnnotations;

namespace BlendersDC_API.DTOs
{
    public class EggDTO
    {
        [Required]
        public int ID { get; set; }     // PK
        [Required]
        public double NormalEgg { get; set; }        // Not Null
        [Required]
        public double FreeRangeEgg { get; set; }        // Not Null
        [Required]
        public double EggYolk { get; set; }    // Not Null
        [Required]
        public DateTime CreatedAt { get; set; }     // Not Null
    }
}
