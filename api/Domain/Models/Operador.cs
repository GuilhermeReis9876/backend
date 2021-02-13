using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models.Entities
{
    [Table("Operadores")]
    public class Operador : UsuarioAbstract
    {
        public string Matricula { get; set; }

        public EnumTipoDeUsuario TipoDeUsuario { get; set; }
    }
}
