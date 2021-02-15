using System.Collections.Generic;
using System.Threading.Tasks;
using api.Models.Entities;

namespace Application.Interfaces
{
    public interface IModeloService
    {
        Task<IEnumerable<Modelo>> GetModelos();

        Task<Modelo> GetModeloById(int id);

    }
}