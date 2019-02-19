using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebCursos.Models;

namespace WebCursos.Controllers
{
    public class LeccionesController : Controller
    {
        private readonly DesaprendiendoDBContext _context;

        public LeccionesController(DesaprendiendoDBContext context)
        {
            _context = context;
        }

        // GET: Lecciones
        public async Task<IActionResult> Index()
        {
            var desaprendiendoDBContext = _context.Lección.Include(l => l.ModuloNavigation);
            return View(await desaprendiendoDBContext.ToListAsync());
        }

        // GET: Lecciones/Details/5
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

        // GET: Lecciones/Create
        public IActionResult Create()
        {
            ViewData["Modulo"] = new SelectList(_context.Modulo, "Id", "Id");
            return View();
        }

        // POST: Lecciones/Create
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
            ViewData["Modulo"] = new SelectList(_context.Modulo, "Id", "Id", lección.Modulo);
            return View(lección);
        }

        // GET: Lecciones/Edit/5
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
            ViewData["Modulo"] = new SelectList(_context.Modulo, "Id", "Id", lección.Modulo);
            return View(lección);
        }

        // POST: Lecciones/Edit/5
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
            ViewData["Modulo"] = new SelectList(_context.Modulo, "Id", "Id", lección.Modulo);
            return View(lección);
        }

        // GET: Lecciones/Delete/5
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

        // POST: Lecciones/Delete/5
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
