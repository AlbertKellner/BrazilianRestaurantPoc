using MediatR;
using Playground.Application.Features.Dish.Command.GetAll.Interface;
using Playground.Application.Features.Dish.Query.GetAll.Models;

namespace Playground.Application.Features.Dish.Query.GetAll.UseCase
{
    public class GetAllDishUseCaseHandler : IRequestHandler<GetAllDishQuery, IEnumerable<GetAllDishOutput>>
    {
        private readonly IGetAllDishRepository _getAllDishRepository;

        public GetAllDishUseCaseHandler(IGetAllDishRepository getAllDishRepository)
        {
            _getAllDishRepository = getAllDishRepository;
        }

        public async Task<IEnumerable<GetAllDishOutput>> Handle(GetAllDishQuery input, CancellationToken cancellationToken)
        {
            var result = await _getAllDishRepository.GetAllDishAsync(input, cancellationToken);

            return result;
        }
    }
}
