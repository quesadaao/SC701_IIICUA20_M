using DAL.EF;
using DO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using data = DO.Objects;

namespace BS
{
    public class GroupComment : ICRUD<data.GroupComment>
    {
        private SolutionDBContext _repo = null;
        public GroupComment(SolutionDBContext solutionDBContext)
        {
            _repo = solutionDBContext;
        }
        public void Delete(data.GroupComment t)
        {
            new DAL.GroupComment(_repo).Delete(t);
        }

        public IEnumerable<data.GroupComment> GetAll()
        {
            return new DAL.GroupComment(_repo).GetAll();
        }

        public data.GroupComment GetOneById(int id)
        {
            return new DAL.GroupComment(_repo).GetOneById(id);
        }

        public void Insert(data.GroupComment t)
        {
            new DAL.GroupComment(_repo).Insert(t);
        }

        public void Update(data.GroupComment t)
        {
            new DAL.GroupComment(_repo).Update(t);
        }
    }
}
