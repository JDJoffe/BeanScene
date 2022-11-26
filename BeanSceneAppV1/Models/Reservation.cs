using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace BeanSceneAppV1.Models
{
    public class Reservation
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [Required]
        [DisplayName("Time")]
        public int TimeSlotId { get; set; }
        [Required]
        public TimeSlot TimeSlot { get; set; }
        [Required]
        public int SittingId { get; set; }
        [Required]
        public Sitting Sitting { get; set; }
        [Required]
        [DisplayName("Guest Amount")]
        public int GuestAmount { get; set; }         
        [Required]
        [DisplayName("First Name")]
        [MaxLength(255)]
        public string FirstName { get; set; }
        [Required]
        [DisplayName("Last Name")]
        [MaxLength(255)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(255)]
        public string Phone { get; set; }
        [Required]
        [MaxLength(255)]
        public string Email { get; set; }
        [Required]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [DefaultValue(value: "Not Specified")]
        [DisplayName("Seating Request")]
        [MaxLength(481446)]
        public string SeatingRequest { get; set; }
        [Required]
        public StatusEnum Status { get; set; }
        public enum StatusEnum
        {
            Requested,
            Rejected,
            Accepted,
            Seated,
            Completed
        }
    }
}
