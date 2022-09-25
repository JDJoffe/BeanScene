using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BeanSceneAppV1.Models
{
    public class AreaAvailability
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int AreaId { get; set; }
        [Required]
        public Area Area { get; set; }
        [Required]
        public int TimeSlotId { get; set; }
        [Required]
        public TimeSlot TimeSlot { get; set; }
        [Required]
        public int SittingId { get; set; }
        [Required]
        public Sitting Sitting { get; set; }
        [Required]
        public StatusEnum Status { get; set; }
        
        public enum StatusEnum
        {
            Available,
            Na
        }

    }
}
