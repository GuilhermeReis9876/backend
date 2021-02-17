using System.ComponentModel.DataAnnotations;

namespace api.Domain.Models
{
    public class BaseModel
    {
        [Key]
        public int Id { get; set; }

    }
}
