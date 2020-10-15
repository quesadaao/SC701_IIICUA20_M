using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Solution.APIW2.Models;

namespace Solution.APIW2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UniversidadsController : ControllerBase
    {
        private readonly SC701_IIICUA_P1Context _context;

        public UniversidadsController(SC701_IIICUA_P1Context context)
        {
            _context = context;
        }

        // GET: api/Universidads
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Universidad>>> GetUniversidads()
        {
            return await _context.Universidads.ToListAsync();
        }

        // GET: api/Universidads/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Universidad>> GetUniversidad(int id)
        {
            var universidad = await _context.Universidads.FindAsync(id);

            if (universidad == null)
            {
                return NotFound();
            }

            return universidad;
        }

        // PUT: api/Universidads/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUniversidad(int id, Universidad universidad)
        {
            if (id != universidad.Id)
            {
                return BadRequest();
            }

            _context.Entry(universidad).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UniversidadExists(id))
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

        // POST: api/Universidads
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Universidad>> PostUniversidad(Universidad universidad)
        {
            _context.Universidads.Add(universidad);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUniversidad", new { id = universidad.Id }, universidad);
        }

        // DELETE: api/Universidads/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Universidad>> DeleteUniversidad(int id)
        {
            var universidad = await _context.Universidads.FindAsync(id);
            if (universidad == null)
            {
                return NotFound();
            }

            _context.Universidads.Remove(universidad);
            await _context.SaveChangesAsync();

            return universidad;
        }

        private bool UniversidadExists(int id)
        {
            return _context.Universidads.Any(e => e.Id == id);
        }
    }
}
