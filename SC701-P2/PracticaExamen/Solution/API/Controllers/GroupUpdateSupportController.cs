using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DAL.EF;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using data = DO.Objects;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupUpdateSupportController : ControllerBase
    {
        private readonly SolutionDBContext _context;
        private readonly IMapper _mapper;

        public GroupUpdateSupportController(SolutionDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/GroupUpdateSupports
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.GroupUpdateSupport>>> GetGroupUpdateSupports()
        {
            var aux = await new BS.GroupUpdateSupport(_context).GetAllInclude();
            return _mapper.Map<IEnumerable<data.GroupUpdateSupport>, IEnumerable<Models.GroupUpdateSupport>>(aux).ToList();
        }

        // GET: api/GroupUpdateSupports/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Models.GroupUpdateSupport>> GetGroupUpdateSupport(int id)
        {
            var aux = await new BS.GroupUpdateSupport(_context).GetOneByIdInclude(id);
            var result = _mapper.Map<data.GroupUpdateSupport, Models.GroupUpdateSupport>(aux);
            if (result == null)
            {
                return NotFound();
            }

            return result;
        }

        // PUT: api/GroupUpdateSupports/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGroupUpdateSupport(int id, Models.GroupUpdateSupport groupUpdateSupport)
        {
            if (id != groupUpdateSupport.GroupUpdateSupportId)
            {
                return BadRequest();
            }

            try
            {
                var result = _mapper.Map<Models.GroupUpdateSupport, data.GroupUpdateSupport>(groupUpdateSupport);
                new BS.GroupUpdateSupport(_context).Update(result);
            }
            catch (Exception ee)
            {
                if (!GroupUpdateSupportExists(id))
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

        // POST: api/GroupUpdateSupports
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Models.GroupUpdateSupport>> PostGroupUpdateSupport(Models.GroupUpdateSupport groupUpdateSupport)
        {
            var result = _mapper.Map<Models.GroupUpdateSupport, data.GroupUpdateSupport>(groupUpdateSupport);
            new BS.GroupUpdateSupport(_context).Insert(result);

            return CreatedAtAction("GetGroupUpdateSupport", new { id = groupUpdateSupport.GroupUpdateSupportId }, groupUpdateSupport);
        }

        // DELETE: api/GroupUpdateSupports/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Models.GroupUpdateSupport>> DeleteGroupUpdateSupport(int id)
        {
            var groupUpdateSupport = new BS.GroupUpdateSupport(_context).GetOneById(id);
            var result = _mapper.Map<data.GroupUpdateSupport, Models.GroupUpdateSupport>(groupUpdateSupport);

            if (groupUpdateSupport == null)
            {
                return NotFound();
            }
            new BS.GroupUpdateSupport(_context).Delete(groupUpdateSupport);

            return result;
        }

        private bool GroupUpdateSupportExists(int id)
        {
            return (new BS.GroupUpdateSupport(_context).GetOneById(id) != null);
        }
    }
}
