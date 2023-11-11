using Playground.Application.Features.TableReservation.Command.GetById.Interface;
using Playground.Application.Features.TableReservation.Query.GetById.Models;
using Playground.Application.Shared.InMemoryDatabase;

namespace Playground.Application.Features.TableReservation.Command.GetById.Repositories
{
    public class GetByIdTableReservationRepository : IGetByIdTableReservationRepository
    {
        private readonly TableReservationInMemoryDatabase _inMemoryDatabase;

        public GetByIdTableReservationRepository(TableReservationInMemoryDatabase inMemoryDatabase)
        {
            _inMemoryDatabase = inMemoryDatabase;
        }

        public async Task<GetByIdTableReservationOutput> GetByIdTableReservationAsync(GetByIdTableReservationQuery input, CancellationToken cancellationToken)
        {
            var TableReservationItem = _inMemoryDatabase.GetTableReservationtemById(input.Id);

            if (TableReservationItem == null)
            {
                return new();
            }

            var TableReservationOutput = new GetByIdTableReservationOutput
            {
                Id = input.Id
            };

            return await Task.FromResult(TableReservationOutput);
        }
    }
}
