using Solution.UI.Data;
using Solution.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solution.UI.Services
{
    public class PaisRepositoryEF : IRepositoryPaisEF
    {
        public ApplicationDbContext DbContext;

        public PaisRepositoryEF(ApplicationDbContext dbContext) {
            DbContext = dbContext;
        }

        public List<Pais> ObtenerTodos()
        {
            return DbContext.Paises.ToList();
        }
    }
}
