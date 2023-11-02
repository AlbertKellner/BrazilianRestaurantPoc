using MediatR;
using Playground.Application.Features.TableReservation.Command.GetAll.Interface;
using Playground.Application.Features.TableReservation.Query.GetAll.Models;

namespace Playground.Application.Features.TableReservation.Query.GetAll.UseCase
{
    public class GetAllTableReservationUseCaseHandler : IRequestHandler<GetAllTableReservationQuery, IEnumerable<GetAllTableReservationOutput>>
    {
        private readonly IGetAllTableReservationRepository _getAllTableReservationRepository;

        public GetAllTableReservationUseCaseHandler(IGetAllTableReservationRepository getAllTableReservationRepository)
        {
            _getAllTableReservationRepository = getAllTableReservationRepository;
        }

        public async Task<IEnumerable<GetAllTableReservationOutput>> Handle(GetAllTableReservationQuery input, CancellationToken cancellationToken)
        {
            var result = await _getAllTableReservationRepository.GetAllTableReservationAsync(input, cancellationToken);

            return result;
        }
    }
}
