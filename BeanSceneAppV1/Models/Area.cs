using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BeanSceneAppV1.Models
{
    public class Area
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [DisplayName("Area Name")]
        [MaxLength(255)]
        public string Name { get; set; }
    }
}
