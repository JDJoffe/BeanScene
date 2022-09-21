using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BeanSceneAppV1.Models
{
    public class Area
    {
        [Key]
        [DisplayName("Area Name")]
        public string Area_Name { get; set; }
    }
}
