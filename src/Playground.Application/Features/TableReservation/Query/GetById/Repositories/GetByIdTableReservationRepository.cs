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
            var TableReservation = _inMemoryDatabase.GetTableReservationtemById(input.Id);

            if (TableReservation == null)
            {
                return new();
            }

            var TableReservationOutput = new GetByIdTableReservationOutput
            {
                Id = TableReservation.Id,
                ReservationDateTime = TableReservation.ReservationDateTime,
                TableId = TableReservation.TableId,
                CustomerName = TableReservation.CustomerName,
                CustomerContact = TableReservation.CustomerContact,
                OrderId = TableReservation.OrderId,
                ReservationCode = TableReservation.ReservationCode
            };

            return await Task.FromResult(TableReservationOutput);
        }
    }
}
