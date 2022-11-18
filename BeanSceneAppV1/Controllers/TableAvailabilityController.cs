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
using System.Data;
using Microsoft.AspNetCore.Authorization;


namespace BeanSceneAppV1.Controllers
{
    [Authorize(Roles = "Manager")]
    public class TableAvailabilityController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TableAvailabilityController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TableAvailability
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TableAvailability
                //.Where(t => t.ta)
                .Include(t => t.Table)
                .Include(t => t.TimeSlot);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: TableAvailability/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TableAvailability == null)
            {
                return NotFound();
            }

            var tableAvailability = await _context.TableAvailability
                .Include(t => t.Table)
                .Include(t => t.TimeSlot)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tableAvailability == null)
            {
                return NotFound();
            }

            return View(tableAvailability);
        }

        // GET: TableAvailability/Create
        public IActionResult Create()
        {
            var model = new TableAvailabilityViewModel()
            {
                Tables = _context.Table.ToList(),
                TimeSlots = _context.TimeSlot.ToList()
            };
            return View(model);
            //ViewData["TableId"] = new SelectList(_context.Table, "Id", "Table_Name");
            //ViewData["TimeSlotId"] = new SelectList(_context.TimeSlot, "Id", "Id");
            //return View();
        }

        // POST: TableAvailability/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TableAvailabilityViewModel tableAvailabilityVM)
        {
            var tableAvailability = new Models.TableAvailability
            {
                Id = tableAvailabilityVM.TableAvailability.Id,
                Date = tableAvailabilityVM.TableAvailability.Date,
                TableId = tableAvailabilityVM.TableAvailability.TableId,
                Table = tableAvailabilityVM.TableAvailability.Table,
                TimeSlotId = tableAvailabilityVM.TableAvailability.TimeSlotId,
                TimeSlot = tableAvailabilityVM.TableAvailability.TimeSlot

            };
            tableAvailabilityVM.Tables = _context.Table.ToList();
            tableAvailabilityVM.TimeSlots = _context.TimeSlot.ToList();
            //if (ModelState.IsValid)
            //{
            _context.Add(tableAvailability);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            //}
            //ViewData["TableId"] = new SelectList(_context.Table, "Id", "Table_Name", tableAvailability.TableId);
            //ViewData["TimeSlotId"] = new SelectList(_context.TimeSlot, "Id", "Id", tableAvailability.TimeSlotId);
            return View(tableAvailability);
        }

        // GET: TableAvailability/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TableAvailability == null)
            {
                return NotFound();
            }

            var tableAvailability = await _context.TableAvailability.FindAsync(id);
            if (tableAvailability == null)
            {
                return NotFound();
            }
            ViewData["TableId"] = new SelectList(_context.Table, "Id", "Table_Name", tableAvailability.TableId);
            ViewData["TimeSlotId"] = new SelectList(_context.TimeSlot, "Id", "Id", tableAvailability.TimeSlotId);
            return View(tableAvailability);
        }

        // POST: TableAvailability/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TableId,Date,TimeSlotId")] TableAvailability tableAvailability)
        {
            if (id != tableAvailability.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tableAvailability);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TableAvailabilityExists(tableAvailability.Id))
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
            ViewData["TableId"] = new SelectList(_context.Table, "Id", "Table_Name", tableAvailability.TableId);
            ViewData["TimeSlotId"] = new SelectList(_context.TimeSlot, "Id", "Id", tableAvailability.TimeSlotId);
            return View(tableAvailability);
        }

        // GET: TableAvailability/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TableAvailability == null)
            {
                return NotFound();
            }

            var tableAvailability = await _context.TableAvailability
                .Include(t => t.Table)
                .Include(t => t.TimeSlot)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tableAvailability == null)
            {
                return NotFound();
            }

            return View(tableAvailability);
        }

        // POST: TableAvailability/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TableAvailability == null)
            {
                return Problem("Entity set 'ApplicationDbContext.TableAvailability'  is null.");
            }
            var tableAvailability = await _context.TableAvailability.FindAsync(id);
            if (tableAvailability != null)
            {
                _context.TableAvailability.Remove(tableAvailability);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TableAvailabilityExists(int id)
        {
            return _context.TableAvailability.Any(e => e.Id == id);
        }
    }
}
