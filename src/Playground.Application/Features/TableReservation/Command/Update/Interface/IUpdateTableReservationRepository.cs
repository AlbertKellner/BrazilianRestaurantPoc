using Playground.Application.Features.TableReservation.Command.Update.Models;

namespace Playground.Application.Features.TableReservation.Command.Update.Interface
{
    public interface IUpdateTableReservationRepository
    {
        Task<UpdateTableReservationOutput> UpdateTableReservationAsync(UpdateTableReservationCommand input, CancellationToken cancellationToken);
    }
}
