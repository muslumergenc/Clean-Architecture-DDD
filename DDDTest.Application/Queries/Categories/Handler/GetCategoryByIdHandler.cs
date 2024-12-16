using DDDTest.Application.Interfaces;
using DDDTest.Domain.Entities;
using MediatR;

namespace DDDTest.Application.Queries.Categories.Handler
{
    public class GetCategoryByIdHandler : IRequestHandler<GetCategoryByIdQuery, Category>
    {
        private readonly ICategoryRepository _repository;

        public GetCategoryByIdHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<Category> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            // Veritabanından kategoriyi al
            return await _repository.GetByIdAsync(request.Id);
        }
    }
}
