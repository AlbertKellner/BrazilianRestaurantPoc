using Playground.Application.Features.Dish.Query.GetById.Models;

namespace Playground.Application.Features.Dish.Command.GetById.Interface
{
    public interface IGetByIdDishRepository
    {
        Task<GetByIdDishOutput> GetByIdDishAsync(GetByIdDishQuery input, CancellationToken cancellationToken);
    }
}
