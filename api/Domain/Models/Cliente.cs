using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models.Entities
{
    [Table("Clientes")]
    public class Cliente : UsuarioAbstract
    {
        public string Cpf { get; set; }
        public EnumTipoDeUsuario TipoDeUsuario { get; set; }
    }
}
