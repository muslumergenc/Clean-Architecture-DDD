using DDDTest.Domain.Entities;
using MediatR;

namespace DDDTest.Application.Queries.Products
{
    public class GetAllProductsQuery : IRequest<List<Product>>
    {
    }
}
