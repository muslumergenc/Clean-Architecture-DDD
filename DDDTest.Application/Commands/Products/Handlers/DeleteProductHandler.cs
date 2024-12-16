using DDDTest.Application.Commands.Products.Commands;
using DDDTest.Application.Interfaces;
using MediatR;

namespace DDDTest.Application.Commands.Products.Handlers;

public class DeleteProductHandler:IRequestHandler<DeleteProductCommand>
{
    private readonly IProductRepository _productRepository;

    public DeleteProductHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        await _productRepository.DeleteAsync(request.Id);
    }
}