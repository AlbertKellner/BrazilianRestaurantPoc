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
                Id = TableReservationItem.Id,
                DishName = TableReservationItem.DishName,
                Description = TableReservationItem.Description,
                Price = TableReservationItem.Price,
                Category = TableReservationItem.Category,
                CookingTime = TableReservationItem.CookingTime,
                ServingSize = TableReservationItem.ServingSize,
                Ingredients = TableReservationItem.Ingredients,
                Allergens = TableReservationItem.Allergens,
                SpicinessLevel = TableReservationItem.SpicinessLevel,
                IsAvailable = TableReservationItem.IsAvailable,
                ImageUrl = TableReservationItem.ImageUrl,
                ChefRecommendation = TableReservationItem.ChefRecommendation,
                Special = TableReservationItem.Special
            };

            return await Task.FromResult(TableReservationOutput);
        }
    }
}
