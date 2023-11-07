using Playground.Application.Features.Dish.Command.GetAll.Interface;
using Playground.Application.Features.Dish.Query.GetAll.Models;
using Playground.Application.Shared.InMemoryDatabase;

namespace Playground.Application.Features.Dish.Command.GetAll.Repositories
{
    public class GetAllDishRepository : IGetAllDishRepository
    {
        private readonly DishInMemoryDatabase _inMemoryDatabase;

        public GetAllDishRepository(DishInMemoryDatabase inMemoryDatabase)
        {
            _inMemoryDatabase = inMemoryDatabase;
        }

        public async Task<IEnumerable<GetAllDishOutput>> GetAllDishAsync(GetAllDishQuery input, CancellationToken cancellationToken)
        {
            var dishes = _inMemoryDatabase.GetDishItems()
                .Select(dish => new GetAllDishOutput
                {
                    Id = dish.Id,
                    DishName = dish.DishName,
                    Price = dish.Price,
                    ChefRecommendation = dish.ChefRecommendation
                })
                .ToList();

            return await Task.FromResult(dishes);
        }
    }
}
