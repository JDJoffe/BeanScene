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
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BeanSceneAppV1.Controllers
{
    public class TableController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TableController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Table
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Table.Include(t => t.Area);
              return View(await applicationDbContext.ToListAsync());
        }

        // GET: Table/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Table == null)
            {
                return NotFound();
            }

            var table = await _context.Table
                .Include(t => t.Area)
                .FirstOrDefaultAsync(m => m.Table_Id == id);
            if (table == null)
            {
                return NotFound();
            }
            var model = new TableViewModel()
            {
                Table = table,
                Areas = _context.Area.ToList()
            };
            return View(model);
        }

        // GET: Table/Create
        public IActionResult Create()
        {
            var model = new TableViewModel()
            {            
                Areas = _context.Area.ToList()
            };
            return View(model);
        }

        // POST: Table/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TableViewModel tableVM)
        {
            var table = new Models.Table
            {
                Table_Id = tableVM.Table.Table_Id,
                Area= tableVM.Table.Area,
                Table_Seats = tableVM.Table.Table_Seats
            };
            tableVM.Areas = _context.Area.ToList();
            //if (ModelState.IsValid)
            //{
                _context.Add(table);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            //}
            return View(table);
        }

        // GET: Table/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Table == null)
            {
                return NotFound();
            }

            var table = await _context.Table.FindAsync(id);
            if (table == null)
            {
                return NotFound();
            }

            var model = new TableViewModel()
            {
                Table = table,
                Areas = _context.Area.ToList()
            };
            return View(model);
        }

        // POST: Table/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TableViewModel tableVM)
        {
            //if (ModelState.IsValid)
            //{
                tableVM.Areas = _context.Area.ToList();
                _context.Update(tableVM.Table);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index)); 
            //}

            //if (id != table.Table_Id)
            //{
            //    return NotFound();
            //}

            //if (ModelState.IsValid)
            //{
            //    try
            //    {
            //        _context.Update(table);
            //        await _context.SaveChangesAsync();
            //    }
            //    catch (DbUpdateConcurrencyException)
            //    {
            //        if (!TableExists(table.Table_Id))
            //        {
            //            return NotFound();
            //        }
            //        else
            //        {
            //            throw;
            //        }
            //    }
            //    return RedirectToAction(nameof(Index));
            //}
            //return View(table);
        }

        // GET: Table/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Table == null)
            {
                return NotFound();
            }

            var table = await _context.Table
                .Include(t => t.Area)
                .FirstOrDefaultAsync(m => m.Table_Id == id);
            if (table == null)
            {
                return NotFound();
            }

            var model = new TableViewModel()
            {
                Table = table,
                Areas = _context.Area.ToList()
            };
            return View(model);
            
        }

        // POST: Table/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Table == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Table'  is null.");
            }
            var table = await _context.Table.FindAsync(id);
            if (table != null)
            {
                _context.Table.Remove(table);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TableExists(string id)
        {
          return _context.Table.Any(e => e.Table_Id == id);
        }
    }
}