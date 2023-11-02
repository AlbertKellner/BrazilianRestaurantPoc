using Playground.Application.Features.TableReservation.Command.Delete.Interface;
using Playground.Application.Features.TableReservation.Command.Delete.Models;
using Playground.Application.Shared.InMemoryDatabase;

namespace Playground.Application.Features.TableReservation.Command.Delete.Repositories
{
    public class DeleteTableReservationRepository : IDeleteTableReservationRepository
    {
        private readonly TableReservationInMemoryDatabase _inMemoryDatabase;

        public DeleteTableReservationRepository(TableReservationInMemoryDatabase inMemoryDatabase)
        {
            _inMemoryDatabase = inMemoryDatabase;
        }

        public async Task DeleteTableReservationAsync(DeleteTableReservationCommand input, CancellationToken cancellationToken)
        {
            _inMemoryDatabase.RemoveTableReservationItem(input.Id);
        }
    }
}
