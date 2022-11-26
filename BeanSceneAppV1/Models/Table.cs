using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BeanSceneAppV1.Models
{
    public class Table
    {

        [Required]
        public int Id { get; set; }
        [Required]
        [DisplayName("Table Name")]
        [MaxLength(255)]
        public string Table_Name { get; set; }
        [Required]
        [DisplayName("Table Seats")]
        [MaxLength(255)]
        public int Table_Seats { get; set; }
        [Required]
        public int AreaId { get; set; }
        [Required]
        public Area Area { get; set; }
        //public string NameOf_Area { get; set; }
    }
}
