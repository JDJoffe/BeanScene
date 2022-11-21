﻿using System;
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
//using Microsoft.Data.SqlClient;
using System.Data;
using System.Globalization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
//using SqlParameter = System.Data.SqlClient.SqlParameter;

namespace BeanSceneAppV1.Controllers
{
    public class ReservationController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationUser> _roleManager;

        public ReservationController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;

        }
        [AllowAnonymous]

        // GET: Reservation
        public async Task<IActionResult> Index()
        {
            // automatically when viewed find old reservations and reject them as they are no longer relevant
            List<Reservation> oldReservations = new List<Reservation>();
            oldReservations = _context.Reservation.Where(r => r.Date < DateTime.Today && r.TimeSlot.Time < DateTime.UtcNow.TimeOfDay).ToList();

            if (oldReservations.Count >=1)
            {
                foreach (var item in oldReservations)
                {
                    item.Status = Reservation.StatusEnum.Rejected;
                    _context.Update(item);
                }
                await _context.SaveChangesAsync();

            }
            // get reservations.
            var applicationDbContext = _context.Reservation.Include(r => r.Sitting).Include(r => r.TimeSlot);

           
            // get the user
            ApplicationUser user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                // get a list of the roles the user has
                List<string> usrRoles = new List<string>();
                var roles = await _userManager.GetRolesAsync(user);
                foreach (var item in roles)
                {
                    usrRoles.Add(item.ToString());
                }

                // redirect user based on their role.
                if (usrRoles.Contains("Manager"))
                {
                    return View(await applicationDbContext.ToListAsync());
                    //return RedirectToAction(nameof(Index));
                }
                else if (usrRoles.Contains("Staff") || usrRoles.Contains("Member"))
                {
                    return RedirectToAction(nameof(IndexMember));
                    
                }
            }
            else { return RedirectToAction(nameof(Create)); }

            return View(await applicationDbContext.ToListAsync());
        }
        [Authorize(Roles = "Manager, Staff, Member")]

        // GET: Reservation
        public async Task<IActionResult> IndexMember()
        {
            // get reservations made by this member
            ApplicationUser user = await _userManager.GetUserAsync(User);
            
            var applicationDbContext = _context.Reservation.Where(r => r.Email == user.Email).Include(r => r.Sitting).Include(r => r.TimeSlot);
            return View(await applicationDbContext.ToListAsync());
        }
        [Authorize(Roles = "Manager, Staff")]

        // GET: Reservation
        public async Task<IActionResult> ReservationStatus()
        {
            // get reservations that are current or upcomming and have the requested status.
            // ApplicationUser user = await _userManager.GetUserAsync(User);
            var applicationDbContext = _context.Reservation.Where(r => r.Status == Reservation.StatusEnum.Requested && r.Date >= DateTime.Today && r.TimeSlot.Time >= DateTime.UtcNow.TimeOfDay && r.Sitting.Capacity - r.GuestAmmount >=0).Include(r => r.Sitting).Include(r => r.TimeSlot);
            return View(await applicationDbContext.ToListAsync());
        }     
        [Authorize(Roles = "Manager, Staff, Member")]
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

        [AllowAnonymous]
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
        [AllowAnonymous]
        public async Task<IActionResult> Create(ReservationViewModel reservationVM)
        {

            int sittingId = 0;
            SQLDAL _db;
            _db = new SQLDAL();
            SqlParameter[] sqlparams =
            {
                new SqlParameter("@TimeSlotId",SqlDbType.Int){ Value = reservationVM.Reservation.TimeSlotId},
                new SqlParameter("Date", SqlDbType.DateTime2){Value = reservationVM.Reservation.Date}
            };
            string sql = "USP_AssignSitting";
            DataTable dt = _db.ExecuteSQL(sql, sqlparams, true);
            foreach (DataRow dr in dt.Rows)
            { sittingId = (int)dr.ItemArray.First(); }

            //int.TryParse(sittingId, out int sittingIdnum);

            var reservation = new Models.Reservation
            {
                Id = reservationVM.Reservation.Id,
                Date = reservationVM.Reservation.Date,
                TimeSlot = reservationVM.Reservation.TimeSlot,
                TimeSlotId = reservationVM.Reservation.TimeSlotId,
                Sitting = reservationVM.Reservation.Sitting,
                SittingId = sittingId,
                GuestAmmount = reservationVM.Reservation.GuestAmmount,
                FirstName = reservationVM.Reservation.FirstName,
                LastName = reservationVM.Reservation.LastName,
                Phone = reservationVM.Reservation.Phone,
                Email = reservationVM.Reservation.Email,
                SeatingRequest = reservationVM.Reservation.SeatingRequest,
                Status = Reservation.StatusEnum.Requested

            };
            reservationVM.Sittings = _context.Sitting.ToList();
            reservationVM.TimeSlots = _context.TimeSlot.ToList();
            //if (ModelState.IsValid)
            //{
            _context.Add(reservation);
            await _context.SaveChangesAsync();
            ApplicationUser user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                List<string> usrRoles = new List<string>();
                var roles = await _userManager.GetRolesAsync(user);
                foreach (var item in roles)
                {
                    usrRoles.Add(item.ToString());
                }

                if (usrRoles.Contains("Manager"))
                {
                    return RedirectToAction(nameof(Index));
                }
                else if (usrRoles.Contains("Staff") || usrRoles.Contains("Member"))
                {
                    return RedirectToAction(nameof(IndexMember));
                }
            }
            else { return RedirectToAction(nameof(Create)); }

            //}
            //ViewData["SittingId"] = new SelectList(_context.Sitting, "Id", "Id", reservation.SittingId);
            //ViewData["TimeSlotId"] = new SelectList(_context.TimeSlot, "Id", "Id", reservation.TimeSlotId);
            return View(reservation);
        }

        // GET: Reservation/Edit/5
        [Authorize(Roles = "Manager")]
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
        [Authorize(Roles = "Manager")]
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
        [Authorize(Roles = "Manager")]
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
        [Authorize(Roles = "Manager")]
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
 

        [Authorize(Roles = "Manager, Staff")]
        public async Task<IActionResult> Accept(int? id)
        {
            var reservation = await _context.Reservation.FindAsync(id);
            var sitting = await _context.Sitting.FindAsync(reservation.SittingId);

            reservation.Status = Reservation.StatusEnum.Accepted;
            sitting.Capacity = sitting.Capacity - reservation.GuestAmmount;
            sitting.Guest_Total += reservation.GuestAmmount;
            _context.Reservation.Update(reservation);
            _context.Sitting.Update(sitting);

            _context.SaveChanges();
            return RedirectToAction(nameof(ReservationStatus));

            return View();

        }
        [Authorize(Roles = "Manager, Staff")]
        public async Task<IActionResult> Reject(int? id)
        {
            var reservation = await _context.Reservation.FindAsync(id);

            reservation.Status = Reservation.StatusEnum.Rejected;

            _context.Reservation.Update(reservation);

            _context.SaveChanges();
            return RedirectToAction(nameof(ReservationStatus));

            return View();

        }
    }
}
