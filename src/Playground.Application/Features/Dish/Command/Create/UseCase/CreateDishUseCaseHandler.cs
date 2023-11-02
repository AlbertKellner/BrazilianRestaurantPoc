using MediatR;
using Playground.Application.Features.Dish.Command.Create.Interface;
using Playground.Application.Features.Dish.Command.Create.Models;

namespace Playground.Application.Features.Dish.Command.Create.UseCase
{
    public class CreateDishUseCaseHandler : IRequestHandler<CreateDishCommand, CreateDishOutput>
    {
        private readonly ICreateDishRepository _createDishRepository;

        public CreateDishUseCaseHandler(ICreateDishRepository createDishRepository)
        {
            _createDishRepository = createDishRepository;
        }

        public async Task<CreateDishOutput> Handle(CreateDishCommand input, CancellationToken cancellationToken)
        {
            var result = await _createDishRepository.CreateDishAsync(input, cancellationToken);

            return result;
        }
    }
}
