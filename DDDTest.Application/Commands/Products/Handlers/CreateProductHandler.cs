using DDDTest.Application.Commands.Products.Commands;
using DDDTest.Application.Interfaces;
using DDDTest.Domain.Entities;
using MediatR;
namespace DDDTest.Application.Commands.Products.Handlers;

public class CreateProductHandler : IRequestHandler<CreateProductCommand, int>
{
    private readonly IProductRepository _productRepository;

    public CreateProductHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Product(request.Name, request.Price, request.CategoryId);
        await _productRepository.AddAsync(product);
        return product.Id;
    }
}