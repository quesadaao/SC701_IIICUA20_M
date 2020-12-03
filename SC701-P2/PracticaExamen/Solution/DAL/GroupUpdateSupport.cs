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
    public class GroupUpdateSupport : ICRUD<data.GroupUpdateSupport>
    {
        private RepositoryGroupUpdateSupport _repo = null;
        public GroupUpdateSupport(SolutionDBContext solutionDBContext)
        {
            _repo = new RepositoryGroupUpdateSupport(solutionDBContext);
        }
        public void Delete(data.GroupUpdateSupport t)
        {
            _repo.Delete(t);
            _repo.Commit();
        }

        public IEnumerable<data.GroupUpdateSupport> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<data.GroupUpdateSupport>> GetAllInclude()
        {
            return await _repo.GetAllWithAsync();
        }

        public data.GroupUpdateSupport GetOneById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<data.GroupUpdateSupport> GetOneByIdInclude(int id)
        {
            return await _repo.GetByIdAsync(id);
        }

        public void Insert(data.GroupUpdateSupport t)
        {
            _repo.Insert(t);
            _repo.Commit();
        }

        public void Update(data.GroupUpdateSupport t)
        {
            _repo.Update(t);
            _repo.Commit();
        }
    }
}
