using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BeanSceneAppV1.Models
{
    public class TimeSlot
    {
        [Required]
        public int Id { get; set; } 
        [Required]
        [DataType(DataType.Time)]
        public TimeSpan Time { get; set; }


    }
}
