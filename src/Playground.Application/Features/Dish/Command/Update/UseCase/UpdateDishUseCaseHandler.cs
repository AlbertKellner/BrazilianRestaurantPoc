using MediatR;
using Playground.Application.Features.Dish.Command.Update.Interface;
using Playground.Application.Features.Dish.Command.Update.Models;

namespace Playground.Application.Features.Dish.Command.Update.UseCase
{
    public class UpdateDishUseCaseHandler : IRequestHandler<UpdateDishCommand, UpdateDishOutput>
    {
        private readonly IUpdateDishRepository _updateDishRepository;

        public UpdateDishUseCaseHandler(IUpdateDishRepository updateDishRepository)
        {
            _updateDishRepository = updateDishRepository;
        }

        public async Task<UpdateDishOutput> Handle(UpdateDishCommand input, CancellationToken cancellationToken)
        {
            await _updateDishRepository.UpdateDishAsync(input, cancellationToken);

            return new();
        }
    }
}
