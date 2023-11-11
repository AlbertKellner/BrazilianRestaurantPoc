using BrazilianRestaurant.Application.Shared.InMemoryDatabase.DataBaseItem;
using Playground.Application.Features.Order.Command.Create.Interface;
using Playground.Application.Features.Order.Command.Create.Models;
using Playground.Application.Shared.InMemoryDatabase;

namespace Playground.Application.Features.Order.Command.Create.Repositories
{
    public class CreateOrderRepository : ICreateOrderRepository
    {
        private readonly OrderInMemoryDatabase _inMemoryDatabase;

        public CreateOrderRepository(OrderInMemoryDatabase inMemoryDatabase)
        {
            _inMemoryDatabase = inMemoryDatabase;
        }

        public async Task<CreateOrderOutput> CreateOrderAsync(CreateOrderCommand input, CancellationToken cancellationToken)
        {
            var newItem = new DataBaseOrderItem
            {
                Id = input.Id,
                DishesIds = input.DishesIds,
                Price = input.Price,
                OrderCode = input.OrderCode
            };

            _inMemoryDatabase.AddOrderItem(newItem);

            return new CreateOrderOutput { Id = input.Id };
        }

    }
}
