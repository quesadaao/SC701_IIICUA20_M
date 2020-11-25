using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.W.Models;

namespace API.W.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupUpdatesController : ControllerBase
    {
        private readonly SocialGoalContext _context;

        public GroupUpdatesController(SocialGoalContext context)
        {
            _context = context;
        }

        // GET: api/GroupUpdates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GroupUpdate>>> GetGroupUpdates()
        {
            return await _context.GroupUpdates.ToListAsync();
        }

        // GET: api/GroupUpdates/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GroupUpdate>> GetGroupUpdate(int id)
        {
            var groupUpdate = await _context.GroupUpdates.FindAsync(id);

            if (groupUpdate == null)
            {
                return NotFound();
            }

            return groupUpdate;
        }

        // PUT: api/GroupUpdates/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGroupUpdate(int id, GroupUpdate groupUpdate)
        {
            if (id != groupUpdate.GroupUpdateId)
            {
                return BadRequest();
            }

            _context.Entry(groupUpdate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroupUpdateExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/GroupUpdates
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<GroupUpdate>> PostGroupUpdate(GroupUpdate groupUpdate)
        {
            _context.GroupUpdates.Add(groupUpdate);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGroupUpdate", new { id = groupUpdate.GroupUpdateId }, groupUpdate);
        }

        // DELETE: api/GroupUpdates/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GroupUpdate>> DeleteGroupUpdate(int id)
        {
            var groupUpdate = await _context.GroupUpdates.FindAsync(id);
            if (groupUpdate == null)
            {
                return NotFound();
            }

            _context.GroupUpdates.Remove(groupUpdate);
            await _context.SaveChangesAsync();

            return groupUpdate;
        }

        private bool GroupUpdateExists(int id)
        {
            return _context.GroupUpdates.Any(e => e.GroupUpdateId == id);
        }
    }
}
