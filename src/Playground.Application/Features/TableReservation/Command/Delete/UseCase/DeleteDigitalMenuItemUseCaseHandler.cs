using MediatR;
using Playground.Application.Features.TableReservation.Command.Delete.Models;

namespace Playground.Application.Features.TableReservation.Command.Delete.UseCase
{
    public class DeleteTableReservationUseCaseHandler : IRequestHandler<DeleteTableReservationCommand, DeleteTableReservationOutput>
    {
        public async Task<DeleteTableReservationOutput> Handle(DeleteTableReservationCommand input, CancellationToken cancellationToken)
        {
            return new();
        }
    }
}
