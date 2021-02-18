using api.Domain.Models;
using api.Domain.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api.Application.Interfaces
{
    public interface IOperadorService
    {
        Task<IEnumerable<Operador>> GetOperadores();

        Task<Operador> GetById(int id);

        Task Save(UsuarioViewModel operador);

        Task Delete(Operador operador);

        Task Update(Operador operador);
    }
}