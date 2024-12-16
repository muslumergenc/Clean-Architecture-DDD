using MediatR;

namespace DDDTest.Application.Commands.Products.Commands
{
    public class UpdateProductCommand : IRequest
    {
        public int Id { get; set; }
        public string NewName { get; set; }
        public decimal NewPrice { get; set; }
    }
}
