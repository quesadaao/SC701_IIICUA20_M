using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Solution.UI.Data;
using Solution.UI.Models;

namespace Solution.UI.Controllers
{
    public class UniversidadWController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UniversidadWController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: UniversidadW
        public async Task<IActionResult> Index()
        {
            return View(await _context.Universidad.ToListAsync());
        }

        // GET: UniversidadW/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var universidad = await _context.Universidad
                .FirstOrDefaultAsync(m => m.Id == id);
            if (universidad == null)
            {
                return NotFound();
            }

            return View(universidad);
        }

        // GET: UniversidadW/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UniversidadW/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Fundacion,Dominio")] Universidad universidad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(universidad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(universidad);
        }

        // GET: UniversidadW/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var universidad = await _context.Universidad.FindAsync(id);
            if (universidad == null)
            {
                return NotFound();
            }
            return View(universidad);
        }

        // POST: UniversidadW/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Fundacion,Dominio")] Universidad universidad)
        {
            if (id != universidad.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(universidad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UniversidadExists(universidad.Id))
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
            return View(universidad);
        }

        // GET: UniversidadW/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var universidad = await _context.Universidad
                .FirstOrDefaultAsync(m => m.Id == id);
            if (universidad == null)
            {
                return NotFound();
            }

            return View(universidad);
        }

        // POST: UniversidadW/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var universidad = await _context.Universidad.FindAsync(id);
            _context.Universidad.Remove(universidad);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UniversidadExists(int id)
        {
            return _context.Universidad.Any(e => e.Id == id);
        }
    }
}
