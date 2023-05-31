using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentSmer3.Data;
using StudentSmer3.Models;

namespace StudentSmer3.Controllers
{
    public class SmerController : Controller
    {
        private readonly EFDataContext _context;

        public SmerController(EFDataContext context)
        {
            _context = context;
        }

        // GET: Smer
        public async Task<IActionResult> Index()
        {
              return _context.Smerovi != null ? 
                          View(await _context.Smerovi.ToListAsync()) :
                          Problem("Entity set 'EFDataContext.Smerovi'  is null.");
        }

        // GET: Smer/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Smerovi == null)
            {
                return NotFound();
            }

            var smer = await _context.Smerovi
                .FirstOrDefaultAsync(m => m.SmerID == id);
            if (smer == null)
            {
                return NotFound();
            }

            return View(smer);
        }

        // GET: Smer/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Smer/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SmerID,Naziv")] Smer smer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(smer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(smer);
        }

        // GET: Smer/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Smerovi == null)
            {
                return NotFound();
            }

            var smer = await _context.Smerovi.FindAsync(id);
            if (smer == null)
            {
                return NotFound();
            }
            return View(smer);
        }

        // POST: Smer/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SmerID,Naziv")] Smer smer)
        {
            if (id != smer.SmerID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(smer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SmerExists(smer.SmerID))
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
            return View(smer);
        }

        // GET: Smer/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Smerovi == null)
            {
                return NotFound();
            }

            var smer = await _context.Smerovi
                .FirstOrDefaultAsync(m => m.SmerID == id);
            if (smer == null)
            {
                return NotFound();
            }

            return View(smer);
        }

        // POST: Smer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Smerovi == null)
            {
                return Problem("Entity set 'EFDataContext.Smerovi'  is null.");
            }
            var smer = await _context.Smerovi.FindAsync(id);
            if (smer != null)
            {
                _context.Smerovi.Remove(smer);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SmerExists(int id)
        {
          return (_context.Smerovi?.Any(e => e.SmerID == id)).GetValueOrDefault();
        }
    }
}
