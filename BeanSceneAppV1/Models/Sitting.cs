using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BeanSceneAppV1.Models
{
    public class Sitting
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [DisplayName("Sitting Name")]
        public string Sitting_Type { get; set; }
        [Required]
        public int Capacity { get; set; }
        [Required]
        public int Guest_Total { get; set; }
        [Required]
        public int Tables_Available { get; set; }

    }
}
