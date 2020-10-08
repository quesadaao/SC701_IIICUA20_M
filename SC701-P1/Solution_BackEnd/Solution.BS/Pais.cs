using Solution.DAL.EF;
using Solution.DO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using data = Solution.DO.Objects;

namespace Solution.BS
{
    public class Pais : ICRUD<data.Pais>
    {
        private SolutionDBContext _solutionDBContext = null;
        public Pais(SolutionDBContext solutionDBContext) 
        {
            _solutionDBContext = solutionDBContext;        
        }
        public void Delete(data.Pais t)
        {
            new Solution.DAL.Pais(_solutionDBContext).Delete(t);
        }

        public IEnumerable<data.Pais> GetAll()
        {
            return new Solution.DAL.Pais(_solutionDBContext).GetAll();
        }

        public data.Pais GetOneById(int id)
        {
            return new Solution.DAL.Pais(_solutionDBContext).GetOneById(id);
        }

        public void Insert(data.Pais t)
        {
            t.Id = null;
            new Solution.DAL.Pais(_solutionDBContext).Insert(t);
        }

        public void Update(data.Pais t)
        {
            new Solution.DAL.Pais(_solutionDBContext).Update(t);
        }
    }
}
