using Playground.Application.Features.Order.Command.Delete.Models;

namespace Playground.Application.Features.Order.Command.Delete.Interface
{
    public interface IDeleteOrderRepository
    {
        Task DeleteOrderAsync(DeleteOrderCommand input, CancellationToken cancellationToken);
    }
}
