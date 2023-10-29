using Playground.Application.Features.TableReservation.Command.Create.Interface;
using Playground.Application.Features.TableReservation.Command.Create.Models;
using Playground.Application.Shared.InMemoryDatabase;

namespace Playground.Application.Features.TableReservation.Command.Create.Repositories
{
    public class CreateTableReservationRepository : ICreateTableReservationRepository
    {
        private readonly DigitalMenuInMemoryDatabase _inMemoryDatabase;

        public CreateTableReservationRepository(DigitalMenuInMemoryDatabase inMemoryDatabase)
        {
            _inMemoryDatabase = inMemoryDatabase;
        }

        public async Task<CreateTableReservationOutput> CreateTableReservationAsync(CreateTableReservationCommand input, CancellationToken cancellationToken)
        {
            // Simulating some asynchronous operation
            await Task.Delay(100);

            // Add the input to the in-memory database
            //_inMemoryDatabase.AddTableReservation(new DataBaseTableReservation
            //{
            //    Id = input.Id,
            //    DishName = input.DishName,
            //    Price = input.Price,
            //    IsAvailable = input.IsAvailable
            //});

            return new CreateTableReservationOutput { ReservationId = input.ReservationId };
        }
    }
}
