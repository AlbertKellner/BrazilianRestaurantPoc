using MediatR;
using Playground.Application.Features.Dish.Command.Delete.Models;

namespace Playground.Application.Features.Dish.Command.Delete.UseCase
{
    public class DeleteDishUseCaseHandler : IRequestHandler<DeleteDishCommand, DeleteDishOutput>
    {
        public async Task<DeleteDishOutput> Handle(DeleteDishCommand input, CancellationToken cancellationToken)
        {
            return new();
        }
    }
}
