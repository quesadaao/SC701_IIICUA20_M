using Solution.DAL.EF;
using Solution.DO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using data = Solution.DO.Objects;

namespace Solution.BS
{
    public class Universidad : ICRUD<data.Universidad>
    {
        private SolutionDBContext _solutionDBContext = null;
        public Universidad(SolutionDBContext solutionDBContext)
        {
            _solutionDBContext = solutionDBContext;
        }
        public void Delete(data.Universidad t)
        {
            new Solution.DAL.Universidad(_solutionDBContext).Delete(t);
        }

        public IEnumerable<data.Universidad> GetAll()
        {
            return new Solution.DAL.Universidad(_solutionDBContext).GetAll();
        }

        public data.Universidad GetOneById(int id)
        {
            return new Solution.DAL.Universidad(_solutionDBContext).GetOneById(id);
        }

        public void Insert(data.Universidad t)
        {
            t.Id = null;
            new Solution.DAL.Universidad(_solutionDBContext).Insert(t);
        }

        public void Update(data.Universidad t)
        {
            new Solution.DAL.Universidad(_solutionDBContext).Update(t);
        }
    }
}
