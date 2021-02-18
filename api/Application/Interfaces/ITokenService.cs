using api.Domain.Models;

namespace api.Application.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(object user, EnumTipoDeUsuario tipoDeUsuario, string register);

    }
}