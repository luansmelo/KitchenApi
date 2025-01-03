﻿namespace Kitchen.Domain.Entities
{
    public class Measurement : BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        public Measurement() { }

        public Measurement(string name)
        {
            Name = name;
        }

        public Measurement(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
