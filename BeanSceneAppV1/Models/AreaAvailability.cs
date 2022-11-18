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
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [Required]
        [DisplayName("Start Time")]
        [DataType(DataType.Time)]
        public TimeSpan Start_Time { get; set; }
        [Required]
        [DisplayName("End Time")]
        [DataType(DataType.Time)]
        public TimeSpan End_Time { get; set; }

    }
}
