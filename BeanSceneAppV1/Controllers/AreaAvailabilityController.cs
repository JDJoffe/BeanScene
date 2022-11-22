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
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Authorization;


namespace BeanSceneAppV1.Controllers
{
    [Authorize(Roles = "Manager")]
    public class AreaAvailabilityController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AreaAvailabilityController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AreaAvailability
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.AreaAvailability.Include(a => a.Area);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: AreaAvailability/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AreaAvailability == null)
            {
                return NotFound();
            }

            var areaAvailability = await _context.AreaAvailability
                .Include(a => a.Area)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (areaAvailability == null)
            {
                return NotFound();
            }

            return View(areaAvailability);
        }

        // GET: AreaAvailability/Create
        public IActionResult Create()
        {
            var model = new AreaAvailabilityViewModel()
            {
                Areas = _context.Area.ToList(),
                TimeSlots = _context.TimeSlot.ToList()
            };
            return View(model);
            //ViewData["AreaId"] = new SelectList(_context.Area, "Id", "Name");
            //ViewData["TimeSlotId"] = new SelectList(_context.TimeSlot, "Id", "Id");
            //return View();
        }

        // POST: AreaAvailability/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( AreaAvailabilityViewModel areaAvailabilityVM)
        {
            var areaAvailability = new Models.AreaAvailability
            {
                Id = areaAvailabilityVM.AreaAvailability.Id,
                Date = areaAvailabilityVM.AreaAvailability.Date,
                AreaId = areaAvailabilityVM.AreaAvailability.AreaId,
                Area = areaAvailabilityVM.AreaAvailability.Area,
                Start_Time = areaAvailabilityVM.AreaAvailability.Start_Time,
                End_Time = areaAvailabilityVM.AreaAvailability.End_Time
            };
            areaAvailabilityVM.Areas = _context.Area.ToList();
            areaAvailabilityVM.TimeSlots = _context.TimeSlot.ToList();

            //if (ModelState.IsValid)
            //{
                _context.Add(areaAvailability);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            //}
            //ViewData["AreaId"] = new SelectList(_context.Area, "Id", "Name", areaAvailability.AreaId);
            //ViewData["TimeSlotId"] = new SelectList(_context.TimeSlot, "Id", "Id", areaAvailability.TimeSlotId);
            //return View(areaAvailability);
        }

        // GET: AreaAvailability/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AreaAvailability == null)
            {
                return NotFound();
            }

            var areaAvailability = await _context.AreaAvailability.FindAsync(id);
            if (areaAvailability == null)
            {
                return NotFound();
            }
            ViewData["AreaId"] = new SelectList(_context.Area, "Id", "Name", areaAvailability.AreaId);          
            return View(areaAvailability);
        }

        // POST: AreaAvailability/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AreaId,Date,TimeSlotId,Status")] AreaAvailability areaAvailability)
        {
            if (id != areaAvailability.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(areaAvailability);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AreaAvailabilityExists(areaAvailability.Id))
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
            ViewData["AreaId"] = new SelectList(_context.Area, "Id", "Name", areaAvailability.AreaId);           
            return View(areaAvailability);
        }

        // GET: AreaAvailability/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AreaAvailability == null)
            {
                return NotFound();
            }

            var areaAvailability = await _context.AreaAvailability
                .Include(a => a.Area)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (areaAvailability == null)
            {
                return NotFound();
            }

            return View(areaAvailability);
        }

        // POST: AreaAvailability/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AreaAvailability == null)
            {
                return Problem("Entity set 'ApplicationDbContext.AreaAvailability'  is null.");
            }
            var areaAvailability = await _context.AreaAvailability.FindAsync(id);
            if (areaAvailability != null)
            {
                _context.AreaAvailability.Remove(areaAvailability);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AreaAvailabilityExists(int id)
        {
          return _context.AreaAvailability.Any(e => e.Id == id);
        }
    }
}
