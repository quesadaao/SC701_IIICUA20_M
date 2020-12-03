using DAL.EF;
using DO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DO.Objects;

namespace BS
{

    public class GroupUpdateSupport : ICRUD<data.GroupUpdateSupport>
    {
        private SolutionDBContext _repo = null;
        public GroupUpdateSupport(SolutionDBContext solutionDBContext)
        {
            _repo = solutionDBContext;
        }
        public void Delete(data.GroupUpdateSupport t)
        {
            new DAL.GroupUpdateSupport(_repo).Delete(t);
        }

        public IEnumerable<data.GroupUpdateSupport> GetAll()
        {
            return new DAL.GroupUpdateSupport(_repo).GetAll();
        }
        public async Task<IEnumerable<data.GroupUpdateSupport>> GetAllInclude()
        {
            return await new DAL.GroupUpdateSupport(_repo).GetAllInclude();
        }

        public data.GroupUpdateSupport GetOneById(int id)
        {
            return new DAL.GroupUpdateSupport(_repo).GetOneById(id);
        }
        public async Task<data.GroupUpdateSupport> GetOneByIdInclude(int id)
        {
            return await new DAL.GroupUpdateSupport(_repo).GetOneByIdInclude(id);
        }

        public void Insert(data.GroupUpdateSupport t)
        {
            new DAL.GroupUpdateSupport(_repo).Insert(t);
        }

        public void Update(data.GroupUpdateSupport t)
        {
            new DAL.GroupUpdateSupport(_repo).Update(t);
        }
    }
}
