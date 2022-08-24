using System.ComponentModel.DataAnnotations;

namespace BlendersDC_API.Models
{
    public class Egg
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
