using MediatR;
using Playground.Application.Features.TableReservation.Command.Delete.Interface;
using Playground.Application.Features.TableReservation.Command.Delete.Models;

namespace Playground.Application.Features.TableReservation.Command.Delete.UseCase
{
    public class DeleteTableReservationUseCaseHandler : IRequestHandler<DeleteTableReservationCommand, DeleteTableReservationOutput>
    {
        private readonly IDeleteTableReservationRepository _createTableReservationRepository;

        public DeleteTableReservationUseCaseHandler(IDeleteTableReservationRepository createTableReservationRepository)
        {
            _createTableReservationRepository = createTableReservationRepository;
        }

        public async Task<DeleteTableReservationOutput> Handle(DeleteTableReservationCommand input, CancellationToken cancellationToken)
        {
            await _createTableReservationRepository.DeleteTableReservationAsync(input, cancellationToken);

            return new();
        }
    }
}
