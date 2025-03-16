namespace Ambev.DeveloperEvaluation.Application.Products.GetProduct
{
    public class GetProductResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public ProductDto Product { get; set; }

        public GetProductResult(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        public GetProductResult(bool success, ProductDto product)
        {
            Success = success;
            Product = product;
        }
    }

    public class ProductDto
    {
        public Guid ProductId { get; set; }  // Ajustado para usar Guid como esperado
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public string Image { get; set; }
        public decimal Rating { get; set; }
    }
}
