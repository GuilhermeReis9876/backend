using api.Domain.ViewModels;
using api.Models.Entities;

namespace Application.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(Cliente user);
    }
}