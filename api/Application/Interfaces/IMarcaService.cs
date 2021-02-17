using api.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api.Application.Interfaces
{
    public interface IMarcaService
    {
        Task<IEnumerable<Marca>> GetMarcas();

        Task<Marca> GetMarcaById(int id);

    }
}