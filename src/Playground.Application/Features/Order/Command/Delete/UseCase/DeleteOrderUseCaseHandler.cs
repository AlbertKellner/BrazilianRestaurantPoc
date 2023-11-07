using MediatR;
using Playground.Application.Features.Order.Command.Delete.Interface;
using Playground.Application.Features.Order.Command.Delete.Models;

namespace Playground.Application.Features.Order.Command.Delete.UseCase
{
    public class DeleteOrderUseCaseHandler : IRequestHandler<DeleteOrderCommand, DeleteOrderOutput>
    {
        private readonly IDeleteOrderRepository _createOrderRepository;

        public DeleteOrderUseCaseHandler(IDeleteOrderRepository createOrderRepository)
        {
            _createOrderRepository = createOrderRepository;
        }

        public async Task<DeleteOrderOutput> Handle(DeleteOrderCommand input, CancellationToken cancellationToken)
        {
            await _createOrderRepository.DeleteOrderAsync(input, cancellationToken);

            return new();
        }
    }
}
