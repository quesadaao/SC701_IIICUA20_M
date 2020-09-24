using Solution.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solution.UI.Services
{
    public interface IRepositoryPaisEF
    {
        List<Pais> ObtenerTodos();
    }
}
