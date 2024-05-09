namespace Kitchen.Application.Contracts.UseCases
{
    public class RemoveInputToProduct
    {
        public Guid ProductId { get; set; } = Guid.Empty;
        public Guid IngredientId { get; set; } = Guid.Empty;
    }
}
