using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BeanSceneAppV1.Models
{
    public class TableAvailabilityReservation
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int TableAvailabilityId { get; set; }
        [Required]
        public TableAvailability TableAvailability { get; set; }
        [Required]
        public int ReservationId { get; set; }
        [Required]
        public Reservation Reservation { get; set; }
        
    }
}
