using BeanSceneAppV1.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BeanSceneAppV1.ViewModels
{
    public class TableAvailabilityViewModel
    {
        public TableAvailability TableAvailability { get; set; }
        public IEnumerable<Table> Tables {get; set;}
        public IEnumerable<TimeSlot> TimeSlots { get; set; }
    }
}
