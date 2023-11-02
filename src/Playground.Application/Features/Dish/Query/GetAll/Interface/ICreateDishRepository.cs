using Playground.Application.Features.Dish.Query.GetAll.Models;

namespace Playground.Application.Features.Dish.Command.GetAll.Interface
{
    public interface IGetAllDishRepository
    {
        Task<IEnumerable<GetAllDishOutput>> GetAllDishAsync(GetAllDishQuery input, CancellationToken cancellationToken);
    }
}
