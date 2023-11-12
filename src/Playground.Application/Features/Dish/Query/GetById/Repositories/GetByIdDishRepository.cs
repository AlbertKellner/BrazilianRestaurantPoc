using Playground.Application.Features.Dish.Command.GetById.Interface;
using Playground.Application.Features.Dish.Query.GetById.Models;
using Playground.Application.Shared.InMemoryDatabase;

namespace Playground.Application.Features.Dish.Command.GetById.Repositories
{
    public class GetByIdDishRepository : IGetByIdDishRepository
    {
        private readonly DishInMemoryDatabase _inMemoryDatabase;

        public GetByIdDishRepository(DishInMemoryDatabase inMemoryDatabase)
        {
            _inMemoryDatabase = inMemoryDatabase;
        }

        public async Task<GetByIdDishOutput> GetByIdDishAsync(GetByIdDishQuery input, CancellationToken cancellationToken)
        {
            var dishItem = _inMemoryDatabase.GetDishtemById(input.Id);

            if (dishItem == null)
            {
                return new();
            }

            var dishOutput = new GetByIdDishOutput
            {
                Id = dishItem.Id,
                DishName = dishItem.DishName,
                Price = dishItem.Price,
                ChefRecommendation = dishItem.ChefRecommendation,
                Quantity = dishItem.Quantity,
                Category = dishItem.Category
            };

            return await Task.FromResult(dishOutput);
        }
    }
}
