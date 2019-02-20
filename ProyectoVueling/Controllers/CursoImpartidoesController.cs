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
    public class CursoImpartidoesController : Controller
    {
        private readonly DesaprendiendoDBContext _context;

        public CursoImpartidoesController(DesaprendiendoDBContext context)
        {
            _context = context;
        }

        // GET: CursoImpartidoes
        public async Task<IActionResult> Index()
        {
            var desaprendiendoDBContext = _context.CursoImpartido.Include(c => c.IdClienteNavigation).Include(c => c.IdCursoNavigation);
            return View(await desaprendiendoDBContext.ToListAsync());
        }

        // GET: CursoImpartidoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cursoImpartido = await _context.CursoImpartido
                .Include(c => c.IdClienteNavigation)
                .Include(c => c.IdCursoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cursoImpartido == null)
            {
                return NotFound();
            }

            return View(cursoImpartido);
        }

        // GET: CursoImpartidoes/Create
        public IActionResult Create()
        {
            ViewData["IdCliente"] = new SelectList(_context.Cliente, "Id", "Id");
            ViewData["IdCurso"] = new SelectList(_context.Curso, "Id", "Id");
            return View();
        }

        // POST: CursoImpartidoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdCurso,IdCliente,Fecha,Audio,Nota")] CursoImpartido cursoImpartido)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cursoImpartido);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCliente"] = new SelectList(_context.Cliente, "Id", "Id", cursoImpartido.IdCliente);
            ViewData["IdCurso"] = new SelectList(_context.Curso, "Id", "Id", cursoImpartido.IdCurso);
            return View(cursoImpartido);
        }

        // GET: CursoImpartidoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cursoImpartido = await _context.CursoImpartido.FindAsync(id);
            if (cursoImpartido == null)
            {
                return NotFound();
            }
            ViewData["IdCliente"] = new SelectList(_context.Cliente, "Id", "Id", cursoImpartido.IdCliente);
            ViewData["IdCurso"] = new SelectList(_context.Curso, "Id", "Id", cursoImpartido.IdCurso);
            return View(cursoImpartido);
        }

        // POST: CursoImpartidoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdCurso,IdCliente,Fecha,Audio,Nota")] CursoImpartido cursoImpartido)
        {
            if (id != cursoImpartido.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cursoImpartido);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CursoImpartidoExists(cursoImpartido.Id))
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
            ViewData["IdCliente"] = new SelectList(_context.Cliente, "Id", "Id", cursoImpartido.IdCliente);
            ViewData["IdCurso"] = new SelectList(_context.Curso, "Id", "Id", cursoImpartido.IdCurso);
            return View(cursoImpartido);
        }

        // GET: CursoImpartidoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cursoImpartido = await _context.CursoImpartido
                .Include(c => c.IdClienteNavigation)
                .Include(c => c.IdCursoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cursoImpartido == null)
            {
                return NotFound();
            }

            return View(cursoImpartido);
        }

        // POST: CursoImpartidoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cursoImpartido = await _context.CursoImpartido.FindAsync(id);
            _context.CursoImpartido.Remove(cursoImpartido);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CursoImpartidoExists(int id)
        {
            return _context.CursoImpartido.Any(e => e.Id == id);
        }
    }
}
