using Playground.Application.Features.Order.Command.GetAll.Interface;
using Playground.Application.Features.Order.Query.GetAll.Models;
using Playground.Application.Shared.InMemoryDatabase;

namespace Playground.Application.Features.Order.Command.GetAll.Repositories
{
    public class GetAllOrderRepository : IGetAllOrderRepository
    {
        private readonly OrderInMemoryDatabase _inMemoryDatabase;

        public GetAllOrderRepository(OrderInMemoryDatabase inMemoryDatabase)
        {
            _inMemoryDatabase = inMemoryDatabase;
        }

        public async Task<IEnumerable<GetAllOrderOutput>> GetAllOrderAsync(GetAllOrderQuery input, CancellationToken cancellationToken)
        {
            var orders = _inMemoryDatabase.GetOrderItems()
                            .Select(order => new GetAllOrderOutput
                            {
                                Id = order.Id,
                                DishesIds = order.DishesIds,
                                Price = order.Price
                            })
                            .ToList();


            return await Task.FromResult(orders);
        }
    }
}
