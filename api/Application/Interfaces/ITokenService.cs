using System.Threading.Tasks;

namespace api.Application.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(object user);

        Task<object> GetUserByToken(string token);
    }
}