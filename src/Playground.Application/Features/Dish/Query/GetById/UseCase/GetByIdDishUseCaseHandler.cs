using MediatR;
using Playground.Application.Features.Dish.Command.GetAll.Interface;
using Playground.Application.Features.Dish.Command.GetAll.Repositories;
using Playground.Application.Features.Dish.Command.GetById.Interface;
using Playground.Application.Features.Dish.Query.GetById.Models;

namespace Playground.Application.Features.Dish.Query.GetById.UseCase
{
    public class GetByIdDishUseCaseHandler : IRequestHandler<GetByIdDishQuery, GetByIdDishOutput>
    {
        private readonly IGetByIdDishRepository _getByIdDishRepository;

        public GetByIdDishUseCaseHandler(IGetByIdDishRepository getByIdDishRepository)
        {
            _getByIdDishRepository = getByIdDishRepository;
        }

        public async Task<GetByIdDishOutput> Handle(GetByIdDishQuery input, CancellationToken cancellationToken)
        {
            var result = await _getByIdDishRepository.GetByIdDishAsync(input, cancellationToken);

            return result;
        }
    }
}
