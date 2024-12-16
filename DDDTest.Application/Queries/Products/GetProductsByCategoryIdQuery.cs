using DDDTest.Domain.Entities;
using MediatR;

namespace DDDTest.Application.Queries.Products
{
    public class GetProductsByCategoryIdQuery:IRequest<List<Product>>
    {
        public int CategoryId { get; set; }
    }
}
