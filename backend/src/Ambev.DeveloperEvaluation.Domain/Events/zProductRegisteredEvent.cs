namespace Ambev.DeveloperEvaluation.Domain.Events
{
    public class ProductRegisteredEvent
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
    }
}
