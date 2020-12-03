using DAL.EF;
using DO.Objects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    // Clase que es una extension de repository
    // Implementa la interfase IRepositoryGroupComment
    // Esta interfase se encarga de implementar metodos que necesiten implementar el include para devolver la informacion
    public class RepositoryGroupComment : Repository<GroupComment>, IRepositoryGroupComment
    {

        //Constructor correspondiente a la clase
        //Parametro Context para poderlo recibir y utilizar
        public RepositoryGroupComment(SolutionDBContext context) : base(context)
        { }

        public async Task<IEnumerable<GroupComment>> GetAllWithGroupCommentsAsync()
        {
            return await SolutionDBContext.GroupComments.Include(a => a.GroupUpdate).ToListAsync();
        }

        public async Task<GroupComment> GetWithGroupCommentByIdAsync(int id)
        {
            return await SolutionDBContext.GroupComments.
                Include(a => a.GroupUpdate).
                SingleOrDefaultAsync(z => z.GroupCommentId == id);
        }
        //Metodo para inicializar el contexto y poderlo utilizar en los metodos
        private SolutionDBContext SolutionDBContext
        {
            get { return dBContext as SolutionDBContext; }
        }
    }

}
