using BeanSceneAppV1.Models;

namespace BeanSceneAppV1.ViewModels
{
    public class TableViewModel
    {
        public IEnumerable<Area> Areas { get; set; }
        public Table Table { get; set; }
    }
}
