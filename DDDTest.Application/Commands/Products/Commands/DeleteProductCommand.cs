using MediatR;

namespace DDDTest.Application.Commands.Products.Commands
{
    public class DeleteProductCommand : IRequest
    {
        public int Id { get; set; }
    }
}
