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
    public class AmedidasController : Controller
    {
        private readonly DesaprendiendoDBContext _context;

        public AmedidasController(DesaprendiendoDBContext context)
        {
            _context = context;
        }

        // GET: Amedidas
        public async Task<IActionResult> Index()
        {
            var desaprendiendoDBContext = _context.Amedida.Include(a => a.CursoNavigation).Include(a => a.ModuloNavigation);
            return View(await desaprendiendoDBContext.ToListAsync());
        }

        // GET: Amedidas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var amedida = await _context.Amedida
                .Include(a => a.CursoNavigation)
                .Include(a => a.ModuloNavigation)
                .FirstOrDefaultAsync(m => m.Curso == id);
            if (amedida == null)
            {
                return NotFound();
            }

            return View(amedida);
        }

        // GET: Amedidas/Create
        public IActionResult Create()
        {
            ViewData["Curso"] = new SelectList(_context.Curso, "Id", "Id");
            ViewData["Modulo"] = new SelectList(_context.Modulo, "Id", "Id");
            return View();
        }

        // POST: Amedidas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Curso,Modulo,Observaciones")] Amedida amedida)
        {
            if (ModelState.IsValid)
            {
                _context.Add(amedida);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Curso"] = new SelectList(_context.Curso, "Id", "Id", amedida.Curso);
            ViewData["Modulo"] = new SelectList(_context.Modulo, "Id", "Id", amedida.Modulo);
            return View(amedida);
        }

        // GET: Amedidas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var amedida = await _context.Amedida.FindAsync(id);
            if (amedida == null)
            {
                return NotFound();
            }
            ViewData["Curso"] = new SelectList(_context.Curso, "Id", "Id", amedida.Curso);
            ViewData["Modulo"] = new SelectList(_context.Modulo, "Id", "Id", amedida.Modulo);
            return View(amedida);
        }

        // POST: Amedidas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Curso,Modulo,Observaciones")] Amedida amedida)
        {
            if (id != amedida.Curso)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(amedida);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AmedidaExists(amedida.Curso))
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
            ViewData["Curso"] = new SelectList(_context.Curso, "Id", "Id", amedida.Curso);
            ViewData["Modulo"] = new SelectList(_context.Modulo, "Id", "Id", amedida.Modulo);
            return View(amedida);
        }

        // GET: Amedidas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var amedida = await _context.Amedida
                .Include(a => a.CursoNavigation)
                .Include(a => a.ModuloNavigation)
                .FirstOrDefaultAsync(m => m.Curso == id);
            if (amedida == null)
            {
                return NotFound();
            }

            return View(amedida);
        }

        // POST: Amedidas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var amedida = await _context.Amedida.FindAsync(id);
            _context.Amedida.Remove(amedida);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AmedidaExists(int id)
        {
            return _context.Amedida.Any(e => e.Curso == id);
        }
    }
}
