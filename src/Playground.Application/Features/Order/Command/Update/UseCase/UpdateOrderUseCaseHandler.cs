using MediatR;
using Playground.Application.Features.Order.Command.Update.Interface;
using Playground.Application.Features.Order.Command.Update.Models;

namespace Playground.Application.Features.Order.Command.Update.UseCase
{
    public class UpdateOrderUseCaseHandler : IRequestHandler<UpdateOrderCommand, UpdateOrderOutput>
    {
        private readonly IUpdateOrderRepository _updateOrderRepository;

        public UpdateOrderUseCaseHandler(IUpdateOrderRepository updateOrderRepository)
        {
            _updateOrderRepository = updateOrderRepository;
        }

        public async Task<UpdateOrderOutput> Handle(UpdateOrderCommand input, CancellationToken cancellationToken)
        {
            await _updateOrderRepository.UpdateOrderAsync(input, cancellationToken);

            return new();
        }
    }
}
