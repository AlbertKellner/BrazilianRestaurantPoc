using MediatR;
using Playground.Application.Features.Dish.Command.Update.Models;

namespace Playground.Application.Features.Dish.Command.Update.UseCase
{
    public class UpdateDishUseCaseHandler : IRequestHandler<UpdateDishCommand, UpdateDishOutput>
    {
        public async Task<UpdateDishOutput> Handle(UpdateDishCommand input, CancellationToken cancellationToken)
        {
            return new UpdateDishOutput
            {
                //Id = input.Id,
                //Task = input.Task,
                //IsCompleted = input.IsCompleted
            };
        }
    }
}
