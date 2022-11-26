using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BeanSceneAppV1.Data;
using BeanSceneAppV1.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using BeanSceneAppV1.ViewModels;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NuGet.Configuration;
using System.Collections.Immutable;

namespace BeanSceneAppV1.Controllers
{
    [Authorize(Roles = "Manager, Staff")]
    public class TableReservationController : Controller
    {
        private readonly ApplicationDbContext _context;


        public TableReservationController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TableReservation
        public async Task<IActionResult> Index()
        {

            var applicationDbContext = _context.Reservation.Where(r => r.Status == Reservation.StatusEnum.Accepted).Include(r => r.Sitting).Include(r => r.TimeSlot);
            return View(await applicationDbContext.ToListAsync());
        }


        // GET: Reservation
        public async Task<IActionResult> AssignTables(int? id)
        {
            // return if null
            if (id == null || _context.TableReservation == null)
            {
                return NotFound();
            }
            // get the reservation passed through id
            var reservationQuery = _context.Reservation.Where(r => r.Id == id);
            Reservation reservation = reservationQuery.First();
            // get timeslot of reservation 
            var timeslotQuery = _context.TimeSlot.Where(t => t.Id == reservation.TimeSlotId);
            TimeSlot timeslot = timeslotQuery.First();

            // get unavailable tables from tableavailability
            List<TableAvailability> unavailableTables = new List<TableAvailability>();
            unavailableTables = _context.TableAvailability.Distinct().Where(ta => ta.Date == reservation.Date && ta.TimeSlotId == reservation.TimeSlotId).ToList();

            int tablesNeeded = 0;
            if (reservation.GuestAmount / 4 >= 1)
            {
                tablesNeeded = reservation.GuestAmount / 4;
                if (reservation.GuestAmount % 4 >= 1)
                {
                    tablesNeeded++;
                }
            }
            // get list of all tables
            List<Models.Table>[] availableTables = new List<Models.Table>[tablesNeeded];
            //2
            // available table list 2
            /*
             * List 1
             * m1
             * m2
             * m3
             * list 2
             * m1
             * m2
             * m3
             */
            for (int i = 0; i < tablesNeeded; i++)
            {
                availableTables[i] = _context.Table.ToList();
            }

            // remove unavailable tables from list of all tables.
            for (int i = 0; i < tablesNeeded; i++)
            {

                for (int j = 0; j < unavailableTables.Count; j++)
                {
                    availableTables[i].Remove(unavailableTables[j].Table);
                }
            }


            // set data to new model
            var model = new TableReservationViewModel()
            {
                // pass available tables to model
                Tables = availableTables
            };
            model.TableReservation = new TableReservation();
            model.TableReservation.ReservationId = (int)id;
            model.TableReservation.Reservation = reservation;
            model.TableReservation.Reservation.TimeSlot = timeslot;
            model.TablesNeeded = tablesNeeded;
            /*
             * 8 people
             * 8/4 = 2 > 1
             * needed = 8 / 4 = 2
             * 8 % 4 >= 1
             * 
             */


            //sitting.Tables_Available += reservation.GuestAmount / 4;
            //if (reservation.GuestAmount % 4 >= 1)
            //{
            //    sitting.Tables_Available++;
            //}
            // pass model
            return View(model);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AssignTables(TableReservationViewModel tableReservationVM)
        {
            Reservation reservation = await _context.Reservation.FindAsync(tableReservationVM.TableReservation.ReservationId);
            //for each table needed, create a table reservation and a table availability
            for (int i = 0; i < tableReservationVM.TablesNeeded; i++)
            {
                var tableReservation = new Models.TableReservation
                {
                    // id whack maybe test it
                    Id = tableReservationVM.TableReservation.Id + i - 1,
                    ReservationId = tableReservationVM.TableReservation.ReservationId

                };
                tableReservation.Table = (Models.Table)tableReservationVM.Tables[i];
                tableReservation.TableId = tableReservation.Table.Id;
                var tableAvailability = new Models.TableAvailability
                {
                   // id whack
                    Date = tableReservationVM.TableReservation.Reservation.Date,
                    TimeSlotId = tableReservationVM.TableReservation.Reservation.TimeSlotId,
                    TableId = tableReservation.TableId
                };
                //if (ModelState.IsValid)
                //{
                tableReservationVM.Tables[i] = _context.Table.ToList();
                _context.Add(tableAvailability);
                _context.Add(tableReservation);
                if (reservation.Status != Reservation.StatusEnum.Seated)
                {
                    reservation.Status = Reservation.StatusEnum.Seated;
                }
            }
             
            //Reservation reservation = reservationQuery.First();
            Sitting sitting = await _context.Sitting.FindAsync(reservation.SittingId);



            sitting.Tables_Available = sitting.Tables_Available - tableReservationVM.TablesNeeded;
            try
            {

                
                _context.Update(sitting);
                _context.Update(reservation);
               
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {

                throw;
            }
            // }

            //}     
            //return View(tableReservation);
        }



        private bool TableAvailabilityReservationExists(int id)
        {
            return _context.TableReservation.Any(e => e.Id == id);
        }
    }
}
