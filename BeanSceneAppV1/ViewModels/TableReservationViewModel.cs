using BeanSceneAppV1.Models;
using BeanSceneAppV1.ViewModels;

namespace BeanSceneAppV1.ViewModels
{
    public class TableReservationViewModel
    {
        public TableReservation TableReservation { get; set; }
        public IEnumerable<Table> Tables { get; set; }

    }
}
