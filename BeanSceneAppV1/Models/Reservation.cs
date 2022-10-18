using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace BeanSceneAppV1.Models
{
    public class Reservation
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int TimeslotId { get; set; }
        [Required]
        [DisplayName("Time")]
        public TimeSlot TimeSlot { get; set; }      
        [Required]
        public int GuestAmmount { get; set; }         
        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Email { get; set; }
        [AllowNull]
        [DisplayName("Seating Request")]
        public string SeatingRequest { get; set; }
        [Required]
        public StatusEnum Status { get; set; }
        public enum StatusEnum
        {
            Requested,
            Rejected,
            Accepted
        }
    }
}
