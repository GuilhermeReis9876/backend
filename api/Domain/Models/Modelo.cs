using System.ComponentModel.DataAnnotations.Schema;

namespace api.Domain.Models
{
    [Table("Modelos")]
    public class Modelo : BaseModel
    {
        public string Name { get; set; }

        [ForeignKey("Marca")]
        public int MarcaId { get; set; }

        public Marca Marca { get; set; }
    }
}
