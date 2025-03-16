using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.DeleteProduct
{
    public class DeleteProductCommand : IRequest<bool>
    {
        public Guid ProductId { get; }

        public DeleteProductCommand(Guid productId)
        {
            ProductId = productId;
        }
    }
}
