using BeanSceneAppV1.Models;
using BeanSceneAppV1.ViewModels;

namespace BeanSceneAppV1.ViewModels
{
    public class TableAvailabilityReservationViewModel
    {
        public Reservation Reservation { get; set; }
        public IEnumerable<TableAvailability> TableAvailabilities { get; set; }
       
    }
}
