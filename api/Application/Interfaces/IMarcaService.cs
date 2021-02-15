using System.Collections.Generic;
using System.Threading.Tasks;
using api.Models.Entities;

namespace Application.Interfaces
{
    public interface IMarcaService
    {
        Task<IEnumerable<Marca>> GetMarcas();

        Task<Marca> GetMarcaById(int id);

    }
}