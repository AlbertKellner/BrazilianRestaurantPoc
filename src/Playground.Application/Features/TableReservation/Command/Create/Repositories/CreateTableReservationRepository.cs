using BrazilianRestaurant.Application.Shared.InMemoryDatabase.DataBaseItem;
using Playground.Application.Features.TableReservation.Command.Create.Interface;
using Playground.Application.Features.TableReservation.Command.Create.Models;
using Playground.Application.Shared.InMemoryDatabase;

namespace Playground.Application.Features.TableReservation.Command.Create.Repositories
{
    public class CreateTableReservationRepository : ICreateTableReservationRepository
    {
        private readonly TableReservationInMemoryDatabase _inMemoryDatabase;

        public CreateTableReservationRepository(TableReservationInMemoryDatabase inMemoryDatabase)
        {
            _inMemoryDatabase = inMemoryDatabase;
        }

        public async Task<CreateTableReservationOutput> CreateTableReservationAsync(CreateTableReservationCommand input, CancellationToken cancellationToken)
        {
            var newItem = new DataBaseTableReservationItem
            {
                Id = input.Id,
                ReservationDateTime = input.ReservationDateTime,
                TableId = input.TableId,
                CustomerName = input.CustomerName,
                CustomerContact = input.CustomerContact,
                OrderId = input.OrderId,
                ReservationCode = input.ReservationCode
            };

            _inMemoryDatabase.AddTableReservationItem(newItem);

            return new CreateTableReservationOutput { Id = input.Id };
        }

    }
}
