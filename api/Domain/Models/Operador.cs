using System.ComponentModel.DataAnnotations.Schema;

namespace api.Domain.Models
{
    [Table("Operadores")]
    public class Operador : UsuarioAbstract
    {
        public string Matricula { get; set; }

        public EnumTipoDeUsuario TipoDeUsuario { get; set; }
    }
}
