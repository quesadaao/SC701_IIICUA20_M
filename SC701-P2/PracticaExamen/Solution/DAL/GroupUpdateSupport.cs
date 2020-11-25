using DAL.EF;
using DAL.Repository;
using DO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using data = DO.Objects;

namespace DAL
{
    public class GroupUpdateSupport : ICRUD<data.GroupUpdateSupport>
    {
        private Repository<data.GroupUpdateSupport> _repo = null;
        public GroupUpdateSupport(SolutionDBContext solutionDBContext)
        {
            _repo = new Repository<data.GroupUpdateSupport>(solutionDBContext);
        }
        public void Delete(data.GroupUpdateSupport t)
        {
            _repo.Delete(t);
            _repo.Commit();
        }

        public IEnumerable<data.GroupUpdateSupport> GetAll()
        {
            return _repo.GetAll();
        }

        public data.GroupUpdateSupport GetOneById(int id)
        {
            return _repo.GetOneById(id);
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
