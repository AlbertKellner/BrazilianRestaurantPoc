using Playground.Application.Features.Order.Command.Update.Models;

namespace Playground.Application.Features.Order.Command.Update.Interface
{
    public interface IUpdateOrderRepository
    {
        Task<UpdateOrderOutput> UpdateOrderAsync(UpdateOrderCommand input, CancellationToken cancellationToken);
    }
}
