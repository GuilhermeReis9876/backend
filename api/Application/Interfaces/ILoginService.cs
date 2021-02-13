using System.Threading.Tasks;
using api.Domain.ViewModels;

namespace Application.Interfaces
{
    public interface ILoginService
    {
        Task<LoginViewModel> ValidateUser(string login, string senha);
    }
}