using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    public class ProductRepository : IProductRepository
    {
        // Simulando uma base de dados em memória (substituir por implementação real, por exemplo, usando Entity Framework)
        private readonly List<Product> _products = new List<Product>();

        public async Task<Product> CreateAsync(Product product, CancellationToken cancellationToken = default)
        {
            await Task.Delay(100, cancellationToken);

            product.Id = Guid.NewGuid(); // Garantindo que um novo ID seja gerado
            _products.Add(product);
            return product;
        }

        public async Task<Product?> GetByIdAsync(Guid productId, CancellationToken cancellationToken = default)
        {
            await Task.Delay(100, cancellationToken);
            return _products.FirstOrDefault(p => p.Id == productId);
        }

        public async Task<IEnumerable<Product>> GetAllAsync(int pageNumber, int pageSize, CancellationToken cancellationToken = default)
        {
            await Task.Delay(100, cancellationToken);
            return _products.Skip((pageNumber - 1) * pageSize).Take(pageSize);
        }

        public async Task<Product?> UpdateAsync(Product product, CancellationToken cancellationToken = default)
        {
            await Task.Delay(100, cancellationToken);

            var existingProduct = _products.FirstOrDefault(p => p.Id == product.Id);
            if (existingProduct != null)
            {
                _products.Remove(existingProduct);
                _products.Add(product);
                return product;
            }
            return null;
        }

        public async Task<bool> DeleteAsync(Guid productId, CancellationToken cancellationToken = default)
        {
            await Task.Delay(100, cancellationToken);

            var product = _products.FirstOrDefault(p => p.Id == productId);
            if (product != null)
            {
                _products.Remove(product);
                return true;
            }
            return false;
        }
    }
}
