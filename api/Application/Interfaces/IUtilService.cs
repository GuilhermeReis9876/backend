using System.Threading.Tasks;
using api.Domain.ViewModels;

namespace api.Application.Interfaces
{
    public interface IUtilService
    {
        Task<UserInfoViewModel> GetUserByToken(string token);
    }
}