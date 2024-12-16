using DDDTest.Application.Commands.Categories.Commands;
using DDDTest.Application.Interfaces;
using MediatR;

namespace DDDTest.Application.Commands.Categories.Handlers;

public class DeleteCategoryHandler:IRequestHandler<DeleteCategoryCommand>
{ 
    private readonly ICategoryRepository _categoryRepository;
    public DeleteCategoryHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }
    public async Task Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        await _categoryRepository.DeleteAsync(request.Id);
    }
}