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
            var Orderes = _inMemoryDatabase.GetOrderItems()
                .Select(Order => new GetAllOrderOutput
                {
                    Id = Order.Id,
                    OrderName = Order.OrderName,
                    Price = Order.Price,
                    ChefRecommendation = Order.ChefRecommendation
                })
                .ToList();

            return await Task.FromResult(Orderes);
        }
    }
}
