using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UI.W.Models;

namespace UI.W.Controllers
{
    public class GroupUpdateSupportsController : Controller
    {
        private readonly SocialGoalContext _context;

        public GroupUpdateSupportsController(SocialGoalContext context)
        {
            _context = context;
        }

        // GET: GroupUpdateSupports
        public async Task<IActionResult> Index()
        {
            var socialGoalContext = _context.GroupUpdateSupports.Include(g => g.GroupUpdate);
            return View(await socialGoalContext.ToListAsync());
        }

        // GET: GroupUpdateSupports/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupUpdateSupport = await _context.GroupUpdateSupports
                .Include(g => g.GroupUpdate)
                .FirstOrDefaultAsync(m => m.GroupUpdateSupportId == id);
            if (groupUpdateSupport == null)
            {
                return NotFound();
            }

            return View(groupUpdateSupport);
        }

        // GET: GroupUpdateSupports/Create
        public IActionResult Create()
        {
            ViewData["GroupUpdateId"] = new SelectList(_context.GroupUpdates, "GroupUpdateId", "GroupUpdateId");
            return View();
        }

        // POST: GroupUpdateSupports/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GroupUpdateSupportId,GroupUpdateId,GroupUserId,UpdateSupportedDate")] GroupUpdateSupport groupUpdateSupport)
        {
            if (ModelState.IsValid)
            {
                _context.Add(groupUpdateSupport);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GroupUpdateId"] = new SelectList(_context.GroupUpdates, "GroupUpdateId", "GroupUpdateId", groupUpdateSupport.GroupUpdateId);
            return View(groupUpdateSupport);
        }

        // GET: GroupUpdateSupports/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupUpdateSupport = await _context.GroupUpdateSupports.FindAsync(id);
            if (groupUpdateSupport == null)
            {
                return NotFound();
            }
            ViewData["GroupUpdateId"] = new SelectList(_context.GroupUpdates, "GroupUpdateId", "GroupUpdateId", groupUpdateSupport.GroupUpdateId);
            return View(groupUpdateSupport);
        }

        // POST: GroupUpdateSupports/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GroupUpdateSupportId,GroupUpdateId,GroupUserId,UpdateSupportedDate")] GroupUpdateSupport groupUpdateSupport)
        {
            if (id != groupUpdateSupport.GroupUpdateSupportId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(groupUpdateSupport);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GroupUpdateSupportExists(groupUpdateSupport.GroupUpdateSupportId))
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
            ViewData["GroupUpdateId"] = new SelectList(_context.GroupUpdates, "GroupUpdateId", "GroupUpdateId", groupUpdateSupport.GroupUpdateId);
            return View(groupUpdateSupport);
        }

        // GET: GroupUpdateSupports/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupUpdateSupport = await _context.GroupUpdateSupports
                .Include(g => g.GroupUpdate)
                .FirstOrDefaultAsync(m => m.GroupUpdateSupportId == id);
            if (groupUpdateSupport == null)
            {
                return NotFound();
            }

            return View(groupUpdateSupport);
        }

        // POST: GroupUpdateSupports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var groupUpdateSupport = await _context.GroupUpdateSupports.FindAsync(id);
            _context.GroupUpdateSupports.Remove(groupUpdateSupport);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GroupUpdateSupportExists(int id)
        {
            return _context.GroupUpdateSupports.Any(e => e.GroupUpdateSupportId == id);
        }
    }
}
