using Playground.Application.Features.Dish.Command.Delete.Models;

namespace Playground.Application.Features.Dish.Command.Delete.Interface
{
    public interface IDeleteDishRepository
    {
        Task DeleteDishAsync(DeleteDishCommand input, CancellationToken cancellationToken);
    }
}
