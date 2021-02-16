using api.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IModeloService
    {
        Task<IEnumerable<Modelo>> GetModelos();

        Task<Modelo> GetModeloById(int id);

    }
}