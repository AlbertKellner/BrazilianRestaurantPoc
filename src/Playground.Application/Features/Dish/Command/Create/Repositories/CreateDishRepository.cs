using BrazilianRestaurant.Application.Shared.InMemoryDatabase.DataBaseItem;
using Playground.Application.Features.Dish.Command.Create.Interface;
using Playground.Application.Features.Dish.Command.Create.Models;
using Playground.Application.Shared.InMemoryDatabase;

namespace Playground.Application.Features.Dish.Command.Create.Repositories
{
    public class CreateDishRepository : ICreateDishRepository
    {
        private readonly DishInMemoryDatabase _inMemoryDatabase;

        public CreateDishRepository(DishInMemoryDatabase inMemoryDatabase)
        {
            _inMemoryDatabase = inMemoryDatabase;
        }

        public async Task<CreateDishOutput> CreateDishAsync(CreateDishCommand input, CancellationToken cancellationToken)
        {
            var newItem = new DataBaseDishItem
            {
                Id = input.Id,
                DishName = input.DishName,
                Description = input.Description,
                Price = input.Price,
                Category = input.Category,
                CookingTime = input.CookingTime,
                ServingSize = input.ServingSize,
                Ingredients = input.Ingredients,
                Allergens = input.Allergens,
                SpicinessLevel = input.SpicinessLevel,
                IsAvailable = input.IsAvailable,
                ImageUrl = input.ImageUrl,
                ChefRecommendation = input.ChefRecommendation,
                Special = input.Special
            };

            _inMemoryDatabase.AddDishItem(newItem);

            return new CreateDishOutput { Id = input.Id };
        }

    }
}
