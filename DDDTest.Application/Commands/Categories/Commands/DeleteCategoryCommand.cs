using MediatR;

namespace DDDTest.Application.Commands.Categories.Commands;

public class DeleteCategoryCommand : IRequest
{
    public int Id { get; set; }
}