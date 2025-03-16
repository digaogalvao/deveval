using Ambev.DeveloperEvaluation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Services
{
    public interface ISaleService
    {
        Task CreateSaleAsync(Sale sale);
        Task UpdateSaleAsync(Sale sale);
        Task<Sale?> GetSaleByIdAsync(Guid saleId);
        Task<IEnumerable<Sale>> GetAllSalesAsync(int pageNumber, int pageSize);
        Task<bool> DeleteSaleAsync(Guid saleId);
        decimal ApplyDiscounts(Sale sale);
    }
}
