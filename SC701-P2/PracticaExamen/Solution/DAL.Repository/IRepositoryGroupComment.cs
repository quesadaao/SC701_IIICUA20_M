using DO.Objects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{

    //Interfase encargada de definir como vamos a implementar los metodos de include
    //Esta misma Interfase implementa la interfase de repository para poder acceder a los metodos basicos
    public interface IRepositoryGroupComment : IRepository<GroupComment> {

        Task<IEnumerable<GroupComment>> GetAllWithGroupCommentsAsync();
        Task<GroupComment> GetWithGroupCommentByIdAsync(int id);
    }
}
