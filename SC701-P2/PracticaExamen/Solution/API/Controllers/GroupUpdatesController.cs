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
    public class GroupUpdatesController : ControllerBase
    {
        private readonly SolutionDBContext _context;

        public GroupUpdatesController(SolutionDBContext context)
        {
            _context = context;
        }

        // GET: api/GroupUpdates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<data.GroupUpdate>>> GetGroupUpdates()
        {
            return new BS.GroupUpdate(_context).GetAll().ToList();
        }

        // GET: api/GroupUpdates/5
        [HttpGet("{id}")]
        public async Task<ActionResult<data.GroupUpdate>> GetGroupUpdate(int id)
        {
            var groupUpdate = new BS.GroupUpdate(_context).GetOneById(id);

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
        public async Task<IActionResult> PutGroupUpdate(int id, data.GroupUpdate groupUpdate)
        {
            if (id != groupUpdate.GroupUpdateId)
            {
                return BadRequest();
            }

            try
            {
                new BS.GroupUpdate(_context).Update(groupUpdate);
            }
            catch (Exception ee)
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
        public async Task<ActionResult<data.GroupUpdate>> PostGroupUpdate(data.GroupUpdate groupUpdate)
        {
            new BS.GroupUpdate(_context).Insert(groupUpdate);

            return CreatedAtAction("GetGroupUpdate", new { id = groupUpdate.GroupUpdateId }, groupUpdate);
        }

        // DELETE: api/GroupUpdates/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<data.GroupUpdate>> DeleteGroupUpdate(int id)
        {
            var groupUpdate = new BS.GroupUpdate(_context).GetOneById(id);
            if (groupUpdate == null)
            {
                return NotFound();
            }

            new BS.GroupUpdate(_context).Delete(groupUpdate);

            return groupUpdate;
        }

        private bool GroupUpdateExists(int id)
        {
            return (new BS.GroupUpdate(_context).GetOneById(id) != null);
        }
    }
}