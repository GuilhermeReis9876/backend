using api.Domain.Models;

namespace api.Domain.ViewModels
{
    public class UsuarioViewModel
    {
        public string Matricula { get; set; }
        public string Cpf { get; set; }

        public string Senha { get; set; }

        public string Nome { get; set; }

        public string DiaDeNascimento { get; set; }

        public EnumTipoDeUsuario TipoUsuario { get; set; }

        public string TipoUsuarioDescricao { get; set; }


    }
}
