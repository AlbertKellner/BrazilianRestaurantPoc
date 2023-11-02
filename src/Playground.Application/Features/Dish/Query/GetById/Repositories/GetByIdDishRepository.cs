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
                Description = dishItem.Description,
                Price = dishItem.Price,
                Category = dishItem.Category,
                CookingTime = dishItem.CookingTime,
                ServingSize = dishItem.ServingSize,
                Ingredients = dishItem.Ingredients,
                Allergens = dishItem.Allergens,
                SpicinessLevel = dishItem.SpicinessLevel,
                IsAvailable = dishItem.IsAvailable,
                ImageUrl = dishItem.ImageUrl,
                ChefRecommendation = dishItem.ChefRecommendation,
                Special = dishItem.Special
            };

            return await Task.FromResult(dishOutput);
        }
    }
}
