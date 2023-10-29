using MediatR;
using Playground.Application.Features.DigitalMenuItem.Query.GetById.Models;

namespace Playground.Application.Features.DigitalMenuItem.Query.GetById.UseCase
{
    public class GetByIdDigitalMenuItemUseCaseHandler : IRequestHandler<GetByIdDigitalMenuItemQuery, GetByIdDigitalMenuItemOutput>
    {
        public async Task<GetByIdDigitalMenuItemOutput> Handle(GetByIdDigitalMenuItemQuery input, CancellationToken cancellationToken)
        {
            var items = new List<GetByIdDigitalMenuItemOutput>
            {
                new GetByIdDigitalMenuItemOutput
                {
                    //Id = new Guid(),
                    //Task = "GetById - ToDoItem - UseCaseHandler",
                    //IsCompleted = true
                }
            };

            return items.SingleOrDefault(item => item.Id == input.Id) ?? new GetByIdDigitalMenuItemOutput();
        }
    }
}
