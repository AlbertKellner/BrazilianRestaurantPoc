using Playground.Application.Features.TableReservation.Query.GetAll.Models;

namespace Playground.Application.Features.TableReservation.Command.GetAll.Interface
{
    public interface IGetAllTableReservationRepository
    {
        Task<IEnumerable<GetAllTableReservationOutput>> GetAllTableReservationAsync(GetAllTableReservationQuery input, CancellationToken cancellationToken);
    }
}
