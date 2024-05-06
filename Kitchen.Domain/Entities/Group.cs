using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kitchen.Domain.Entities
{
    [Table("group")]
    public class Group
    {
        [Key]
        public Guid Id { get; private set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        public Group(string name)
        {
            Name = name;
        }
    }
}
