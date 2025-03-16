using System.Threading;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Events;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    public class CreateSaleHandler : IRequestHandler<CreateSaleCommand, CreateSaleResult>
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IMapper _mapper;

        public CreateSaleHandler(ISaleRepository saleRepository, IMapper mapper)
        {
            _saleRepository = saleRepository;
            _mapper = mapper;
        }

        public async Task<CreateSaleResult> Handle(CreateSaleCommand request, CancellationToken cancellationToken)
        {
            // Validando os itens da venda
            if (request.Items == null || request.Items.Count == 0)
            {
                return new CreateSaleResult(false, "Venda precisa ter pelo menos um item.");
            }

            // Criar uma nova venda
            var sale = _mapper.Map<Sale>(request);

            // Adicionar itens à venda
            foreach (var itemDto in request.Items)
            {
                var saleItem = _mapper.Map<SaleItem>(itemDto);
                sale.AddItem(saleItem);  // Método que adiciona o item à venda
            }

            // Persistir a venda no repositório
            var createdSale = await _saleRepository.CreateAsync(sale, cancellationToken);

            // Publicar evento de venda criada
            var saleRegisteredEvent = new SaleRegisteredEvent();
            saleRegisteredEvent.SaleCreated(createdSale.Id, createdSale.CustomerId, createdSale.SaleDate);

            // Retornar o resultado da criação da venda
            return new CreateSaleResult(true, "Venda criada com sucesso.", createdSale.Id);
        }
    }
}
