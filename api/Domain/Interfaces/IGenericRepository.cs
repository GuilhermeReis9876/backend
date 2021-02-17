using api.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api.Domain.Interfaces
{
    public interface IGenericRepository<T> where T : BaseModel
    {
        Task<IEnumerable<T>> GetAll();

        Task<T> GetById(int id);

        Task Save(T t);

        Task Update(T t);

        Task Delete(T t);

    }
}