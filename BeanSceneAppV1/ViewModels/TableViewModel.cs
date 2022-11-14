using BeanSceneAppV1.Models;

namespace BeanSceneAppV1.ViewModels
{
    public class TableViewModel
    { 
        public Table Table { get; set; }
        public IEnumerable<Area> Areas { get; set; }
    }
}
