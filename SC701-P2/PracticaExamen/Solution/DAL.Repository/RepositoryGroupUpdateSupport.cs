using DAL.EF;
using DO.Objects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class RepositoryGroupUpdateSupport : Repository<GroupUpdateSupport>, IRepositoryGroupUpdateSupport
    {

        //Constructor correspondiente a la clase
        //Parametro Context para poderlo recibir y utilizar
        public RepositoryGroupUpdateSupport(SolutionDBContext context) : base(context)
        { }

        public async Task<IEnumerable<GroupUpdateSupport>> GetAllWithAsync()
        {
            return await SolutionDBContext.GroupUpdateSupports.Include(a => a.GroupUpdate).ToListAsync();
        }

        public async Task<GroupUpdateSupport> GetByIdAsync(int id)
        {
            return await SolutionDBContext.GroupUpdateSupports.
                Include(a => a.GroupUpdate).
                SingleOrDefaultAsync(z => z.GroupUpdateId == id);
        }
        private SolutionDBContext SolutionDBContext
        {
            get { return dBContext as SolutionDBContext; }
        }
    }
}
