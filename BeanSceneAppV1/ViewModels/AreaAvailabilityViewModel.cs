using BeanSceneAppV1.Models;

namespace BeanSceneAppV1.ViewModels
{
    public class AreaAvailabilityViewModel
    {
        public AreaAvailability AreaAvailability { get; set; }
        public IEnumerable<Area> Areas { get; set; }
        public IEnumerable<TimeSlot> TimeSlots { get; set; }
    }
}
