using DDDTest.Domain.Entities;
using MediatR;

namespace DDDTest.Application.Queries.Categories
{
    public class GetAllCategoriesQuery : IRequest<List<Category>> { }
}