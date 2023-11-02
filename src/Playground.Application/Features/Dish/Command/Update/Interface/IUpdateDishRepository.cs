using Playground.Application.Features.Dish.Command.Update.Models;

namespace Playground.Application.Features.Dish.Command.Update.Interface
{
    public interface IUpdateDishRepository
    {
        Task<UpdateDishOutput> UpdateDishAsync(UpdateDishCommand input, CancellationToken cancellationToken);
    }
}
