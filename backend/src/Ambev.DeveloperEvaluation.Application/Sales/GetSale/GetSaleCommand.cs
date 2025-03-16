using System;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale
{
    public class GetSaleCommand : IRequest<GetSaleResult>
    {
        public Guid SaleId { get; set; }

        public GetSaleCommand(Guid saleId)
        {
            SaleId = saleId;
        }
    }
}
