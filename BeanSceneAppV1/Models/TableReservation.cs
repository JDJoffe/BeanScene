using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BeanSceneAppV1.Models
{
    public class TableReservation
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int TableId { get; set; }
        [Required]
        public Table Table { get; set; }
        [Required]
        public int ReservationId { get; set; }
        [Required]
        public Reservation Reservation { get; set; }
        
    }
}
