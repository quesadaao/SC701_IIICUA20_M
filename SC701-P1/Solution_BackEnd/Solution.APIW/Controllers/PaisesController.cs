using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Solution.APIW.Models;

namespace Solution.APIW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaisesController : ControllerBase
    {
        private readonly SC701_IIICUA_P1Context _context;

        public PaisesController(SC701_IIICUA_P1Context context)
        {
            _context = context;
        }

        // GET: api/Paises
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Paise>>> GetPaises()
        {
            return await _context.Paises.ToListAsync();
        }

        // GET: api/Paises/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Paise>> GetPaise(int id)
        {
            var paise = await _context.Paises.FindAsync(id);

            if (paise == null)
            {
                return NotFound();
            }

            return paise;
        }

        // PUT: api/Paises/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaise(int id, Paise paise)
        {
            if (id != paise.Id)
            {
                return BadRequest();
            }

            _context.Entry(paise).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaiseExists(id))
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

        // POST: api/Paises
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Paise>> PostPaise(Paise paise)
        {
            _context.Paises.Add(paise);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPaise", new { id = paise.Id }, paise);
        }

        // DELETE: api/Paises/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Paise>> DeletePaise(int id)
        {
            var paise = await _context.Paises.FindAsync(id);
            if (paise == null)
            {
                return NotFound();
            }

            _context.Paises.Remove(paise);
            await _context.SaveChangesAsync();

            return paise;
        }

        private bool PaiseExists(int id)
        {
            return _context.Paises.Any(e => e.Id == id);
        }
    }
}
