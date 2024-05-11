namespace Kitchen.Application.UseCases.Menu
{
    public class IngredientModel
    {
        public Guid Id { get; set; } = Guid.Empty;
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public decimal UnitPrice { get; set; } = decimal.Zero;
        public decimal Grammage { get; set; } = decimal.Zero;
        public string MeasurementUnit { get; set; } = string.Empty;
    }

    public class ProductModel
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
        public List<IngredientModel> Ingredients { get; set; } = [];

        public static implicit operator List<object>(ProductModel v)
        {
            throw new NotImplementedException();
        }
    }

    public class CategoryModel
    {
        public Guid CategoryId { get; set; } = Guid.Empty;
        public string Name { get; set; } = string.Empty;
        public List<ProductModel> Products { get; set; } = [];
    }

    public class MenuResponse
    {
        public Guid Id { get; set; } = Guid.Empty;
        public string Name { get; set; } = string.Empty;
        public List<CategoryModel> Categories { get; set; } = [];
    }
}
