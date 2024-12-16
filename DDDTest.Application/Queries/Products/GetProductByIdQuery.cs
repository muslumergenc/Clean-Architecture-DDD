using DDDTest.Domain.Entities;
using MediatR;

namespace DDDTest.Application.Queries.Products
{
    public class GetProductByIdQuery:IRequest<Product>
    {
        public int Id { get; set; }
    }
}
