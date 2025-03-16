using MediatR;
using System;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProduct
{
    public class GetProductCommand : IRequest<GetProductResult>
    {
        public Guid ProductId { get; }

        public GetProductCommand(Guid productId)
        {
            ProductId = productId;
        }
    }
}
