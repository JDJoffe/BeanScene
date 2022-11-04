using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BeanSceneAppV1.Data;
using BeanSceneAppV1.Models;
using BeanSceneAppV1.ViewModels;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Globalization;

namespace BeanSceneAppV1.Controllers
{
    public class ReservationController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReservationController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Reservation
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Reservation.Include(r => r.Sitting).Include(r => r.TimeSlot);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Reservation/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Reservation == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservation
                .Include(r => r.Sitting)
                .Include(r => r.TimeSlot)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        // GET: Reservation/Create
        public IActionResult Create()
        {
            var model = new ReservationViewModel()
            {
                Sittings = _context.Sitting.ToList(),
                TimeSlots = _context.TimeSlot.ToList()
            };
            //ViewData["SittingId"] = new SelectList(_context.Sitting, "Id", "Id");
            //ViewData["TimeSlotId"] = new SelectList(_context.TimeSlot, "Id", "Id");
            return View(model);
        }

        // POST: Reservation/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ReservationViewModel reservationVM)
        {


            SQLDAL _db;
            _db = new SQLDAL();


            string timeslotTime = "";
            string sql = "SELECT [Time] FROM TIMESLOT t " +
                $"WHERE '{reservationVM.Reservation.TimeSlotId}' = t.Id";
            DataTable dt = _db.ExecuteSQL(sql);
            foreach (DataRow dr in dt.Rows)
            { timeslotTime = dr.ItemArray.First().ToString(); }


            string sittingId = "";
            string sql2 = "SELECT Id FROM SITTING s " +
            $"WHERE ('{reservationVM.Reservation.Date}' BETWEEN s.Start_Date AND s.End_Date) AND " +
            $" ('{timeslotTime}' BETWEEN s.Start_Time AND s.End_Time)";

            string sql3 = "SELECT Id FROM Sitting";

            DataTable dt2 = _db.ExecuteSQL(sql2);
            foreach (DataRow dr2 in dt2.Rows)
            { sittingId = dr2.ItemArray.First().ToString(); }

            int.TryParse(sittingId, out int sittingIdnum);

            var reservation = new Models.Reservation
            {
                Id = reservationVM.Reservation.Id,
                Date = reservationVM.Reservation.Date,
                TimeSlot = reservationVM.Reservation.TimeSlot,
                TimeSlotId = reservationVM.Reservation.TimeSlotId,
                Sitting = reservationVM.Reservation.Sitting,
                SittingId = sittingIdnum,
                GuestAmmount = reservationVM.Reservation.GuestAmmount,
                FirstName = reservationVM.Reservation.FirstName,
                LastName = reservationVM.Reservation.LastName,
                Phone = reservationVM.Reservation.Phone,
                Email = reservationVM.Reservation.Email,
                SeatingRequest = reservationVM.Reservation.SeatingRequest,
                Status = reservationVM.Reservation.Status

            };
            reservationVM.Sittings = _context.Sitting.ToList();
            reservationVM.TimeSlots = _context.TimeSlot.ToList();
            //if (ModelState.IsValid)
            //{
            _context.Add(reservation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            //}
            //ViewData["SittingId"] = new SelectList(_context.Sitting, "Id", "Id", reservation.SittingId);
            //ViewData["TimeSlotId"] = new SelectList(_context.TimeSlot, "Id", "Id", reservation.TimeSlotId);
            return View(reservation);
        }

        // GET: Reservation/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Reservation == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservation.FindAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }
            var model = new ReservationViewModel()
            {
                Sittings = _context.Sitting.ToList(),
                TimeSlots = _context.TimeSlot.ToList()
            };
            return View(model);
        }

        // POST: Reservation/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ReservationViewModel reservationVM)
        {
            var reservation = new Models.Reservation
            {
                Id = reservationVM.Reservation.Id,
                Date = reservationVM.Reservation.Date,
                TimeSlot = reservationVM.Reservation.TimeSlot,
                TimeSlotId = reservationVM.Reservation.TimeSlotId,
                Sitting = reservationVM.Reservation.Sitting,
                SittingId = reservationVM.Reservation.SittingId,
                GuestAmmount = reservationVM.Reservation.GuestAmmount,
                FirstName = reservationVM.Reservation.FirstName,
                LastName = reservationVM.Reservation.LastName,
                Phone = reservationVM.Reservation.Phone,
                Email = reservationVM.Reservation.Email,
                SeatingRequest = reservationVM.Reservation.SeatingRequest,
                Status = reservationVM.Reservation.Status
            };
            reservationVM.Sittings = _context.Sitting.ToList();
            reservationVM.TimeSlots = _context.TimeSlot.ToList();

            //if (id != reservation.Id)
            //{
            //    return NotFound();
            //}

            //if (ModelState.IsValid)
            //{
            //    try
            //    {
            //        _context.Update(reservation);
            //        await _context.SaveChangesAsync();
            //    }
            //    catch (DbUpdateConcurrencyException)
            //    {
            //        if (!ReservationExists(reservation.Id))
            //        {
            //            return NotFound();
            //        }
            //        else
            //        {
            //            throw;
            //        }
            //    }
            _context.Update(reservation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            //}
            //ViewData["SittingId"] = new SelectList(_context.Sitting, "Id", "Id", reservation.SittingId);
            //ViewData["TimeSlotId"] = new SelectList(_context.TimeSlot, "Id", "Id", reservation.TimeSlotId);
            //return View(reservation);
        }

        // GET: Reservation/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Reservation == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservation
                .Include(r => r.Sitting)
                .Include(r => r.TimeSlot)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        // POST: Reservation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Reservation == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Reservation'  is null.");
            }
            var reservation = await _context.Reservation.FindAsync(id);
            if (reservation != null)
            {
                _context.Reservation.Remove(reservation);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservationExists(int id)
        {
            return _context.Reservation.Any(e => e.Id == id);
        }
    }
}
