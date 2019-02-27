using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoVueling.Models;

namespace ProyectoVueling.Controllers
{
    public class ModulosCursoCerradoesController : Controller
    {
        private readonly DesaprendiendoDBContext _context;

        public ModulosCursoCerradoesController(DesaprendiendoDBContext context)
        {
            _context = context;
        }

        // GET: ModulosCursoCerradoes
        public async Task<IActionResult> Index()
        {
            var desaprendiendoDBContext = _context.ModulosCursoCerrado.Include(m => m.IdCursoCerradoNavigation).Include(m => m.IdModuloCerradoNavigation);
            return View(await desaprendiendoDBContext.ToListAsync());
        }

        // GET: ModulosCursoCerradoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modulosCursoCerrado = await _context.ModulosCursoCerrado
                .Include(m => m.IdCursoCerradoNavigation)
                .Include(m => m.IdModuloCerradoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (modulosCursoCerrado == null)
            {
                return NotFound();
            }

            return View(modulosCursoCerrado);
        }

        // GET: ModulosCursoCerradoes/Create
        public IActionResult Create()
        {
            ViewData["IdCursoCerrado"] = new SelectList(_context.Curso, "Id", "Id");
            ViewData["IdModuloCerrado"] = new SelectList(_context.Modulo, "Id", "Id");
            return View();
        }

        // POST: ModulosCursoCerradoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdCursoCerrado,IdModuloCerrado,IdProfesor")] ModulosCursoCerrado modulosCursoCerrado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(modulosCursoCerrado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCursoCerrado"] = new SelectList(_context.Curso, "Id", "Id", modulosCursoCerrado.IdCursoCerrado);
            ViewData["IdModuloCerrado"] = new SelectList(_context.Modulo, "Id", "Id", modulosCursoCerrado.IdModuloCerrado);
            return View(modulosCursoCerrado);
        }

        // GET: ModulosCursoCerradoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modulosCursoCerrado = await _context.ModulosCursoCerrado.FindAsync(id);
            if (modulosCursoCerrado == null)
            {
                return NotFound();
            }
            ViewData["IdCursoCerrado"] = new SelectList(_context.Curso, "Id", "Id", modulosCursoCerrado.IdCursoCerrado);
            ViewData["IdModuloCerrado"] = new SelectList(_context.Modulo, "Id", "Id", modulosCursoCerrado.IdModuloCerrado);
            return View(modulosCursoCerrado);
        }

        // POST: ModulosCursoCerradoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdCursoCerrado,IdModuloCerrado,IdProfesor")] ModulosCursoCerrado modulosCursoCerrado)
        {
            if (id != modulosCursoCerrado.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(modulosCursoCerrado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModulosCursoCerradoExists(modulosCursoCerrado.Id))
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
            ViewData["IdCursoCerrado"] = new SelectList(_context.Curso, "Id", "Id", modulosCursoCerrado.IdCursoCerrado);
            ViewData["IdModuloCerrado"] = new SelectList(_context.Modulo, "Id", "Id", modulosCursoCerrado.IdModuloCerrado);
            return View(modulosCursoCerrado);
        }

        // GET: ModulosCursoCerradoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modulosCursoCerrado = await _context.ModulosCursoCerrado
                .Include(m => m.IdCursoCerradoNavigation)
                .Include(m => m.IdModuloCerradoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (modulosCursoCerrado == null)
            {
                return NotFound();
            }

            return View(modulosCursoCerrado);
        }

        // POST: ModulosCursoCerradoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var modulosCursoCerrado = await _context.ModulosCursoCerrado.FindAsync(id);
            _context.ModulosCursoCerrado.Remove(modulosCursoCerrado);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ModulosCursoCerradoExists(int id)
        {
            return _context.ModulosCursoCerrado.Any(e => e.Id == id);
        }
    }
}
