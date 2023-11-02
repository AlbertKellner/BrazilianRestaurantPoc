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
                    DishName = TableReservation.DishName,
                    Description = TableReservation.Description,
                    Price = TableReservation.Price,
                    Category = TableReservation.Category,
                    CookingTime = TableReservation.CookingTime,
                    ServingSize = TableReservation.ServingSize,
                    Ingredients = TableReservation.Ingredients.ToArray(),
                    Allergens = TableReservation.Allergens.ToArray(),
                    SpicinessLevel = TableReservation.SpicinessLevel,
                    IsAvailable = TableReservation.IsAvailable,
                    ImageUrl = TableReservation.ImageUrl,
                    ChefRecommendation = TableReservation.ChefRecommendation,
                    Special = TableReservation.Special
                })
                .ToList();

            return await Task.FromResult(TableReservationes);
        }
    }
}
