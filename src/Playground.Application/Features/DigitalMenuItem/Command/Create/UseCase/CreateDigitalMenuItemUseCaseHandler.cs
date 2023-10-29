using MediatR;
using Playground.Application.Features.DigitalMenuItem.Command.Create.Interface;
using Playground.Application.Features.DigitalMenuItem.Command.Create.Models;

namespace Playground.Application.Features.DigitalMenuItem.Command.Create.UseCase
{
    public class CreateDigitalMenuItemUseCaseHandler : IRequestHandler<CreateDigitalMenuItemCommand, CreateDigitalMenuItemOutput>
    {
        private readonly ICreateDigitalMenuItemRepository _createDigitalMenuItemRepository;

        public CreateDigitalMenuItemUseCaseHandler(ICreateDigitalMenuItemRepository createDigitalMenuItemRepository)
        {
            _createDigitalMenuItemRepository = createDigitalMenuItemRepository;
        }

        public async Task<CreateDigitalMenuItemOutput> Handle(CreateDigitalMenuItemCommand input, CancellationToken cancellationToken)
        {
            var result = await _createDigitalMenuItemRepository.CreateDigitalMenuItemAsync(input, cancellationToken);

            return result;
        }
    }
}
