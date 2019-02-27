using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoVueling.Models;

namespace ProyectoVueling.Controllers
{
    public class ModulosCursoAmedidasController : Controller
    {
        private readonly DesaprendiendoDBContext _context;

        public ModulosCursoAmedidasController(DesaprendiendoDBContext context)
        {
            _context = context;
        }

        // GET: ModulosCursoAmedidas
        public async Task<IActionResult> Index()
        {
            var desaprendiendoDBContext = _context.ModulosCursoAmedida.Include(m => m.IdCursoAmedidaNavigation).Include(m => m.IdModuloAmedidaNavigation).Include(m => m.IdProfesorNavigation);
            return View(await desaprendiendoDBContext.ToListAsync());
        }

        // GET: ModulosCursoAmedidas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modulosCursoAmedida = await _context.ModulosCursoAmedida
                .Include(m => m.IdCursoAmedidaNavigation)
                .Include(m => m.IdModuloAmedidaNavigation)
                .Include(m => m.IdProfesorNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (modulosCursoAmedida == null)
            {
                return NotFound();
            }

            return View(modulosCursoAmedida);
        }

        // GET: ModulosCursoAmedidas/Create
        public IActionResult Create()
        {
            ViewData["IdCursoAmedida"] = new SelectList(_context.CursoAmedida, "Id", "Id");
            ViewData["IdModuloAmedida"] = new SelectList(_context.Modulo, "Id", "Id");
            ViewData["IdProfesor"] = new SelectList(_context.Profesor, "Id", "Id");
            return View();
        }

        // POST: ModulosCursoAmedidas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdCursoAmedida,IdModuloAmedida,IdProfesor")] ModulosCursoAmedida modulosCursoAmedida)
        {
            if (ModelState.IsValid)
            {
                _context.Add(modulosCursoAmedida);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCursoAmedida"] = new SelectList(_context.CursoAmedida, "Id", "Id", modulosCursoAmedida.IdCursoAmedida);
            ViewData["IdModuloAmedida"] = new SelectList(_context.Modulo, "Id", "Id", modulosCursoAmedida.IdModuloAmedida);
            ViewData["IdProfesor"] = new SelectList(_context.Profesor, "Id", "Id", modulosCursoAmedida.IdProfesor);
            return View(modulosCursoAmedida);
        }

        // GET: ModulosCursoAmedidas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modulosCursoAmedida = await _context.ModulosCursoAmedida.FindAsync(id);
            if (modulosCursoAmedida == null)
            {
                return NotFound();
            }
            ViewData["IdCursoAmedida"] = new SelectList(_context.CursoAmedida, "Id", "Id", modulosCursoAmedida.IdCursoAmedida);
            ViewData["IdModuloAmedida"] = new SelectList(_context.Modulo, "Id", "Id", modulosCursoAmedida.IdModuloAmedida);
            ViewData["IdProfesor"] = new SelectList(_context.Profesor, "Id", "Id", modulosCursoAmedida.IdProfesor);
            return View(modulosCursoAmedida);
        }

        // POST: ModulosCursoAmedidas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdCursoAmedida,IdModuloAmedida,IdProfesor")] ModulosCursoAmedida modulosCursoAmedida)
        {
            if (id != modulosCursoAmedida.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(modulosCursoAmedida);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModulosCursoAmedidaExists(modulosCursoAmedida.Id))
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
            ViewData["IdCursoAmedida"] = new SelectList(_context.CursoAmedida, "Id", "Id", modulosCursoAmedida.IdCursoAmedida);
            ViewData["IdModuloAmedida"] = new SelectList(_context.Modulo, "Id", "Id", modulosCursoAmedida.IdModuloAmedida);
            ViewData["IdProfesor"] = new SelectList(_context.Profesor, "Id", "Id", modulosCursoAmedida.IdProfesor);
            return View(modulosCursoAmedida);
        }

        // GET: ModulosCursoAmedidas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modulosCursoAmedida = await _context.ModulosCursoAmedida
                .Include(m => m.IdCursoAmedidaNavigation)
                .Include(m => m.IdModuloAmedidaNavigation)
                .Include(m => m.IdProfesorNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (modulosCursoAmedida == null)
            {
                return NotFound();
            }

            return View(modulosCursoAmedida);
        }

        // POST: ModulosCursoAmedidas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var modulosCursoAmedida = await _context.ModulosCursoAmedida.FindAsync(id);
            _context.ModulosCursoAmedida.Remove(modulosCursoAmedida);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ModulosCursoAmedidaExists(int id)
        {
            return _context.ModulosCursoAmedida.Any(e => e.Id == id);
        }
    }
}
