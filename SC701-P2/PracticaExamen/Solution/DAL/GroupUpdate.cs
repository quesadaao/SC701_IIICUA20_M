using DAL.EF;
using DAL.Repository;
using DO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using data = DO.Objects;

namespace DAL
{
    public class GroupUpdate : ICRUD<data.GroupUpdate>
    {
        private Repository<data.GroupUpdate> _repo = null;
        public GroupUpdate(SolutionDBContext solutionDBContext)
        {
            _repo = new Repository<data.GroupUpdate>(solutionDBContext);
        }
        public void Delete(data.GroupUpdate t)
        {
            _repo.Delete(t);
            _repo.Commit();
        }

        public IEnumerable<data.GroupUpdate> GetAll()
        {
            return _repo.GetAll();
        }

        public data.GroupUpdate GetOneById(int id)
        {
            return _repo.GetOneById(id);
        }

        public void Insert(data.GroupUpdate t)
        {
            _repo.Insert(t);
            _repo.Commit();
        }

        public void Update(data.GroupUpdate t)
        {
            _repo.Update(t);
            _repo.Commit();
        }
    }
}
