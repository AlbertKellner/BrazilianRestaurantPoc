using MediatR;
using Playground.Application.Features.Order.Command.GetAll.Interface;
using Playground.Application.Features.Order.Command.GetAll.Repositories;
using Playground.Application.Features.Order.Command.GetById.Interface;
using Playground.Application.Features.Order.Query.GetById.Models;

namespace Playground.Application.Features.Order.Query.GetById.UseCase
{
    public class GetByIdOrderUseCaseHandler : IRequestHandler<GetByIdOrderQuery, GetByIdOrderOutput>
    {
        private readonly IGetByIdOrderRepository _getByIdOrderRepository;

        public GetByIdOrderUseCaseHandler(IGetByIdOrderRepository getByIdOrderRepository)
        {
            _getByIdOrderRepository = getByIdOrderRepository;
        }

        public async Task<GetByIdOrderOutput> Handle(GetByIdOrderQuery input, CancellationToken cancellationToken)
        {
            var result = await _getByIdOrderRepository.GetByIdOrderAsync(input, cancellationToken);

            return result;
        }
    }
}
