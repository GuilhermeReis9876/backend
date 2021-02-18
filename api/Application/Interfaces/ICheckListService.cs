using api.Domain.Models;
using System.Threading.Tasks;

namespace api.Application.Interfaces
{
    public interface ICheckListService
    {
        Task RegistrarLiberacao(CheckList cl, string token);

        Task RegistrarRetorno(CheckList cl, string token);

    }
}