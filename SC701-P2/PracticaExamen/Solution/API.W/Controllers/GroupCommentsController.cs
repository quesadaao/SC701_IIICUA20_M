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
    public class GroupCommentsController : ControllerBase
    {
        private readonly SocialGoalContext _context;

        public GroupCommentsController(SocialGoalContext context)
        {
            _context = context;
        }

        // GET: api/GroupComments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GroupComment>>> GetGroupComments()
        {
            return await _context.GroupComments.ToListAsync();
        }

        // GET: api/GroupComments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GroupComment>> GetGroupComment(int id)
        {
            var groupComment = await _context.GroupComments.FindAsync(id);

            if (groupComment == null)
            {
                return NotFound();
            }

            return groupComment;
        }

        // PUT: api/GroupComments/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGroupComment(int id, GroupComment groupComment)
        {
            if (id != groupComment.GroupCommentId)
            {
                return BadRequest();
            }

            _context.Entry(groupComment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroupCommentExists(id))
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

        // POST: api/GroupComments
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<GroupComment>> PostGroupComment(GroupComment groupComment)
        {
            _context.GroupComments.Add(groupComment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGroupComment", new { id = groupComment.GroupCommentId }, groupComment);
        }

        // DELETE: api/GroupComments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GroupComment>> DeleteGroupComment(int id)
        {
            var groupComment = await _context.GroupComments.FindAsync(id);
            if (groupComment == null)
            {
                return NotFound();
            }

            _context.GroupComments.Remove(groupComment);
            await _context.SaveChangesAsync();

            return groupComment;
        }

        private bool GroupCommentExists(int id)
        {
            return _context.GroupComments.Any(e => e.GroupCommentId == id);
        }
    }
}
