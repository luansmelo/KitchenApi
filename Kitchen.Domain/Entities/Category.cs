using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Kitchen.Domain.Entities
{
    [Table("category")]
    public class Category
    {
        [Key]
        public Guid Id { get; private set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; private set; }

        public Category(string name)
        {
            Name = name;
        }
    }
}
