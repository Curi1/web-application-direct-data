using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using CRUDModals.Models; // Substitua com o namespace correto do seu projeto

public class CargosController : Controller
{
    private readonly Contexto _context;

    public CargosController(Contexto context)
    {
        _context = context;
    }

    // GET: Cargo
    public async Task<IActionResult> Index()
    {
        return View(await _context.Cargos.ToListAsync());
    }

    // GET: Cargo/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var cargo = await _context.Cargos
            .FirstOrDefaultAsync(m => m.CargoId == id);
        if (cargo == null)
        {
            return NotFound();
        }

        return View(cargo);
    }

    // GET: Cargo/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Cargo/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("CargoId,Titulo")] Cargo cargo)
    {
        if (ModelState.IsValid)
        {
            _context.Add(cargo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(cargo);
    }

    // GET: Cargo/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var cargo = await _context.Cargos.FindAsync(id);
        if (cargo == null)
        {
            return NotFound();
        }
        return View(cargo);
    }

    // POST: Cargo/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("CargoId,Titulo")] Cargo cargo)
    {
        if (id != cargo.CargoId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(cargo);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CargoExists(cargo.CargoId))
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
        return View(cargo);
    }

    // GET: Cargo/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var cargo = await _context.Cargos
            .FirstOrDefaultAsync(m => m.CargoId == id);
        if (cargo == null)
        {
            return NotFound();
        }

        return View(cargo);
    }

    // POST: Cargo/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var cargo = await _context.Cargos.FindAsync(id);
        _context.Cargos.Remove(cargo);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool CargoExists(int id)
    {
        return _context.Cargos.Any(e => e.CargoId == id);
    }
}
