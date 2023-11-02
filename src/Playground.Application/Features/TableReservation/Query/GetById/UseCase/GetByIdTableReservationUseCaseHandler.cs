using MediatR;
using Playground.Application.Features.TableReservation.Command.GetAll.Interface;
using Playground.Application.Features.TableReservation.Command.GetAll.Repositories;
using Playground.Application.Features.TableReservation.Command.GetById.Interface;
using Playground.Application.Features.TableReservation.Query.GetById.Models;

namespace Playground.Application.Features.TableReservation.Query.GetById.UseCase
{
    public class GetByIdTableReservationUseCaseHandler : IRequestHandler<GetByIdTableReservationQuery, GetByIdTableReservationOutput>
    {
        private readonly IGetByIdTableReservationRepository _getByIdTableReservationRepository;

        public GetByIdTableReservationUseCaseHandler(IGetByIdTableReservationRepository getByIdTableReservationRepository)
        {
            _getByIdTableReservationRepository = getByIdTableReservationRepository;
        }

        public async Task<GetByIdTableReservationOutput> Handle(GetByIdTableReservationQuery input, CancellationToken cancellationToken)
        {
            var result = await _getByIdTableReservationRepository.GetByIdTableReservationAsync(input, cancellationToken);

            return result;
        }
    }
}
