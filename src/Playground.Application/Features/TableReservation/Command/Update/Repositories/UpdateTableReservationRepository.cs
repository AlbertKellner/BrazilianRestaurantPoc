using BrazilianRestaurant.Application.Shared.InMemoryDatabase.DataBaseItem;
using Playground.Application.Features.TableReservation.Command.Update.Interface;
using Playground.Application.Features.TableReservation.Command.Update.Models;
using Playground.Application.Shared.InMemoryDatabase;

namespace Playground.Application.Features.TableReservation.Command.Update.Repositories
{
    public class UpdateTableReservationRepository : IUpdateTableReservationRepository
    {
        private readonly TableReservationInMemoryDatabase _inMemoryDatabase;

        public UpdateTableReservationRepository(TableReservationInMemoryDatabase inMemoryDatabase)
        {
            _inMemoryDatabase = inMemoryDatabase;
        }

        public async Task<UpdateTableReservationOutput> UpdateTableReservationAsync(UpdateTableReservationCommand input, CancellationToken cancellationToken)
        {
            var databaseItem = new DataBaseTableReservationItem
            {
                Id = input.Id,
                ReservationDateTime = input.ReservationDateTime,
                TableId = input.TableId,
                CustomerName = input.CustomerName,
                CustomerContact = input.CustomerContact,
                OrderId = input.OrderId,
                ReservationCode = input.ReservationCode
            };

            _inMemoryDatabase.UpdateTableReservationItem(databaseItem);

            return new();
        }

    }
}
