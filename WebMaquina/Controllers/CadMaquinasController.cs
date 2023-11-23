using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebMaquina.Data;
using WebMaquina.Models;

namespace WebMaquina.Controllers
{
    public class CadMaquinasController : Controller
    {
        private readonly BDContext _context;

        public CadMaquinasController(BDContext context)
        {
            _context = context;
        }

        // GET: CadMaquinas
        public async Task<IActionResult> Index()
        {
              return _context.CadMaquina != null ? 
                          View(await _context.CadMaquina.ToListAsync()) :
                          Problem("Entity set 'BDContext.CadMaquina'  is null.");
        }

        // GET: CadMaquinas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CadMaquina == null)
            {
                return NotFound();
            }

            var cadMaquina = await _context.CadMaquina
                .FirstOrDefaultAsync(m => m.IDMaquina == id);
            if (cadMaquina == null)
            {
                return NotFound();
            }

            return View(cadMaquina);
        }

        // GET: CadMaquinas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CadMaquinas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDMaquina,Modelo,Produto")] CadMaquina cadMaquina)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cadMaquina);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cadMaquina);
        }

        // GET: CadMaquinas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CadMaquina == null)
            {
                return NotFound();
            }

            var cadMaquina = await _context.CadMaquina.FindAsync(id);
            if (cadMaquina == null)
            {
                return NotFound();
            }
            return View(cadMaquina);
        }

        // POST: CadMaquinas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IDMaquina,Modelo,Produto")] CadMaquina cadMaquina)
        {
            if (id != cadMaquina.IDMaquina)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cadMaquina);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CadMaquinaExists(cadMaquina.IDMaquina))
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
            return View(cadMaquina);
        }

        // GET: CadMaquinas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CadMaquina == null)
            {
                return NotFound();
            }

            var cadMaquina = await _context.CadMaquina
                .FirstOrDefaultAsync(m => m.IDMaquina == id);
            if (cadMaquina == null)
            {
                return NotFound();
            }

            return View(cadMaquina);
        }

        // POST: CadMaquinas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CadMaquina == null)
            {
                return Problem("Entity set 'BDContext.CadMaquina'  is null.");
            }
            var cadMaquina = await _context.CadMaquina.FindAsync(id);
            if (cadMaquina != null)
            {
                _context.CadMaquina.Remove(cadMaquina);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CadMaquinaExists(int id)
        {
          return (_context.CadMaquina?.Any(e => e.IDMaquina == id)).GetValueOrDefault();
        }
    }
}
