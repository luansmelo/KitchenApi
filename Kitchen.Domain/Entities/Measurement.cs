namespace Kitchen.Domain.Entities
{
    public class Measurement : BaseEntity
    {
        public string? Name { get; set; }

        public Measurement() { }

        public Measurement(string name)
        {
            Name = name;
        }
    }
}
