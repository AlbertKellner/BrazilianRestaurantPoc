using MediatR;
using Playground.Application.Features.TableReservation.Query.GetById.Models;

namespace Playground.Application.Features.TableReservation.Query.GetById.UseCase
{
    public class GetByIdTableReservationUseCaseHandler : IRequestHandler<GetByIdTableReservationQuery, GetByIdTableReservationOutput>
    {
        public async Task<GetByIdTableReservationOutput> Handle(GetByIdTableReservationQuery input, CancellationToken cancellationToken)
        {
            var items = new List<GetByIdTableReservationOutput>
            {
                new GetByIdTableReservationOutput
                {
                    //Id = new Guid(),
                    //Task = "GetById - ToDoItem - UseCaseHandler",
                    //IsCompleted = true
                }
            };

            return items.SingleOrDefault(item => item.ReservationId == input.ReservationId) ?? new GetByIdTableReservationOutput();
        }
    }
}
