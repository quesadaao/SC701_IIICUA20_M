using DAL.EF;
using DO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using data = DO.Objects;

namespace BS
{
    public class GroupUpdate : ICRUD<data.GroupUpdate>
    {
        private SolutionDBContext _repo = null;
        public GroupUpdate(SolutionDBContext solutionDBContext)
        {
            _repo = solutionDBContext;
        }
        public void Delete(data.GroupUpdate t)
        {
            new DAL.GroupUpdate(_repo).Delete(t);
        }

        public IEnumerable<data.GroupUpdate> GetAll()
        {
            return new DAL.GroupUpdate(_repo).GetAll();
        }

        public data.GroupUpdate GetOneById(int id)
        {
            return new DAL.GroupUpdate(_repo).GetOneById(id);
        }

        public void Insert(data.GroupUpdate t)
        {
            new DAL.GroupUpdate(_repo).Insert(t);
        }

        public void Update(data.GroupUpdate t)
        {
            new DAL.GroupUpdate(_repo).Update(t);
        }
    }
}
