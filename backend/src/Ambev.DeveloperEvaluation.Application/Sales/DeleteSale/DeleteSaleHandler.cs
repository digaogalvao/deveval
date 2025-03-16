using System.Threading;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.DeleteSale
{
    public class DeleteSaleHandler : IRequestHandler<DeleteSaleCommand, DeleteSaleResult>
    {
        private readonly ISaleRepository _saleRepository;

        public DeleteSaleHandler(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }

        public async Task<DeleteSaleResult> Handle(DeleteSaleCommand request, CancellationToken cancellationToken)
        {
            var saleExists = await _saleRepository.GetByIdAsync(request.SaleId, cancellationToken);

            if (saleExists == null)
            {
                return new DeleteSaleResult(false, "Venda não encontrada.");
            }

            var deleted = await _saleRepository.DeleteAsync(request.SaleId, cancellationToken);

            return new DeleteSaleResult(deleted, deleted ? "Venda excluída com sucesso." : "Falha ao excluir a venda.");
        }
    }
}
