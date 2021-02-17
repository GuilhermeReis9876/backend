using api.Domain.Models;

namespace api.Domain.ViewModels
{
    public class UsuarioUpdateViewModel
    {
        public string Nome { get; set; }

        public string DiaDeNascimento { get; set; }

        public Endereco Endereco { get; set; }
    }
}
