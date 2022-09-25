using BeanSceneAppV1.Models;

namespace BeanSceneAppV1.ViewModels
{
    public class TimeSlotViewModel
    {
        public TimeSlot TimeSlot { get; set; }
        public IEnumerable<Sitting> Sittings { get; set; }
    }
}
