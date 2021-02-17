using api.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api.Application.Interfaces
{
    public interface IModeloService
    {
        Task<IEnumerable<Modelo>> GetModelos();

        Task<Modelo> GetModeloById(int id);

    }
}