﻿using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoVueling.Models;

namespace ProyectoVueling.Controllers
{
    public class CursoesController : Controller
    {
        private readonly DesaprendiendoDBContext _context;

        public CursoesController(DesaprendiendoDBContext context)
        {
            _context = context;
        }

        // GET: Cursoes
        public async Task<IActionResult> Index()
        {
            var desaprendiendoDBContext = _context.Curso.Include(c => c.SubCategoriaNavigation);
            return View(await desaprendiendoDBContext.ToListAsync());
        }

        // GET: Cursoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var curso = await _context.Curso
                .Include(c => c.SubCategoriaNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (curso == null)
            {
                return NotFound();
            }

            return View(curso);
        }

        // GET: Cursoes/Create
        public IActionResult Create()
        {
            ViewData["SubCategoria"] = new SelectList(_context.SubCategoria, "Id", "SubCategoria1");
            return View();
        }

        // POST: Cursoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Curso1,ComentarioHtml,ImagenMiniatura,ImagenGrande,SubCategoria")] Curso curso)
        {
            if (ModelState.IsValid)
            {
                _context.Add(curso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SubCategoria"] = new SelectList(_context.SubCategoria, "Id", "SubCategoria1", curso.SubCategoria);
            return View(curso);
        }

        // GET: Cursoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var curso = await _context.Curso.FindAsync(id);
            if (curso == null)
            {
                return NotFound();
            }
            ViewData["SubCategoria"] = new SelectList(_context.SubCategoria, "Id", "SubCategoria1", curso.SubCategoria);
            return View(curso);
        }

        // POST: Cursoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Curso1,ComentarioHtml,ImagenMiniatura,ImagenGrande,SubCategoria")] Curso curso)
        {
            if (id != curso.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(curso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CursoExists(curso.Id))
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
            ViewData["SubCategoria"] = new SelectList(_context.SubCategoria, "Id", "SubCategoria1", curso.SubCategoria);
            return View(curso);
        }

        // GET: Cursoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var curso = await _context.Curso
                .Include(c => c.SubCategoriaNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (curso == null)
            {
                return NotFound();
            }

            return View(curso);
        }

        // POST: Cursoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var curso = await _context.Curso.FindAsync(id);
            _context.Curso.Remove(curso);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CursoExists(int id)
        {
            return _context.Curso.Any(e => e.Id == id);
        }
    }
}
