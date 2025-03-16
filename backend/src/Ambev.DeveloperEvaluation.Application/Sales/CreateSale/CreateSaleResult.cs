namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    public class CreateSaleResult
    {
        public bool Success { get; }
        public string Message { get; }
        public Guid? SaleId { get; }

        public CreateSaleResult(bool success, string message, Guid? saleId = null)
        {
            Success = success;
            Message = message;
            SaleId = saleId;
        }
    }
}
