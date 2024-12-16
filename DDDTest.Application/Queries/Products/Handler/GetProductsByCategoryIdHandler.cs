using DDDTest.Application.Interfaces;
using DDDTest.Domain.Entities;
using MediatR;

namespace DDDTest.Application.Queries.Products.Handler;

public class GetProductsByCategoryIdHandler:IRequestHandler<GetProductsByCategoryIdQuery, List<Product>>
{
    private readonly IProductRepository _productRepository;

    public GetProductsByCategoryIdHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<List<Product>> Handle(GetProductsByCategoryIdQuery request, CancellationToken cancellationToken)
    {
        return await _productRepository.GetByCategoryIdAsync(request.CategoryId);
    }
}