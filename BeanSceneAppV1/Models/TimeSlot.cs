using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;

namespace BeanSceneAppV1.Models
{
    public class TimeSlot
    {
        [Required]
        public int Id { get; set; }
        [Required]      
        public int SittingId { get; set; }
        [Required] 
        [DisplayName("Sitting Name")]
        [Column(TypeName = "varchar(9)")]
        public Sitting Sitting { get; set; }
        [Required]
        [Column(TypeName = "date")]
        public DateTime Date { get; set; }
        [Required]
        [DisplayName("Start Time")]
        //[Column(TypeName = "time")]
        public TimeSpan Start_Time { get; set; }
        [Required]
        [DisplayName("End Time")]
        //[Column(TypeName = "time")]
        public TimeSpan End_Time { get; set; }
    }
}
