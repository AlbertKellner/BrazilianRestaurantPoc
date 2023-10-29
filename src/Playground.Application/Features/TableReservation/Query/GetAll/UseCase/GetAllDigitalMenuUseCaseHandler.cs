using MediatR;
using Playground.Application.Features.TableReservation.Query.GetAll.Models;

namespace Playground.Application.Features.TableReservation.Query.GetAll.UseCase
{
    public class GetAllTableReservationUseCaseHandler : IRequestHandler<GetAllTableReservationQuery, IEnumerable<GetAllTableReservationOutput>>
    {
        public async Task<IEnumerable<GetAllTableReservationOutput>> Handle(GetAllTableReservationQuery input, CancellationToken cancellationToken)
        {
            var items = new List<GetAllTableReservationOutput>
            {
                //new GetAllTableReservationOutput
                //{
                //    Id = 98,
                //    Task = "Task 98",
                //    IsCompleted = true
                //},
                //new GetAllTableReservationOutput
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
