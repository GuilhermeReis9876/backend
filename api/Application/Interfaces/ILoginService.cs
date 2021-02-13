using api.Domain.ViewModels;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ILoginService
    {
        Task<LoginViewModel> ValidateUser(string login, string senha);

        Task<bool> UserExists(string login);
    }
}