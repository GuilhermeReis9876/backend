


using api.Domain.ViewModels;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IOperadorService
    {
        Task Save(UsuarioViewModel usuarioVM);
    }
}