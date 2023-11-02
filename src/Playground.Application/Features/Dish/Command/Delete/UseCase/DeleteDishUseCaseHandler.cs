using MediatR;
using Playground.Application.Features.Dish.Command.Delete.Interface;
using Playground.Application.Features.Dish.Command.Delete.Models;

namespace Playground.Application.Features.Dish.Command.Delete.UseCase
{
    public class DeleteDishUseCaseHandler : IRequestHandler<DeleteDishCommand, DeleteDishOutput>
    {
        private readonly IDeleteDishRepository _createDishRepository;

        public DeleteDishUseCaseHandler(IDeleteDishRepository createDishRepository)
        {
            _createDishRepository = createDishRepository;
        }

        public async Task<DeleteDishOutput> Handle(DeleteDishCommand input, CancellationToken cancellationToken)
        {
            await _createDishRepository.DeleteDishAsync(input, cancellationToken);

            return new();
        }
    }
}
