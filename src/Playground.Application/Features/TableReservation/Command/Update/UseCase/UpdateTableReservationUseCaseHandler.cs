using MediatR;
using Playground.Application.Features.TableReservation.Command.Update.Interface;
using Playground.Application.Features.TableReservation.Command.Update.Models;

namespace Playground.Application.Features.TableReservation.Command.Update.UseCase
{
    public class UpdateTableReservationUseCaseHandler : IRequestHandler<UpdateTableReservationCommand, UpdateTableReservationOutput>
    {
        private readonly IUpdateTableReservationRepository _updateTableReservationRepository;

        public UpdateTableReservationUseCaseHandler(IUpdateTableReservationRepository updateTableReservationRepository)
        {
            _updateTableReservationRepository = updateTableReservationRepository;
        }

        public async Task<UpdateTableReservationOutput> Handle(UpdateTableReservationCommand input, CancellationToken cancellationToken)
        {
            await _updateTableReservationRepository.UpdateTableReservationAsync(input, cancellationToken);

            return new();
        }
    }
}
