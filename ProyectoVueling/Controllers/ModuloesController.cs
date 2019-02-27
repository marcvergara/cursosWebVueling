using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoVueling.Models;

namespace ProyectoVueling.Controllers
{
    public class ModuloesController : Controller
    {
        private readonly DesaprendiendoDBContext _context;

        public ModuloesController(DesaprendiendoDBContext context)
        {
            _context = context;
        }

        // GET: Moduloes
        public async Task<IActionResult> Index()
        {
            var desaprendiendoDBContext = _context.Modulo.Include(m => m.CursoNavigation).Include(m => m.IdProfesorNavigation);
            return View(await desaprendiendoDBContext.ToListAsync());
        }

        // GET: Moduloes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modulo = await _context.Modulo
                .Include(m => m.CursoNavigation)
                .Include(m => m.IdProfesorNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (modulo == null)
            {
                return NotFound();
            }

            return View(modulo);
        }

        // GET: Moduloes/Create
        public IActionResult Create()
        {
            ViewData["Curso"] = new SelectList(_context.Curso, "Id", "Curso1");
            ViewData["IdProfesor"] = new SelectList(_context.Profesor, "Id", "Nombre");
            return View();
        }

        // POST: Moduloes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Modulo1,ComentarioHtml,Curso,DuracionEnMinutos,HayEjercicios,Pos,IdProfesor")] Modulo modulo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(modulo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Curso"] = new SelectList(_context.Curso, "Id", "Curso1", modulo.Curso);
            ViewData["IdProfesor"] = new SelectList(_context.Profesor, "Id", "Nombre", modulo.IdProfesor);
            return View(modulo);
        }

        // GET: Moduloes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modulo = await _context.Modulo.FindAsync(id);
            if (modulo == null)
            {
                return NotFound();
            }
            ViewData["Curso"] = new SelectList(_context.Curso, "Id", "Curso1", modulo.Curso);
            ViewData["IdProfesor"] = new SelectList(_context.Profesor, "Id", "Nombre", modulo.IdProfesor);
            return View(modulo);
        }

        // POST: Moduloes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Modulo1,ComentarioHtml,Curso,DuracionEnMinutos,HayEjercicios,Pos,IdProfesor")] Modulo modulo)
        {
            if (id != modulo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(modulo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModuloExists(modulo.Id))
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
            ViewData["Curso"] = new SelectList(_context.Curso, "Id", "Curso1", modulo.Curso);
            ViewData["IdProfesor"] = new SelectList(_context.Profesor, "Id", "Nombre", modulo.IdProfesor);
            return View(modulo);
        }

        // GET: Moduloes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modulo = await _context.Modulo
                .Include(m => m.CursoNavigation)
                .Include(m => m.IdProfesorNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (modulo == null)
            {
                return NotFound();
            }

            return View(modulo);
        }

        // POST: Moduloes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var modulo = await _context.Modulo.FindAsync(id);
            _context.Modulo.Remove(modulo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ModuloExists(int id)
        {
            return _context.Modulo.Any(e => e.Id == id);
        }
    }
}
