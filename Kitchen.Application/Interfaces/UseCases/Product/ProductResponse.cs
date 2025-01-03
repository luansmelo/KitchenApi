﻿using Kitchen.Domain.Enums;

namespace Kitchen.Application.Contracts.UseCases
{
    public class ProductResponse
    {
        public Guid Id { get; set; } = Guid.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Accession { get; set; } = 0;
        public string Resource { get; set; } = string.Empty;
        public string PreparationTime { get; set; } = string.Empty;
        public string? Photo_url { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string WeekDay { get; set; } = string.Empty;
        public List<IngredientResponse>? Ingredients { get; set; }
    }
}
