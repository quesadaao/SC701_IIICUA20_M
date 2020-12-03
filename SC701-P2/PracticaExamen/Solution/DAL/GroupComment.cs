using DAL.EF;
using DAL.Repository;
using DO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DO.Objects;

namespace DAL
{
    public class GroupComment : ICRUD<data.GroupComment>
    {
        private RepositoryGroupComment _repo = null;
        public GroupComment(SolutionDBContext solutionDBContext)
        {
            _repo = new RepositoryGroupComment(solutionDBContext);
        }
        public void Delete(data.GroupComment t)
        {
            _repo.Delete(t);
            _repo.Commit();
        }

        public IEnumerable<data.GroupComment> GetAll()
        {
            return _repo.GetAll();
        }

        public data.GroupComment GetOneById(int id)
        {
            return _repo.GetOneById(id);
        }
        public async Task<IEnumerable<data.GroupComment>> GetAllInclude()
        {
            return await _repo.GetAllWithGroupCommentsAsync();
        }

        public async Task<data.GroupComment> GetOneByIdInclude(int id)
        {
            return await _repo.GetWithGroupCommentByIdAsync(id);
        }

        public void Insert(data.GroupComment t)
        {
            _repo.Insert(t);
            _repo.Commit();
        }

        public void Update(data.GroupComment t)
        {
            _repo.Update(t);
            _repo.Commit();
        }
    }
}
