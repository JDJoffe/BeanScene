using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BeanSceneAppV1.Models
{
    public class Reservation
    {
        [Required]
        public int Id { get; set; }
    }
}
