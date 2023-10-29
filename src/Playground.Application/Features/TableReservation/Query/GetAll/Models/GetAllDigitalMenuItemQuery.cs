using MediatR;

namespace Playground.Application.Features.TableReservation.Query.GetAll.Models
{
    public class GetAllTableReservationQuery : IRequest<IEnumerable<GetAllTableReservationOutput>>
    {
        public IEnumerable<string> ErrosList()
        {
            return new List<string>();
        }

        public bool IsInvalid() => ErrosList().Any();

        public string FormattedErrosList() => $"({string.Join("|", ErrosList())})";
    }
}
