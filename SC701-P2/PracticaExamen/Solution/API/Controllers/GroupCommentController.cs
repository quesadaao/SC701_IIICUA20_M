using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.EF;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using data = DO.Objects;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupCommentController : ControllerBase
    {
        private readonly SolutionDBContext _context;

        public GroupCommentController(SolutionDBContext context)
        {
            _context = context;
        }

        // GET: api/GroupComments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<data.GroupComment>>> GetGroupComments()
        {
            return new BS.GroupComment(_context).GetAll().ToList();
        }

        // GET: api/GroupComments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<data.GroupComment>> GetGroupComment(int id)
        {
            var groupComment = new BS.GroupComment(_context).GetOneById(id);

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
        public async Task<IActionResult> PutGroupComment(int id, data.GroupComment groupComment)
        {
            if (id != groupComment.GroupCommentId)
            {
                return BadRequest();
            }

            try
            {
                new BS.GroupComment(_context).Update(groupComment);
            }
            catch (Exception ee)
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
        public async Task<ActionResult<data.GroupComment>> PostGroupComment(data.GroupComment groupComment)
        {
            new BS.GroupComment(_context).Insert(groupComment);

            return CreatedAtAction("GetGroupComment", new { id = groupComment.GroupCommentId }, groupComment);
        }

        // DELETE: api/GroupComments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<data.GroupComment>> DeleteGroupComment(int id)
        {
            var groupComment = new BS.GroupComment(_context).GetOneById(id);
            if (groupComment == null)
            {
                return NotFound();
            }
            new BS.GroupComment(_context).Delete(groupComment);

            return groupComment;
        }

        private bool GroupCommentExists(int id)
        {
            return (new BS.GroupComment(_context).GetOneById(id) != null);
        }
    }
}