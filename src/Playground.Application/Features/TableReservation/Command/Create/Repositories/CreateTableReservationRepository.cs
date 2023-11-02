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
                DishName = input.DishName,
                Description = input.Description,
                Price = input.Price,
                Category = input.Category,
                CookingTime = input.CookingTime,
                ServingSize = input.ServingSize,
                Ingredients = input.Ingredients,
                Allergens = input.Allergens,
                SpicinessLevel = input.SpicinessLevel,
                IsAvailable = input.IsAvailable,
                ImageUrl = input.ImageUrl,
                ChefRecommendation = input.ChefRecommendation,
                Special = input.Special
            };

            _inMemoryDatabase.AddTableReservationItem(newItem);

            return new CreateTableReservationOutput { Id = input.Id };
        }

    }
}
