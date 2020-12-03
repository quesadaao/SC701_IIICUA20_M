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
    public class GroupUpdatesController : ControllerBase
    {
        private readonly SolutionDBContext _context;
        private readonly IMapper _mapper;

        public GroupUpdatesController(SolutionDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/GroupUpdates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.GroupUpdate>>> GetGroupUpdates()
        {
            var result = new BS.GroupUpdate(_context).GetAll().ToList();
            var aux = _mapper.Map<IEnumerable<data.GroupUpdate>, IEnumerable<Models.GroupUpdate>>(result);
            return aux.ToList();
        }

        // GET: api/GroupUpdates/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Models.GroupUpdate>> GetGroupUpdate(int id)
        {
            var groupUpdate = new BS.GroupUpdate(_context).GetOneById(id);
            var aux = _mapper.Map<data.GroupUpdate, Models.GroupUpdate>(groupUpdate);

            if (aux == null)
            {
                return NotFound();
            }

            return aux;
        }

        // PUT: api/GroupUpdates/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGroupUpdate(int id, Models.GroupUpdate groupUpdate)
        {
            if (id != groupUpdate.GroupUpdateId)
            {
                return BadRequest();
            }

            try
            {
                var aux = _mapper.Map<Models.GroupUpdate, data.GroupUpdate>(groupUpdate);
                new BS.GroupUpdate(_context).Update(aux);
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
        public async Task<ActionResult<Models.GroupUpdate>> PostGroupUpdate(Models.GroupUpdate groupUpdate)
        {
            var aux = _mapper.Map<Models.GroupUpdate, data.GroupUpdate>(groupUpdate);
            new BS.GroupUpdate(_context).Insert(aux);

            return CreatedAtAction("GetGroupUpdate", new { id = groupUpdate.GroupUpdateId }, groupUpdate);
        }

        // DELETE: api/GroupUpdates/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Models.GroupUpdate>> DeleteGroupUpdate(int id)
        {
            var groupUpdate = new BS.GroupUpdate(_context).GetOneById(id);
            var aux = _mapper.Map<data.GroupUpdate, Models.GroupUpdate>(groupUpdate);
            if (groupUpdate == null)
            {
                return NotFound();
            }

            new BS.GroupUpdate(_context).Delete(groupUpdate);

            return aux;
        }

        private bool GroupUpdateExists(int id)
        {
            return (new BS.GroupUpdate(_context).GetOneById(id) != null);
        }
    }
}