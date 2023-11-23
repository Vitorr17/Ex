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
    public class CadClientesController : Controller
    {
        private readonly BDContext _context;

        public CadClientesController(BDContext context)
        {
            _context = context;
        }

        // GET: CadClientes
        public async Task<IActionResult> Index()
        {
              return _context.CadCliente != null ? 
                          View(await _context.CadCliente.ToListAsync()) :
                          Problem("Entity set 'BDContext.CadCliente'  is null.");
        }

        // GET: CadClientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CadCliente == null)
            {
                return NotFound();
            }

            var cadCliente = await _context.CadCliente
                .FirstOrDefaultAsync(m => m.IDCliente == id);
            if (cadCliente == null)
            {
                return NotFound();
            }

            return View(cadCliente);
        }

        // GET: CadClientes/Create
        public IActionResult Create()
        {
            
            return View();
        }

        // POST: CadClientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDCliente,Nome,Sobrenome")] CadCliente cadCliente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cadCliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cadCliente);
        }

        // GET: CadClientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CadCliente == null)
            {
                return NotFound();
            }

            var cadCliente = await _context.CadCliente.FindAsync(id);
            if (cadCliente == null)
            {
                return NotFound();
            }
            return View(cadCliente);
        }

        // POST: CadClientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IDCliente,Nome,Sobrenome")] CadCliente cadCliente)
        {
            if (id != cadCliente.IDCliente)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cadCliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CadClienteExists(cadCliente.IDCliente))
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
            return View(cadCliente);
        }

        // GET: CadClientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CadCliente == null)
            {
                return NotFound();
            }

            var cadCliente = await _context.CadCliente
                .FirstOrDefaultAsync(m => m.IDCliente == id);
            if (cadCliente == null)
            {
                return NotFound();
            }

            return View(cadCliente);
        }

        // POST: CadClientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CadCliente == null)
            {
                return Problem("Entity set 'BDContext.CadCliente'  is null.");
            }
            var cadCliente = await _context.CadCliente.FindAsync(id);
            if (cadCliente != null)
            {
                _context.CadCliente.Remove(cadCliente);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CadClienteExists(int id)
        {
          return (_context.CadCliente?.Any(e => e.IDCliente == id)).GetValueOrDefault();
        }
    }
}
