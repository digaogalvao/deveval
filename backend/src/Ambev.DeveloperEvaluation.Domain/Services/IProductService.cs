using Ambev.DeveloperEvaluation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Services
{
    public interface IProductService
    {
        Task CreateProductAsync(Product product);
        Task UpdateProductAsync(Product product);
        Task<Product?> GetProductByIdAsync(Guid productId);
        Task<IEnumerable<Product>> GetAllProductsAsync(int pageNumber, int pageSize);
        Task<bool> DeleteProductAsync(Guid productId);
        decimal CalculateDiscount(Product product);
    }
}
