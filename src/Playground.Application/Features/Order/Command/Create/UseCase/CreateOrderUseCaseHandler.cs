using MediatR;
using Playground.Application.Features.Order.Command.Create.Interface;
using Playground.Application.Features.Order.Command.Create.Models;

namespace Playground.Application.Features.Order.Command.Create.UseCase
{
    public class CreateOrderUseCaseHandler : IRequestHandler<CreateOrderCommand, CreateOrderOutput>
    {
        private readonly ICreateOrderRepository _createOrderRepository;

        public CreateOrderUseCaseHandler(ICreateOrderRepository createOrderRepository)
        {
            _createOrderRepository = createOrderRepository;
        }

        public async Task<CreateOrderOutput> Handle(CreateOrderCommand input, CancellationToken cancellationToken)
        {
            var result = await _createOrderRepository.CreateOrderAsync(input, cancellationToken);

            return result;
        }
    }
}
