using System.ComponentModel.DataAnnotations.Schema;

namespace api.Domain.Models
{
    [Table("Enderecos")]
    public class Endereco : BaseModel
    {
        public string Cep { get; set; }

        public string Logradouro { get; set; }

        public int Numero { get; set; }

        public string Complemento { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }
    }
}
