using MediatR;
using Playground.Application.Features.TableReservation.Command.Update.Models;

namespace Playground.Application.Features.TableReservation.Command.Update.UseCase
{
    public class UpdateTableReservationUseCaseHandler : IRequestHandler<UpdateTableReservationCommand, UpdateTableReservationOutput>
    {
        public async Task<UpdateTableReservationOutput> Handle(UpdateTableReservationCommand input, CancellationToken cancellationToken)
        {
            return new UpdateTableReservationOutput
            {
                //Id = input.Id,
                //Task = input.Task,
                //IsCompleted = input.IsCompleted
            };
        }
    }
}
