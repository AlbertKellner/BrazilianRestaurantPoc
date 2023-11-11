using BrazilianRestaurant.Application.Shared.InMemoryDatabase.DataBaseItem;
using Playground.Application.Features.Order.Command.GetById.Interface;
using Playground.Application.Features.Order.Query.GetById.Models;
using Playground.Application.Shared.InMemoryDatabase;

namespace Playground.Application.Features.Order.Command.GetById.Repositories
{
    public class GetByIdOrderRepository : IGetByIdOrderRepository
    {
        private readonly OrderInMemoryDatabase _inMemoryDatabase;

        public GetByIdOrderRepository(OrderInMemoryDatabase inMemoryDatabase)
        {
            _inMemoryDatabase = inMemoryDatabase;
        }

        public async Task<GetByIdOrderOutput> GetByIdOrderAsync(GetByIdOrderQuery input, CancellationToken cancellationToken)
        {
            var OrderItem = _inMemoryDatabase.GetOrdertemById(input.Id);

            if (OrderItem == null)
            {
                return new();
            }

            var OrderOutput = new GetByIdOrderOutput
            {
                Id = input.Id
            };

            return await Task.FromResult(OrderOutput);
        }
    }
}
