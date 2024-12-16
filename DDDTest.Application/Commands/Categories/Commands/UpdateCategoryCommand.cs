using MediatR;

namespace DDDTest.Application.Commands.Categories.Commands
{
    public class UpdateCategoryCommand : IRequest
    {
        public int Id { get; set; }
        public string? NewName { get; set; }
    }
}
