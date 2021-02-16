using api.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IMarcaService
    {
        Task<IEnumerable<Marca>> GetMarcas();

        Task<Marca> GetMarcaById(int id);

    }
}