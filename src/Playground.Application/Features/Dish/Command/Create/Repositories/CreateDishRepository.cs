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
                Price = input.Price,
                ChefRecommendation = input.ChefRecommendation,
                Quantity = input.Quantity,
                Category = input.Category
            };

            _inMemoryDatabase.AddDishItem(newItem);

            return new CreateDishOutput { Id = input.Id };
        }

    }
}
