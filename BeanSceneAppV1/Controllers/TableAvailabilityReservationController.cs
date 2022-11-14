using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BeanSceneAppV1.Data;
using BeanSceneAppV1.Models;

namespace BeanSceneAppV1.Controllers
{
    public class TableAvailabilityReservationController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TableAvailabilityReservationController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TableAvailabilityReservation
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TableReservation.Include(t => t.Reservation).Include(t => t.TableAvailability);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: TableAvailabilityReservation/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TableReservation == null)
            {
                return NotFound();
            }

            var tableAvailabilityReservation = await _context.TableReservation
                .Include(t => t.Reservation)
                .Include(t => t.TableAvailability)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tableAvailabilityReservation == null)
            {
                return NotFound();
            }

            return View(tableAvailabilityReservation);
        }

        // GET: TableAvailabilityReservation/Create
        public IActionResult Create()
        {
            ViewData["ReservationId"] = new SelectList(_context.Reservation, "Id", "Email");
            ViewData["TableAvailabilityId"] = new SelectList(_context.TableAvailability, "Id", "Id");
            return View();
        }

        // POST: TableAvailabilityReservation/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TableAvailabilityId,ReservationId")] TableAvailabilityReservation tableAvailabilityReservation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tableAvailabilityReservation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ReservationId"] = new SelectList(_context.Reservation, "Id", "Email", tableAvailabilityReservation.ReservationId);
            ViewData["TableAvailabilityId"] = new SelectList(_context.TableAvailability, "Id", "Id", tableAvailabilityReservation.TableAvailabilityId);
            return View(tableAvailabilityReservation);
        }

        // GET: TableAvailabilityReservation/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TableReservation == null)
            {
                return NotFound();
            }

            var tableAvailabilityReservation = await _context.TableReservation.FindAsync(id);
            if (tableAvailabilityReservation == null)
            {
                return NotFound();
            }
            ViewData["ReservationId"] = new SelectList(_context.Reservation, "Id", "Email", tableAvailabilityReservation.ReservationId);
            ViewData["TableAvailabilityId"] = new SelectList(_context.TableAvailability, "Id", "Id", tableAvailabilityReservation.TableAvailabilityId);
            return View(tableAvailabilityReservation);
        }

        // POST: TableAvailabilityReservation/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TableAvailabilityId,ReservationId")] TableAvailabilityReservation tableAvailabilityReservation)
        {
            if (id != tableAvailabilityReservation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tableAvailabilityReservation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TableAvailabilityReservationExists(tableAvailabilityReservation.Id))
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
            ViewData["ReservationId"] = new SelectList(_context.Reservation, "Id", "Email", tableAvailabilityReservation.ReservationId);
            ViewData["TableAvailabilityId"] = new SelectList(_context.TableAvailability, "Id", "Id", tableAvailabilityReservation.TableAvailabilityId);
            return View(tableAvailabilityReservation);
        }

        // GET: TableAvailabilityReservation/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TableReservation == null)
            {
                return NotFound();
            }

            var tableAvailabilityReservation = await _context.TableReservation
                .Include(t => t.Reservation)
                .Include(t => t.TableAvailability)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tableAvailabilityReservation == null)
            {
                return NotFound();
            }

            return View(tableAvailabilityReservation);
        }

        // POST: TableAvailabilityReservation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TableReservation == null)
            {
                return Problem("Entity set 'ApplicationDbContext.TableReservation'  is null.");
            }
            var tableAvailabilityReservation = await _context.TableReservation.FindAsync(id);
            if (tableAvailabilityReservation != null)
            {
                _context.TableReservation.Remove(tableAvailabilityReservation);
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
