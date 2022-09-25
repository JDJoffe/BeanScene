using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BeanSceneAppV1.Models
{
    public class TimeSlot
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [DisplayName("Sitting Name")]
        public int SittingId { get; set; }
        [Required]
        public Sitting Sitting { get; set; }
        [Required]
        public DateOnly Date { get; set; }
        [Required]
        [DisplayName("Start Time")]
        public TimeOnly Start_Time { get; set; }
        [Required]
        [DisplayName("Start Time")]
        public TimeOnly End_Time { get; set; }
    }
}
