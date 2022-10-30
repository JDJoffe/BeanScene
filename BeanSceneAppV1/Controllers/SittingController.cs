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
    public class SittingController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SittingController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Sitting
        public async Task<IActionResult> Index()
        {
              return View(await _context.Sitting.ToListAsync());
        }

        // GET: Sitting/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Sitting == null)
            {
                return NotFound();
            }

            var sitting = await _context.Sitting
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sitting == null)
            {
                return NotFound();
            }

            return View(sitting);
        }

        // GET: Sitting/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sitting/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Sitting_Type,Start_Date,End_Date,Start_Time,End_Time,Capacity,Guest_Total,Tables_Available")] Sitting sitting)
        {
            if (ModelState.IsValid)
            {
                sitting.Tables_Available = sitting.Capacity / 4;
                _context.Add(sitting);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sitting);
        }

        // GET: Sitting/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Sitting == null)
            {
                return NotFound();
            }

            var sitting = await _context.Sitting.FindAsync(id);
            if (sitting == null)
            {
                return NotFound();
            }
            return View(sitting);
        }

        // POST: Sitting/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Sitting_Type,Start_Date,End_Date,Start_Time,End_Time,Capacity,Guest_Total,Tables_Available")] Sitting sitting)
        {
            if (id != sitting.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sitting);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SittingExists(sitting.Id))
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
            return View(sitting);
        }

        // GET: Sitting/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Sitting == null)
            {
                return NotFound();
            }

            var sitting = await _context.Sitting
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sitting == null)
            {
                return NotFound();
            }

            return View(sitting);
        }

        // POST: Sitting/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Sitting == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Sitting'  is null.");
            }
            var sitting = await _context.Sitting.FindAsync(id);
            if (sitting != null)
            {
                _context.Sitting.Remove(sitting);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SittingExists(int id)
        {
          return _context.Sitting.Any(e => e.Id == id);
        }
    }
}
