using Playground.Application.Features.Dish.Command.Delete.Interface;
using Playground.Application.Features.Dish.Command.Delete.Models;
using Playground.Application.Shared.InMemoryDatabase;

namespace Playground.Application.Features.Dish.Command.Delete.Repositories
{
    public class DeleteDishRepository : IDeleteDishRepository
    {
        private readonly DishInMemoryDatabase _inMemoryDatabase;

        public DeleteDishRepository(DishInMemoryDatabase inMemoryDatabase)
        {
            _inMemoryDatabase = inMemoryDatabase;
        }

        public async Task DeleteDishAsync(DeleteDishCommand input, CancellationToken cancellationToken)
        {
            _inMemoryDatabase.RemoveDishItem(input.Id);
        }
    }
}
