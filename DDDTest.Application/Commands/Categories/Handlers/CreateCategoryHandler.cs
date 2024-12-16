using DDDTest.Application.Commands.Categories.Commands;
using DDDTest.Application.Interfaces;
using DDDTest.Domain.Entities;
using MediatR;

namespace DDDTest.Application.Commands.Categories.Handlers
{
    public class CreateCategoryHandler : IRequestHandler<CreateCategoryCommand, int>
    {
        private readonly ICategoryRepository _categoryRepository;
        public CreateCategoryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<int> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = new Category(request.Name);
            await _categoryRepository.AddAsync(category);
            return category.Id;
        }
    }
}
