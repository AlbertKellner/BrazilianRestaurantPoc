using MediatR;
using Playground.Application.Features.Dish.Query.GetAll.Models;

namespace Playground.Application.Features.Dish.Query.GetAll.UseCase
{
    public class GetAllDishUseCaseHandler : IRequestHandler<GetAllDishQuery, IEnumerable<GetAllDishOutput>>
    {
        public async Task<IEnumerable<GetAllDishOutput>> Handle(GetAllDishQuery input, CancellationToken cancellationToken)
        {
            var items = new List<GetAllDishOutput>
            {
                //new GetAllDishOutput
                //{
                //    Id = 98,
                //    Task = "Task 98",
                //    IsCompleted = true
                //},
                //new GetAllDishOutput
                //{
                //    Id = 99,
                //    Task = "Task 99",
                //    IsCompleted = true
                //}
            };

            return items;
        }
    }
}
