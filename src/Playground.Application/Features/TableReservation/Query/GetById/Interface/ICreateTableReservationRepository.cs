using Playground.Application.Features.TableReservation.Query.GetById.Models;

namespace Playground.Application.Features.TableReservation.Command.GetById.Interface
{
    public interface IGetByIdTableReservationRepository
    {
        Task<GetByIdTableReservationOutput> GetByIdTableReservationAsync(GetByIdTableReservationQuery input, CancellationToken cancellationToken);
    }
}
