using Playground.Application.Features.Order.Query.GetById.Models;

namespace Playground.Application.Features.Order.Command.GetById.Interface
{
    public interface IGetByIdOrderRepository
    {
        Task<GetByIdOrderOutput> GetByIdOrderAsync(GetByIdOrderQuery input, CancellationToken cancellationToken);
    }
}
