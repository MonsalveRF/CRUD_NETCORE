using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRUD_Q10.Models;

namespace CRUD_Q10.Controllers
{
    public class TblTestsController : Controller
    {
        private readonly MvcQ10DbContext _context;

        public TblTestsController(MvcQ10DbContext context)
        {
            _context = context;
        }

        // GET: TblTests
        public async Task<IActionResult> Index()
        {
              return View(await _context.TblTests.ToListAsync());
        }

        // GET: TblTests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TblTests == null)
            {
                return NotFound();
            }

            var tblTest = await _context.TblTests
                .FirstOrDefaultAsync(m => m.PruebaIdentificacion == id);
            if (tblTest == null)
            {
                return NotFound();
            }

            return View(tblTest);
        }

        // GET: TblTests/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TblTests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PruebaNombre,PruebaApellidos,PruebaIdentificacion,PruebaGenero,PruebaTelefono,PruebaMail")] TblTest tblTest)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblTest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblTest);
        }

        // GET: TblTests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TblTests == null)
            {
                return NotFound();
            }

            var tblTest = await _context.TblTests.FindAsync(id);
            if (tblTest == null)
            {
                return NotFound();
            }
            return View(tblTest);
        }

        // POST: TblTests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PruebaNombre,PruebaApellidos,PruebaIdentificacion,PruebaGenero,PruebaTelefono,PruebaMail")] TblTest tblTest)
        {
            if (id != tblTest.PruebaIdentificacion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblTest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblTestExists(tblTest.PruebaIdentificacion))
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
            return View(tblTest);
        }

        // GET: TblTests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TblTests == null)
            {
                return NotFound();
            }

            var tblTest = await _context.TblTests
                .FirstOrDefaultAsync(m => m.PruebaIdentificacion == id);
            if (tblTest == null)
            {
                return NotFound();
            }

            return View(tblTest);
        }

        // POST: TblTests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TblTests == null)
            {
                return Problem("Entity set 'MvcQ10DbContext.TblTests'  is null.");
            }
            var tblTest = await _context.TblTests.FindAsync(id);
            if (tblTest != null)
            {
                _context.TblTests.Remove(tblTest);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblTestExists(int id)
        {
          return _context.TblTests.Any(e => e.PruebaIdentificacion == id);
        }
    }
}
