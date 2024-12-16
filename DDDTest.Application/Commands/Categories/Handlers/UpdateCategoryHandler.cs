using DDDTest.Application.Commands.Categories.Commands;
using DDDTest.Application.Interfaces;
using MediatR;

namespace DDDTest.Application.Commands.Categories.Handlers
{
    public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryCommand>
    {
        private readonly ICategoryRepository _categoryRepository;

        public UpdateCategoryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(request.Id);
            if (category == null)
                throw new KeyNotFoundException("Category not found.");

            category.UpdateCategoryName(request.NewName);
            await _categoryRepository.UpdateAsync(category);
        }
    }
}
