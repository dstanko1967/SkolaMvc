using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SkolaMvc.Models;

namespace SkolaMvc.Controllers
{
    public class StudentisController : Controller
    {
        private readonly SkolaContext _context;

        public StudentisController(SkolaContext context)
        {
            _context = context;
        }

        // GET: Studentis
        public async Task<IActionResult> Index()
        {
            return View(await _context.Studenti.ToListAsync());
        }

        // GET: Studentis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studenti = await _context.Studenti
                .FirstOrDefaultAsync(m => m.IdStudent == id);
            if (studenti == null)
            {
                return NotFound();
            }

            return View(studenti);
        }

        // GET: Studentis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Studentis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdStudent,Ime,Prezime,DatumRođenja,MestoRođenja")] Studenti studenti)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studenti);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(studenti);
        }

        // GET: Studentis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studenti = await _context.Studenti.FindAsync(id);
            if (studenti == null)
            {
                return NotFound();
            }
            return View(studenti);
        }

        // POST: Studentis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdStudent,Ime,Prezime,DatumRođenja,MestoRođenja")] Studenti studenti)
        {
            if (id != studenti.IdStudent)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studenti);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentiExists(studenti.IdStudent))
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
            return View(studenti);
        }

        // GET: Studentis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studenti = await _context.Studenti
                .FirstOrDefaultAsync(m => m.IdStudent == id);
            if (studenti == null)
            {
                return NotFound();
            }

            return View(studenti);
        }

        // POST: Studentis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var studenti = await _context.Studenti.FindAsync(id);
            _context.Studenti.Remove(studenti);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentiExists(int id)
        {
            return _context.Studenti.Any(e => e.IdStudent == id);
        }
    }
}
