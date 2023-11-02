using Playground.Application.Features.TableReservation.Command.Create.Models;

namespace Playground.Application.Features.TableReservation.Command.Create.Interface
{
    public interface ICreateTableReservationRepository
    {
        Task<CreateTableReservationOutput> CreateTableReservationAsync(CreateTableReservationCommand input, CancellationToken cancellationToken);
    }
}
