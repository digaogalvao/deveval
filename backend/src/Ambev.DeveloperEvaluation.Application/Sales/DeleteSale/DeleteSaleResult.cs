namespace Ambev.DeveloperEvaluation.Application.Sales.DeleteSale
{
    public class DeleteSaleResult
    {
        public bool Success { get; }
        public string Message { get; }

        public DeleteSaleResult(bool success, string message)
        {
            Success = success;
            Message = message;
        }
    }
}
