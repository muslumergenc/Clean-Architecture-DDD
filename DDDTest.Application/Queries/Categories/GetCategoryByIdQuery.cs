using DDDTest.Domain.Entities;
using MediatR;

namespace DDDTest.Application.Queries.Categories
{
    public class GetCategoryByIdQuery: IRequest<Category>
    {
        public int Id {
            get;
            set;
        }
    }
}
