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
            //var othercontext = _context.AreaAvailability;
            // var othercontext2 = _context.TableAvailability;
            //bool bam (Reservation r)
            // {
            //     othercontext2.Where(t => t.Date != r.Date && t.TimeSlotId != r.TimeSlotId);

            //     if ( othercontext2.ToListAsync().Result.Count >=1 )
            //     {
            //         return false;
            //     }
            //     return true;
            // }
            // bool cheese = true;
            // // ApplicationUser user = await _userManager.GetUserAsync(User);
            // var applicationDbContext = _context.Reservation.Where(r=>  bam(r)  && cheese == true ).Include(r => r.Sitting).Include(r => r.TimeSlot);

            if (id == null || _context.TableReservation == null)
            {
                return NotFound();
            }



            var reservationQuery = _context.Reservation.Where(r => r.Id == id);
            Reservation reservation = reservationQuery.First();
            var timeslotQuery = _context.TimeSlot.Where(t => t.Id == reservation.TimeSlotId);
            TimeSlot timeslot = timeslotQuery.First();
            // var tableAvailabilityQuery = _context.TableAvailability.ToList();
            List<TableAvailability> unavailableTables = new List<TableAvailability>();
            //var tablereservationQuery = _context.TableReservation.Include(t => t.Table).ToList();
            //List<TableReservation> tableReservations = new List<TableReservation>();
            //foreach (var item in tableAvailabilityQuery)
            //{
            //    tableAvailabilities.Add(item);
            //}
            //TableReservationViewModel TableReservation = new TableReservationViewModel();
            //List<Table> tableList = new List<Table>();
            //if (tableAvailabilities.Count == 0)
            //{
            //    TableReservation.Tables = _context.Table.ToList();
            //}
            //else
            //{
            unavailableTables = _context.TableAvailability.Distinct().Where(ta => ta.Date == reservation.Date && ta.TimeSlotId == reservation.TimeSlotId)
                .ToList();


            List<Models.Table> availableTables = new List<Models.Table>();
            availableTables = _context.Table.ToList();
            // }
            foreach (var item in unavailableTables)
            {

                availableTables.Remove(item.Table);

            }

            var newmodel = new TableReservationViewModel()
            {

                Tables = availableTables
            };
            newmodel.TableReservation = new TableReservation();
            newmodel.TableReservation.ReservationId = (int)id;
            newmodel.TableReservation.Reservation = reservation;
            newmodel.TableReservation.Reservation.TimeSlot = timeslot;
            //ViewData["ReservationId"] = Reservation.Id;
            return View(newmodel);
            //return View(await applicationDbContext.ToListAsync());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AssignTables(TableReservationViewModel tableReservationVM)
        {

            var tableReservation = new Models.TableReservation
            {
                Id = tableReservationVM.TableReservation.Id,
                ReservationId = tableReservationVM.TableReservation.ReservationId,
                TableId = tableReservationVM.TableReservation.TableId
            };
            var tableAvailability = new Models.TableAvailability
            {
                Date = tableReservationVM.TableReservation.Reservation.Date,
                TimeSlotId = tableReservationVM.TableReservation.Reservation.TimeSlotId,
                TableId = tableReservationVM.TableReservation.TableId
            };
            //if (ModelState.IsValid)
            //{


            try
            {

                tableReservationVM.Tables = _context.Table.ToList();
                _context.Add(tableAvailability);
                _context.Add(tableReservation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {

                throw;
            }
            //}     
            return View(tableReservation);
        }

        // GET: TableReservation/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TableReservation == null)
            {
                return NotFound();
            }

            var tableReservation = await _context.TableReservation
                .Include(t => t.Reservation)
                .Include(t => t.Table)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tableReservation == null)
            {
                return NotFound();
            }

            return View(tableReservation);
        }

        // GET: TableReservation/Create


        // GET: TableReservation/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TableReservation == null)
            {
                return NotFound();
            }

            var tableReservation = await _context.TableReservation.FindAsync(id);
            if (tableReservation == null)
            {
                return NotFound();
            }
            ViewData["ReservationId"] = new SelectList(_context.Reservation, "Id", "Email", tableReservation.ReservationId);
            ViewData["TableId"] = new SelectList(_context.Table, "Id", "Id", tableReservation.TableId);
            return View(tableReservation);
        }

        // POST: TableReservation/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TableId,ReservationId")] TableReservation tableReservation)
        {
            if (id != tableReservation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tableReservation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TableAvailabilityReservationExists(tableReservation.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ReservationId"] = new SelectList(_context.Reservation, "Id", "Email", tableReservation.ReservationId);
            ViewData["TableId"] = new SelectList(_context.Table, "Id", "Id", tableReservation.TableId);
            return View(tableReservation);
        }

        // GET: TableReservation/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TableReservation == null)
            {
                return NotFound();
            }

            var tableReservation = await _context.TableReservation
                .Include(t => t.Reservation)
                .Include(t => t.Table)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tableReservation == null)
            {
                return NotFound();
            }

            return View(tableReservation);
        }

        // POST: TableReservation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TableReservation == null)
            {
                return Problem("Entity set 'ApplicationDbContext.TableReservation'  is null.");
            }
            var tableReservation = await _context.TableReservation.FindAsync(id);
            if (tableReservation != null)
            {
                _context.TableReservation.Remove(tableReservation);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TableAvailabilityReservationExists(int id)
        {
            return _context.TableReservation.Any(e => e.Id == id);
        }
    }
}
