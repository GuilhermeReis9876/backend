using api.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api.Domain.Interfaces
{
    public interface ICheckListRepository : IGenericRepository<CheckList>
    {
        Task<List<CheckList>> GetCheckListByLocacaoId(int id);

    }
}
