using api.Domain.Models;

namespace api.Domain.ViewModels
{
    public class UsuarioResponseViewModel
    {

        public int Id { get; set; }
        public string Matricula { get; set; }
        public string Cpf { get; set; }

        public string Nome { get; set; }

        public string DiaDeNascimento { get; set; }

        public EnumTipoDeUsuario TipoUsuario { get; set; }
        public string TipoUsuarioDescricao { get; set; }
        public Endereco Endereco { get; set; }
        public string Error { get; set; }

    }
}
