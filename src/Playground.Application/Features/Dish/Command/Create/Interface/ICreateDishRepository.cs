using Playground.Application.Features.Dish.Command.Create.Models;

namespace Playground.Application.Features.Dish.Command.Create.Interface
{
    public interface ICreateDishRepository
    {
        Task<CreateDishOutput> CreateDishAsync(CreateDishCommand input, CancellationToken cancellationToken);
    }
}
