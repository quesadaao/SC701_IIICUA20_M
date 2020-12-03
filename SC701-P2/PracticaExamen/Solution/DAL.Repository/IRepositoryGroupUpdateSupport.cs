using DO.Objects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public interface IRepositoryGroupUpdateSupport : IRepository<GroupUpdateSupport>
    {
        Task<IEnumerable<GroupUpdateSupport>> GetAllWithAsync();
        Task<GroupUpdateSupport> GetByIdAsync(int id);
    }
}
