using MediatR;

namespace DDDTest.Application.Commands.Categories.Commands;
public class CreateCategoryCommand : IRequest<int>
{
        public string? Name { get; set; }
}
