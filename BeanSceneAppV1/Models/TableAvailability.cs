using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BeanSceneAppV1.Models
{
    public class TableAvailability
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int TableId { get; set; }
        [Required]
        public Table Table { get; set; }      
        [Required]
        [DataType(DataType.Date)]    
        public DateTime Date { get; set; }
        [Required]
        public int TimeSlotId { get; set; }
        [Required]
        public TimeSlot TimeSlot { get; set; }
        [Required]
        public StatusEnum Status { get; set; }
        public enum StatusEnum
        {
            Available,
            NA
        }
    }
}
