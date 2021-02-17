using api.Domain.ViewModels;
using System.Threading.Tasks;

namespace api.Application.Interfaces
{
    public interface ILoginService
    {
        Task<LoginViewModel> ValidateUser(string login, string senha);

        Task<bool> UserExists(string login);
    }
}