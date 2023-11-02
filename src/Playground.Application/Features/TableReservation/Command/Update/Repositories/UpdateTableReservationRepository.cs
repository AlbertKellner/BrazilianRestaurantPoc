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

            _inMemoryDatabase.UpdateTableReservationItem(databaseItem);

            return new();
        }
    }
}
