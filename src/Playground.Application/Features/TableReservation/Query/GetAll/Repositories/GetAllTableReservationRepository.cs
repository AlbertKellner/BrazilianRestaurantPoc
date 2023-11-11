using Playground.Application.Features.TableReservation.Command.GetAll.Interface;
using Playground.Application.Features.TableReservation.Query.GetAll.Models;
using Playground.Application.Shared.InMemoryDatabase;

namespace Playground.Application.Features.TableReservation.Command.GetAll.Repositories
{
    public class GetAllTableReservationRepository : IGetAllTableReservationRepository
    {
        private readonly TableReservationInMemoryDatabase _inMemoryDatabase;

        public GetAllTableReservationRepository(TableReservationInMemoryDatabase inMemoryDatabase)
        {
            _inMemoryDatabase = inMemoryDatabase;
        }

        public async Task<IEnumerable<GetAllTableReservationOutput>> GetAllTableReservationAsync(GetAllTableReservationQuery input, CancellationToken cancellationToken)
        {
            var TableReservationes = _inMemoryDatabase.GetTableReservationItems()
                .Select(TableReservation => new GetAllTableReservationOutput
                {
                    Id = TableReservation.Id,
                    ReservationDateTime = TableReservation.ReservationDateTime,
                    TableId = TableReservation.TableId,
                    CustomerName = TableReservation.CustomerName,
                    CustomerContact = TableReservation.CustomerContact,
                    OrderId = TableReservation.OrderId,
                    ReservationCode = TableReservation.ReservationCode
                })
                .ToList();

            return await Task.FromResult(TableReservationes);
        }
    }
}
