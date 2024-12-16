using DDDTest.Application.Commands.Products.Commands;
using DDDTest.Application.Interfaces;
using MediatR;

namespace DDDTest.Application.Commands.Products.Handlers;

public class UpdateProductHandler:IRequestHandler<UpdateProductCommand>
{
    private readonly IProductRepository _productRepository;

    public UpdateProductHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(request.Id);
        if (product==null)
            throw new Exception("Product not found");
        product.UpdateProductName(request.NewName);
        product.UpdatePrice(request.NewPrice);
        await _productRepository.UpdateAsync(product);
    }
}