using Playground.Application.Features.Order.Command.Create.Models;

namespace Playground.Application.Features.Order.Command.Create.Interface
{
    public interface ICreateOrderRepository
    {
        Task<CreateOrderOutput> CreateOrderAsync(CreateOrderCommand input, CancellationToken cancellationToken);
    }
}
