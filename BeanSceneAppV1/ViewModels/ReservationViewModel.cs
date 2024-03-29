﻿using BeanSceneAppV1.Models;

namespace BeanSceneAppV1.ViewModels
{
    public class ReservationViewModel
    {
        public Reservation Reservation { get; set; }       
        public IEnumerable<TimeSlot> TimeSlots { get; set; }
        public IEnumerable<Sitting> Sittings { get; set; }
    }
}
