using Playground.Application.Features.Order.Query.GetAll.Models;

namespace Playground.Application.Features.Order.Command.GetAll.Interface
{
    public interface IGetAllOrderRepository
    {
        Task<IEnumerable<GetAllOrderOutput>> GetAllOrderAsync(GetAllOrderQuery input, CancellationToken cancellationToken);
    }
}
