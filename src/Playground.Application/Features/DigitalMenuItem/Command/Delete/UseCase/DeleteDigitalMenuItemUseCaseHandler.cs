using MediatR;
using Playground.Application.Features.DigitalMenuItem.Command.Delete.Models;

namespace Playground.Application.Features.DigitalMenuItem.Command.Delete.UseCase
{
    public class DeleteDigitalMenuItemUseCaseHandler : IRequestHandler<DeleteDigitalMenuItemCommand, DeleteDigitalMenuItemOutput>
    {
        public async Task<DeleteDigitalMenuItemOutput> Handle(DeleteDigitalMenuItemCommand input, CancellationToken cancellationToken)
        {
            return new();
        }
    }
}
