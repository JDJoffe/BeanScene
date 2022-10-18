using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeanSceneAppV1.Models
{
    public class Sitting
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [DisplayName("Sitting Name")]
        [Column(TypeName = "varchar(9)")]
        public string Sitting_Type { get; set; }
        [Required]
        public int Capacity { get; set; }
        [Required]
        public int Guest_Total { get; set; }
        [Required]
        public int Tables_Available { get; set; }

    }
}
