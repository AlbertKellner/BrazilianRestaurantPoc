using Playground.Application.Features.DigitalMenuItem.Command.Create.Interface;
using Playground.Application.Features.DigitalMenuItem.Command.Create.Models;
using Playground.Application.Shared.InMemoryDatabase;

namespace Playground.Application.Features.DigitalMenuItem.Command.Create.Repositories
{
    public class CreateDigitalMenuItemRepository : ICreateDigitalMenuItemRepository
    {
        private readonly DigitalMenuInMemoryDatabase _inMemoryDatabase;

        public CreateDigitalMenuItemRepository(DigitalMenuInMemoryDatabase inMemoryDatabase)
        {
            _inMemoryDatabase = inMemoryDatabase;
        }

        public async Task<CreateDigitalMenuItemOutput> CreateDigitalMenuItemAsync(CreateDigitalMenuItemCommand input, CancellationToken cancellationToken)
        {
            // Simulating some asynchronous operation
            await Task.Delay(100);

            // Add the input to the in-memory database
            _inMemoryDatabase.AddDigitalMenuItem(new DataBaseDigitalMenuItem
            {
                Id = input.Id,
                DishName = input.DishName,
                Price = input.Price,
                IsAvailable = input.IsAvailable
            });

            return new CreateDigitalMenuItemOutput { Id = input.Id };
        }
    }
}
