namespace api.Application.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(object user);
    }
}