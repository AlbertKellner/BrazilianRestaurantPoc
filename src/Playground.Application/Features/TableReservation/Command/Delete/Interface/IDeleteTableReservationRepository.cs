using Playground.Application.Features.TableReservation.Command.Delete.Models;

namespace Playground.Application.Features.TableReservation.Command.Delete.Interface
{
    public interface IDeleteTableReservationRepository
    {
        Task DeleteTableReservationAsync(DeleteTableReservationCommand input, CancellationToken cancellationToken);
    }
}
