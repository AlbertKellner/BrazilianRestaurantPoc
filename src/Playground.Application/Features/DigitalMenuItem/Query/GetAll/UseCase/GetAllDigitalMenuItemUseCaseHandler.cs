using MediatR;
using Playground.Application.Features.DigitalMenuItem.Query.GetAll.Models;

namespace Playground.Application.Features.DigitalMenuItem.Query.GetAll.UseCase
{
    public class GetAllDigitalMenuItemUseCaseHandler : IRequestHandler<GetAllDigitalMenuItemQuery, IEnumerable<GetAllDigitalMenuItemOutput>>
    {
        public async Task<IEnumerable<GetAllDigitalMenuItemOutput>> Handle(GetAllDigitalMenuItemQuery input, CancellationToken cancellationToken)
        {
            var items = new List<GetAllDigitalMenuItemOutput>
            {
                //new GetAllDigitalMenuItemOutput
                //{
                //    Id = 98,
                //    Task = "Task 98",
                //    IsCompleted = true
                //},
                //new GetAllDigitalMenuItemOutput
                //{
                //    Id = 99,
                //    Task = "Task 99",
                //    IsCompleted = true
                //}
            };

            return items;
        }
    }
}
