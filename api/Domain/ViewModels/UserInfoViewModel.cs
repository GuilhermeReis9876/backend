using api.Domain.Models;

namespace api.Domain.ViewModels
{
    public class UserInfoViewModel
    {
        public int Id { get; set; }
        public string Register { get; set; }
        public EnumTipoDeUsuario TipoDeUsuario { get; set; }
    }
}