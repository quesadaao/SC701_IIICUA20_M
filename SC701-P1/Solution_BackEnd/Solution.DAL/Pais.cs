using Solution.DAL.EF;
using Solution.DAL.Repository;
using Solution.DO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using data = Solution.DO.Objects;

namespace Solution.DAL
{
    public class Pais : ICRUD<data.Pais>
    {
        private Repository<data.Pais> _repository = null;
        public Pais(SolutionDBContext solutionDBContext) 
        {
            _repository = new Repository<data.Pais>(solutionDBContext);        
        }
        public void Delete(data.Pais t)
        {
            _repository.Delete(t);
            _repository.Commit();
        }

        public IEnumerable<data.Pais> GetAll()
        {
            return _repository.GetAll();
        }

        public data.Pais GetOneById(int id)
        {
            return _repository.GetOneById(id);
        }

        public void Insert(data.Pais t)
        {
            _repository.Insert(t);
            _repository.Commit();
        }

        public void Update(data.Pais t)
        {
            _repository.Update(t);
            _repository.Commit();
        }
    }
}
