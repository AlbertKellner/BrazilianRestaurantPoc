using Playground.Application.Features.Order.Command.Delete.Interface;
using Playground.Application.Features.Order.Command.Delete.Models;
using Playground.Application.Shared.InMemoryDatabase;

namespace Playground.Application.Features.Order.Command.Delete.Repositories
{
    public class DeleteOrderRepository : IDeleteOrderRepository
    {
        private readonly OrderInMemoryDatabase _inMemoryDatabase;

        public DeleteOrderRepository(OrderInMemoryDatabase inMemoryDatabase)
        {
            _inMemoryDatabase = inMemoryDatabase;
        }

        public async Task DeleteOrderAsync(DeleteOrderCommand input, CancellationToken cancellationToken)
        {
            _inMemoryDatabase.RemoveOrderItem(input.Id);
        }
    }
}
