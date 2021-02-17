using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Domain.Models
{
    [Table("Marcas")]
    public class Marca : BaseModel
    {
        public string Name { get; set; }

        public ICollection<Modelo> Modelos { get; set; }
    }
}
