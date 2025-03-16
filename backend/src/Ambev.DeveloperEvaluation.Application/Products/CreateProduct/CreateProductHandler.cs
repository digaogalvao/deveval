using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, CreateProductResult>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public CreateProductHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<CreateProductResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            // Mapping the command to the product entity
            var product = _mapper.Map<Product>(request);

            // Saving the product to the repository
            product = await _productRepository.CreateAsync(product, cancellationToken);

            decimal ratingRate = (decimal)product.Rating;

            // Returning the result
            return new CreateProductResult(
                product.Id,
                product.Title,
                product.Price,
                product.Description,
                product.Category,
                product.Image,
                ratingRate,
                product.Rating
            );
        }
    }
}
