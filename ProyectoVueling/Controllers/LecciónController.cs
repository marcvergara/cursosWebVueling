using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoVueling.Models;

namespace ProyectoVueling.Controllers
{
    public class LecciónController : Controller
    {
        private readonly DesaprendiendoDBContext _context;

        public LecciónController(DesaprendiendoDBContext context)
        {
            _context = context;
        }

        // GET: Lección
        public async Task<IActionResult> Index()
        {
            var desaprendiendoDBContext = _context.Lección.Include(l => l.ModuloNavigation);
            return View(await desaprendiendoDBContext.ToListAsync());
        }

        // GET: Lección/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lección = await _context.Lección
                .Include(l => l.ModuloNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lección == null)
            {
                return NotFound();
            }

            return View(lección);
        }

        // GET: Lección/Create
        public IActionResult Create()
        {
            ViewData["Modulo"] = new SelectList(_context.Modulo, "Id", "Modulo1");
            return View();
        }

        // POST: Lección/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Lección1,ComentarioHtml,Modulo,HayEjercicios,Pos")] Lección lección)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lección);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Modulo"] = new SelectList(_context.Modulo, "Id", "Modulo1", lección.Modulo);
            return View(lección);
        }

        // GET: Lección/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lección = await _context.Lección.FindAsync(id);
            if (lección == null)
            {
                return NotFound();
            }
            ViewData["Modulo"] = new SelectList(_context.Modulo, "Id", "Modulo1", lección.Modulo);
            return View(lección);
        }

        // POST: Lección/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Lección1,ComentarioHtml,Modulo,HayEjercicios,Pos")] Lección lección)
        {
            if (id != lección.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lección);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LecciónExists(lección.Id))
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
            ViewData["Modulo"] = new SelectList(_context.Modulo, "Id", "Modulo1", lección.Modulo);
            return View(lección);
        }

        // GET: Lección/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lección = await _context.Lección
                .Include(l => l.ModuloNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lección == null)
            {
                return NotFound();
            }

            return View(lección);
        }

        // POST: Lección/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lección = await _context.Lección.FindAsync(id);
            _context.Lección.Remove(lección);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LecciónExists(int id)
        {
            return _context.Lección.Any(e => e.Id == id);
        }
    }
}
