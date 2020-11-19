using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UI.Relationships.Models;

namespace UI.Relationships.Controllers
{
    public class GroupCommentsController : Controller
    {
        private readonly SocialGoalContext _context;

        public GroupCommentsController(SocialGoalContext context)
        {
            _context = context;
        }

        // GET: GroupComments
        public async Task<IActionResult> Index()
        {
            var socialGoalContext = _context.GroupComments.Include(g => g.GroupUpdate);
            return View(await socialGoalContext.ToListAsync());
        }

        // GET: GroupComments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupComment = await _context.GroupComments
                .Include(g => g.GroupUpdate)
                .FirstOrDefaultAsync(m => m.GroupCommentId == id);
            if (groupComment == null)
            {
                return NotFound();
            }

            return View(groupComment);
        }

        // GET: GroupComments/Create
        public IActionResult Create()
        {
            ViewData["GroupUpdateId"] = new SelectList(_context.GroupUpdates, "GroupUpdateId", "GroupUpdateId");
            return View();
        }

        // POST: GroupComments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GroupCommentId,CommentText,GroupUpdateId,CommentDate")] GroupComment groupComment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(groupComment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GroupUpdateId"] = new SelectList(_context.GroupUpdates, "GroupUpdateId", "GroupUpdateId", groupComment.GroupUpdateId);
            return View(groupComment);
        }

        // GET: GroupComments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupComment = await _context.GroupComments.FindAsync(id);
            if (groupComment == null)
            {
                return NotFound();
            }
            ViewData["GroupUpdateId"] = new SelectList(_context.GroupUpdates, "GroupUpdateId", "GroupUpdateId", groupComment.GroupUpdateId);
            return View(groupComment);
        }

        // POST: GroupComments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GroupCommentId,CommentText,GroupUpdateId,CommentDate")] GroupComment groupComment)
        {
            if (id != groupComment.GroupCommentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(groupComment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GroupCommentExists(groupComment.GroupCommentId))
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
            ViewData["GroupUpdateId"] = new SelectList(_context.GroupUpdates, "GroupUpdateId", "GroupUpdateId", groupComment.GroupUpdateId);
            return View(groupComment);
        }

        // GET: GroupComments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupComment = await _context.GroupComments
                .Include(g => g.GroupUpdate)
                .FirstOrDefaultAsync(m => m.GroupCommentId == id);
            if (groupComment == null)
            {
                return NotFound();
            }

            return View(groupComment);
        }

        // POST: GroupComments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var groupComment = await _context.GroupComments.FindAsync(id);
            _context.GroupComments.Remove(groupComment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GroupCommentExists(int id)
        {
            return _context.GroupComments.Any(e => e.GroupCommentId == id);
        }
    }
}
