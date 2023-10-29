using Playground.Application.Features.DigitalMenuItem.Command.Create.Models;

namespace Playground.Application.Features.DigitalMenuItem.Command.Create.Interface
{
    public interface ICreateDigitalMenuItemRepository
    {
        Task<CreateDigitalMenuItemOutput> CreateDigitalMenuItemAsync(CreateDigitalMenuItemCommand input, CancellationToken cancellationToken);
    }
}
