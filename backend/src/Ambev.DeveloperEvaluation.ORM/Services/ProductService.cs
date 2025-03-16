using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Application.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task CreateProductAsync(Product product)
        {
            // Verifique se o produto já existe, validações adicionais, etc.
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }

            await _productRepository.CreateAsync(product);
        }

        public async Task UpdateProductAsync(Product product)
        {
            // Validar ou adicionar lógica de negócios antes de atualizar o produto
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }

            await _productRepository.UpdateAsync(product);
        }

        public async Task<Product?> GetProductByIdAsync(Guid productId)
        {
            // Aqui você pode adicionar lógica adicional se necessário
            return await _productRepository.GetByIdAsync(productId);
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync(int pageNumber, int pageSize)
        {
            // Paginação e lógica de recuperação de todos os produtos
            return await _productRepository.GetAllAsync(pageNumber, pageSize);
        }

        public async Task<bool> DeleteProductAsync(Guid productId)
        {
            // Lógica de verificação antes de deletar o produto (dependências, etc.)
            return await _productRepository.DeleteAsync(productId);
        }

        public decimal CalculateDiscount(Product product)
        {
            // Exemplo de cálculo de desconto; substitua conforme necessário para sua lógica de negócios
            decimal discount = 0;
            if (product.Price > 100)
            {
                discount = 0.1m; // Exemplo: 10% de desconto para produtos com preço superior a 100
            }
            return product.Price * discount;
        }
    }
}
