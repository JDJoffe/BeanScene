﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeanSceneAppV1.Models
{
    public class Sitting
    {
        [Required]
        public int Id { get; set; }

        [DisplayName("Sitting Name")]
        //[Column(TypeName = "varchar(9)")]
        public SittingEnum Sitting_Type { get; set; }
        public enum SittingEnum
        {
            Breakfast,
            Lunch,
            Dinner
        }
        [Required]
        [DisplayName("Start Date")]
        [DataType(DataType.Date)]
        //[Index(IsUnique =true)]
        public DateTime Start_Date { get; set; }
        [Required]
        [DisplayName("End Date")]
        [DataType(DataType.Date)]
        //[Index(IsUnique =true)]
        public DateTime End_Date { get; set; }
        [Required]
        [DisplayName("Start Time")]
        [DataType(DataType.Time)]
        public TimeSpan Start_Time { get; set; }
        [Required]
        [DisplayName("End Time")]
        [DataType(DataType.Time)]
        public TimeSpan End_Time { get; set; }
        [Required]
        //[MaxLength(255)]
        public int Capacity { get; set; }
        [DisplayName("Total Guests")]
        //[MaxLength(255)]
        public int Guest_Total { get; set; }
        [Required]
        [DisplayName("Tables Available")]
        //[MaxLength(255)]
        public int Tables_Available { get; set; }
    }
}
