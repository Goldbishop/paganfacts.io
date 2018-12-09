using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using paganfacts.io.Models;

namespace paganfacts.io.Controllers
{
    public class DeitiesController : Controller
    {
        private readonly paganfactsioContext _context;

        public DeitiesController(paganfactsioContext context)
        {
            _context = context;
        }

        // GET: Deities
        public async Task<IActionResult> Index()
        {
            return View(await _context.Deities.ToListAsync());
        }

        // GET: Deities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deities = await _context.Deities
                .FirstOrDefaultAsync(m => m.ID == id);
            if (deities == null)
            {
                return NotFound();
            }

            return View(deities);
        }

        // GET: Deities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Deities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Origin,Description")] Deities deities)
        {
            if (ModelState.IsValid)
            {
                _context.Add(deities);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(deities);
        }

        // GET: Deities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deities = await _context.Deities.FindAsync(id);
            if (deities == null)
            {
                return NotFound();
            }
            return View(deities);
        }

        // POST: Deities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Origin,Description")] Deities deities)
        {
            if (id != deities.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(deities);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeitiesExists(deities.ID))
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
            return View(deities);
        }

        // GET: Deities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deities = await _context.Deities
                .FirstOrDefaultAsync(m => m.ID == id);
            if (deities == null)
            {
                return NotFound();
            }

            return View(deities);
        }

        // POST: Deities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var deities = await _context.Deities.FindAsync(id);
            _context.Deities.Remove(deities);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeitiesExists(int id)
        {
            return _context.Deities.Any(e => e.ID == id);
        }
    }
}
