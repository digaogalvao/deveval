using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Services
{
    public class SaleService : ISaleService
    {
        private readonly ISaleRepository _saleRepository;

        public SaleService(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }

        public async Task CreateSaleAsync(Sale sale)
        {
            // Aplica o cálculo de desconto antes de persistir
            ApplyDiscounts(sale);

            // Persiste a venda no repositório
            await _saleRepository.CreateAsync(sale);
        }

        public async Task UpdateSaleAsync(Sale sale)
        {
            // Aplica o cálculo de desconto antes de atualizar
            ApplyDiscounts(sale);

            // Atualiza a venda no repositório
            await _saleRepository.UpdateAsync(sale);
        }

        public decimal ApplyDiscounts(Sale sale)
        {
            decimal discount = 0;

            // Aplica o desconto com base na quantidade de itens
            foreach (var item in sale.Items)
            {
                if (item.Quantity >= 4)
                {
                    // Exemplo: Desconto de 10% para 4 ou mais itens
                    discount += item.TotalPrice * 0.1M;  // 10% de desconto
                }
            }

            // Devolve o valor do desconto aplicado
            return discount;
        }

        public async Task<Sale?> GetSaleByIdAsync(Guid saleId)
        {
            return await _saleRepository.GetByIdAsync(saleId);
        }

        public async Task<IEnumerable<Sale>> GetAllSalesAsync(int pageNumber, int pageSize)
        {
            return await _saleRepository.GetAllAsync(pageNumber, pageSize);
        }

        public async Task<bool> DeleteSaleAsync(Guid saleId)
        {
            return await _saleRepository.DeleteAsync(saleId);
        }
    }
}
