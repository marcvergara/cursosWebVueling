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
    public class CursoAmedidasController : Controller
    {
        private readonly DesaprendiendoDBContext _context;

        public CursoAmedidasController(DesaprendiendoDBContext context)
        {
            _context = context;
        }

        // GET: CursoAmedidas
        public async Task<IActionResult> Index()
        {
            return View(await _context.CursoAmedida.ToListAsync());
        }

        // GET: CursoAmedidas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cursoAmedida = await _context.CursoAmedida
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cursoAmedida == null)
            {
                return NotFound();
            }

            return View(cursoAmedida);
        }

        // GET: CursoAmedidas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CursoAmedidas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,FechaCreación")] CursoAmedida cursoAmedida)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cursoAmedida);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cursoAmedida);
        }

        // GET: CursoAmedidas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cursoAmedida = await _context.CursoAmedida.FindAsync(id);
            if (cursoAmedida == null)
            {
                return NotFound();
            }
            return View(cursoAmedida);
        }

        // POST: CursoAmedidas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,FechaCreación")] CursoAmedida cursoAmedida)
        {
            if (id != cursoAmedida.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cursoAmedida);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CursoAmedidaExists(cursoAmedida.Id))
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
            return View(cursoAmedida);
        }

        // GET: CursoAmedidas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cursoAmedida = await _context.CursoAmedida
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cursoAmedida == null)
            {
                return NotFound();
            }

            return View(cursoAmedida);
        }

        // POST: CursoAmedidas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cursoAmedida = await _context.CursoAmedida.FindAsync(id);
            _context.CursoAmedida.Remove(cursoAmedida);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CursoAmedidaExists(int id)
        {
            return _context.CursoAmedida.Any(e => e.Id == id);
        }
    }
}
