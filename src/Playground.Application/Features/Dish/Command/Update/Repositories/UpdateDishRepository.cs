using BrazilianRestaurant.Application.Shared.InMemoryDatabase.DataBaseItem;
using Playground.Application.Features.Dish.Command.Update.Interface;
using Playground.Application.Features.Dish.Command.Update.Models;
using Playground.Application.Shared.InMemoryDatabase;

namespace Playground.Application.Features.Dish.Command.Update.Repositories
{
    public class UpdateDishRepository : IUpdateDishRepository
    {
        private readonly DishInMemoryDatabase _inMemoryDatabase;

        public UpdateDishRepository(DishInMemoryDatabase inMemoryDatabase)
        {
            _inMemoryDatabase = inMemoryDatabase;
        }

        public async Task<UpdateDishOutput> UpdateDishAsync(UpdateDishCommand input, CancellationToken cancellationToken)
        {
            var databaseItem = new DataBaseDishItem
            {
                Id = input.Id,
                DishName = input.DishName,
                Price = input.Price,
                ChefRecommendation = input.ChefRecommendation,
            };

            _inMemoryDatabase.UpdateDishItem(databaseItem);

            return new();
        }
    }
}
