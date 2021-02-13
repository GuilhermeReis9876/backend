using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models.Entities
{
    public abstract class UsuarioAbstract : BaseModel
    {
        public string Nome { get; set; }

        public DateTime DiaDeNascimento { get; set; }

        [ForeignKey("Endereco")]
        public int? EnderecoId { get; set; }
        public Endereco Endereco { get; set; }

        public byte[] PasswordSalt { get; set; }
        public byte[] PassworkHash { get; set; }


    }
}
