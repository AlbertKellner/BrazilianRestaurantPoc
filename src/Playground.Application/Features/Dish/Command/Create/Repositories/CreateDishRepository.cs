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
            // Simulating some asynchronous operation
            await Task.Delay(100);

            // Add the input to the in-memory database
            _inMemoryDatabase.AddDishItem(new DataBaseDishItem
            {
                Id = input.Id,
                DishName = input.DishName,
                Price = input.Price,
                IsAvailable = input.IsAvailable
            });

            return new CreateDishOutput { Id = input.Id };
        }
    }
}
