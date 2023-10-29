using MediatR;
using Playground.Application.Features.DigitalMenuItem.Command.Update.Models;

namespace Playground.Application.Features.DigitalMenuItem.Command.Update.UseCase
{
    public class UpdateDigitalMenuItemUseCaseHandler : IRequestHandler<UpdateDigitalMenuItemCommand, UpdateDigitalMenuItemOutput>
    {
        public async Task<UpdateDigitalMenuItemOutput> Handle(UpdateDigitalMenuItemCommand input, CancellationToken cancellationToken)
        {
            return new UpdateDigitalMenuItemOutput
            {
                //Id = input.Id,
                //Task = input.Task,
                //IsCompleted = input.IsCompleted
            };
        }
    }
}
