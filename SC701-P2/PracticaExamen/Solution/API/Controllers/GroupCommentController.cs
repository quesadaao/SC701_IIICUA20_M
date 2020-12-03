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
    public class GroupCommentController : ControllerBase
    {
        private readonly SolutionDBContext _context;
        private readonly IMapper _mapper;

        public GroupCommentController(SolutionDBContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        // GET: api/GroupComments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.GroupComment>>> GetGroupComments()
        {
            var aux = await new BS.GroupComment(_context).GetAllInclude();
            return _mapper.Map<IEnumerable<data.GroupComment>, IEnumerable<Models.GroupComment>>(aux).ToList();
        }

        // GET: api/GroupComments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Models.GroupComment>> GetGroupComment(int id)
        {
            var aux = await new BS.GroupComment(_context).GetOneByIdInclude(id);
            var result = _mapper.Map<data.GroupComment, Models.GroupComment>(aux);
            if (result == null)
            {
                return NotFound();
            }
            return result;
        }

        // PUT: api/GroupComments/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGroupComment(int id, Models.GroupComment groupComment)
        {
            if (id != groupComment.GroupCommentId)
            {
                return BadRequest();
            }

            try
            {
                var result = _mapper.Map<Models.GroupComment, data.GroupComment>(groupComment);
                new BS.GroupComment(_context).Update(result);
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
        public async Task<ActionResult<Models.GroupComment>> PostGroupComment(Models.GroupComment groupComment)
        {
            var result = _mapper.Map<Models.GroupComment, data.GroupComment>(groupComment);
            new BS.GroupComment(_context).Insert(result);

            return CreatedAtAction("GetGroupComment", new { id = groupComment.GroupCommentId }, groupComment);
        }

        // DELETE: api/GroupComments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Models.GroupComment>> DeleteGroupComment(int id)
        {
            var groupComment = new BS.GroupComment(_context).GetOneById(id);
            var result = _mapper.Map<data.GroupComment, Models.GroupComment>(groupComment);

            if (groupComment == null)
            {
                return NotFound();
            }
            new BS.GroupComment(_context).Delete(groupComment);

            return result;
        }

        private bool GroupCommentExists(int id)
        {
            return (new BS.GroupComment(_context).GetOneById(id) != null);
        }
    }
}