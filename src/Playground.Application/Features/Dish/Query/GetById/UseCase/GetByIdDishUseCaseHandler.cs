using MediatR;
using Playground.Application.Features.Dish.Query.GetById.Models;

namespace Playground.Application.Features.Dish.Query.GetById.UseCase
{
    public class GetByIdDishUseCaseHandler : IRequestHandler<GetByIdDishQuery, GetByIdDishOutput>
    {
        public async Task<GetByIdDishOutput> Handle(GetByIdDishQuery input, CancellationToken cancellationToken)
        {
            var items = new List<GetByIdDishOutput>
            {
                new GetByIdDishOutput
                {
                    //Id = new Guid(),
                    //Task = "GetById - ToDoItem - UseCaseHandler",
                    //IsCompleted = true
                }
            };

            return items.SingleOrDefault(item => item.Id == input.Id) ?? new GetByIdDishOutput();
        }
    }
}
