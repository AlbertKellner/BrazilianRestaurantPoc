using MediatR;
using Playground.Application.Features.Order.Command.GetAll.Interface;
using Playground.Application.Features.Order.Query.GetAll.Models;

namespace Playground.Application.Features.Order.Query.GetAll.UseCase
{
    public class GetAllOrderUseCaseHandler : IRequestHandler<GetAllOrderQuery, IEnumerable<GetAllOrderOutput>>
    {
        private readonly IGetAllOrderRepository _getAllOrderRepository;

        public GetAllOrderUseCaseHandler(IGetAllOrderRepository getAllOrderRepository)
        {
            _getAllOrderRepository = getAllOrderRepository;
        }

        public async Task<IEnumerable<GetAllOrderOutput>> Handle(GetAllOrderQuery input, CancellationToken cancellationToken)
        {
            var result = await _getAllOrderRepository.GetAllOrderAsync(input, cancellationToken);

            return result;
        }
    }
}
