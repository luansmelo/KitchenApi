using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kitchen.Domain.Entities
{
    [Table("measurement")]
    public class Measurement
    {
        [Key]
        public Guid Id { get; private set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        public Measurement(string name)
        {
            Name = name;
        }
    }
}
