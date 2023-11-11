using BrazilianRestaurant.Application.Shared.InMemoryDatabase.DataBaseItem;
using Playground.Application.Features.Order.Command.Update.Interface;
using Playground.Application.Features.Order.Command.Update.Models;
using Playground.Application.Shared.InMemoryDatabase;

namespace Playground.Application.Features.Order.Command.Update.Repositories
{
    public class UpdateOrderRepository : IUpdateOrderRepository
    {
        private readonly OrderInMemoryDatabase _inMemoryDatabase;

        public UpdateOrderRepository(OrderInMemoryDatabase inMemoryDatabase)
        {
            _inMemoryDatabase = inMemoryDatabase;
        }

        public async Task<UpdateOrderOutput> UpdateOrderAsync(UpdateOrderCommand input, CancellationToken cancellationToken)
        {
            var databaseItem = new DataBaseOrderItem
            {
                Id = input.Id,
                DishesIds = input.DishesIds,
                Price = input.Price,
                OrderCode = input.OrderCode
            };

            _inMemoryDatabase.UpdateOrderItem(databaseItem);

            return new();
        }
    }
}
