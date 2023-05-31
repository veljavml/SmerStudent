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
    public class StudentController : Controller
    {
        private readonly EFDataContext _context;

        public StudentController(EFDataContext context)
        {
            _context = context;
        }

        // GET: Student
        public async Task<IActionResult> Index(string filter)
        {
            var eFDataContext = _context.Studenti.Include(s => s.Smer).Where(s=>filter==null || s.Ime==filter||s.Prezime==filter||s.Smer.Naziv==filter);
            return View(await eFDataContext.ToListAsync());
        }

        // GET: Student/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Studenti == null)
            {
                return NotFound();
            }

            var student = await _context.Studenti
                .Include(s => s.Smer)
                .FirstOrDefaultAsync(m => m.StudentID == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Student/Create
        public IActionResult Create()
        {
            ViewData["SmerID"] = new SelectList(_context.Smerovi, "SmerID", "Naziv");
            return View();
        }

        // POST: Student/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentID,Ime,Prezime,JMBG,BrojIndeksa,DatumRodjenja,SmerID")] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SmerID"] = new SelectList(_context.Smerovi, "SmerID", "Naziv", student.SmerID);
            return View(student);
        }

        // GET: Student/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Studenti == null)
            {
                return NotFound();
            }

            var student = await _context.Studenti.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            ViewData["SmerID"] = new SelectList(_context.Smerovi, "SmerID", "Naziv", student.SmerID);
            return View(student);
        }

        // POST: Student/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StudentID,Ime,Prezime,JMBG,BrojIndeksa,DatumRodjenja,SmerID")] Student student)
        {
            if (id != student.StudentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.StudentID))
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
            ViewData["SmerID"] = new SelectList(_context.Smerovi, "SmerID", "Naziv", student.SmerID);
            return View(student);
        }

        // GET: Student/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Studenti == null)
            {
                return NotFound();
            }

            var student = await _context.Studenti
                .Include(s => s.Smer)
                .FirstOrDefaultAsync(m => m.StudentID == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Studenti == null)
            {
                return Problem("Entity set 'EFDataContext.Studenti'  is null.");
            }
            var student = await _context.Studenti.FindAsync(id);
            if (student != null)
            {
                _context.Studenti.Remove(student);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int id)
        {
          return (_context.Studenti?.Any(e => e.StudentID == id)).GetValueOrDefault();
        }
    }
}
